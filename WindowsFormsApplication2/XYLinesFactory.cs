using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class XYLinesFactory
    {
        private static float move = 50f;
        private static float Ybase;

        public static void DrawXY(Panel pan)
        {
            //   float move = 50f;
            Graphics g = pan.CreateGraphics();

            float newX = pan.Width - move;
            float newY = pan.Height - move;

            PointF px1 = new PointF(move, newY);
            PointF px2 = new PointF(newX, newY);
            g.DrawLine(new Pen(Brushes.Gray, 2), px1, px2);

            PointF py1 = new PointF(move, move);
            PointF py2 = new PointF(move, newY);
            g.DrawLine(new Pen(Brushes.Gray, 2), py1, py2);

            /*
            Console.WriteLine(px1);
            Console.WriteLine(px2);
            Console.WriteLine(py1);
            Console.WriteLine(py2);


            Console.WriteLine(pan.Top);
            Console.WriteLine(pan.Height);
            Console.WriteLine(pan.Bottom);

            Console.WriteLine(pan.Left);
            Console.WriteLine(pan.Right);
            */
        }

        public static void DrawYLine(Panel pan, float maxY, int len)
        {
            //   float move = 50f;
            float LenX = pan.Width - 2 * move;
            float LenY = pan.Height - 2 * move;
            Graphics g = pan.CreateGraphics();
            for (int i = 0; i < len; i++)
            {
                PointF px1 = new PointF(move, LenY * i / len + move);
                PointF px2 = new PointF(move + 10, LenY * i / len + move - 10);
                string sx = (maxY - maxY * i / len).ToString(); ;
                g.DrawLine(new Pen(Brushes.Gray, 2), px1, px2);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Far;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(sx, new Font("宋体", 8f), Brushes.Gray, new PointF(move / 1.2f, LenY * i / len + move * 1.1f), drawFormat);
            }
            Pen pen = new Pen(Color.Gray, 2);
            g.DrawString("Y轴", new Font("宋体 ", 10f), Brushes.Gray, new PointF(move / 3, move / 2f));
        }

        public static int getMove() { return (int)move; }
        //public static int getYbase() { return (int)Ybase; }
        public static int getYbase(Panel pan) 
        {
            Ybase = pan.Height - move;
            return (int)Ybase;
        }
    }
}
