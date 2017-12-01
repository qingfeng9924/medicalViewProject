using System;
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
        private string strCon = "Server=DESKTOP-V68FDEE;User=123;Pwd=123;DataBase=SKHS";
        public int doctorAdviceId;

        //数据库操作参数
        SqlConnection sqlcon;
        SqlCommand sqlcmd;
        SqlDataReader sqldr;
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
        //数据库查询
        public List<monitorInfo> sqlReadMonitor()
        {
            sqlcmd.CommandText = setsql("select * from TB_DOCTOR_ADVICE_MONITOR_ITEM where DOCTOR_ADVICE_ID=" + doctorAdviceId);
            sqldr = sqlcmd.ExecuteReader();
            List<monitorInfo> list = new List<monitorInfo>();
            while(sqldr.Read())
            {
                monitorInfo monitor = new monitorInfo();
                monitor.DOCTOR_ADVICE_ID = sqldr["DOCTOR_ADVICE_ID"].ToString();
                monitor.MONITOR_TYPE_ID = sqldr["MONITOR_TYPE_ID"].ToString();
                monitor.MONITOE_PARA_ID = sqldr["MONITOR_PARA_ID"].ToString();
                monitor.PARA_UP_LIMIT = sqldr["PARA_UP_LIMIT"].ToString();
                monitor.PARA_UP_ALERT = sqldr["PARA_UP_ALERT"].ToString();
                monitor.PARA_DOWN_LIMIT = sqldr["PARA_DOWN_LIMIT"].ToString();
                monitor.PARA_DOWN_ALERT = sqldr["PARA_DOWN_ALERT"].ToString();

                list.Add(monitor);
            }
                return list;
        }

    }
}
