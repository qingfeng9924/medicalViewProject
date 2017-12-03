using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    /// <summary>
    /// 跑步机
    /// </summary>
    class Treadmill
    {
        private int curSpeed;
        private int upperSpeed;
        private int lowerSpeed;
        private int Time;
        private int Slope;
        private int upperSlope;
        private int lowerSlope;

        public void setCurSpeed(int speed)
        {
            curSpeed = speed;
        }

        public int getCurSpeed()
        {
            return curSpeed;
        }

        public void setUpperSpeed(int speed)
        {
            upperSpeed = speed;
        }

        public int getUpperSpeed()
        {
            return upperSpeed;
        }

        public void setLowerSpeed(int speed)
        {
            lowerSpeed = speed;
        }

        public int getLowerSpeed()
        {
            return lowerSpeed;
        }

        public void setTime(int time)
        {
            Time = time;
        }

        public int getTime()
        {
            return Time;
        }

        public void setSlope(int slope)
        {
            Slope = slope;
        }

        public int getSlope()
        {
            return Slope;
        }

        public void setUpperSlope(int slope)
        {
            upperSlope = slope;
        }

        public int getUpperSlope()
        {
            return upperSlope;
        }

        public void setLowerSlope(int slope)
        {
            lowerSlope = slope;
        }

        public int getLowerSlope()
        {
            return lowerSlope;
        }


        public int speedToHeight()
        {
            return (int)((curSpeed - 1) * 300 / 24);
        }
    }
}
