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
        private float curSpeed;
        private float upperSpeed;
        private float lowerSpeed;
        private float Time;
        private int Slope;

        public void setCurSpeed(float speed)
        {
            curSpeed = speed;
        }

        public float getCurSpeed()
        {
            return curSpeed;
        }

        public void setUpperSpeed(float speed)
        {
            upperSpeed = speed;
        }

        public float getUpperSpeed()
        {
            return upperSpeed;
        }

        public void setLowerSpeed(float speed)
        {
            lowerSpeed = speed;
        }

        public float getLowerSpeed()
        {
            return lowerSpeed;
        }

        public void setTime(float time)
        {
            Time = time;
        }

        public float getTime()
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

        public int speedToHeight()
        {
            return (int)((curSpeed - 1) * 300 / 24);
        }
    }
}
