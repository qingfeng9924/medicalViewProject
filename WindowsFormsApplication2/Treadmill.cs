using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Treadmill
    {
        private float curSpeed;
        private float upperSpeed;
        private float lowerSpeed;
        private float distance;

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

        public void setDistance(float dis)
        {
            distance = dis;
        }

        public float getDistance()
        {
            return distance;
        }
    }
}
