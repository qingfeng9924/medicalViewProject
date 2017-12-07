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
        private List<CubeControl> cubeList;
        private int cubeNum;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        //        Form1 form = new Form1();
        private int ybase;

        public CubeHelper(List<CubeControl> List, int Ybase)
        {
            cubeList = List;
            cubeNum = cubeList.Count;
            ybase = Ybase;
            initList();
        }

        private void initList()
        {
            for (int i = 0; i < cubeNum; i++)
            {
                cubeList[i].Image = Image.FromFile("1.png");
                if (i == 0)
                {
                    //System.Console.WriteLine("Ybase:" + XYLinesFactory.getYbase());
                    //cubeList[i].Location = new System.Drawing.Point(XYLinesFactory.getMove() + 1, 398 - XYLinesFactory.getMove() - cubeList[i].Height - 1);
                    cubeList[i].Location = new System.Drawing.Point(XYLinesFactory.getMove() + 1,ybase - cubeList[i].Height - 1);
                   // System.Console.WriteLine("位置0:"+cubeList[i].Location);
                }
                else
                {
                    cubeList[i].Location = new System.Drawing.Point((cubeList[i - 1].Left + (int)(0.75 * cubeList[i - 1].Width)), ybase - cubeList[i].Height - 1);
                  //  System.Console.WriteLine("位置:" + cubeList[i].Location);
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



        public List<CubeControl> getList()
        {
            return cubeList;
        }
    }
}
