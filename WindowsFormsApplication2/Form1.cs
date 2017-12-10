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
        private CubeControl cube;
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
            cube = (sender as CubeControl);

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


        public void mouseHover(object sender, EventArgs e)
        {
            // pWidth=
            ///心率
            if (sender == hrLabel[0])
            {
                if (sc1 == null)
                {
                    sc1 = new SecondCtrl(hrLabel[0]);
                }
                hrLabel[0].Parent.Refresh();//刷新父容器，清除掉其他控件的边框
                hrLabel[0].BringToFront();
                // this.cCtrl.Visible = false;
                sc1.Visible = true;
                // sc.BackColor = Color.Red;
                hrLabel[0].Parent.Controls.Add(sc1);
                sc1.Refresh();
                ///o = new OperateControl(hrLabel[0]); 
                if (sc1 != null)
                {
                    sc1.MouseMove += new MouseEventHandler(MouseMove);
                    //   sc. += new MouseEventHandler(MouseDown);
                    //hrOpPanel.BackColor = Color.Black;
                }
            }
            else if (sender == hrLabel[1])
            {
                //  hrLabel[1].BackColor = Color.Black;
                if (rsc1 == null)
                {
                    rsc1 = new RightSecondControl(hrLabel[1]);
                }
                hrLabel[1].Parent.Refresh();//刷新父容器，清除掉其他控件的边框
                hrLabel[1].BringToFront();
                // this.cCtrl.Visible = false;
                rsc1.Visible = true;
                // Helper helper = new Helper();
                // rsc1.BackColor = helper.createColor(114, 149, 182); ;
                hrLabel[1].Parent.Controls.Add(rsc1);
                rsc1.Refresh();
                ///o = new OperateControl(hrLabel[0]); 
                if (rsc1 != null)
                {
                    rsc1.MouseMove += new MouseEventHandler(MouseMove);
                    //   sc. += new MouseEventHandler(MouseDown);
                    //hrOpPanel.BackColor = Color.Black;
                }
            }
            else if (sender == hrLabel[2])
            {
                //  hrLabel[1].BackColor = Color.Black;
                if (rsc2 == null)
                {
                    rsc2 = new RightSecondControl(hrLabel[2]);
                }
                hrLabel[1].Parent.Refresh();//刷新父容器，清除掉其他控件的边框
                hrLabel[1].BringToFront();
                // this.cCtrl.Visible = false;
                rsc2.Visible = true;
                // rsc2.BackColor = Color.Red;
                hrLabel[2].Parent.Controls.Add(rsc2);
                rsc2.Refresh();
                ///o = new OperateControl(hrLabel[0]); 
                if (rsc2 != null)
                {
                    rsc2.MouseMove += new MouseEventHandler(MouseMove);

                }
            }
            //收缩压
            if (sender == ssyLabel[0])
            {
                if (sc2 == null)
                {
                    sc2 = new SecondCtrl(ssyLabel[0]);
                }
                ssyLabel[0].Parent.Refresh();//刷新父容器，清除掉其他控件的边框
                ssyLabel[0].BringToFront();
                // this.cCtrl.Visible = false;
                sc2.Visible = true;
                // sc.BackColor = Color.Red;
                ssyLabel[0].Parent.Controls.Add(sc2);
                sc2.Refresh();
                ///o = new OperateControl(hrLabel[0]); 
                if (sc2 != null)
                {
                    sc2.MouseMove += new MouseEventHandler(MouseMove);
                    //   sc. += new MouseEventHandler(MouseDown);
                    //hrOpPanel.BackColor = Color.Black;
                }
            }
            else if (sender == ssyLabel[1])
            {
                //  hrLabel[1].BackColor = Color.Black;
                if (rsc3 == null)
                {
                    rsc3 = new RightSecondControl(ssyLabel[1]);
                }
                ssyLabel[1].Parent.Refresh();//刷新父容器，清除掉其他控件的边框
                ssyLabel[1].BringToFront();
                // this.cCtrl.Visible = false;
                rsc3.Visible = true;
                // Helper helper = new Helper();
                // rsc1.BackColor = helper.createColor(114, 149, 182); ;
                ssyLabel[1].Parent.Controls.Add(rsc3);
                rsc3.Refresh();
                ///o = new OperateControl(hrLabel[0]); 
                if (rsc3 != null)
                {
                    rsc3.MouseMove += new MouseEventHandler(MouseMove);
                    //   sc. += new MouseEventHandler(MouseDown);
                    //hrOpPanel.BackColor = Color.Black;
                }
            }
            else if (sender == ssyLabel[2])
            {
                //  hrLabel[1].BackColor = Color.Black;
                if (rsc4 == null)
                {
                    rsc4 = new RightSecondControl(ssyLabel[2]);
                }
                ssyLabel[1].Parent.Refresh();//刷新父容器，清除掉其他控件的边框
                ssyLabel[1].BringToFront();
                // this.cCtrl.Visible = false;
                rsc4.Visible = true;
                // rsc2.BackColor = Color.Red;
                ssyLabel[2].Parent.Controls.Add(rsc4);
                rsc4.Refresh();
                ///o = new OperateControl(hrLabel[0]); 
                if (rsc4 != null)
                {
                    rsc4.MouseMove += new MouseEventHandler(MouseMove);

                }
            }
        }
        void MouseMove(object sender, MouseEventArgs e)
        {
            //心率
            if (hrLabel[2].Location.X + hrLabel[2].Width < hrOpPanel.Width - 5)
            {
                if (sender == sc1)
                {
                    hrLabel[1].Location = new Point(hrLabel[0].Location.X + hrLabel[0].Width + 2, 2);
                    hrLabel[2].Location = new Point(hrLabel[1].Location.X + hrLabel[1].Width + 2, 2);
                }
                else if (sender == rsc1)
                {
                    hrLabel[2].Location = new Point(hrLabel[1].Location.X + hrLabel[1].Width + 2, 2);
                }
                if (sender == sc1)
                {
                    sc1.createBounds();
                    if (rsc1 != null)
                    {
                        rsc1.createBounds();
                    }
                }
                else if (sender == rsc1)
                {
                    rsc1.createBounds();
                    if (rsc2 != null)
                        rsc2.createBounds();
                }
                else if (sender == rsc2)
                {
                    rsc2.createBounds();
                }
                this.hrLabel[1].Refresh();
                this.hrLabel[0].Refresh();
                this.hrLabel[2].Refresh();
            }
            else
            {
                hrLabel[1].Location = new Point(hrLabel[0].Location.X + hrLabel[0].Width + 2, 2);
                hrLabel[2].Location = new Point(hrLabel[1].Location.X + hrLabel[1].Width + 2, 2);
            }
            //收缩压
            if (ssyLabel[2].Location.X + hrLabel[2].Width < hrOpPanel.Width - 5)
            {
                if (sender == sc2)
                {
                    ssyLabel[1].Location = new Point(ssyLabel[0].Location.X + ssyLabel[0].Width + 2, 2);
                    ssyLabel[2].Location = new Point(ssyLabel[1].Location.X + ssyLabel[1].Width + 2, 2);
                }
                else if (sender == rsc3)
                {
                    ssyLabel[2].Location = new Point(ssyLabel[1].Location.X + ssyLabel[1].Width + 2, 2);
                }
                if (sender == sc2)
                {
                    sc2.createBounds();
                    if (rsc3 != null)
                    {
                        rsc3.createBounds();
                    }
                }
                else if (sender == rsc3)
                {
                    rsc3.createBounds();
                    if (rsc4 != null)
                        rsc4.createBounds();
                }
                else if (sender == rsc4)
                {
                    rsc4.createBounds();
                }
                this.ssyLabel[1].Refresh();
                this.ssyLabel[0].Refresh();
                this.ssyLabel[2].Refresh();
            }
            else
            {
                ssyLabel[1].Location = new Point(ssyLabel[0].Location.X + ssyLabel[0].Width + 2, 2);
                ssyLabel[2].Location = new Point(ssyLabel[1].Location.X + ssyLabel[1].Width + 2, 2);
            }

        }

    }
}
