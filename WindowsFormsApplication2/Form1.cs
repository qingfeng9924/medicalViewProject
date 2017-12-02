using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private CubeConrol cube;
        private Point p;

        public Form1()
        {
            InitializeComponent();
        }
        //label监听实现
        //跑步机
        void saveButton_MouseClick(object sender, EventArgs e)
        {
            /*
            hrImageLabel.Text = "x=" + hrLabel[].Location.X+"right="+hrLabel.Right+"width="+hrLabel.Width;
            hrImageLabel.BackColor = Color.Blue;
            hrImageLabel.Refresh();
            this.Refresh();
             * */
              
        }
        public void label_runMach_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            label_runMach.Location = new System.Drawing.Point(19,9);
            label_runMach.Size = new System.Drawing.Size(102, 102);
        }
        public void label_runMach_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            label_runMach.Location = new System.Drawing.Point(20, 10);
            label_runMach.Size = new System.Drawing.Size(lpWidth, lpWidth);
        }
        //椭圆机
        public void label_ovalMach_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            label_ovalMach.Location = new System.Drawing.Point(label_ovalMach.Location.X -1, label_ovalMach.Location.Y-1);
            label_ovalMach.Size = new System.Drawing.Size(lpWidth + 2, lpHeight+2);
        }
        public void label_ovalMach_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            label_ovalMach.Location = new System.Drawing.Point(label_runMach.Location.X + label_runMach.Width + 60, label_runMach.Location.Y);
            label_ovalMach.Size = new System.Drawing.Size(lpWidth, lpWidth);
        }
        public void label_stByc_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            label_stByc.Location = new System.Drawing.Point(label_ovalMach.Location.X + label_ovalMach.Width + 59, label_ovalMach.Location.Y-1);
            label_stByc.Size = new System.Drawing.Size(lpWidth+2, lpHeight+2);
        }
        public void label_stByc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            label_stByc.Location = new System.Drawing.Point(label_ovalMach.Location.X + label_ovalMach.Width + 60, label_ovalMach.Location.Y);
            label_stByc.Size = new System.Drawing.Size(lpWidth, lpHeight);
        }
        public void label_lieByc_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            label_lieByc.Location = new System.Drawing.Point(label_stByc.Location.X + label_stByc.Width+39, label_stByc.Location.Y-1);
            label_lieByc.Size = new System.Drawing.Size(lpWidth+2, lpHeight+2);
        }
        public void label_lieByc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            label_lieByc.Location = new System.Drawing.Point(label_stByc.Location.X + label_stByc.Width+40, label_stByc.Location.Y);
            label_lieByc.Size = new System.Drawing.Size(lpWidth, lpHeight);
        }

        /***************************************************************************/

        /*
        private void DrawPan_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("fdsafdsa");
            XYLinesFactory.DrawXY(runMachPanel);
            XYLinesFactory.DrawYLine(runMachPanel, 10, 5);

        }
        */

        private void cubeMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            p.X = e.X;
            p.Y = e.Y;
        }

        private void cubeMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            cube = (sender as CubeConrol);

            if (e.Button == MouseButtons.Left)
            {
                if (cube.isMove == true)
                {
                    int position = cubeList.IndexOf(cube);
                    for (int i = position + 1; i < cubeList.Count(); i++)
                    {
                        cubeList[i].Left = cubeList[i - 1].Left + (int)(0.75 * cubeList[i - 1].Width);
                    }
                }
            }
        }

    }
}
