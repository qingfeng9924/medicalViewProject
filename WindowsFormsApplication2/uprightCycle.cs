using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class uprightCycle
    {
        private float resistance;
        private float upperResistance;
        private float lowerResistance;
        private float distance;

        public void setResistance(float resis)
        {
            resistance = resis;
        }
        public float getResistance()
        {
            return resistance;
        }

        public void setUpperResistance(float resis)
        {
            upperResistance = resis;
        }
        public float getUpperResistance()
        {
            return upperResistance;
        }

        public void setLowerResistance(float resis)
        {
            lowerResistance = resis;
        }
        public float getLowerResistance()
        {
            return lowerResistance;
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
