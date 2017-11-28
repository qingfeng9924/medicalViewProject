using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{

    class CubeHelper
    {
        private List<CubeConrol> cubeList;
        private int cubeNum;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        //        Form1 form = new Form1();

        public CubeHelper(int num)
        {
            cubeList = new List<CubeConrol>();
            cubeNum = num;
            initList();
        }

        private void initList()
        {
            for (int i = 0; i < cubeNum; i++)
            {
                cubeList.Add(new CubeConrol(100,200));
                cubeList[i].Image = Image.FromFile("1.png");
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

        public List<CubeConrol> getList()
        {
            return cubeList;
        }
    }
}
