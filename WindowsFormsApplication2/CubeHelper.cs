using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{

    class CubeHelper
    {
        private List<myControl.UserControl1> cubeList;
        private int cubeNum;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        //        Form1 form = new Form1();

        public CubeHelper(int num)
        {
            cubeList = new List<myControl.UserControl1>();
            cubeNum = num;
            initList();
        }

        private void initList()
        {
            for (int i = 0; i < cubeNum; i++)
            {
                cubeList.Add(new myControl.UserControl1());
                cubeList[i].BackColor = System.Drawing.Color.Transparent;
                cubeList[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                if (i == 0)
                {
                    cubeList[i].Location = new System.Drawing.Point(XYLinesFactory.getMove() + 1, 398 - XYLinesFactory.getMove() - cubeList[i].Height - 1);
                    //cubeList[i].Location = new System.Drawing.Point(XYLinesFactory.getMove() + 1, XYLinesFactory.getYbase() - cubeList[i].Height - 1);
                }
                else
                {
                    cubeList[i].Location = new System.Drawing.Point((cubeList[i - 1].Left + (int)(0.75 * cubeList[i - 1].Width)), 398 - XYLinesFactory.getMove() - cubeList[i].Height - 1);
                    //cubeList[i].Location = new System.Drawing.Point((cubeList[i - 1].Left + (int)(0.75 * cubeList[i - 1].Width)), XYLinesFactory.getYbase() - cubeList[i].Height - 1);
                }
                cubeList[i].Name = "cube" + i;
                cubeList[i].Size = new System.Drawing.Size(150, 150);
                cubeList[i].TabIndex = i;
                //cubeList[i].Base = form.getPanel().Height - XYLinesFactory.getMove() - 1;
                cubeList[i].Base = 398 - XYLinesFactory.getMove() - 1;
                /*
                if (i != 0) 
                {
                    cubeList[i].Parent = cubeList[i - 1];
                }
                 * */
            }
        }

        public List<myControl.UserControl1> getList()
        {
            return cubeList;
        }
    }
}
