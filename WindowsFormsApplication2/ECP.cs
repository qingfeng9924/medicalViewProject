using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class ECP
    {
        private float exPressure;
        private float upperExPressure;
        private float lowerExPressure;
        private float Time;
        private float R2I_offset;
        private float R2D_offset;

        public void setExPressure(float pressure)
        {
            exPressure = pressure;
        }

        public float getExPressure()
        {
            return exPressure;
        }

        public void setUpperExPressure(float pressure)
        {
            upperExPressure = pressure;
        }

        public float getUpperExPressure()
        {
            return upperExPressure;
        }

        public void setLowerExPressure(float pressure)
        {
            lowerExPressure = pressure;
        }

        public float getLowerExPressure()
        {
            return lowerExPressure;
        }

        public void setTime(float time)
        {
            Time = time;
        }
        public float getTime()
        {
            return Time;
        }

        public void setR2I(float offset)
        {
            R2I_offset = offset;
        }
        public float getR2I()
        {
            return R2I_offset;
        }

        public void setR2D(float offset)
        {
            R2D_offset = offset;
        }
        public float getR2D()
        {
            return R2D_offset;
        }
    }
}
