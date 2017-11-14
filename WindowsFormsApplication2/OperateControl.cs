using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class OperateControl
    {
        private Control cCtrl;
        public  SecondCtrl sc;
        public OperateControl(Control ctr)
        {
            this.cCtrl=ctr;
            addEvents();
        }

        public void addEvents()
        {
            this.cCtrl.MouseClick += new MouseEventHandler(mouseClick);
        }
        void mouseClick(object sender, MouseEventArgs e)
        {
            //this.cCtrl.BackColor = Color.Yellow;
            if(sc==null)
            {
                sc = new SecondCtrl(this.cCtrl);
            }
            this.cCtrl.Parent.Refresh();//刷新父容器，清除掉其他控件的边框
            this.cCtrl.BringToFront();
           // this.cCtrl.Visible = false;
            sc.Visible = true;
            sc.BackColor = Color.Blue;
            this.cCtrl.Parent.Controls.Add(sc);
            sc.Refresh();
        }
    }
}
