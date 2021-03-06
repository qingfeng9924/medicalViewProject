﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication2
{
    //数据库操作类
    class SQLHelper
    {
        //数据库服务器
        private string strCon = "Server=昔景;User=sa;Pwd=qingfeng;DataBase=SKHS";
        public int doctorAdviceId;

        //数据库操作参数
        SqlConnection sqlcon;
        SqlCommand sqlcmd;
        SqlDataReader sqldrMonitor;
        SqlDataReader sqldrOrder;
        SqlDataReader sqldrDevice;
        SqlDataReader sqldrPatientName;
        SqlDataReader sqldrDoctorName;
        SqlDataReader sqldrExeTime;
        SqlDataReader sqldrIsAva;
        //设置sql语句
        public string setsql(string str)
        {
            return str;
        }

        //构造函数
        public SQLHelper(int id)
        {
            doctorAdviceId = id;
            sqlcon = new SqlConnection(strCon);
            sqlcmd = new SqlCommand();
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            sqlcmd.Connection = sqlcon;
        }

        //查询病人姓名
        public string sqlReaderPatientName()
        {
            sqlcmd.CommandText = setsql("select * from TB_PATIENT,TB_DOCTOR_ADVICE where TB_PATIENT.PATIENT_ID = TB_DOCTOR_ADVICE.PATIENT_ID and TB_DOCTOR_ADVICE.ADVICE_ID = " + doctorAdviceId);
            sqldrPatientName = sqlcmd.ExecuteReader();
            string patient_name = null;
            if(sqldrPatientName.HasRows)
            {
                while(sqldrPatientName.Read())
                {
                    patient_name = sqldrPatientName["NAME"].ToString();
                }
            }
            sqldrPatientName.Close();
            return patient_name;
        }

        /*
        //查询医生姓名
        public string sqlReaderDoctorName()
        {
            sqlcmd.CommandText = setsql("select * from TB_PATIENT,TB_DOCTOR_ADVICE where TB_PATIENT.PATIENT_ID = TB_DOCTOR_ADVICE.PATIENT_ID and TB_DOCTOR_ADVICE.ADVICE_ID = " + doctorAdviceId);
            sqldrDoctorName = sqlcmd.ExecuteReader();
            string patient_name = null;
            if (sqldrDoctorName.HasRows)
            {
                while (sqldrDoctorName.Read())
                {
                    patient_name = sqldrDoctorName["NAME"].ToString();
                }
            }
            sqldrDoctorName.Close();
            return patient_name;
        }
        */

        //查询执行时间
        public string sqlReaderExeTime()
        {
            sqlcmd.CommandText = setsql("select EXECUTE_TIME from TB_DOCTOR_ADVICE where ADVICE_ID = " + doctorAdviceId);
            sqldrExeTime = sqlcmd.ExecuteReader();
            string exeTime = null;
            if (sqldrExeTime.HasRows)
            {
                while (sqldrExeTime.Read())
                {
                    exeTime = sqldrExeTime["EXECUTE_TIME"].ToString();
                }
            }
            sqldrExeTime.Close();
            return exeTime;
        }

        //查询医嘱状态
        public string sqlReaderIsAva()
        {
            sqlcmd.CommandText = setsql("select IS_AVAILABLE from TB_DOCTOR_ADVICE where ADVICE_ID = " + doctorAdviceId);
            sqldrIsAva = sqlcmd.ExecuteReader();
            string isAva = null;
            if (sqldrIsAva.HasRows)
            {
                while (sqldrIsAva.Read())
                {
                    isAva = sqldrIsAva["IS_AVAILABLE"].ToString();
                }
            }
            sqldrIsAva.Close();
            return isAva;
        }

        //数据库查询
        public List<monitorInfo> sqlReadMonitor()
        {
            sqlcmd.CommandText = setsql("select * from TB_DOCTOR_ADVICE_MONITOR_ITEM where DOCTOR_ADVICE_ID=" + doctorAdviceId);
            sqldrMonitor = sqlcmd.ExecuteReader();
            List<monitorInfo> list = new List<monitorInfo>();
            if (sqldrMonitor.HasRows)
            {
                while (sqldrMonitor.Read())
                {
                    monitorInfo monitor = new monitorInfo();
                    monitor.DOCTOR_ADVICE_ID = sqldrMonitor["DOCTOR_ADVICE_ID"].ToString();
                    monitor.MONITOR_TYPE_ID = sqldrMonitor["MONITOR_TYPE_ID"].ToString();
                    monitor.MONITOE_PARA_ID = sqldrMonitor["MONITOR_PARA_ID"].ToString();
                    monitor.PARA_UP_LIMIT = sqldrMonitor["PARA_UP_LIMIT"].ToString();
                    monitor.PARA_UP_ALERT = sqldrMonitor["PARA_UP_ALERT"].ToString();
                    monitor.PARA_DOWN_LIMIT = sqldrMonitor["PARA_DOWN_LIMIT"].ToString();
                    monitor.PARA_DOWN_ALERT = sqldrMonitor["PARA_DOWN_ALERT"].ToString();

                    if (monitor.PARA_UP_LIMIT.Equals(""))
                        monitor.PARA_UP_LIMIT = "NULL";
                    if (monitor.PARA_UP_ALERT.Equals(""))
                        monitor.PARA_UP_ALERT = "NULL";
                    if (monitor.PARA_DOWN_LIMIT.Equals(""))
                        monitor.PARA_DOWN_LIMIT = "NULL";
                    if (monitor.PARA_DOWN_ALERT.Equals(""))
                        monitor.PARA_DOWN_ALERT = "NULL";

                    list.Add(monitor);
                }
            }
            sqldrMonitor.Close();
                return list;
        }

        //根据医嘱号查询运动方案执行顺序
        public List<ExecuteOrder> sqlReaderOrder()
        {
            sqlcmd.CommandText = setsql("select * from TB_EXERCISE_PLAN where DOCTOR_ADVICE_ID=" + doctorAdviceId);
            sqldrOrder = sqlcmd.ExecuteReader();
            List<ExecuteOrder> orderList = new List<ExecuteOrder>();
            int num = 0;
            if(sqldrOrder.HasRows)
            {
                while(sqldrOrder.Read())
                {
                    ExecuteOrder order = new ExecuteOrder();
                    order.EXECUTE_ORDER = int.Parse(sqldrOrder["EXECUTE_ORDER"].ToString());
                    order.EXERCISE_PLAN_ID = int.Parse(sqldrOrder["EXERCISE_PLAN_ID"].ToString());
                    order.DEVICE_TYPE_ID = int.Parse(sqldrOrder["DEVICE_TYPE_ID"].ToString());
                    orderList.Add(order);
                    num++;
                    System.Console.Write("执行顺序：" + order.EXECUTE_ORDER);
                    System.Console.Write("方案ID：" + order.EXERCISE_PLAN_ID);
                    System.Console.WriteLine("设备：" + order.DEVICE_TYPE_ID);
                }
                System.Console.WriteLine("Exercise_num:" + num);
                sortForOrder(orderList);
            }

            sqldrOrder.Close();
            for (int i = 0; i < orderList.Count;i++ )
            {
                System.Console.WriteLine(orderList[i].EXERCISE_PLAN_ID);
            }
                return orderList;
        }
        
        //根据医嘱号查询运动设备
        public List<deviceInfo> sqlReaderDevice()
        {
            sqlcmd.CommandText = setsql("select TB_EXERCISE_PLAN.DEVICE_TYPE_ID,TB_EXERCISE_PLAN.SECTION_NUM,TB_EXERCISE_PLAN_ITEM.EXERCISE_PLAN_ID,TB_EXERCISE_PLAN_ITEM.SECTION_ORDER,TB_EXERCISE_PLAN_ITEM.PARAMETER_ID,TB_EXERCISE_PLAN_ITEM.VALUE_IN_SECTION,TB_EXERCISE_PLAN_ITEM.MAX_VALUE,TB_EXERCISE_PLAN_ITEM.MIN_VALUE from TB_EXERCISE_PLAN_ITEM,TB_EXERCISE_PLAN where TB_EXERCISE_PLAN_ITEM.EXERCISE_PLAN_ID=TB_EXERCISE_PLAN.EXERCISE_PLAN_ID and TB_EXERCISE_PLAN.DOCTOR_ADVICE_ID=" + doctorAdviceId);
            sqldrDevice = sqlcmd.ExecuteReader();
            List<deviceInfo> list = new List<deviceInfo>();
            if (sqldrDevice.HasRows)
            {
                while (sqldrDevice.Read())
                {
                    deviceInfo device = new deviceInfo();
                    
                    device.EXERCISE_PLAN_ID = sqldrDevice["EXERCISE_PLAN_ID"].ToString();
                    device.DEVICE_TYPE_ID = sqldrDevice["DEVICE_TYPE_ID"].ToString();
                    device.SECTION_ORDER = sqldrDevice["SECTION_ORDER"].ToString();
                    device.PARAMETER_ID = sqldrDevice["PARAMETER_ID"].ToString();
                    device.VALUE_IN_SECTION = sqldrDevice["VALUE_IN_SECTION"].ToString();
                    device.MAX_VALUE = sqldrDevice["MAX_VALUE"].ToString();
                    device.MIN_VALUE = sqldrDevice["MIN_VALUE"].ToString();
                    device.SECTION_NUM = sqldrDevice["SECTION_NUM"].ToString();

                    if (device.MAX_VALUE.Equals(""))
                        device.MAX_VALUE = "NULL";
                    if (device.MIN_VALUE.Equals(""))
                        device.MIN_VALUE = "NULL";


                    list.Add(device);
                }
            }
            sqldrDevice.Close();
            return list;
        }

        public void sortForOrder(List<ExecuteOrder> list)
        {
            int n = list.Count;
            for (int j = 0; j < n - 1; j++) 
            {
                for (int i = 0; i < n - 1 - j; i++) 
                {
                    if(list[i].EXECUTE_ORDER>list[i+1].EXECUTE_ORDER)
                    {
                        ExecuteOrder temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                    }
                }
            }
        }
         

    }
}
