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

        //设置跑步机参数
        public List<Treadmill> setTreadmillParameter(List<deviceInfo> deviceList, int planId)
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
                                treadmill.setTime(int.Parse(deviceList[i].VALUE_IN_SECTION));
                            }
                            //参数为跑步机的速度
                            else if (deviceList[i].PARAMETER_ID.Equals("4"))
                            {
                                treadmill.setCurSpeed(int.Parse(deviceList[i].VALUE_IN_SECTION));
                                treadmill.setUpperSpeed(int.Parse(deviceList[i].MAX_VALUE));
                                treadmill.setLowerSpeed(int.Parse(deviceList[i].MIN_VALUE));
                            }

                            //参数为跑步机的坡度
                            else if (deviceList[i].PARAMETER_ID.Equals("5"))
                            {
                                treadmill.setSlope(int.Parse(deviceList[i].VALUE_IN_SECTION));
                                treadmill.setUpperSlope(int.Parse(deviceList[i].MAX_VALUE));
                                treadmill.setLowerSlope(int.Parse(deviceList[i].MIN_VALUE));
                            }
                        }
                    }
                }
                treadmillList.Add(treadmill);
                j++;
            }
            return treadmillList;
        }

        //设置椭圆机参数
        public List<Elliptical> setEllipticalParameter(List<deviceInfo> deviceList, int planId)
        {
            List<Elliptical> ellipticalList = new List<Elliptical>();
            int j = 1;
            while (j <= cubeNum)
            {
                Elliptical elliptical = new Elliptical();
                for (int i = 0; i < deviceList.Count; i++)
                {
                    //判断是否是当前方案
                    if (deviceList[i].EXERCISE_PLAN_ID.Equals(planId.ToString()))
                    {
                        //判断是否为当前段
                        if (deviceList[i].SECTION_ORDER.Equals(j.ToString()))
                        {
                            //参数为椭圆机的距离
                            if (deviceList[i].PARAMETER_ID.Equals("14"))
                            {
                                elliptical.setDistance(int.Parse(deviceList[i].VALUE_IN_SECTION));
                            }
                            //参数为椭圆机的阻力
                            else if (deviceList[i].PARAMETER_ID.Equals("17"))
                            {
                                elliptical.setResistance(int.Parse(deviceList[i].VALUE_IN_SECTION));
                                elliptical.setUpperResistance(int.Parse(deviceList[i].MAX_VALUE));
                                elliptical.setLowerResistance(int.Parse(deviceList[i].MIN_VALUE));
                            }
                        }
                    }
                }
                ellipticalList.Add(elliptical);
                j++;
            }
            return ellipticalList;
        }

        //设置立式健身车参数
        public List<uprightCycle> setuprightCycleParameter(List<deviceInfo> deviceList, int planId)
        {
            List<uprightCycle> uprightcycleList = new List<uprightCycle>();
            int j = 1;
            while (j <= cubeNum)
            {
                uprightCycle uprightcycle = new uprightCycle();
                for (int i = 0; i < deviceList.Count; i++)
                {
                    //判断是否是当前方案
                    if (deviceList[i].EXERCISE_PLAN_ID.Equals(planId.ToString()))
                    {
                        //判断是否为当前段
                        if (deviceList[i].SECTION_ORDER.Equals(j.ToString()))
                        {
                            //参数为立式健身车的距离
                            if (deviceList[i].PARAMETER_ID.Equals("28"))
                            {
                                uprightcycle.setDistance(int.Parse(deviceList[i].VALUE_IN_SECTION));
                            }
                            //参数为立式健身车的阻力
                            else if (deviceList[i].PARAMETER_ID.Equals("31"))
                            {
                                uprightcycle.setResistance(int.Parse(deviceList[i].VALUE_IN_SECTION));
                                uprightcycle.setUpperResistance(int.Parse(deviceList[i].MAX_VALUE));
                                uprightcycle.setLowerResistance(int.Parse(deviceList[i].MIN_VALUE));
                            }
                        }
                    }
                }
                uprightcycleList.Add(uprightcycle);
                j++;
            }
            return uprightcycleList;
        }

        //设置卧式健身车参数
        public List<recumbentCycle> setrecumbentCycleParameter(List<deviceInfo> deviceList, int planId)
        {
            List<recumbentCycle> recumbentcycleList = new List<recumbentCycle>();
            int j = 1;
            while (j <= cubeNum)
            {
                recumbentCycle recumbentcycle = new recumbentCycle();
                for (int i = 0; i < deviceList.Count; i++)
                {
                    //判断是否是当前方案
                    if (deviceList[i].EXERCISE_PLAN_ID.Equals(planId.ToString()))
                    {
                        //判断是否为当前段
                        if (deviceList[i].SECTION_ORDER.Equals(j.ToString()))
                        {
                            //参数为卧式健身车的距离
                            if (deviceList[i].PARAMETER_ID.Equals("7"))
                            {
                                recumbentcycle.setDistance(int.Parse(deviceList[i].VALUE_IN_SECTION));
                            }
                            //参数为卧式健身车的阻力
                            else if (deviceList[i].PARAMETER_ID.Equals("10"))
                            {
                                recumbentcycle.setResistance(int.Parse(deviceList[i].VALUE_IN_SECTION));
                                recumbentcycle.setUpperResistance(int.Parse(deviceList[i].MAX_VALUE));
                                recumbentcycle.setLowerResistance(int.Parse(deviceList[i].MIN_VALUE));
                            }
                        }
                    }
                }
                recumbentcycleList.Add(recumbentcycle);
                j++;
            }
            return recumbentcycleList;
        }
    }
}
