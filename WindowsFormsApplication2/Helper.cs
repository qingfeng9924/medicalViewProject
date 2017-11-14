using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Helper
    {
        public static Font font1=new Font("华文新魏",22.2f, FontStyle.Bold);
        /*
        string fontName;
        float size;
        FontStyle style;
        HelpFont()
        {
        }
        public HelpFont(string fontNme,float size,FontStyle style)
        {
            this.fontName = fontName;
            this.size = size;
            this.style = style;
        }
         * */
        //Form1 form1 = new Form1();
        public Font createFont1()
        {
            float a = 0;
            return new Font("华文新魏", Form1.getScreeWidth ()/ 90+a, FontStyle.Bold);
        }
        public Font createFont2()
        {
            float a = 0;
            return new Font("微软雅黑", Form1.getScreeWidth() / 115 + a, FontStyle.Bold);
        }
        public Color createColor(int r,int g,int b)
        {
            return Color.FromArgb(255, r, g, b);
        }
    }
}
