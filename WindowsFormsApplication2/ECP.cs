using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{

    //体外反搏
    class ECP
    {
        private int exPressure;
        private int upperExPressure;
        private int lowerExPressure;
        private int Time;
        private int R2I_offset;
        private int upperR2I_offset;
        private int lowerR2I_offset;
        private int R2D_offset;
        private int upperR2D_offset;
        private int lowerR2D_offset;

        public void setExPressure(int pressure)
        {
            exPressure = pressure;
        }

        public int getExPressure()
        {
            return exPressure;
        }

        public void setUpperExPressure(int pressure)
        {
            upperExPressure = pressure;
        }

        public int getUpperExPressure()
        {
            return upperExPressure;
        }

        public void setLowerExPressure(int pressure)
        {
            lowerExPressure = pressure;
        }

        public int getLowerExPressure()
        {
            return lowerExPressure;
        }

        public void setTime(int time)
        {
            Time = time;
        }
        public int getTime()
        {
            return Time;
        }

        public void setR2I(int offset)
        {
            R2I_offset = offset;
        }
        public int getR2I()
        {
            return R2I_offset;
        }

        public void setUpperR2I(int offset)
        {
            upperR2I_offset = offset;
        }

        public int getUpperR2I()
        {
            return upperR2I_offset;
        }

        public void setLowerR2I(int offset)
        {
            lowerR2I_offset = offset;
        }

        public int getLowerR2I()
        {
            return lowerR2I_offset;
        }

        public void setR2D(int offset)
        {
            R2D_offset = offset;
        }
        public int getR2D()
        {
            return R2D_offset;
        }

        public void setUpperR2D(int offset)
        {
            upperR2D_offset = offset;
        }

        public int getUpperR2D()
        {
            return upperR2D_offset;
        }

        public void setLowerR2D(int offset)
        {
            lowerR2D_offset = offset;
        }

        public int getLowerR2D()
        {
            return lowerR2D_offset;
        }
    }
}
