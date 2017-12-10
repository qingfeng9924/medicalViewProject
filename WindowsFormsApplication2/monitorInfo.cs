using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class monitorInfo
    {
        public String DOCTOR_ADVICE_ID;   //医嘱ID
        public String MONITOR_TYPE_ID;    //监护设备ID
        public String MONITOE_PARA_ID;    //监护参数ID
        public String PARA_UP_LIMIT;      //上限
        public String PARA_UP_ALERT;      //上限预警值
        public String PARA_DOWN_LIMIT;    //下限
        public String PARA_DOWN_ALERT;    //下限预警值

        //血氧--------MONITOR_PARA_ID = 1
        //舒张压------MONITPR_PARA_ID = 2
        //收缩压------MONITOR_PARA_ID = 3
        //心率--------MONITOR_PARA_ID = 4
    }
}
