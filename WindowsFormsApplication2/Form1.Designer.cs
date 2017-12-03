using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace WindowsFormsApplication2
{
    partial class Form1
    {
        private List<CubeControl> cubeList;
        private int move = XYLinesFactory.getMove();
        private int cubeNum = 4;
     //   private Panel DrawPan = new Panel();




        /// <summary>
        /// 必需的设计器变量。
        /// //创建刷新县线程
        //Thread t;
        /// </summary>
        int lpWidth = 100;
        int lpHeight = 100;
        SecondCtrl sc1;
        RightSecondControl rsc1,rsc2;
        SecondCtrl sc2;
        RightSecondControl rsc3, rsc4;
        SecondCtrl sc3;
        RightSecondControl rsc5, rsc6;
        private System.ComponentModel.IContainer components = null;
        //获取屏幕分辨路
        OperateControl o;
        int width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        int height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        int labelWidth = 100;
        int labelHeight = 100;
        //顶部panel
        Panel topPanel;
        //信息panel
        Panel infoPanel;
        Label doctorInfoLabel, patientInfoLabel, adviceIsExeLabel, exeTimeLabel;
        string doc=null;
        string pat=null;
        string isExe=null;
        string exeTime=null;

        RadioButton isStrictExe;

        Button saveButton;
        //绘画panel
        DrawPanel runMachPanel, ovalMachPanel, lieBycPanel, stBycPanel;
        //4个Image
        System.Drawing.Image runningMach_Image = System.Drawing.Image.FromFile("runningMach.png");
        System.Drawing.Image ovalMach_Image = System.Drawing.Image.FromFile("ovalMach.png");
       // System.Drawing.Image runningMach_Image = System.Drawing.Image.FromFile("runningMach.png");
       // System.Drawing.Image ovalMach_Image = System.Drawing.Image.FromFile("ovalMach.png");


        Panel boPanel;
        UserPanel boOpPanel;

        Label boLabel, boImageLabel;
        Panel showPanel;
        Panel hrPanel;
        UserPanel hrOpPanel;

        Label []hrLabel=new Label[3];
        Label hrImageLabel;

        Panel ssyPanel;
        UserPanel ssyOpPanel;
        Label[] ssyLabel = new Label[3];
        Label ssyImageLabel;

        Panel szyPanel;
        UserPanel szyOpPanel;

        Label[] szyLabel = new Label[3];
        Label szyImageLabel;

        //4个矢量图
        Image boImage = System.Drawing.Image.FromFile("bo.png");
        Image hrImage = System.Drawing.Image.FromFile("hr.png");
        Image ssyImage = System.Drawing.Image.FromFile("ssy.png");
        Image szyImage = System.Drawing.Image.FromFile("szy.png");


        Panel labelPanel;





        //选择的label
        System.Windows.Forms.Label label_runMach, label_ovalMach, label_lieByc, label_stByc, testLabel;
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        public void  reFresh()
        {

        }
        private void InitializeComponent()
        {
            //测试赋值
            doc = "医生1";
            pat = "病人1";
            isExe = "未执行";
            exeTime = "****-**-**";

            //font
            Helper helper = new Helper();

           

            infoPanel = new Panel();
            infoPanel.Size = new System.Drawing.Size(width,30);
            infoPanel.Location = new Point(0,0);
            infoPanel.BackColor = Color.White;
            infoPanel.BorderStyle = BorderStyle.FixedSingle;
           // infoPanel.BackColor = helper.createColor(196,203,211);
            infoPanel.BackColor = Color.Gray;


            topPanel = new Panel();
            topPanel.Size = new System.Drawing.Size(width, height/4);
            topPanel.Location = new Point(0, infoPanel.Height);
            topPanel.BorderStyle = BorderStyle.FixedSingle;
            doctorInfoLabel = new Label();
            doctorInfoLabel.Size = new System.Drawing.Size(width/6-1,infoPanel.Height);
            doctorInfoLabel.Location = new Point(0,0);
            doctorInfoLabel.Font = helper.createFont1();
            doctorInfoLabel.Text = "医生:" + doc;
            doctorInfoLabel.BorderStyle = BorderStyle.FixedSingle;
          //  doctorInfoLabel.TextAlign = ContentAlignment.TopLeft;
            infoPanel.Controls.Add(doctorInfoLabel);

            patientInfoLabel = new Label();
            patientInfoLabel.Size = new System.Drawing.Size(width / 6 - 1, infoPanel.Height - 1);
            patientInfoLabel.Location = new Point(width / 6, 0);
            patientInfoLabel.Font = helper.createFont1();
            patientInfoLabel.Text = "病人:" + pat;
            patientInfoLabel.BorderStyle = BorderStyle.FixedSingle;
           // patientInfoLabel.TextAlign = ContentAlignment.TopRight;
            infoPanel.Controls.Add(patientInfoLabel);


            adviceIsExeLabel = new Label();
            adviceIsExeLabel.Font = helper.createFont1();
            adviceIsExeLabel.Size = new System.Drawing.Size(width / 6 -1, infoPanel.Height - 1);
            adviceIsExeLabel.Location = new Point(width / 6*2, 0);
            adviceIsExeLabel.Text = "医嘱状态:" + isExe;
            adviceIsExeLabel.BorderStyle = BorderStyle.FixedSingle;
           // adviceIsExeLabel.TextAlign = ContentAlignment.BottomLeft;
            infoPanel.Controls.Add(adviceIsExeLabel);

            exeTimeLabel = new Label();
            exeTimeLabel.Font = helper.createFont1();
            exeTimeLabel.Size = new System.Drawing.Size(width / 6 - 1, infoPanel.Height - 1);
            exeTimeLabel.Location = new Point(width / 6*3,0);
            exeTimeLabel.Text = "执行时间:" + exeTime;
            exeTimeLabel.BorderStyle = BorderStyle.FixedSingle; ;
           // exeTimeLabel.TextAlign = ContentAlignment.BottomLeft;
            infoPanel.Controls.Add(exeTimeLabel);

            isStrictExe = new RadioButton();
            isStrictExe.Text = "严格执行";
            isStrictExe.Font = helper.createFont1();
            isStrictExe.Size = new System.Drawing.Size(width / 6 - 1, infoPanel.Height - 1);
            isStrictExe.Location = new Point(width / 6*4,0);
            //isStrictExe.BorderStyle = BorderStyle.FixedSingle;
            //isStrictExe.TextAlign = ContentAlignment.TopCenter;
            infoPanel.Controls.Add(isStrictExe);

            saveButton = new Button();
            saveButton.Text = "完成修改";
            saveButton.Font = helper.createFont2();
            saveButton.Size = new System.Drawing.Size(width / 6 - 1, infoPanel.Height - 1);
            saveButton.Location = new Point(width / 6*5,0);
            saveButton.FlatAppearance.BorderColor = Color.Gray;
            saveButton.FlatAppearance.MouseOverBackColor = Color.Orange;
            saveButton.MouseClick += new MouseEventHandler(saveButton_MouseClick);
            this.saveButton.FlatStyle = FlatStyle.Flat;
            infoPanel.Controls.Add(saveButton);
            
            
            
            
            //*******************////////////
            //血氧
            boPanel = new Panel();
            boPanel.Location = new Point(0,10);
            boPanel.Size = new System.Drawing.Size(topPanel.Width/4 - 5, topPanel.Height);

            boImageLabel = new Label();
            boImageLabel.Image = boImage;
            boImageLabel.Location = new Point(0, 0);
            boImageLabel.Size = new System.Drawing.Size(boPanel.Width,boPanel.Height/2-10);


            boOpPanel = new UserPanel();
            boOpPanel.Location = new Point(0,boImageLabel.Height+27);
            boOpPanel.Size = new System.Drawing.Size(boPanel.Width,35);
            boOpPanel.BackColor = Color.White;
            boLabel = new Label();
            boLabel.Size = new System.Drawing.Size(50,boOpPanel.Height);
            boLabel.Location = new Point(50,0);
            boLabel.BackColor = helper.createColor(114, 149, 182);
            new OperateControl(boLabel);
           // boLabel.Text = "ssssssssssssssssssssssss";
            boOpPanel.Controls.Add(boLabel);

            boPanel.Controls.Add(boImageLabel);
            boPanel.Controls.Add(boOpPanel);
            //心率
            //心率
            hrPanel = new Panel();
            hrPanel.Location = new Point(boPanel.Width + boPanel.Location.X + 5, 10);
            hrPanel.Size = new System.Drawing.Size(topPanel.Width/4 - 5, topPanel.Height);

            hrImageLabel = new Label();
            hrImageLabel.Image = hrImage;
            hrImageLabel.Location = new Point(0, 0);
            hrImageLabel.Size = new System.Drawing.Size(hrPanel.Width, hrPanel.Height / 2 - 10);


            hrOpPanel = new UserPanel();
            hrOpPanel.Location = new Point(0, hrImageLabel.Height + 27);
            hrOpPanel.Size = new System.Drawing.Size(hrPanel.Width, 35);
            hrOpPanel.BackColor = Color.White;
            hrLabel[0] = new Label();
            hrLabel[0].Size = new System.Drawing.Size(50, hrOpPanel.Height-4);
            hrLabel[0].Location = new Point(50, 2);
            hrLabel[0].BackColor = Color.Red;
           // hrLabel[0].MouseClick += new MouseEventHandler(mouseClick);
            hrLabel[1] = new Label();
            hrLabel[1].Size = new System.Drawing.Size(50, hrOpPanel.Height-4);
            hrLabel[1].Location = new Point(hrLabel[0].Location.X+hrLabel[0].Width+2, 2);
            hrLabel[1].BackColor = helper.createColor(114, 149, 182);
           // hrLabel[1].MouseClick += new MouseEventHandler(mouseClick);


            hrLabel[2] = new Label();
            hrLabel[2].Size = new System.Drawing.Size(50, hrOpPanel.Height-4);
            hrLabel[2].Location = new Point(hrLabel[1].Location.X+hrLabel[1].Width+2, 2);

            hrLabel[2].BackColor = Color.Red;
            hrLabel[2].MouseEnter += new EventHandler(mouseHover);
            hrLabel[1].MouseEnter += new EventHandler(mouseHover);
            hrLabel[0].MouseEnter += new EventHandler(mouseHover);

            // boLabel.Text = "ssssssssssssssssssssssss";
            hrOpPanel.Controls.Add(hrLabel[0]);
            hrOpPanel.Controls.Add(hrLabel[1]);
            hrOpPanel.Controls.Add(hrLabel[2]);
            hrPanel.Controls.Add(hrImageLabel);
            hrPanel.Controls.Add(hrOpPanel);
          //  hrOpPanel.MouseClick += new MouseEventHandler(re);
          //  hrLabel[1].MouseMove += new MouseEventHandler(mouseMove);
           
            
            
            //收缩压

            ssyPanel = new Panel();
            ssyPanel.Location = new Point(hrPanel.Width + hrPanel.Location.X + 5, 10);
            ssyPanel.Size = new System.Drawing.Size(topPanel.Width/4 - 5, topPanel.Height);

            ssyImageLabel = new Label();
            ssyImageLabel.Image = ssyImage;
            ssyImageLabel.Location = new Point(0, 0);
            ssyImageLabel.Size = new System.Drawing.Size(ssyPanel.Width, ssyPanel.Height / 2 - 10);


            ssyOpPanel = new UserPanel();
            ssyOpPanel.Location = new Point(0, ssyImageLabel.Height + 27);
            ssyOpPanel.Size = new System.Drawing.Size(ssyPanel.Width, 35);
            ssyOpPanel.BackColor = Color.White;
            ssyLabel[0] = new Label();
            ssyLabel[0].Size = new System.Drawing.Size(50, ssyOpPanel.Height - 4);
            ssyLabel[0].Location = new Point(50, 2);
            ssyLabel[0].BackColor = Color.Red;
           // ssyLabel[0].MouseClick += new MouseEventHandler(mouseClick);
            ssyLabel[1] = new Label();
            ssyLabel[1].Size = new System.Drawing.Size(50, ssyOpPanel.Height - 4);
            ssyLabel[1].Location = new Point(ssyLabel[0].Location.X + ssyLabel[0].Width + 2, 2);
            ssyLabel[1].BackColor = helper.createColor(114, 149, 182);
            // hrLabel[1].MouseClick += new MouseEventHandler(mouseClick);


            ssyLabel[2] = new Label();
            ssyLabel[2].Size = new System.Drawing.Size(50, ssyOpPanel.Height - 4);
            ssyLabel[2].Location = new Point(ssyLabel[1].Location.X + ssyLabel[1].Width + 2, 2);

            ssyLabel[2].BackColor = Color.Red;
            ssyLabel[2].MouseEnter += new EventHandler(mouseHover);
            ssyLabel[1].MouseEnter += new EventHandler(mouseHover);
            ssyLabel[0].MouseEnter += new EventHandler(mouseHover);

            // boLabel.Text = "ssssssssssssssssssssssss";
            ssyOpPanel.Controls.Add(ssyLabel[0]);
            ssyOpPanel.Controls.Add(ssyLabel[1]);
            ssyOpPanel.Controls.Add(ssyLabel[2]);
            ssyPanel.Controls.Add(ssyImageLabel);
            ssyPanel.Controls.Add(ssyOpPanel);
            


            ///舒张压
            ///
            szyPanel = new Panel();
            szyPanel.Location = new Point(ssyPanel.Width + ssyPanel.Location.X + 5, 10);
            szyPanel.Size = new System.Drawing.Size(topPanel.Width / 4 - 20, topPanel.Height);

            szyImageLabel = new Label();
            szyImageLabel.Image = szyImage;
            szyImageLabel.Location = new Point(0, 0);
            szyImageLabel.Size = new System.Drawing.Size(szyPanel.Width, szyPanel.Height / 2 - 10);


            szyOpPanel = new UserPanel();
            szyOpPanel.Location = new Point(0, szyImageLabel.Height + 27);
            szyOpPanel.Size = new System.Drawing.Size(szyPanel.Width, 35);
            szyOpPanel.BackColor = Color.White;
            szyLabel[0] = new Label();
            szyLabel[0].Size = new System.Drawing.Size(50, szyOpPanel.Height - 4);
            szyLabel[0].Location = new Point(50, 2);
            szyLabel[0].BackColor = Color.Red;
            //szyLabel[0].MouseClick += new MouseEventHandler(mouseClick);
            szyLabel[1] = new Label();
            szyLabel[1].Size = new System.Drawing.Size(50, szyOpPanel.Height - 4);
            szyLabel[1].Location = new Point(szyLabel[0].Location.X + szyLabel[0].Width + 2, 2);
            szyLabel[1].BackColor = helper.createColor(114, 149, 182);
            // hrLabel[1].MouseClick += new MouseEventHandler(mouseClick);


            szyLabel[2] = new Label();
            szyLabel[2].Size = new System.Drawing.Size(50, szyOpPanel.Height - 4);
            szyLabel[2].Location = new Point(szyLabel[1].Location.X + szyLabel[1].Width + 2, 2);

            szyLabel[2].BackColor = Color.Red;
            szyLabel[2].MouseEnter += new EventHandler(mouseHover);
            szyLabel[1].MouseEnter += new EventHandler(mouseHover);
            szyLabel[0].MouseEnter += new EventHandler(mouseHover);

            // boLabel.Text = "ssssssssssssssssssssssss";
            szyOpPanel.Controls.Add(szyLabel[0]);
            szyOpPanel.Controls.Add(szyLabel[1]);
            szyOpPanel.Controls.Add(szyLabel[2]);
            szyPanel.Controls.Add(szyImageLabel);
            szyPanel.Controls.Add(szyOpPanel);

            topPanel.Controls.Add(szyPanel);
            topPanel.Controls.Add(ssyPanel);
            topPanel.Controls.Add(hrPanel);
            topPanel.Controls.Add(boPanel);


            labelPanel = new Panel();
            labelPanel.Size = new Size(width,height/6);
            labelPanel.Location = new Point(0,topPanel.Location.Y+topPanel.Height);
            //labelPanel.BackColor = Color.Pink;
            labelPanel.BorderStyle = BorderStyle.FixedSingle;

            //this.Controls.Add(label_runMach);
           // this.Controls.Add(label_lieByc);
            //this.Controls.Add(label_ovalMach);
           // this.Controls.Add(label_stByc);



            this.Controls.Add(labelPanel);
            this.Controls.Add(infoPanel);
            this.Controls.Add(topPanel);


            

            //跑步机label
            label_runMach = new System.Windows.Forms.Label();
          //  label_runMach.Text = "跑步机";
            label_runMach.Location = new System.Drawing.Point(20, 10);
            label_runMach.Size = new System.Drawing.Size(lpWidth, lpWidth);
            label_runMach.Image = runningMach_Image;
            label_runMach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //runningMach_Image.Width = label_runMach.Width;

            labelPanel.Controls.Add(label_runMach);
            //椭圆机
            label_ovalMach = new System.Windows.Forms.Label();
           // label_ovalMach.Text = "椭圆机";
            label_ovalMach.Location = new System.Drawing.Point(label_runMach.Location.X + label_runMach.Width + 60, label_runMach.Location.Y);
            label_ovalMach.Size = new System.Drawing.Size(lpWidth, lpWidth);
            label_ovalMach.Image = ovalMach_Image;
            label_ovalMach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            labelPanel.Controls.Add(label_ovalMach);
            //立式健身车
            label_stByc = new System.Windows.Forms.Label();
          //  label_stByc.Text = "立式健身车";
            label_stByc.Location = new System.Drawing.Point(label_ovalMach.Location.X + label_ovalMach.Width +60, label_ovalMach.Location.Y);
            label_stByc.Size = new System.Drawing.Size(lpWidth, lpHeight);
            label_stByc.Image = ovalMach_Image;
            label_stByc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            labelPanel.Controls.Add(label_stByc);
         
            //卧式健身车
            label_lieByc = new System.Windows.Forms.Label();
            label_lieByc.Text = "立式健身车";
            label_lieByc.Location = new System.Drawing.Point(label_stByc.Location.X + label_stByc.Width+40, label_stByc.Location.Y);
            label_lieByc.Size = new System.Drawing.Size(lpWidth,lpHeight);
            label_lieByc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label_lieByc.Image = ovalMach_Image;
            labelPanel.Controls.Add(label_lieByc);


            runMachPanel = new DrawPanel();
            runMachPanel.Location = new Point(0,labelPanel.Location.Y+labelPanel.Height);
            runMachPanel.Size = new Size(width,height-labelPanel.Location.Y-labelPanel.Height-20);
            runMachPanel.BackColor = Color.White;
           // runMachPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPan_Paint);
                        
         //   runMachPanel.SuspendLayout();

            //绘画panel
            /*
             *
             * 
             * 绘画
             * 
             **/
            SQLHelper sqlHelper = new SQLHelper(307);
            List<monitorInfo> monitorList = sqlHelper.sqlReadMonitor();
            List<deviceInfo> deviceList = sqlHelper.sqlReaderDevice();
            List<ExecuteOrder> orderList = new List<ExecuteOrder>();
            orderList = sqlHelper.sqlReaderOrder();
            int planId = orderList[2].EXERCISE_PLAN_ID;

            /*
            for (int i = 0; i < orderList.Count;i++ )
            {
                System.Console.WriteLine(orderList[i]);
            }
            */
                /*
                for (int i = 0; i < deviceList.Count;i++ )
                {
                    System.Console.Write(deviceList[i].EXERCISE_PLAN_ID + " ");
                    System.Console.Write(deviceList[i].DEVICE_TYPE_ID + " ");
                    System.Console.Write(deviceList[i].SECTION_ORDER + " ");
                    System.Console.Write(deviceList[i].PARAMETER_ID + " ");
                    System.Console.Write(deviceList[i].VALUE_IN_SECTION + " ");
                    System.Console.Write(deviceList[i].MAX_VALUE + " ");
                    System.Console.Write(deviceList[i].MIN_VALUE + " ");
                    System.Console.WriteLine(deviceList[i].SECTION_NUM + " ");
                }

                
                    for (int i = 0; i < monitorList.Count;i++)
                    {
                        System.Console.Write(monitorList[i].DOCTOR_ADVICE_ID + " ");
                        System.Console.Write(monitorList[i].MONITOR_TYPE_ID + " ");
                        System.Console.Write(monitorList[i].MONITOE_PARA_ID + " ");
                        if (monitorList[i].PARA_UP_LIMIT.Equals(""))
                        {
                            System.Console.Write("NULL ");
                        }
                        else System.Console.Write(monitorList[i].PARA_UP_LIMIT + " ");
                        if (monitorList[i].PARA_UP_ALERT.Equals(""))
                        {
                            System.Console.Write("NULL ");
                        }
                        else System.Console.Write(monitorList[i].PARA_UP_ALERT + " ");
                        System.Console.Write(monitorList[i].PARA_DOWN_LIMIT + " ");
                        System.Console.WriteLine(monitorList[i].PARA_DOWN_ALERT + " ");
                    }
                
                */

            deviceHelper devicehelper = new deviceHelper();
            devicehelper.setCubeNum(deviceList, planId);
            cubeNum = devicehelper.getCubeNum();
            System.Console.WriteLine("cubeNum = " + cubeNum);

            //跑步机
            if (devicehelper.getDeviceType(deviceList, planId) == 1)
            {
                List<Treadmill> treadmillList = devicehelper.setTreadmillParameter(deviceList, planId);

                cubeList = new List<CubeControl>();

                for (int i = 0; i < cubeNum; i++)
                {
                    CubeControl cube = new CubeControl(100, 100);
                    int time = treadmillList[i].getTime();
                    int curSpeed = treadmillList[i].getCurSpeed();
                    int upperSpeed = treadmillList[i].getUpperSpeed();
                    int lowerSpeed = treadmillList[i].getLowerSpeed();
                    cube.setTreadmillWidthHeight(time, curSpeed, upperSpeed, lowerSpeed);
                    cubeList.Add(cube);
                }

                CubeHelper cubeHelper = new CubeHelper(cubeList);
                cubeList = cubeHelper.getList();

                for (int i = cubeNum - 1; i >= 0; i--)
                {
                    runMachPanel.Controls.Add(cubeList[i]);
                    cubeList[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.cubeMouseDown);
                    cubeList[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.cubeMouseMove);
                }


                for (int i = 0; i < treadmillList.Count; i++)
                {
                    System.Console.WriteLine("跑步机：");
                    System.Console.Write("时间：" + treadmillList[i].getTime() + " ");
                    System.Console.Write("速度：" + treadmillList[i].getCurSpeed() + " ");
                    System.Console.Write("速度上限：" + treadmillList[i].getUpperSpeed() + " ");
                    System.Console.Write("速度下限：" + treadmillList[i].getLowerSpeed() + " ");
                    System.Console.Write("坡度：" + treadmillList[i].getSlope() + " ");
                    System.Console.Write("坡度上限：" + treadmillList[i].getUpperSlope() + " ");
                    System.Console.WriteLine("坡度下限：" + treadmillList[i].getLowerSlope() + " ");
                }
            }

            //椭圆机
            else if (devicehelper.getDeviceType(deviceList, planId) == 3)
            {
                List<Elliptical> ellipticalList = devicehelper.setEllipticalParameter(deviceList, planId);

                for (int i = 0; i < ellipticalList.Count; i++)
                {
                    System.Console.WriteLine("椭圆机：");
                    System.Console.Write("距离：" + ellipticalList[i].getDistance() + " ");
                    System.Console.Write("阻力：" + ellipticalList[i].getResistance() + " ");
                    System.Console.Write("阻力上限：" + ellipticalList[i].getUpperResistance() + " ");
                    System.Console.WriteLine("阻力下限：" + ellipticalList[i].getLowerResistance() + " ");
                }
            }

            //立式健身车
            else if (devicehelper.getDeviceType(deviceList, planId) == 13)
            {
                List<uprightCycle> uprightcycleList = devicehelper.setuprightCycleParameter(deviceList, planId);

                for (int i = 0; i < uprightcycleList.Count; i++)
                {
                    System.Console.WriteLine("立式健身车：");
                    System.Console.Write("距离：" + uprightcycleList[i].getDistance() + " ");
                    System.Console.Write("阻力：" + uprightcycleList[i].getResistance() + " ");
                    System.Console.Write("阻力上限：" + uprightcycleList[i].getUpperResistance() + " ");
                    System.Console.WriteLine("阻力下限：" + uprightcycleList[i].getLowerResistance() + " ");
                }
            }

            //卧式健身车
            else if (devicehelper.getDeviceType(deviceList, planId) == 14)
            {
                List<recumbentCycle> recumbentcycleList = devicehelper.setrecumbentCycleParameter(deviceList, planId);

                for (int i = 0; i < recumbentcycleList.Count; i++)
                {
                    System.Console.WriteLine("卧式健身车：");
                    System.Console.Write("距离：" + recumbentcycleList[i].getDistance() + " ");
                    System.Console.Write("阻力：" + recumbentcycleList[i].getResistance() + " ");
                    System.Console.Write("阻力上限：" + recumbentcycleList[i].getUpperResistance() + " ");
                    System.Console.WriteLine("阻力下限：" + recumbentcycleList[i].getLowerResistance() + " ");
                }
            }

            /*
            CubeHelper cubeHelper = new CubeHelper(cubeNum);

            cubeList = cubeHelper.getList();
            for (int i = cubeNum - 1; i >= 0; i--)
            {
                runMachPanel.Controls.Add(cubeList[i]);
                cubeList[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.cubeMouseDown);
                cubeList[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.cubeMouseMove);
            }
              */
        //    this.runMachPanel.Location = new System.Drawing.Point(1, 1);
            this.runMachPanel.Name = "runMachPanel";
      //      this.runMachPanel.Size = new System.Drawing.Size(971, 481);
            this.runMachPanel.TabIndex = 0;
           // this.runMachPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPan_Paint);
           // XYLinesFactory.DrawXY(runMachPanel);
           // XYLinesFactory.DrawYLine(runMachPanel, 10, 5);

            this.Controls.Add(this.runMachPanel);

            //设置监听
            label_runMach.MouseHover += new System.EventHandler(label_runMach_MouseHover);
            label_runMach.MouseLeave += new System.EventHandler(label_runMach_MouseLeave);
            label_ovalMach.MouseHover += new System.EventHandler(label_ovalMach_MouseHover);
            label_ovalMach.MouseLeave += new System.EventHandler(label_ovalMach_MouseLeave);
            label_stByc.MouseHover += new System.EventHandler(label_stByc_MouseHover);
            label_stByc.MouseLeave += new System.EventHandler(label_stByc_MouseLeave);
            label_lieByc.MouseHover += new System.EventHandler(label_lieByc_MouseHover);
            label_lieByc.MouseLeave += new System.EventHandler(label_lieByc_MouseLeave);

            ///





            //runMachPanel.Controls.Add(testLabel);


            
            //this.Controls.Add(runMachPanel);
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            //设置窗体大小不能被改变
          //   this.MaximizeBox = false;
           // this.MinimizeBox = false;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.ClientSize = new System.Drawing.Size(width, height);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            //this.AutoSize = false;
            this.Text = "Form1";
        }
        //
        public void update()
        {

        }
        public static int getScreeWidth()
        {
            return System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width; ;
        }
        public static  int getScreeHeight()
        {
            return System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height; ;
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
            if (hrLabel[2].Location.X + hrLabel[2].Width < hrOpPanel.Width-5)
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
        #endregion
    }
    //绘画panel
    class DrawPanel : System.Windows.Forms.Panel
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Pen panelPen = new Pen(Color.Red,2);
            Graphics g = this.CreateGraphics();
            XYLinesFactory.DrawXY(this);
            XYLinesFactory.DrawYLine(this, 10, 5);
        }
    }
    
    class UserPanel :Panel
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Helper helper=new Helper();
            Pen panelPen = new Pen(helper.createColor(176,196,214), 2);
            Graphics g = this.CreateGraphics();
            g.DrawRectangle(panelPen, 0, 0, this.Width, this.Height);
        }
    }
    
    //椭圆机
    class OvalMach
    {
        int rang;

        public int Rang
        {
            get { return rang; }
            set { rang = value; }
        }
        int segmentation;

        public int Segmentation
        {
            get { return segmentation; }
            set { segmentation = value; }
        }
        System.Collections.ArrayList timeList;

        public System.Collections.ArrayList TimeList
        {
            get { return timeList; }
            set { timeList = value; }
        }
        int fN;

        public int FN
        {
            get { return fN; }
            set { fN = value; }
        }
        int maxF;

        public int MaxF
        {
            get { return maxF; }
            set { maxF = value; }
        }
        int minF;

        public int MinF
        {
            get { return minF; }
            set { minF = value; }
        }
    }
}

