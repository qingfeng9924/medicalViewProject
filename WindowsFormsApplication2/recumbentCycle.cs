using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    //卧式健身车
    class recumbentCycle
    {
        private int resistance;
        private int upperResistance;
        private int lowerResistance;
        private int distance;

        public void setResistance(int resis)
        {
            resistance = resis;
        }
        public int getResistance()
        {
            return resistance;
        }

        public void setUpperResistance(int resis)
        {
            upperResistance = resis;
        }
        public int getUpperResistance()
        {
            return upperResistance;
        }

        public void setLowerResistance(int resis)
        {
            lowerResistance = resis;
        }
        public int getLowerResistance()
        {
            return lowerResistance;
        }

        public void setDistance(int dis)
        {
            distance = dis;
        }
        public int getDistance()
        {
            return distance;
        }
    }
}
