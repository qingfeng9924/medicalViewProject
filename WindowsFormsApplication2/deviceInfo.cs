using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class deviceInfo
    {
        //  1---------跑步机  1-------时间   4---------速度（1-25）   5-----------坡度（0-15）
        //  3---------椭圆机   14-------距离  17--------阻力（1-15）
        //  6---------体外反搏   20-------时间   21-------R2I偏移  22---------R2D偏移   23-----------期望压力
        //  13--------立式健身车  28------距离   31---------阻力（1-16）
        //  14--------卧式健身车  7-------距离   10-----------阻力（1-15）     

        public String EXERCISE_PLAN_ID;  //运动方案ID
        public String DEVICE_TYPE_ID;    //设备类型ID
        public String SECTION_ORDER;     //执行顺序号
        public String PARAMETER_ID;      //参数ID
        public String VALUE_IN_SECTION;  //该段该参数值
        public String MAX_VALUE;         //该段该参数最大值
        public String MIN_VALUE;         //该段该参数最小值
        public String SECTION_NUM;       //该方案段数
    }
}
