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
        private SQLHelper sqlHelper;
        private List<monitorInfo> monitorList;
        private List<deviceInfo> deviceList;
        private List<ExecuteOrder> orderList;
        private int planId;
        private int[] monitorPara = new int[14];
        private int operatedSec;

        public Form1()
        {
            setData();
            setMonitorPara();
            InitializeComponent();
        }

        public void setData()
        {
            sqlHelper = new SQLHelper(307);
            //sqlHelper = new SQLHelper(319);
            monitorList = sqlHelper.sqlReadMonitor();
            deviceList = sqlHelper.sqlReaderDevice();
            orderList = new List<ExecuteOrder>();
            orderList = sqlHelper.sqlReaderOrder();
            planId = orderList[0].EXERCISE_PLAN_ID;
        }

        public void setMonitorPara()
        {
            for (int i = 0; i < monitorList.Count; i++) 
            {
                if (monitorList[i].MONITOE_PARA_ID.Equals("1"))
                {
                    monitorPara[0] = int.Parse(monitorList[i].PARA_DOWN_LIMIT);
                    monitorPara[1] = int.Parse(monitorList[i].PARA_DOWN_ALERT);
                }
                else if(monitorList[i].MONITOE_PARA_ID.Equals("2"))
                {
                    monitorPara[10] = int.Parse(monitorList[i].PARA_DOWN_LIMIT);
                    monitorPara[11] = int.Parse(monitorList[i].PARA_DOWN_ALERT);
                    monitorPara[12] = int.Parse(monitorList[i].PARA_UP_ALERT);
                    monitorPara[13] = int.Parse(monitorList[i].PARA_UP_LIMIT);
                }
                else if (monitorList[i].MONITOE_PARA_ID.Equals("3"))
                {
                    monitorPara[6] = int.Parse(monitorList[i].PARA_DOWN_LIMIT);
                    monitorPara[7] = int.Parse(monitorList[i].PARA_DOWN_ALERT);
                    monitorPara[8] = int.Parse(monitorList[i].PARA_UP_ALERT);
                    monitorPara[9] = int.Parse(monitorList[i].PARA_UP_LIMIT);
                }
                else if (monitorList[i].MONITOE_PARA_ID.Equals("4"))
                {
                    monitorPara[2] = int.Parse(monitorList[i].PARA_DOWN_LIMIT);
                    monitorPara[3] = int.Parse(monitorList[i].PARA_DOWN_ALERT);
                    monitorPara[4] = int.Parse(monitorList[i].PARA_UP_ALERT);
                    monitorPara[5] = int.Parse(monitorList[i].PARA_UP_LIMIT);
                }
            }
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
        private void numberParameter_ValueChanged_null(object sender, EventArgs e)
        {

        }

        private void numberParameter1_ValueChanged(object sender, EventArgs e)
        {
            switch(deviceTypeDisplayNow)
            {
                case 1:
                    treadmillList[operatedSec - 1].setTime((int)numberParameter1.Value);
                    cubeList[operatedSec - 1].Width = ((int)numberParameter1.Value / 60) * 5;

                    devicehelper.changeParaInList(deviceList, planId, operatedSec, 1, (int)numberParameter1.Value);

                    for (int i = operatedSec; i < cubeList.Count; i++) 
                    {
                        cubeList[i].Left = cubeList[i - 1].Left + (int)(0.75 * cubeList[i - 1].Width);
                    }

                    runMachPanel.Refresh();

                    break;

                case 3:
                    ellipticalList[operatedSec - 1].setDistance((int)numberParameter1.Value);
                    cubeList[operatedSec - 1].Width = (int)numberParameter1.Value / 2;

                    devicehelper.changeParaInList(deviceList, planId, operatedSec, 14, (int)numberParameter1.Value);

                    for (int i = operatedSec; i < cubeList.Count; i++)
                    {
                        cubeList[i].Left = cubeList[i - 1].Left + (int)(0.75 * cubeList[i - 1].Width);
                    }
                    runMachPanel.Refresh();

                    break;

                case 13:
                    uprightCycleList[operatedSec - 1].setDistance((int)numberParameter1.Value);
                    cubeList[operatedSec - 1].Width = (int)numberParameter1.Value / 2;

                    devicehelper.changeParaInList(deviceList, planId, operatedSec, 28, (int)numberParameter1.Value);

                    for (int i = operatedSec; i < cubeList.Count; i++)
                    {
                        cubeList[i].Left = cubeList[i - 1].Left + (int)(0.75 * cubeList[i - 1].Width);
                    }
                    runMachPanel.Refresh();

                    break;

                case 14:
                    recumbentCycleList[operatedSec - 1].setDistance((int)numberParameter1.Value);
                    cubeList[operatedSec - 1].Width = (int)numberParameter1.Value / 2;

                    devicehelper.changeParaInList(deviceList, planId, operatedSec, 7, (int)numberParameter1.Value);

                    for (int i = operatedSec; i < cubeList.Count; i++)
                    {
                        cubeList[i].Left = cubeList[i - 1].Left + (int)(0.75 * cubeList[i - 1].Width);
                    }
                    runMachPanel.Refresh();

                    break;


                case 6:
                    ecpList[operatedSec - 1].setTime((int)numberParameter1.Value);
                    cubeList[operatedSec - 1].Width = ((int)numberParameter1.Value / 60) * 10;

                    devicehelper.changeParaInList(deviceList, planId, operatedSec, 20, (int)numberParameter1.Value);

                    for (int i = operatedSec; i < cubeList.Count; i++)
                    {
                        cubeList[i].Left = cubeList[i - 1].Left + (int)(0.75 * cubeList[i - 1].Width);
                    }
                    runMachPanel.Refresh();


                    break;
            }
        }

        private void numberParameter2_ValueChanged(object sender, EventArgs e)
        {
            switch(deviceTypeDisplayNow)
            {
                case 1:
                    treadmillList[operatedSec - 1].setCurSpeed((int)numberParameter2.Value);
                    numberParameter3.Minimum = (int)numberParameter2.Value;
                    numberParameter4.Maximum = (int)numberParameter2.Value;
                    cubeList[operatedSec - 1].Height = 100 + (((int)numberParameter2.Value) / 100) * ((345 - 100) / (25 - 1));
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaInList(deviceList, planId, operatedSec, 4, (int)numberParameter2.Value);
                    runMachPanel.Refresh();
                    break;

                case 3:
                    ellipticalList[operatedSec - 1].setResistance((int)numberParameter2.Value);
                    numberParameter3.Minimum = (int)numberParameter2.Value;
                    numberParameter4.Maximum = (int)numberParameter2.Value;
                    cubeList[operatedSec - 1].Height = 100 + ((int)numberParameter2.Value) * (345 - 100) / (15 - 1);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaInList(deviceList, planId, operatedSec, 17, (int)numberParameter2.Value);
                    runMachPanel.Refresh();
                    break;

                case 13:
                    uprightCycleList[operatedSec - 1].setResistance((int)numberParameter2.Value);
                    numberParameter3.Minimum = (int)numberParameter2.Value;
                    numberParameter4.Maximum = (int)numberParameter2.Value;
                    cubeList[operatedSec - 1].Height = 100 + ((int)numberParameter2.Value) * (345 - 100) / (16 - 1);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaInList(deviceList, planId, operatedSec, 31, (int)numberParameter2.Value);
                    runMachPanel.Refresh();
                    break;

                case 14:
                    recumbentCycleList[operatedSec - 1].setResistance((int)numberParameter2.Value);
                    numberParameter3.Minimum = (int)numberParameter2.Value;
                    numberParameter4.Maximum = (int)numberParameter2.Value;
                    cubeList[operatedSec - 1].Height = 100 + ((int)numberParameter2.Value) * (345 - 100) / (15 - 1);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaInList(deviceList, planId, operatedSec, 10, (int)numberParameter2.Value);
                    runMachPanel.Refresh();
                    break;

                case 6:
                    ecpList[operatedSec - 1].setExPressure((int)numberParameter2.Value);
                    numberParameter3.Minimum = (int)numberParameter2.Value;
                    numberParameter4.Maximum = (int)numberParameter2.Value;
                    cubeList[operatedSec - 1].Height = 100 + ((int)numberParameter2.Value) * (345 - 100) / (70 - 1);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaInList(deviceList, planId, operatedSec, 23, (int)numberParameter2.Value);
                    runMachPanel.Refresh();
                    break;

            }
        }

        private void numberParameter3_ValueChanged(object sender, EventArgs e)
        {
            switch (deviceTypeDisplayNow)
            {
                case 1:
                    treadmillList[operatedSec - 1].setUpperSpeed((int)numberParameter3.Value);
                    numberParameter2.Maximum = (int)numberParameter3.Value;
                    cubeList[operatedSec - 1].MaxHeight = 100 + (((int)numberParameter3.Value) / 100) * ((345 - 100) / (25 - 1));
                    cubeList[operatedSec - 1].MaximumSize = new System.Drawing.Size(cubeList[operatedSec - 1].MaxWidth, cubeList[operatedSec - 1].MaxHeight);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaMaxValueInList(deviceList, planId, operatedSec, 4, (int)numberParameter3.Value);
                    break;

                case 3:
                    ellipticalList[operatedSec - 1].setUpperResistance((int)numberParameter3.Value);
                    numberParameter2.Maximum = (int)numberParameter3.Value;
                    cubeList[operatedSec - 1].MaxHeight = 100 + ((int)numberParameter3.Value) * (345 - 100) / (15 - 1);
                    cubeList[operatedSec - 1].MaximumSize = new System.Drawing.Size(cubeList[operatedSec - 1].MaxWidth, cubeList[operatedSec - 1].MaxHeight);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaMaxValueInList(deviceList, planId, operatedSec, 17, (int)numberParameter3.Value);
                    break;

                case 13:
                    uprightCycleList[operatedSec - 1].setUpperResistance((int)numberParameter3.Value);
                    numberParameter2.Maximum = (int)numberParameter3.Value;
                    cubeList[operatedSec - 1].MaxHeight = 100 + ((int)numberParameter3.Value) * (345 - 100) / (16 - 1);
                    cubeList[operatedSec - 1].MaximumSize = new System.Drawing.Size(cubeList[operatedSec - 1].MaxWidth, cubeList[operatedSec - 1].MaxHeight);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaMaxValueInList(deviceList, planId, operatedSec, 31, (int)numberParameter3.Value);
                    break;

                case 14:
                    recumbentCycleList[operatedSec - 1].setUpperResistance((int)numberParameter3.Value);
                    numberParameter2.Maximum = (int)numberParameter3.Value;
                    cubeList[operatedSec - 1].MaxHeight = 100 + ((int)numberParameter3.Value) * (345 - 100) / (15 - 1);
                    cubeList[operatedSec - 1].MaximumSize = new System.Drawing.Size(cubeList[operatedSec - 1].MaxWidth, cubeList[operatedSec - 1].MaxHeight);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaMaxValueInList(deviceList, planId, operatedSec, 10, (int)numberParameter3.Value);
                    break;

                case 6:
                    ecpList[operatedSec - 1].setUpperExPressure((int)numberParameter3.Value);
                    numberParameter2.Maximum = (int)numberParameter3.Value;
                    cubeList[operatedSec - 1].MaxHeight = 100 + ((int)numberParameter3.Value) * (345 - 100) / (70 - 1);
                    cubeList[operatedSec - 1].MaximumSize = new System.Drawing.Size(cubeList[operatedSec - 1].MaxWidth, cubeList[operatedSec - 1].MaxHeight);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaMaxValueInList(deviceList, planId, operatedSec, 23, (int)numberParameter3.Value);
                    break;
            }
        }

        private void numberParameter4_ValueChanged(object sender, EventArgs e)
        {
            switch (deviceTypeDisplayNow)
            {
                case 1:
                    treadmillList[operatedSec - 1].setLowerSpeed((int)numberParameter4.Value);
                    numberParameter2.Minimum = (int)numberParameter4.Value;
                    cubeList[operatedSec - 1].MinHeight = 100 + (((int)numberParameter4.Value) / 100) * ((345 - 100) / (25 - 1));
                    cubeList[operatedSec - 1].MinimumSize = new System.Drawing.Size(cubeList[operatedSec - 1].MinWidth, cubeList[operatedSec - 1].MinHeight);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaMinValueInList(deviceList, planId, operatedSec, 4, (int)numberParameter4.Value);
                    break;

                case 3:
                    ellipticalList[operatedSec - 1].setLowerResistance((int)numberParameter4.Value);
                    numberParameter2.Minimum = (int)numberParameter4.Value;
                    cubeList[operatedSec - 1].MinHeight = 100 + ((int)numberParameter4.Value) * (345 - 100) / (15 - 1);
                    cubeList[operatedSec - 1].MinimumSize = new System.Drawing.Size(cubeList[operatedSec - 1].MinWidth, cubeList[operatedSec - 1].MinHeight);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaMinValueInList(deviceList, planId, operatedSec, 17, (int)numberParameter4.Value);
                    break;

                case 13:
                    uprightCycleList[operatedSec - 1].setLowerResistance((int)numberParameter4.Value);
                    numberParameter2.Minimum = (int)numberParameter4.Value;
                    cubeList[operatedSec - 1].MinHeight = 100 + ((int)numberParameter4.Value) * (345 - 100) / (16 - 1);
                    cubeList[operatedSec - 1].MinimumSize = new System.Drawing.Size(cubeList[operatedSec - 1].MinWidth, cubeList[operatedSec - 1].MinHeight);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaMinValueInList(deviceList, planId, operatedSec, 31, (int)numberParameter4.Value);
                    break;

                case 14:
                    recumbentCycleList[operatedSec - 1].setLowerResistance((int)numberParameter4.Value);
                    numberParameter2.Minimum = (int)numberParameter4.Value;
                    cubeList[operatedSec - 1].MinHeight = 100 + ((int)numberParameter4.Value) * (345 - 100) / (15 - 1);
                    cubeList[operatedSec - 1].MinimumSize = new System.Drawing.Size(cubeList[operatedSec - 1].MinWidth, cubeList[operatedSec - 1].MinHeight);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaMinValueInList(deviceList, planId, operatedSec, 10, (int)numberParameter4.Value);
                    break;

                case 6:
                    ecpList[operatedSec - 1].setLowerExPressure((int)numberParameter4.Value);
                    numberParameter2.Minimum = (int)numberParameter4.Value;
                    cubeList[operatedSec - 1].MinHeight = 100 + ((int)numberParameter4.Value) * (345 - 100) / (70 - 1);
                    cubeList[operatedSec - 1].MinimumSize = new System.Drawing.Size(cubeList[operatedSec - 1].MinWidth, cubeList[operatedSec - 1].MinHeight);
                    cubeList[operatedSec - 1].Top = cubeList[operatedSec - 1].getBase() - cubeList[operatedSec - 1].Height;
                    devicehelper.changeParaMinValueInList(deviceList, planId, operatedSec, 23, (int)numberParameter4.Value);
                    break;
            }
        }

        private void numberParameter5_ValueChanged(object sender, EventArgs e)
        {
            switch(deviceTypeDisplayNow)
            {
                case 1:
                    treadmillList[operatedSec - 1].setSlope((int)numberParameter5.Value);
                    numberParameter6.Minimum = (int)numberParameter5.Value;
                    numberParameter7.Maximum = (int)numberParameter5.Value;
                    devicehelper.changeParaInList(deviceList, planId, operatedSec, 5, (int)numberParameter5.Value);

                    break;

                case 6:
                    ecpList[operatedSec - 1].setR2I((int)numberParameter5.Value);
                    numberParameter6.Minimum = (int)numberParameter5.Value;
                    numberParameter7.Maximum = (int)numberParameter5.Value;
                    devicehelper.changeParaInList(deviceList, planId, operatedSec, 21, (int)numberParameter5.Value);

                    break;
            }
        }

        private void numberParameter6_ValueChanged(object sender, EventArgs e)
        {
            switch(deviceTypeDisplayNow)
            {
                case 1:
                    treadmillList[operatedSec - 1].setUpperSlope((int)numberParameter6.Value);
                    numberParameter5.Maximum = (int)numberParameter6.Value;                  
                    devicehelper.changeParaMaxValueInList(deviceList, planId, operatedSec, 5, (int)numberParameter6.Value);

                    break;

                case 6:
                    ecpList[operatedSec - 1].setUpperR2I((int)numberParameter6.Value);
                    numberParameter5.Maximum = (int)numberParameter6.Value;
                    devicehelper.changeParaMaxValueInList(deviceList, planId, operatedSec, 21, (int)numberParameter6.Value);

                    break;
            }
        }

        private void numberParameter7_ValueChanged(object sender, EventArgs e)
        {
            switch(deviceTypeDisplayNow)
            {
                case 1:
                    treadmillList[operatedSec - 1].setLowerSlope((int)numberParameter7.Value);
                    numberParameter5.Minimum = (int)numberParameter7.Value;
                    devicehelper.changeParaMinValueInList(deviceList, planId, operatedSec, 5, (int)numberParameter7.Value);

                    break;

                case 6:
                    ecpList[operatedSec - 1].setLowerR2I((int)numberParameter7.Value);
                    numberParameter5.Minimum = (int)numberParameter7.Value;
                    devicehelper.changeParaMinValueInList(deviceList, planId, operatedSec, 21, (int)numberParameter7.Value);

                    break;
            }

        }

        private void numberParameter8_ValueChanged(object sender, EventArgs e)
        {
            switch(deviceTypeDisplayNow)
            {
                case 6:
                    ecpList[operatedSec - 1].setR2D((int)numberParameter8.Value);
                    numberParameter9.Minimum = (int)numberParameter8.Value;
                    numberParameter10.Maximum = (int)numberParameter8.Value;
                    devicehelper.changeParaInList(deviceList, planId, operatedSec, 22, (int)numberParameter8.Value);

                    break;
            }
        }

        private void numberParameter9_ValueChanged(object sender, EventArgs e)
        {
            switch (deviceTypeDisplayNow)
            {
                case 6:
                    ecpList[operatedSec - 1].setUpperR2D((int)numberParameter9.Value);
                    numberParameter8.Maximum = (int)numberParameter9.Value;
                    devicehelper.changeParaMaxValueInList(deviceList, planId, operatedSec, 22, (int)numberParameter9.Value);

                    break;
            }
        }

        private void numberParameter10_ValueChanged(object sender, EventArgs e)
        {
            switch (deviceTypeDisplayNow)
            {
                case 6:
                    ecpList[operatedSec - 1].setLowerR2D((int)numberParameter10.Value);
                    numberParameter8.Minimum = (int)numberParameter10.Value;
                    devicehelper.changeParaMinValueInList(deviceList, planId, operatedSec, 22, (int)numberParameter10.Value);

                    break;
            }
        }


        private void cubeMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            p.X = e.X;
            p.Y = e.Y;

            cube = (sender as CubeControl);
            txSectionNumber.Text = (cube.TabIndex + 1).ToString();
            operatedSec = cube.TabIndex + 1;


            switch(deviceTypeDisplayNow)
            {
                case 1:
                    numberParameter1.ValueChanged -= new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged -= new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged -= new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged -= new System.EventHandler(this.numberParameter4_ValueChanged);
                    numberParameter5.ValueChanged -= new System.EventHandler(this.numberParameter5_ValueChanged);
                    numberParameter6.ValueChanged -= new System.EventHandler(this.numberParameter6_ValueChanged);
                    numberParameter7.ValueChanged -= new System.EventHandler(this.numberParameter7_ValueChanged);

                    numberParameter1.Value = treadmillList[cube.TabIndex].getTime();

                    numberParameter2.Maximum = 2500;
                    numberParameter2.Minimum = 0;
                    numberParameter3.Maximum = 2500;
                    numberParameter3.Minimum = 0;
                    numberParameter4.Maximum = 2500;
                    numberParameter4.Minimum = 0;

                    numberParameter5.Maximum = 10;
                    numberParameter5.Minimum = 0;
                    numberParameter6.Maximum = 10;
                    numberParameter6.Minimum = 0;
                    numberParameter7.Maximum = 10;
                    numberParameter7.Minimum = 0;

                    numberParameter2.Value = treadmillList[cube.TabIndex].getCurSpeed();
                    numberParameter3.Value = treadmillList[cube.TabIndex].getUpperSpeed();
                    numberParameter4.Value = treadmillList[cube.TabIndex].getLowerSpeed();
                    numberParameter2.Maximum = treadmillList[cube.TabIndex].getUpperSpeed();
                    numberParameter2.Minimum = treadmillList[cube.TabIndex].getLowerSpeed();
                    numberParameter3.Maximum = 2500;
                    numberParameter3.Minimum = treadmillList[cube.TabIndex].getCurSpeed();
                    numberParameter4.Maximum = treadmillList[cube.TabIndex].getCurSpeed();
                    numberParameter4.Minimum = 0;

                    numberParameter5.Value = treadmillList[cube.TabIndex].getSlope();
                    numberParameter6.Value = treadmillList[cube.TabIndex].getUpperSlope();
                    numberParameter7.Value = treadmillList[cube.TabIndex].getLowerSlope();
                    numberParameter5.Maximum = treadmillList[cube.TabIndex].getUpperSlope();
                    numberParameter5.Minimum = treadmillList[cube.TabIndex].getLowerSlope();
                    numberParameter6.Maximum = 10;
                    numberParameter6.Minimum = treadmillList[cube.TabIndex].getSlope();
                    numberParameter7.Maximum = treadmillList[cube.TabIndex].getSlope();
                    numberParameter7.Minimum = 0;

                    numberParameter1.ValueChanged += new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged += new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged += new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged += new System.EventHandler(this.numberParameter4_ValueChanged);
                    numberParameter5.ValueChanged += new System.EventHandler(this.numberParameter5_ValueChanged);
                    numberParameter6.ValueChanged += new System.EventHandler(this.numberParameter6_ValueChanged);
                    numberParameter7.ValueChanged += new System.EventHandler(this.numberParameter7_ValueChanged);

                    break;

                case 3:
                    numberParameter1.ValueChanged -= new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged -= new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged -= new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged -= new System.EventHandler(this.numberParameter4_ValueChanged);

                    numberParameter1.Value = ellipticalList[cube.TabIndex].getDistance();

                    numberParameter2.Maximum = 15;
                    numberParameter2.Minimum = 1;
                    numberParameter3.Maximum = 15;
                    numberParameter3.Minimum = 1;
                    numberParameter4.Maximum = 15;
                    numberParameter4.Minimum = 1;

                    numberParameter2.Value = ellipticalList[cube.TabIndex].getResistance();
                    numberParameter3.Value = ellipticalList[cube.TabIndex].getUpperResistance();
                    numberParameter4.Value = ellipticalList[cube.TabIndex].getLowerResistance();
                    numberParameter2.Maximum = ellipticalList[cube.TabIndex].getUpperResistance();
                    numberParameter2.Minimum = ellipticalList[cube.TabIndex].getLowerResistance();
                    numberParameter3.Maximum = 15;
                    numberParameter3.Minimum = ellipticalList[cube.TabIndex].getResistance();
                    numberParameter4.Maximum = ellipticalList[cube.TabIndex].getResistance();
                    numberParameter4.Minimum = 1;

                    numberParameter1.ValueChanged += new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged += new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged += new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged += new System.EventHandler(this.numberParameter4_ValueChanged);

                    break;

                case 13:
                    numberParameter1.ValueChanged -= new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged -= new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged -= new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged -= new System.EventHandler(this.numberParameter4_ValueChanged);

                    numberParameter1.Value = uprightCycleList[cube.TabIndex].getDistance();

                    numberParameter2.Maximum = 16;
                    numberParameter2.Minimum = 1;
                    numberParameter3.Maximum = 16;
                    numberParameter3.Minimum = 1;
                    numberParameter4.Maximum = 16;
                    numberParameter4.Minimum = 1;

                    numberParameter2.Value = uprightCycleList[cube.TabIndex].getResistance();
                    numberParameter3.Value = uprightCycleList[cube.TabIndex].getUpperResistance();
                    numberParameter4.Value = uprightCycleList[cube.TabIndex].getLowerResistance();
                    numberParameter2.Maximum = uprightCycleList[cube.TabIndex].getUpperResistance();
                    numberParameter2.Minimum = uprightCycleList[cube.TabIndex].getLowerResistance();
                    numberParameter3.Maximum = 16;
                    numberParameter3.Minimum = uprightCycleList[cube.TabIndex].getResistance();
                    numberParameter4.Maximum = uprightCycleList[cube.TabIndex].getResistance();
                    numberParameter4.Minimum = 1;

                    numberParameter1.ValueChanged += new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged += new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged += new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged += new System.EventHandler(this.numberParameter4_ValueChanged);

                    break;

                case 14:
                    numberParameter1.ValueChanged -= new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged -= new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged -= new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged -= new System.EventHandler(this.numberParameter4_ValueChanged);

                    numberParameter1.Value = recumbentCycleList[cube.TabIndex].getDistance();

                    numberParameter2.Maximum = 15;
                    numberParameter2.Minimum = 1;
                    numberParameter3.Maximum = 15;
                    numberParameter3.Minimum = 1;
                    numberParameter4.Maximum = 15;
                    numberParameter4.Minimum = 1;

                    numberParameter2.Value = recumbentCycleList[cube.TabIndex].getResistance();
                    numberParameter3.Value = recumbentCycleList[cube.TabIndex].getUpperResistance();
                    numberParameter4.Value = recumbentCycleList[cube.TabIndex].getLowerResistance();
                    numberParameter2.Maximum = recumbentCycleList[cube.TabIndex].getUpperResistance();
                    numberParameter2.Minimum = recumbentCycleList[cube.TabIndex].getLowerResistance();
                    numberParameter3.Maximum = 15;
                    numberParameter3.Minimum = recumbentCycleList[cube.TabIndex].getResistance();
                    numberParameter4.Maximum = recumbentCycleList[cube.TabIndex].getResistance();
                    numberParameter4.Minimum = 1;

                    numberParameter1.ValueChanged += new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged += new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged += new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged += new System.EventHandler(this.numberParameter4_ValueChanged);

                    break;

                case 6:
                    numberParameter1.ValueChanged -= new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged -= new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged -= new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged -= new System.EventHandler(this.numberParameter4_ValueChanged);
                    numberParameter5.ValueChanged -= new System.EventHandler(this.numberParameter5_ValueChanged);
                    numberParameter6.ValueChanged -= new System.EventHandler(this.numberParameter6_ValueChanged);
                    numberParameter7.ValueChanged -= new System.EventHandler(this.numberParameter7_ValueChanged);
                    numberParameter8.ValueChanged -= new System.EventHandler(this.numberParameter8_ValueChanged);
                    numberParameter9.ValueChanged -= new System.EventHandler(this.numberParameter9_ValueChanged);
                    numberParameter10.ValueChanged -= new System.EventHandler(this.numberParameter10_ValueChanged);

                    numberParameter1.Value = ecpList[cube.TabIndex].getTime();

                    numberParameter2.Maximum = 70;
                    numberParameter2.Minimum = 1;
                    numberParameter3.Maximum = 70;
                    numberParameter3.Minimum = 1;
                    numberParameter4.Maximum = 70;
                    numberParameter4.Minimum = 1;

                    numberParameter5.Maximum = 500;
                    numberParameter5.Minimum = 1;
                    numberParameter6.Maximum = 500;
                    numberParameter6.Minimum = 1;
                    numberParameter7.Maximum = 500;
                    numberParameter7.Minimum = 1;

                    numberParameter8.Maximum = 500;
                    numberParameter8.Minimum = 1;
                    numberParameter9.Maximum = 500;
                    numberParameter9.Minimum = 1;
                    numberParameter10.Maximum = 500;
                    numberParameter10.Minimum = 1;

                    numberParameter2.Value = ecpList[cube.TabIndex].getExPressure();
                    numberParameter3.Value = ecpList[cube.TabIndex].getUpperExPressure();
                    numberParameter4.Value = ecpList[cube.TabIndex].getLowerExPressure();
                    numberParameter2.Maximum = ecpList[cube.TabIndex].getUpperExPressure();
                    numberParameter2.Minimum = ecpList[cube.TabIndex].getLowerExPressure();
                    numberParameter3.Maximum = 70;
                    numberParameter3.Minimum = ecpList[cube.TabIndex].getExPressure();
                    numberParameter4.Maximum = ecpList[cube.TabIndex].getExPressure();
                    numberParameter4.Minimum = 1;

                    numberParameter5.Value = ecpList[cube.TabIndex].getR2I();
                    numberParameter6.Value = ecpList[cube.TabIndex].getUpperR2I();
                    numberParameter7.Value = ecpList[cube.TabIndex].getLowerR2I();
                    numberParameter5.Maximum = ecpList[cube.TabIndex].getUpperR2I();
                    numberParameter5.Minimum = ecpList[cube.TabIndex].getLowerR2I();
                    numberParameter6.Maximum = 500;
                    numberParameter6.Minimum = ecpList[cube.TabIndex].getR2I();
                    numberParameter7.Maximum = ecpList[cube.TabIndex].getR2I();
                    numberParameter7.Minimum = 1;

                    numberParameter8.Value = ecpList[cube.TabIndex].getR2D();
                    numberParameter9.Value = ecpList[cube.TabIndex].getUpperR2D();
                    numberParameter10.Value = ecpList[cube.TabIndex].getLowerR2D();
                    numberParameter8.Maximum = ecpList[cube.TabIndex].getUpperR2D();
                    numberParameter8.Minimum = ecpList[cube.TabIndex].getLowerR2D();
                    numberParameter9.Maximum = 500;
                    numberParameter9.Minimum = ecpList[cube.TabIndex].getR2D();
                    numberParameter10.Maximum = ecpList[cube.TabIndex].getR2D();
                    numberParameter10.Minimum = 1;

                    numberParameter1.ValueChanged += new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged += new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged += new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged += new System.EventHandler(this.numberParameter4_ValueChanged);
                    numberParameter5.ValueChanged += new System.EventHandler(this.numberParameter5_ValueChanged);
                    numberParameter6.ValueChanged += new System.EventHandler(this.numberParameter6_ValueChanged);
                    numberParameter7.ValueChanged += new System.EventHandler(this.numberParameter7_ValueChanged);
                    numberParameter8.ValueChanged += new System.EventHandler(this.numberParameter8_ValueChanged);
                    numberParameter9.ValueChanged += new System.EventHandler(this.numberParameter9_ValueChanged);
                    numberParameter10.ValueChanged += new System.EventHandler(this.numberParameter10_ValueChanged);

                    break;
            }
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

                    switch(deviceTypeDisplayNow)
                    {
                        case 1:
                            if (cube.isMoveRight == true)
                                numberParameter1.Value = cube.Width * 12;
                            if (cube.isMoveTop == true)
                            {
                                if (cube.Height == cube.MaxHeight)
                                    numberParameter2.Value = numberParameter2.Maximum;
                                else if (cube.Height == cube.MinHeight)
                                    numberParameter2.Value = numberParameter2.Minimum;
                                else
                                    numberParameter2.Value = (cube.Height - 100) * 480 / 49;
                            }

                            break;

                        case 3:
                            if (cube.isMoveRight == true)
                                numberParameter1.Value = cube.Width * 2;
                            if (cube.isMoveTop == true) 
                            {
                                if (cube.Height == cube.MaxHeight)
                                    numberParameter2.Value = numberParameter2.Maximum;
                                else if (cube.Height == cube.MinHeight)
                                    numberParameter2.Value = numberParameter2.Minimum;
                                else
                                    numberParameter2.Value = (cube.Height - 100) * 14 / 245;
                            }

                            break;

                        case 13:
                            if (cube.isMoveRight == true)
                                numberParameter1.Value = cube.Width * 2;
                            if (cube.isMoveTop == true) 
                            {
                                if (cube.Height == cube.MaxHeight)
                                    numberParameter2.Value = numberParameter2.Maximum;
                                else if (cube.Height == cube.MinHeight)
                                    numberParameter2.Value = numberParameter2.Minimum;
                                else
                                    numberParameter2.Value = (cube.Height - 100) * 15 / 245;
                            }

                            break;

                        case 14:
                            if (cube.isMoveRight == true)
                                numberParameter1.Value = cube.Width * 2;
                            if (cube.isMoveTop == true) 
                            {
                                if (cube.Height == cube.MaxHeight)
                                    numberParameter2.Value = numberParameter2.Maximum;
                                else if (cube.Height == cube.MinHeight)
                                    numberParameter2.Value = numberParameter2.Minimum;
                                else
                                    numberParameter2.Value = (cube.Height - 100) * 14 / 245;
                            }

                            break;

                        case 6:
                            if (cube.isMoveRight == true)
                                numberParameter1.Value = cube.Width * 6;
                            if (cube.isMoveTop == true) 
                            {
                                if (cube.Height == cube.MaxHeight)
                                    numberParameter2.Value = numberParameter2.Maximum;
                                else if (cube.Height == cube.MinHeight)
                                    numberParameter2.Value = numberParameter2.Minimum;
                                else
                                    numberParameter2.Value = (cube.Height - 100) * 69 / 245;
                            }

                            break;

                    }
                }
            }
        }


        public void mouseHover(object sender, EventArgs e)
        {
            // pWidth=

            //血氧
            Console.WriteLine("$$$$$$$$$$$$$$$");
            if(sender==boLabel)
            {
                if(sc0==null)
                {
                    sc0 = new SecondCtrl(boLabel);
                    //boLabel.Parent.Refresh();
                    sc0.Visible = true;
                    boLabel.Parent.Controls.Add(sc0);
                    sc0.Refresh();
                }
                if (sc0 != null)
                {
                    sc0.MouseMove += new MouseEventHandler(MouseMove);
                }
            }
            ///心率
            
            if (sender == hrLabel[0])
            {
                if (sc1 == null)
                {
                    sc1 = new SecondCtrl(hrLabel[0]);
                }
                //hrLabel[0].Parent.Refresh();//刷新父容器，清除掉其他控件的边框
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
               // hrLabel[1].Parent.Refresh();//刷新父容器，清除掉其他控件的边框
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
            //舒张压
            if (sender == szyLabel[0])
            {
                if (sc3 == null)
                {
                    sc3 = new SecondCtrl(szyLabel[0]);
                }
               // szyLabel[0].Parent.Refresh();//刷新父容器，清除掉其他控件的边框
                szyLabel[0].BringToFront();
                // this.cCtrl.Visible = false;
                sc3.Visible = true;
                // sc.BackColor = Color.Red;
                szyLabel[0].Parent.Controls.Add(sc3);
                sc3.Refresh();
                ///o = new OperateControl(hrLabel[0]); 
                if (sc3 != null)
                {
                    sc3.MouseMove += new MouseEventHandler(MouseMove);
                    //   sc. += new MouseEventHandler(MouseDown);
                    //hrOpPanel.BackColor = Color.Black;
                }
            }
            else if (sender == szyLabel[1])
            {
                if (rsc5 == null)
                {
                    rsc5 = new RightSecondControl(szyLabel[1]);
                }
               // szyLabel[1].Parent.Refresh();//刷新父容器，清除掉其他控件的边框
                szyLabel[1].BringToFront();
                rsc5.Visible = true;
                szyLabel[1].Parent.Controls.Add(rsc5);
                rsc5.Refresh();
                if (rsc5 != null)
                {
                    rsc5.MouseMove += new MouseEventHandler(MouseMove);
                    //   sc. += new MouseEventHandler(MouseDown);
                    //hrOpPanel.BackColor = Color.Black;
                }
            }
            else if (sender == szyLabel[2])
            {
                //  hrLabel[1].BackColor = Color.Black;
                if (rsc6 == null)
                {
                    rsc6 = new RightSecondControl(szyLabel[2]);
                }
                //szyLabel[1].Parent.Refresh();//刷新父容器，清除掉其他控件的边框
                szyLabel[1].BringToFront();
                // this.cCtrl.Visible = false;
                rsc6.Visible = true;
                // rsc2.BackColor = Color.Red;
                szyLabel[2].Parent.Controls.Add(rsc6);
                rsc6.Refresh();
                ///o = new OperateControl(hrLabel[0]); 
                if (rsc6 != null)
                {
                    rsc6.MouseMove += new MouseEventHandler(MouseMove);

                }
            }
        }
        void MouseMove(object sender, MouseEventArgs e)
        {
            //血氧
            if(sender==sc0)
            {
                if(boLabel.Right+5>boOpPanel.Width)
                {
                    boLabel.Width = boOpPanel.Width - boLabel.Location.X - 5;
                }
                infLabel[0].Location = new Point(boLabel.Location.X - 5, boOpPanel.Location.Y + boOpPanel.Height + 2);
                //infLabel[0].Location = new Point(boLabel.Location.X + boLabel.Width, boOpPanel.Location.Y + boOpPanel.Height + 2);
                infLabel[0].Text =((int)((float)boLabel.Location.X / boOpPanel.Width*60)+60+1)+"";
                infLabel[1].Location = new Point(boLabel.Location.X + boLabel.Width-15, boOpPanel.Location.Y + boOpPanel.Height + 2);
                //infLabel[0].Location = new Point(boLabel.Location.X + boLabel.Width, boOpPanel.Location.Y + boOpPanel.Height + 2);
                infLabel[1].Text = ((int)((float)boLabel.Right*60 / boOpPanel.Width) + 60 + 1) + "";
                infLabel[1].Parent.Refresh();
            }




 
            //心率
                if (sender == sc1)
                {
                    if(hrLabel[2].Right+5>hrOpPanel.Width)
                    {
                        hrLabel[2].Location = new Point(hrOpPanel.Width-6-hrLabel[2].Width,2);
                        hrLabel[1].Location = new Point(hrLabel[2].Location.X - 1 - hrLabel[1].Width,2);
                        hrLabel[0].Width = hrLabel[1].Location.X - 1 - hrLabel[0].Location.X;
                    }
                    else {
                        hrLabel[1].Location = new Point(hrLabel[0].Location.X + hrLabel[0].Width + 2, 2);
                        hrLabel[2].Location = new Point(hrLabel[1].Location.X + hrLabel[1].Width + 2, 2);
                    }
                   
                    infLabel[2].Location = new Point(hrLabel[0].Location.X - 25, hrOpPanel.Location.Y + hrOpPanel.Height + 2);
                    infLabel[2].Text =(int)((float)hrLabel[0].Location.X * 130/ hrOpPanel.Width + 31)+"";
                    infLabel[3].Location = new Point(hrLabel[1].Location.X - 25, hrOpPanel.Location.Y - 15);
                    infLabel[3].Text = (int)((float)hrLabel[0].Right / hrOpPanel.Width * 130 + 31) + "";
                   // infLabel[4].Location = new Point(hrLabel[2].Location.X - 5, hrOpPanel.Location.Y + hrOpPanel.Height + 2);
                    infLabel[4].Text = (int)((float)hrLabel[2].Location.X / hrOpPanel.Width * 130 + 30) + "";
                    infLabel[4].Location = new Point(hrLabel[2].Location.X - 5, hrOpPanel.Location.Y + hrOpPanel.Height + 2);
                    infLabel[5].Location = new Point(hrLabel[2].Location.X + hrLabel[2].Width - 15, hrOpPanel.Location.Y - 15);
                    infLabel[5].Text = (int)((float)hrLabel[2].Right / hrOpPanel.Width * 130 + 30) + "";
                    if (infLabel[2].Left < 3)
                    {
                        infLabel[2].Left = 5;
                    }
                    infLabel[5].Refresh();
                    infLabel[3].Refresh();
                    infLabel[2].Refresh();
                    infLabel[4].Refresh();
                }
                else if (sender == rsc1)
                {
                    if (hrLabel[2].Right + 5 > hrOpPanel.Width)
                    {
                        hrLabel[2].Location = new Point(hrOpPanel.Width - 6 - hrLabel[2].Width, 2);
                        hrLabel[1].Width = hrLabel[2].Location.X - 1 - hrLabel[1].Location.X;
                    }
                    else
                    {
                        hrLabel[2].Location = new Point(hrLabel[1].Location.X + hrLabel[1].Width + 2, 2);
                    }
                    infLabel[5].Location = new Point(hrLabel[2].Location.X + hrLabel[2].Width - 15, hrOpPanel.Location.Y - 15);
                    infLabel[5].Text = (int)((float)hrLabel[2].Right / hrOpPanel.Width * 130 + 30) + "";
                    infLabel[5].Refresh();
                    infLabel[4].Location = new Point(hrLabel[2].Location.X - 5, hrOpPanel.Location.Y + hrOpPanel.Height + 2);
                    infLabel[4].Text = (int)((float)hrLabel[2].Location.X/hrOpPanel.Width*130+30) + "";
                    infLabel[4].Refresh();

                }else if(sender==rsc2)
                {
                    if(hrLabel[2].Right+5>hrOpPanel.Width)
                    {
                        hrLabel[2].Width = hrOpPanel.Width - 5 - hrLabel[2].Location.X;
                    }
                    infLabel[5].Location = new Point(hrLabel[2].Location.X + hrLabel[2].Width - 15, hrOpPanel.Location.Y - 15);
                    infLabel[5].Text = (int)((float)hrLabel[2].Right/ hrOpPanel.Width * 130 + 30) + "";
                    infLabel[5].Refresh();
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

                //收缩压
                if (sender == sc2)
                {
                    if (ssyLabel[2].Right + 5 > ssyOpPanel.Width)
                    {
                        ssyLabel[2].Location = new Point(ssyOpPanel.Width - 6 - ssyLabel[2].Width, 2);
                        ssyLabel[1].Location = new Point(ssyLabel[2].Location.X - 1 - ssyLabel[1].Width, 2);
                        ssyLabel[0].Width = ssyLabel[1].Location.X - 1 - ssyLabel[0].Location.X;
                    }
                    else
                    {
                        ssyLabel[1].Location = new Point(ssyLabel[0].Location.X + ssyLabel[0].Width + 2, 2);
                        ssyLabel[2].Location = new Point(ssyLabel[1].Location.X + ssyLabel[1].Width + 2, 2);
                    }
                    infLabel[6].Location = new Point(ssyLabel[0].Location.X - 25, ssyOpPanel.Height + ssyOpPanel.Location.Y + 2);
                    infLabel[6].Text = (int)((float)ssyLabel[0].Location.X/ssyOpPanel.Width*150+31) + "";
                    if(infLabel[6].Left<3)
                    {
                        infLabel[6].Left = 3;
                    }
                    infLabel[7].Text = (int)((float)ssyLabel[0].Right / ssyOpPanel.Width * 150 + 31) + "";
                    infLabel[7].Location = new Point(ssyLabel[1].Location.X - 25, ssyOpPanel.Location.Y - 15);
                    infLabel[7].Refresh();
                    infLabel[8].Text = (int)((float)ssyLabel[2].Location.X / ssyOpPanel.Width * 150 + 29) + "";
                    infLabel[8].Location = new Point(ssyLabel[2].Location.X - 25, ssyOpPanel.Height + ssyOpPanel.Location.Y + 2);
                    infLabel[8].Refresh();
                    infLabel[9].Text = (int)((float)ssyLabel[2].Right / ssyOpPanel.Width * 150 + 29) + "";
                    infLabel[9].Location = new Point(ssyLabel[2].Location.X + ssyLabel[2].Width -25, ssyOpPanel.Location.Y - 15);
                    infLabel[9].Refresh();
                    infLabel[6].Refresh();
                }
                else if (sender == rsc3)
                {
                    if (ssyLabel[2].Right + 5 > ssyOpPanel.Width)
                    {
                        ssyLabel[2].Location = new Point(ssyOpPanel.Width - 6 - ssyLabel[2].Width, 2);
                        ssyLabel[1].Width = ssyLabel[2].Location.X - 1 - ssyLabel[1].Location.X;
                    }
                    else
                    {
                        ssyLabel[2].Location = new Point(ssyLabel[1].Location.X + ssyLabel[1].Width + 2, 2);
                    }
                    infLabel[8].Text = (int)((float)ssyLabel[2].Location.X / ssyOpPanel.Width * 150 + 29) + "";
                    infLabel[8].Location = new Point(ssyLabel[2].Location.X - 25, ssyOpPanel.Height + ssyOpPanel.Location.Y + 2);
                    infLabel[8].Refresh();
                    infLabel[9].Text = (int)((float)ssyLabel[2].Right / ssyOpPanel.Width * 150 + 29) + "";
                    infLabel[9].Location = new Point(ssyLabel[2].Location.X + ssyLabel[2].Width - 25, ssyOpPanel.Location.Y - 15);
                    infLabel[9].Refresh();
                }
                else if (sender == rsc4)
                {
                    if (ssyLabel[2].Right + 5 > ssyOpPanel.Width)
                    {
                        ssyLabel[2].Width = ssyOpPanel.Width - 5 - ssyLabel[2].Location.X;
                    }
                    infLabel[9].Text = (int)((float)ssyLabel[2].Right / ssyOpPanel.Width * 150 + 29) + "";
                    infLabel[9].Location = new Point(ssyLabel[2].Location.X + ssyLabel[2].Width - 25, ssyOpPanel.Location.Y - 15);
                    infLabel[9].Refresh();
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
               
                //舒张压
                if (sender == sc3)
                {
                    if (szyLabel[2].Right + 5 > ssyOpPanel.Width)
                    {
                        szyLabel[2].Location = new Point(szyOpPanel.Width - 6 - szyLabel[2].Width, 2);
                        szyLabel[1].Location = new Point(szyLabel[2].Location.X - 1 - szyLabel[1].Width, 2);
                        szyLabel[0].Width = szyLabel[1].Location.X - 1 - szyLabel[0].Location.X;
                    }
                    else
                    {
                        szyLabel[1].Location = new Point(szyLabel[0].Location.X + szyLabel[0].Width + 2, 2);
                        szyLabel[2].Location = new Point(szyLabel[1].Location.X + szyLabel[1].Width + 2, 2);
                    }
                    infLabel[10].Location = new Point(szyLabel[0].Location.X - 5, szyOpPanel.Height + szyOpPanel.Location.Y + 2);
                    infLabel[10].Text = (int)((float)szyLabel[0].Left/szyOpPanel.Width*100+30)+"";
                    if(infLabel[10].Left<3)
                    {
                        infLabel[10].Left = 3;
                    }
                    infLabel[10].Refresh();
                    infLabel[11].Location = new Point(szyLabel[1].Location.X - 5, szyOpPanel.Location.Y - 15);
                    infLabel[11].Text = (int)((float)szyLabel[0].Right / szyOpPanel.Width * 100 + 32) + "";
                    infLabel[11].Refresh();
                    infLabel[12].Text = (int)((float)szyLabel[2].Left/szyOpPanel.Width*100+30)+"";
                    infLabel[12].Location = new Point(szyLabel[2].Location.X - 15, szyOpPanel.Height + szyOpPanel.Location.Y + 2);
                    infLabel[12].Refresh();
                    infLabel[13].Text = (int)((float)szyLabel[2].Right / szyOpPanel.Width * 100 + 31) + "";
                    infLabel[13].Location = new Point(szyLabel[2].Location.X + szyLabel[2].Width - 25, szyOpPanel.Location.Y - 15);
                    infLabel[13].Refresh();


                }
                else if (sender == rsc5)
                {
                    if (szyLabel[2].Right + 5 > szyOpPanel.Width)
                    {
                        szyLabel[2].Location = new Point(szyOpPanel.Width - 6 - szyLabel[2].Width, 2);
                        szyLabel[1].Width = szyLabel[2].Location.X - 1 - szyLabel[1].Location.X;
                    }
                    else
                    {
                        szyLabel[2].Location = new Point(szyLabel[1].Location.X + szyLabel[1].Width + 2, 2);
                    }
                    infLabel[12].Text = (int)((float)szyLabel[2].Left / szyOpPanel.Width * 100 + 30) + "";
                    infLabel[12].Location = new Point(szyLabel[2].Location.X - 15, szyOpPanel.Height + szyOpPanel.Location.Y + 2);
                    infLabel[12].Refresh();
                    infLabel[13].Text = (int)((float)szyLabel[2].Right / szyOpPanel.Width * 100 + 31) + "";
                    infLabel[13].Location = new Point(szyLabel[2].Location.X + szyLabel[2].Width - 25, szyOpPanel.Location.Y - 15);
                    infLabel[13].Refresh();
                }
                else if (sender == rsc6)
                {
                    if (szyLabel[2].Right + 5 > szyOpPanel.Width)
                    {
                        szyLabel[2].Width = szyOpPanel.Width - 5 - szyLabel[2].Location.X;
                    }
                    infLabel[13].Text = (int)((float)szyLabel[2].Right / szyOpPanel.Width * 100 + 31) + "";
                    infLabel[13].Location = new Point(szyLabel[2].Location.X + szyLabel[2].Width - 25, szyOpPanel.Location.Y - 15);
                    infLabel[13].Refresh();
                }

                if (sender == sc3)
                {
                    sc3.createBounds();
                    if (rsc5 != null)
                    {
                        rsc5.createBounds();
                    }
                }
                else if (sender == rsc5)
                {
                    rsc5.createBounds();
                    if (rsc6 != null)
                        rsc6.createBounds();
                }
                else if (sender == rsc6)
                {
                    rsc6.createBounds();
                }
                this.szyLabel[1].Refresh();
                this.szyLabel[0].Refresh();
                this.szyLabel[2].Refresh();
            /*    System.Console.WriteLine("hrOpanelWidth"+hrOpPanel.Width + "/ssyOpPanel" + ssyOpPanel.Width + "/szyOpPanel" + szyOpPanel.Width);
                System.Console.WriteLine("hrLabel[0]" +( hrLabel[0].Width + hrLabel[0].Location.X));
                System.Console.WriteLine("hrLabel[1]" + hrLabel[1].Left);
                System.Console.WriteLine("hrLabel[1]" +( hrLabel[1].Left+hrLabel[1].Width));
                System.Console.WriteLine("hrLabel[2]" + hrLabel[2].Left);
                System.Console.WriteLine("hrLabel[2]" + hrLabel[2].Left+hrLabel[2].Width);
             * **/
        }

    }
}
