using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class SecondCtrl : UserControl
    {
        enum MousePosOnCtrl
        {
            NONE = 0,
            RIGHT = 2,
            LEFT = 1,
        }
        Rectangle[] sideRec = new Rectangle[2];//边框，用来做响应区域
        Rectangle ControlRect; //控件包含边框的区域  
        Control secCtrl;
        private const int band = 1;
        Size temp = new Size(band, band);
        private int minLength=2;
        public  Point pPoint; //上个鼠标坐标
        public  Point cPoint; //当前鼠标坐标
        private MousePosOnCtrl mpoc;
        Graphics g; //画图板
        public SecondCtrl(Control ctr)
        {
            this.secCtrl = ctr;
            addEvents();
            createBounds();
        }

        public void addEvents()
        {
            //this.Name = "OperateControl" + secCtrl.Name;
            this.MouseDown += new MouseEventHandler(mouseDown);
            this.MouseUp += new MouseEventHandler(mouseUp);
            this.MouseMove += new MouseEventHandler(mouseMove);
        }
        void mouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.SizeWE;
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = false;
                ControlMove();
            }
            else
            {
                this.Visible = true;
                SetCursorShape(e.X, e.Y); //更新鼠标指针样式
            }
        }
        void mouseDown(object sender,MouseEventArgs e)
        {
           // this.Parent.Refresh();
            pPoint = Cursor.Position;
        }
        void mouseUp(object sender, MouseEventArgs e)
        {
            this.secCtrl.Refresh(); //刷掉黑色边框
            if (secCtrl.Left<5)
            secCtrl.Left = 5;
            //if(secCtrl.Right<5)
              //  secCtrl.Right=5;
            this.Visible = true;
            createBounds();
        }

        public void createBounds()
        {
            //创建边界
            int X = secCtrl.Bounds.X - temp.Width -1;
            int Y = secCtrl.Bounds.Y - temp.Height - 1;
            int Height = secCtrl.Bounds.Height + (temp.Height * 2) + 2;
            int Width = secCtrl.Bounds.Width + (temp.Width * 2)+1;
            this.Bounds = new Rectangle(X, Y, Width, Height);
            this.BringToFront();
            //SetRectangles();
            ControlRect = new Rectangle(new Point(0, 0), this.Bounds.Size);
            //设置可视区域
            this.Region = new Region(buildFrame());
            //this.Visible = true;
        }
        private GraphicsPath buildFrame()
        {
            GraphicsPath path = new GraphicsPath();
            //左边框
            sideRec[0] = new Rectangle(0, temp.Height+1, temp.Width + 1, this.Height - temp.Height - 3);
            //右边框
            sideRec[1] = new Rectangle(this.Width - temp.Width - 1, 2, temp.Width + 1, this.Height - temp.Height - 3);
            path.AddRectangle(sideRec[0]);
            path.AddRectangle(sideRec[1]);
            return path;
        }
        public bool SetCursorShape(int x, int y)
        {
            Point point = new Point(x, y);
            if (!ControlRect.Contains(point))
            {
                Cursor.Current = Cursors.Arrow;
                return false;
            }
            else if (sideRec[0].Contains(point))
            {
                Cursor.Current = Cursors.SizeWE;
                mpoc = MousePosOnCtrl.LEFT;
            }
            else if (sideRec[1].Contains(point))
            {
                Cursor.Current = Cursors.SizeWE;
                mpoc = MousePosOnCtrl.RIGHT;
            }
            else
            {
                Cursor.Current = Cursors.Arrow;
            }
            return true;
        }
        private void ControlMove()
        {
            cPoint = Cursor.Position;
            int x = cPoint.X - pPoint.X;
            int y = cPoint.Y - pPoint.Y;
            //Console.WriteLine(pPoint.X + "--------------" + cPoint.X + "x=" + x);
            switch (this.mpoc)
            {
                case MousePosOnCtrl.LEFT:
                        if (secCtrl.Width - x > minLength)
                        {
                            if (secCtrl.Left > 4)
                            {
                                secCtrl.Left += x;
                                secCtrl.Width -= x;
                            }
                        }
                        else
                        {
                            secCtrl.Left -= minLength - secCtrl.Width;
                            secCtrl.Width = minLength;
                        }
                    break;
                case MousePosOnCtrl.RIGHT:
                    if (secCtrl.Width + x > minLength)
                    {
                        secCtrl.Width += x;
                    }
                    else
                    {
                        secCtrl.Width = minLength;
                    }
                    break;
            }
            pPoint = Cursor.Position;
        }        
    }
}
