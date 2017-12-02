using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class deviceHelper
    {
        //private List<deviceInfo> deviceList = new List<deviceInfo>();
        private int cubeNum;

        /*
        public void setDeviceList(List<deviceInfo> list)
        {
            deviceList = list;
        }
        */


        public void setCubeNum(List<deviceInfo> list, int planId)
        {
            cubeNum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].EXERCISE_PLAN_ID.Equals(planId.ToString()))
                {
                    cubeNum = int.Parse(list[i].SECTION_NUM);
                    break;
                }
            }
        }


        public int getCubeNum()
        {
            return cubeNum;
        }


        public void setParameter(List<deviceInfo> deviceList, int planId)
        {
            int deviceTypeId = getDeviceType(deviceList, planId);
            if (deviceTypeId == 1)
            {
                setTreadmillParameter(deviceList, planId);
            }
        }


        public int getDeviceType(List<deviceInfo> deviceList, int planId)
        {
            int i = 0;
            for (; i < deviceList.Count; i++) 
            {
                if (deviceList[i].EXERCISE_PLAN_ID.Equals(planId.ToString()))
                {
                    break;
                }
            }
            return int.Parse(deviceList[i].DEVICE_TYPE_ID);
        }

        public void setTreadmillParameter(List<deviceInfo> deviceList, int planId)
        {
            List<Treadmill> treadmillList = new List<Treadmill>();
            int j = 1;
            while (j <= cubeNum)
            {
                Treadmill treadmill = new Treadmill();
                for (int i = 0; i < deviceList.Count; i++)
                {
                    //判断是否是当前方案
                    if (deviceList[i].EXERCISE_PLAN_ID.Equals(planId.ToString()))
                    {
                        //判断是否为当前段
                        if (deviceList[i].SECTION_ORDER.Equals(j.ToString()))
                        {
                            //参数为跑步机的时间
                            if (deviceList[i].PARAMETER_ID.Equals("1"))
                            {
                                treadmill.setTime(float.Parse(deviceList[i].VALUE_IN_SECTION));
                            }
                            //参数为跑步机的速度
                            if (deviceList[i].PARAMETER_ID.Equals("4"))
                            {
                                treadmill.setCurSpeed(float.Parse(deviceList[i].VALUE_IN_SECTION));
                            }
                            //参数为跑步机的坡度
                            if (deviceList[i].PARAMETER_ID.Equals("5"))
                            {
                                treadmill.setSlope(int.Parse(deviceList[i].VALUE_IN_SECTION));
                            }
                        }
                    }
                }
                treadmillList.Add(treadmill);
                j++;
            }

            for (int i = 0; i < treadmillList.Count; i++)
            {
                System.Console.Write(treadmillList[i].getTime() + " ");
                System.Console.Write(treadmillList[i].getCurSpeed() + " ");
                System.Console.WriteLine(treadmillList[i].getSlope() + " ");
            }
        }
    }
}
