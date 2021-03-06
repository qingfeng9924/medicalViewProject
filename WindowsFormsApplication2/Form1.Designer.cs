﻿using System;
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
        private int cubeNum;
        private int Ybase;
        //private List<deviceInfo> deviceList;
        //private List<ExecuteOrder> orderList;
        private deviceHelper devicehelper;
        private CubeHelper cubeHelper;
        private CubeControl newCube;
        private Label txDeviceType;
        private Label txDeviceTypeName;
        private Label txSection;
        private Label txSectionNumber;
        private Label txParameter1;
        private NumericUpDown numberParameter1;
        private Label txParameter2;
        private NumericUpDown numberParameter2;
        private Label txParameter3;
        private NumericUpDown numberParameter3;
        private Label txParameter4;
        private NumericUpDown numberParameter4;
        private Label txParameter5;
        private NumericUpDown numberParameter5;
        private Label txParameter6;
        private NumericUpDown numberParameter6;
        private Label txParameter7;
        private NumericUpDown numberParameter7;
        private Label txParameter8;
        private NumericUpDown numberParameter8;
        private Label txParameter9;
        private NumericUpDown numberParameter9;
        private Label txParameter10;
        private NumericUpDown numberParameter10;

        private List<Treadmill> treadmillList;
        private List<Elliptical> ellipticalList;
        private List<uprightCycle> uprightCycleList;
        private List<recumbentCycle> recumbentCycleList;
        private List<ECP> ecpList;

        private int deviceTypeDisplayNow;

     //   private Panel DrawPan = new Panel();

        Label[] infLabel;

        Label tempLabe1, tempLabel2, tempLabel3;
        /// <summary>
        /// 必需的设计器变量。
        /// //创建刷新县线程
        //Thread t;
        /// </summary>
        int lpWidth = 100;
        int lpHeight = 100;
        SecondCtrl sc0;
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
        Label doctorInfoLabel, patientInfoLabel, adviceIsAvaLabel, exeTimeLabel;
        string doc=null;
        string pat=null;
        string isAva=null;
        string exeTime=null;

        RadioButton isStrictExe;

        Button saveButton;
        //绘画panel
        DrawPanel runMachPanel, ovalMachPanel, lieBycPanel, stBycPanel;
        //4个Image
        System.Drawing.Image Treadmill_Image = System.Drawing.Image.FromFile("Treadmill.png");     //跑步机
        System.Drawing.Image Elliptical_Image = System.Drawing.Image.FromFile("Elliptical.png");       //椭圆机
        System.Drawing.Image uprightCycle_Image = System.Drawing.Image.FromFile("uprightCycle.png");  //立式健身车
        System.Drawing.Image recumbentCycle_Image = System.Drawing.Image.FromFile("recumbentCycle.png");   //卧式健身车
        System.Drawing.Image ECP_Image = System.Drawing.Image.FromFile("ECP.png");              //体外反搏


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


        Label[] labelCase;


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
            isAva = "可用";
            exeTime = "****-**-**";

            this.AutoScroll = true;
           // this.HorizontalScroll.Visible = false;

            //font
            Helper helper = new Helper();

           

            infoPanel = new Panel();
            infoPanel.Size = new System.Drawing.Size(width,30);
            infoPanel.Location = new Point(0,0);
            infoPanel.BackColor = Color.White;
            infoPanel.BorderStyle = BorderStyle.FixedSingle;
           // infoPanel.BackColor = helper.createColor(196,203,211);
            infoPanel.BackColor = Color.Gray;

            //信息label
            infLabel = new Label[14];

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


            adviceIsAvaLabel = new Label();
            adviceIsAvaLabel.Font = helper.createFont1();
            adviceIsAvaLabel.Size = new System.Drawing.Size(width / 6 -1, infoPanel.Height - 1);
            adviceIsAvaLabel.Location = new Point(width / 6*2, 0);
            adviceIsAvaLabel.Text = "医嘱状态:" + isAva;
            adviceIsAvaLabel.BorderStyle = BorderStyle.FixedSingle;
           // adviceIsExeLabel.TextAlign = ContentAlignment.BottomLeft;
            infoPanel.Controls.Add(adviceIsAvaLabel);

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
            boPanel.Location = new Point(0, 10);
            boPanel.Size = new System.Drawing.Size(topPanel.Width / 4 - 5, topPanel.Height);

            //boPanel.BorderStyle = BorderStyle.Fixed3D;

            boImageLabel = new Label();
            boImageLabel.Image = boImage;
            boImageLabel.Location = new Point(0, 0);
            boImageLabel.Size = new System.Drawing.Size(boPanel.Width, boPanel.Height / 2 - 10);




            boOpPanel = new UserPanel();

           // boOpPanel.BackColor = Color.Red;

            boOpPanel.Location = new Point(0, boImageLabel.Height + 27);
            boOpPanel.Size = new System.Drawing.Size(boPanel.Width, 35);
            //boOpPanel.BackColor = Color.Red;
            boLabel = new Label();
            boLabel.Size = new System.Drawing.Size((int)((float)boOpPanel.Width / 60 * (monitorPara[1] - monitorPara[0])), boOpPanel.Height);
            boLabel.Location = new Point((int)(((float)monitorPara[0] - 60) / 60 * boOpPanel.Width), 0);
            boLabel.BackColor = helper.createColor(114, 149, 182);
            boLabel.MouseHover += new EventHandler(mouseHover);
            // new OperateControl(boLabel);
            // boLabel.Text = "ssssssssssssssssssssssss";
            boOpPanel.Controls.Add(boLabel);

            /*
             * 
             * */

            infLabel[0] = new Label();
            infLabel[0].Location = new Point(boLabel.Location.X - 5, boOpPanel.Location.Y + boOpPanel.Height + 2);
            infLabel[0].Size = new Size(30, 10);
            infLabel[1] = new Label();
            infLabel[1].Location = new Point(boLabel.Location.X + boLabel.Width, boOpPanel.Location.Y + boOpPanel.Height + 2);
            infLabel[1].Size = new Size(30, 10);
            /*
             * 初始化血氧参数
             * */
            infLabel[0].Text = monitorPara[0].ToString();
            infLabel[1].Text = monitorPara[1].ToString();

            boPanel.Controls.Add(infLabel[0]);

            boPanel.Controls.Add(infLabel[1]);
            boPanel.Controls.Add(boImageLabel);
            boPanel.Controls.Add(boOpPanel);
            //心率
            //心率
            hrPanel = new Panel();
            hrPanel.Location = new Point(boPanel.Width + boPanel.Location.X + 5, 10);
            hrPanel.Size = new System.Drawing.Size(topPanel.Width / 4 - 5, topPanel.Height);

            //hrPanel.BorderStyle = BorderStyle.Fixed3D; ;

            hrImageLabel = new Label();
            hrImageLabel.Image = hrImage;
            hrImageLabel.Location = new Point(0, 0);
            hrImageLabel.Size = new System.Drawing.Size(hrPanel.Width, hrPanel.Height / 2 - 10);


            hrOpPanel = new UserPanel();
            hrOpPanel.Location = new Point(0, hrImageLabel.Height + 27);
            hrOpPanel.Size = new System.Drawing.Size(hrPanel.Width, 35);
            hrOpPanel.BackColor = Color.White;
            hrLabel[0] = new Label();
            hrLabel[0].Size = new System.Drawing.Size((int)((float)(monitorPara[3] - monitorPara[2]) / 150 * hrOpPanel.Width), hrOpPanel.Height - 4);
            hrLabel[0].Location = new Point((int)((float)hrOpPanel.Width * (monitorPara[2] - 30) / 150), 2);
            hrLabel[0].BackColor = Color.Red;
            // hrLabel[0].MouseClick += new MouseEventHandler(mouseClick);
            hrLabel[1] = new Label();
            hrLabel[1].Size = new System.Drawing.Size((int)((float)(monitorPara[4] - monitorPara[3]) / 150 * hrOpPanel.Width), hrOpPanel.Height - 4);
            hrLabel[1].Location = new Point(hrLabel[0].Location.X + hrLabel[0].Width + 2, 2);
            hrLabel[1].BackColor = helper.createColor(114, 149, 182);
            // hrLabel[1].MouseClick += new MouseEventHandler(mouseClick);


            hrLabel[2] = new Label();
            hrLabel[2].Size = new System.Drawing.Size((int)((float)(monitorPara[5] - monitorPara[4]) / 150 * hrOpPanel.Width), hrOpPanel.Height - 4);
            hrLabel[2].Location = new Point(hrLabel[1].Location.X + hrLabel[1].Width + 2, 2);

            hrLabel[2].BackColor = Color.Red;
            hrLabel[2].MouseEnter += new EventHandler(mouseHover);
            hrLabel[1].MouseEnter += new EventHandler(mouseHover);
            hrLabel[0].MouseEnter += new EventHandler(mouseHover);




            //初始化心率
            infLabel[2] = new Label();
            infLabel[2].Size = new Size(30, 10);
            infLabel[2].Location = new Point(hrLabel[0].Location.X - 25, hrOpPanel.Location.Y + hrOpPanel.Height + 2);
            infLabel[2].Text = monitorPara[2] + "";

            infLabel[3] = new Label();
            infLabel[3].Size = new Size(30, 10);
            infLabel[3].Location = new Point(hrLabel[1].Location.X - 25, hrOpPanel.Location.Y - 15);
            infLabel[3].Text = monitorPara[3] + "";
            infLabel[4] = new Label();
            infLabel[4].Size = new Size(30, 10);
            infLabel[4].Location = new Point(hrLabel[2].Location.X - 5, hrOpPanel.Location.Y + hrOpPanel.Height + 2);
            infLabel[4].Text = monitorPara[4] + "";
            infLabel[5] = new Label();
            infLabel[5].Size = new Size(30, 10);
            infLabel[5].Location = new Point(hrLabel[2].Location.X + hrLabel[2].Width - 15, hrOpPanel.Location.Y - 15);
            infLabel[5].Text = monitorPara[5] + "";

            //infLabel[3].BackColor = Color.Transparent;
            hrPanel.Controls.Add(infLabel[2]);
            hrPanel.Controls.Add(infLabel[3]);
            hrPanel.Controls.Add(infLabel[4]);
            hrPanel.Controls.Add(infLabel[5]);





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
            ssyPanel.Size = new System.Drawing.Size(topPanel.Width / 4 - 5, topPanel.Height);

            ssyImageLabel = new Label();
            ssyImageLabel.Image = ssyImage;
            ssyImageLabel.Location = new Point(0, 0);
            ssyImageLabel.Size = new System.Drawing.Size(ssyPanel.Width, ssyPanel.Height / 2 - 10);


            ssyOpPanel = new UserPanel();
            ssyOpPanel.Location = new Point(0, ssyImageLabel.Height + 27);
            ssyOpPanel.Size = new System.Drawing.Size(ssyPanel.Width, 35);
            ssyOpPanel.BackColor = Color.White;
            ssyLabel[0] = new Label();
            //  Console.WriteLine("(float)(monitorPara[7] - monitorPara[6])" + (int)((float)(monitorPara[7] - monitorPara[6]) / 150 * ssyOpPanel.Width));
            ssyLabel[0].Size = new System.Drawing.Size((int)((float)(monitorPara[7] - monitorPara[6]) / 150 * ssyOpPanel.Width), ssyOpPanel.Height - 4);
            ssyLabel[0].Location = new Point((int)(((float)(monitorPara[6] - 30)) / 150 * ssyOpPanel.Width), 2);
            ssyLabel[0].BackColor = Color.Red;
            // ssyLabel[0].MouseClick += new MouseEventHandler(mouseClick);
            ssyLabel[1] = new Label();
            ssyLabel[1].Size = new System.Drawing.Size((int)((float)(monitorPara[8] - monitorPara[7]) / 150 * ssyOpPanel.Width), ssyOpPanel.Height - 4);
            ssyLabel[1].Location = new Point(ssyLabel[0].Location.X + ssyLabel[0].Width + 2, 2);
            ssyLabel[1].BackColor = helper.createColor(114, 149, 182);
            // hrLabel[1].MouseClick += new MouseEventHandler(mouseClick);


            ssyLabel[2] = new Label();
            ssyLabel[2].Size = new System.Drawing.Size((int)((float)(monitorPara[9] - monitorPara[8]) / 150 * ssyOpPanel.Width), ssyOpPanel.Height - 4);
            ssyLabel[2].Location = new Point(ssyLabel[1].Location.X + ssyLabel[1].Width + 2, 2);

            ssyLabel[2].BackColor = Color.Red;
            ssyLabel[2].MouseEnter += new EventHandler(mouseHover);
            ssyLabel[1].MouseEnter += new EventHandler(mouseHover);
            ssyLabel[0].MouseEnter += new EventHandler(mouseHover);



            //初始化收缩压
            infLabel[6] = new Label();
            infLabel[6].Location = new Point(ssyLabel[0].Location.X - 25, ssyOpPanel.Height + ssyOpPanel.Location.Y + 2);
            infLabel[6].Size = new System.Drawing.Size(20, 10);
            infLabel[6].Text = monitorPara[6] + "";
            infLabel[7] = new Label();
            infLabel[7].Location = new Point(ssyLabel[1].Location.X - 25, ssyOpPanel.Location.Y - 15);
            infLabel[7].Size = new System.Drawing.Size(25, 10);
            infLabel[7].Text = monitorPara[7] + "";
            infLabel[8] = new Label();
            infLabel[8].Location = new Point(ssyLabel[2].Location.X - 25, ssyOpPanel.Height + ssyOpPanel.Location.Y + 2);
            infLabel[8].Size = new System.Drawing.Size(25, 10);
            infLabel[8].Text = monitorPara[8] + "";

            infLabel[9] = new Label();
            infLabel[9].Location = new Point(ssyLabel[2].Location.X + ssyLabel[2].Width - 25, ssyOpPanel.Location.Y - 15);
            infLabel[9].Size = new System.Drawing.Size(25, 10);
            infLabel[9].Text = monitorPara[9] + "";



            ssyPanel.Controls.Add(infLabel[6]);
            ssyPanel.Controls.Add(infLabel[7]);
            ssyPanel.Controls.Add(infLabel[8]);
            ssyPanel.Controls.Add(infLabel[9]);
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
            szyPanel.Size = new System.Drawing.Size(topPanel.Width / 4 - 5, topPanel.Height);

            szyImageLabel = new Label();
            szyImageLabel.Image = szyImage;
            szyImageLabel.Location = new Point(0, 0);
            szyImageLabel.Size = new System.Drawing.Size(szyPanel.Width, szyPanel.Height / 2 - 10);


            szyOpPanel = new UserPanel();
            szyOpPanel.Location = new Point(0, szyImageLabel.Height + 27);
            szyOpPanel.Size = new System.Drawing.Size(szyPanel.Width, 35);
            szyOpPanel.BackColor = Color.White;
            szyLabel[0] = new Label();
            szyLabel[0].Size = new System.Drawing.Size((int)((float)(monitorPara[11] - monitorPara[10]) / 105 * szyOpPanel.Width), szyOpPanel.Height - 4);
            szyLabel[0].Location = new Point((int)((float)(monitorPara[10] - 50) / 115 * szyOpPanel.Width), 2);
            szyLabel[0].BackColor = Color.Red;
            //szyLabel[0].MouseClick += new MouseEventHandler(mouseClick);
            szyLabel[1] = new Label();
            szyLabel[1].Size = new System.Drawing.Size((int)((float)(monitorPara[12] - monitorPara[11]) / 115 * szyOpPanel.Width), szyOpPanel.Height - 4);
            szyLabel[1].Location = new Point(szyLabel[0].Location.X + szyLabel[0].Width + 2, 2);
            szyLabel[1].BackColor = helper.createColor(114, 149, 182);
            // hrLabel[1].MouseClick += new MouseEventHandler(mouseClick);


            szyLabel[2] = new Label();
            szyLabel[2].Size = new System.Drawing.Size((int)((float)(monitorPara[13] - monitorPara[12]) / 115 * szyOpPanel.Width), szyOpPanel.Height - 4);
            szyLabel[2].Location = new Point(szyLabel[1].Location.X + szyLabel[1].Width + 2, 2);

            szyLabel[2].BackColor = Color.Red;
            szyLabel[2].MouseEnter += new EventHandler(mouseHover);
            szyLabel[1].MouseEnter += new EventHandler(mouseHover);
            szyLabel[0].MouseEnter += new EventHandler(mouseHover);


            //初始化收缩压
            infLabel[10] = new Label();
            infLabel[10].Location = new Point(szyLabel[0].Location.X - 5, szyOpPanel.Height + szyOpPanel.Location.Y + 2);
            infLabel[10].Size = new System.Drawing.Size(20, 10);
            infLabel[10].Text = monitorPara[10] + "";
            infLabel[11] = new Label();
            infLabel[11].Location = new Point(szyLabel[1].Location.X - 5, szyOpPanel.Location.Y - 15);
            infLabel[11].Size = new System.Drawing.Size(25, 10);
            infLabel[11].Text = monitorPara[11] + "";
            infLabel[12] = new Label();
            infLabel[12].Location = new Point(szyLabel[2].Location.X - 15, szyOpPanel.Height + szyOpPanel.Location.Y + 2);
            infLabel[12].Size = new System.Drawing.Size(25, 10);
            infLabel[12].Text = monitorPara[12] + "";

            infLabel[13] = new Label();
            infLabel[13].Location = new Point(szyLabel[2].Location.X + szyLabel[2].Width - 25, szyOpPanel.Location.Y - 15);
            infLabel[13].Size = new System.Drawing.Size(25, 10);
            infLabel[13].Text = monitorPara[13] + "";


            szyPanel.Controls.Add(infLabel[10]);
            szyPanel.Controls.Add(infLabel[11]);
            szyPanel.Controls.Add(infLabel[12]);
            szyPanel.Controls.Add(infLabel[13]);
            //

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
            labelPanel.Size = new Size(width, height / 6);
            labelPanel.Location = new Point(0, topPanel.Location.Y + topPanel.Height);
            //labelPanel.BackColor = Color.Pink;
            labelPanel.BorderStyle = BorderStyle.FixedSingle;

            //this.Controls.Add(label_runMach);
            // this.Controls.Add(label_lieByc);
            //this.Controls.Add(label_ovalMach);
            // this.Controls.Add(label_stByc);


            //血氧等参数信息






            runMachPanel = new DrawPanel();
            runMachPanel.Location = new Point(0, labelPanel.Location.Y + labelPanel.Height);
            runMachPanel.Size = new Size(width - 300, height - labelPanel.Location.Y - labelPanel.Height - 20);
            runMachPanel.BackColor = Color.White;
           
            runMachPanel = new DrawPanel();
            runMachPanel.Location = new Point(0,labelPanel.Location.Y+labelPanel.Height);
            runMachPanel.Size = new Size(width - 300, height - labelPanel.Location.Y - labelPanel.Height - 20);
            runMachPanel.BackColor = Color.White;
            runMachPanel.AutoSize = false;
            runMachPanel.AutoScroll = true;

           // runMachPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPan_Paint);
                        
         //   runMachPanel.SuspendLayout();

            //绘画panel
            /*
             *
             * 
             * 绘画
             * 
             **/
            //sqlHelper = new SQLHelper(307);
            //监护参数
            //List<monitorInfo> monitorList = sqlHelper.sqlReadMonitor();
            //运动方案
            //deviceList = sqlHelper.sqlReaderDevice();
            //执行顺序
            //orderList = new List<ExecuteOrder>();
            //orderList = sqlHelper.sqlReaderOrder();
            //int planId = orderList[0].EXERCISE_PLAN_ID;

            for (int i = 0; i < monitorList.Count; i++) 
            {
                if (monitorList[i].MONITOE_PARA_ID.Equals("1")) 
                {
                    System.Console.WriteLine("血氧：");
                    System.Console.Write("上限:" + monitorList[i].PARA_UP_LIMIT + " ");
                    System.Console.Write("上限预警值:" + monitorList[i].PARA_UP_ALERT + " ");
                    System.Console.Write("下限:" + monitorList[i].PARA_DOWN_LIMIT + " ");
                    System.Console.WriteLine("下限预警值:" + monitorList[i].PARA_DOWN_ALERT + " ");
                }
                else if(monitorList[i].MONITOE_PARA_ID.Equals("2"))
                {
                    System.Console.WriteLine("舒张压");
                    System.Console.Write("上限:" + monitorList[i].PARA_UP_LIMIT + " ");
                    System.Console.Write("上限预警值:" + monitorList[i].PARA_UP_ALERT + " ");
                    System.Console.Write("下限:" + monitorList[i].PARA_DOWN_LIMIT + " ");
                    System.Console.WriteLine("下限预警值:" + monitorList[i].PARA_DOWN_ALERT + " ");
                }
                else if(monitorList[i].MONITOE_PARA_ID.Equals("3"))
                {
                    System.Console.WriteLine("收缩压");
                    System.Console.Write("上限:" + monitorList[i].PARA_UP_LIMIT + " ");
                    System.Console.Write("上限预警值:" + monitorList[i].PARA_UP_ALERT + " ");
                    System.Console.Write("下限:" + monitorList[i].PARA_DOWN_LIMIT + " ");
                    System.Console.WriteLine("下限预警值:" + monitorList[i].PARA_DOWN_ALERT + " ");
                }
                else if (monitorList[i].MONITOE_PARA_ID.Equals("4"))
                {
                    System.Console.WriteLine("心率");
                    System.Console.Write("上限:" + monitorList[i].PARA_UP_LIMIT + " ");
                    System.Console.Write("上限预警值:" + monitorList[i].PARA_UP_ALERT + " ");
                    System.Console.Write("下限:" + monitorList[i].PARA_DOWN_LIMIT + " ");
                    System.Console.WriteLine("下限预警值:" + monitorList[i].PARA_DOWN_ALERT + " ");
                }
            }
            devicehelper = new deviceHelper();
           // devicehelper.setCubeNum(deviceList, planId);
            //cubeNum = devicehelper.getCubeNum();
            //System.Console.WriteLine("cubeNum = " + cubeNum);

            //跑步机
            if (devicehelper.getDeviceType(deviceList, planId) == 1)
            {
                
                List<Treadmill> treadmillList = devicehelper.setTreadmillParameter(deviceList, planId);

                /*
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

                
                cubeHelper = new CubeHelper(cubeList, Ybase);
                cubeList = cubeHelper.getList();

                for (int i = cubeNum - 1; i >= 0; i--)
                {
                    runMachPanel.Controls.Add(cubeList[i]);
                    cubeList[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.cubeMouseDown);
                    cubeList[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.cubeMouseMove);
                }
                */

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

            //体外反搏
            else if (devicehelper.getDeviceType(deviceList, planId) == 6)
            {
                List<ECP> ecpList = devicehelper.setecpParameter(deviceList, planId);

                for (int i = 0; i < ecpList.Count; i++)
                {
                    System.Console.WriteLine("tiwaifanbo：");
                    System.Console.Write("时间：" + ecpList[i].getTime() + " ");
                    System.Console.Write("期望压力：" + ecpList[i].getExPressure() + " ");
                    System.Console.Write("压力上限：" + ecpList[i].getUpperExPressure() + " ");
                    System.Console.Write("压力下限：" + ecpList[i].getLowerExPressure() + " ");
                    System.Console.Write("R2I偏移：" + ecpList[i].getR2I() + " ");
                    System.Console.Write("R2I偏移上限：" + ecpList[i].getUpperR2I() + " ");
                    System.Console.Write("R2I偏移下限：" + ecpList[i].getLowerR2I() + " ");
                    System.Console.Write("R2D偏移：" + ecpList[i].getR2D() + " ");
                    System.Console.Write("R2D偏移上限：" + ecpList[i].getUpperR2D() + " ");
                    System.Console.WriteLine("R2D偏移下限：" + ecpList[i].getLowerR2D() + " ");
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
            this.runMachPanel.AutoScroll = true;
           // this.runMachPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPan_Paint);
           // XYLinesFactory.DrawXY(runMachPanel);
           // XYLinesFactory.DrawYLine(runMachPanel, 10, 5);

            this.Controls.Add(this.runMachPanel);


            /*
            //设置监听
            label_runMach.MouseHover += new System.EventHandler(label_runMach_MouseHover);
            label_runMach.MouseLeave += new System.EventHandler(label_runMach_MouseLeave);
            label_ovalMach.MouseHover += new System.EventHandler(label_ovalMach_MouseHover);
            label_ovalMach.MouseLeave += new System.EventHandler(label_ovalMach_MouseLeave);
            label_stByc.MouseHover += new System.EventHandler(label_stByc_MouseHover);
            label_stByc.MouseLeave += new System.EventHandler(label_stByc_MouseLeave);
            label_lieByc.MouseHover += new System.EventHandler(label_lieByc_MouseHover);
            label_lieByc.MouseLeave += new System.EventHandler(label_lieByc_MouseLeave);
            */
            ///





            //runMachPanel.Controls.Add(testLabel);
            labelCase=new Label[deviceList.Count];
            labelCase = this.generateCase(orderList);
            //labelCase = this.generateCase(deviceList,orderList);
            for (int i = 0; i < labelCase.Length;i++) 
            {
                labelCase[i].MouseClick += new MouseEventHandler(addLabelCaseClickListener);
                labelCase[i].MouseEnter += new EventHandler(addLabelCaseHoverListener);
                labelCase[i].MouseLeave += new EventHandler(addLabelCaseLeaveListener);
                labelPanel.Controls.Add(labelCase[i]);
                
            }
            Console.WriteLine("---------------------------"+labelCase.Length);
            labelPanel.BackColor = Color.Beige;
            this.Controls.Add(labelPanel);
            this.Controls.Add(infoPanel);
            this.Controls.Add(topPanel);

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
        public static int getScreeWidth()
        {
            return System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        }
        public static  int getScreeHeight()
        {
            return System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        }
        public Label[] generateCase(List<ExecuteOrder> orderList)
        {
            int num = orderList.Count;
            if (num == 0)
                return null;
            int labelSize=0;
            if (width/num > lpWidth)
            {
                labelSize = lpWidth;
            }
            else
            {
                labelSize = width / num;
            }
            Label []label=new Label[num];

            for (int i = 0; i < num; i++) {
                label[i] = new Label();
                if(labelSize==100)
                {
                    label[i].Location = new Point(i*(labelSize+10), 10);
                }
                else
                {
                    if (i < num / 2)
                    {
                        label[i].Location = new Point(i * (width / num + labelSize), 5);
                    }
                    else
                    {
                        label[i].Location = new Point((i - num / 2) * (width / num + labelSize), labelSize + 10);
                    }
                }
                    
                label[i].Size = new Size(labelSize, labelSize);
                label[i].Image = this.changeImgSize(labelSize - 1, labelSize - 1, this.setImage(orderList[i].DEVICE_TYPE_ID.ToString()));
                label[i].BackColor = Color.Red;
               // label[i].Image = this.changeImgSize(labelSize-1, labelSize-1, this.setImage(list[i].DEVICE_TYPE_ID));
                //label[i].BackColor = Color.Red;
                label[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; 
            }
           // Console.WriteLine("---------------------------------------------"+label.Length);
            return label;
        }
        //判断是那张标识图片
        /*
         * 
        **/
        public Image setImage(String id)
        {
            Image image=null;
            int tempId = int.Parse(id);
            switch(tempId)
            {
                case 1:
                    image = Treadmill_Image;
                    break;
                case 3:
                    image = Elliptical_Image;
                    break;
                case 6:
                    image = ECP_Image;
                    break;
                case 13:
                    image = uprightCycle_Image;
                    break;
                case 14:
                    image = recumbentCycle_Image;
                    break;
                default:
                    break;
            }
            return image;
        }
        public Image changeImgSize(int width,int height,Image img)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((Image)b);
            g.DrawImage(img,0,0,width,height);
            g.Dispose();
            return b;
        }

        public void addLabelCaseClickListener(object sender, EventArgs e)
        {
            this.Controls.Remove(txDeviceType);
            this.Controls.Remove(txDeviceTypeName);
            this.Controls.Remove(txSection);
            this.Controls.Remove(txSectionNumber);
            this.Controls.Remove(txParameter1);
            this.Controls.Remove(txParameter2);
            this.Controls.Remove(txParameter3);
            this.Controls.Remove(txParameter4);
            this.Controls.Remove(txParameter5);
            this.Controls.Remove(txParameter6);
            this.Controls.Remove(txParameter7);
            this.Controls.Remove(txParameter8);
            this.Controls.Remove(txParameter9);
            this.Controls.Remove(txParameter10);
            this.Controls.Remove(numberParameter1);
            this.Controls.Remove(numberParameter2);
            this.Controls.Remove(numberParameter3);
            this.Controls.Remove(numberParameter4);
            this.Controls.Remove(numberParameter5);
            this.Controls.Remove(numberParameter6);
            this.Controls.Remove(numberParameter7);
            this.Controls.Remove(numberParameter8);
            this.Controls.Remove(numberParameter9);
            this.Controls.Remove(numberParameter10);

            runMachPanel.Controls.Clear();
            int index = ((Label)sender).TabIndex;
            int deviceType = orderList[index].DEVICE_TYPE_ID;
            planId = orderList[index].EXERCISE_PLAN_ID;
            devicehelper.setCubeNum(deviceList, planId);
            cubeNum = devicehelper.getCubeNum();
            System.Console.WriteLine("cubeNum = " + cubeNum);
            cubeList = new List<CubeControl>();
            Ybase = XYLinesFactory.getYbase(runMachPanel);
          //  cubeHelper = new CubeHelper(cubeList, Ybase);
          //  cubeList = cubeHelper.getList();
            switch(deviceType)
            {
                case 1:
                    deviceTypeDisplayNow = 1;
                    treadmillList = devicehelper.setTreadmillParameter(deviceList, planId);
                    for (int i = 0; i < cubeNum; i++)
                    {
                        newCube = new CubeControl(100, 100);
                        int time = treadmillList[i].getTime();
                        int curSpeed = treadmillList[i].getCurSpeed();
                        int upperSpeed = treadmillList[i].getUpperSpeed();
                        int lowerSpeed = treadmillList[i].getLowerSpeed();
                        newCube.setTreadmillWidthHeight(time, curSpeed, upperSpeed, lowerSpeed);
                        cubeList.Add(newCube);
                    }
                    cubeHelper = new CubeHelper(cubeList, Ybase);
                    cubeList = cubeHelper.getList();
                    for (int i = cubeNum - 1; i >= 0; i--)
                    {
                        runMachPanel.Controls.Add(cubeList[i]);
                        cubeList[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.cubeMouseDown);
                        cubeList[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.cubeMouseMove);
                    }

                    operatedSec = 1;

                    txDeviceType = new Label();
                    txDeviceType.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 20);
                    txDeviceType.Size = new System.Drawing.Size(80, 30);
                    txDeviceType.Text = "设备名：";

                    txDeviceTypeName = new Label();
                    txDeviceTypeName.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 20);
                    txDeviceType.Size = new System.Drawing.Size(80, 30);
                    txDeviceTypeName.Text = "跑步机";

                    txSection = new Label();
                    txSection.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 60);
                    txSection.Size = new System.Drawing.Size(80, 30);
                    txSection.Text = "段  号：";

                    txSectionNumber = new Label();
                    txSectionNumber.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 60);
                    txSectionNumber.Size = new System.Drawing.Size(80, 30);
                    txSectionNumber.Text = "1";

                    txParameter1 = new Label();
                    txParameter1.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 100);
                    txParameter1.Size = new System.Drawing.Size(80, 30);
                    txParameter1.Text = "时  间：";

                    numberParameter1 = new NumericUpDown();
                    numberParameter1.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 95);
                    numberParameter1.Size = new System.Drawing.Size(80, 30);
                    numberParameter1.Maximum = 30000;
                    numberParameter1.Minimum = 0;
                    numberParameter1.Value = treadmillList[0].getTime();

                    txParameter2 = new Label();
                    txParameter2.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 140);
                    txParameter2.Size = new System.Drawing.Size(80, 30);
                    txParameter2.Text = "速  度：";

                    numberParameter2 = new NumericUpDown();
                    numberParameter2.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 135);
                    numberParameter2.Size = new System.Drawing.Size(80, 30);
                    numberParameter2.Maximum = treadmillList[0].getUpperSpeed();
                    numberParameter2.Minimum = treadmillList[0].getLowerSpeed();
                    numberParameter2.Value = treadmillList[0].getCurSpeed();

                    txParameter3 = new Label();
                    txParameter3.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 180);
                    txParameter3.Size = new System.Drawing.Size(80, 30);
                    txParameter3.Text = "速度上限：";

                    numberParameter3 = new NumericUpDown();
                    numberParameter3.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 175);
                    numberParameter3.Size = new System.Drawing.Size(80, 30);
                    numberParameter3.Maximum = 2500;
                    numberParameter3.Minimum = treadmillList[0].getCurSpeed();
                    numberParameter3.Value = treadmillList[0].getUpperSpeed();

                    txParameter4 = new Label();
                    txParameter4.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 220);
                    txParameter4.Size = new System.Drawing.Size(80, 30);
                    txParameter4.Text = "速度下限：";

                    numberParameter4 = new NumericUpDown();
                    numberParameter4.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 215);
                    numberParameter4.Size = new System.Drawing.Size(80, 30);
                    numberParameter4.Maximum = treadmillList[0].getCurSpeed();
                    numberParameter4.Minimum = 0;
                    numberParameter4.Value = treadmillList[0].getLowerSpeed();

                    txParameter5 = new Label();
                    txParameter5.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 260);
                    txParameter5.Size = new System.Drawing.Size(80, 30);
                    txParameter5.Text = "坡  度：";

                    numberParameter5 = new NumericUpDown();
                    numberParameter5.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 255);
                    numberParameter5.Size = new System.Drawing.Size(80, 30);
                    numberParameter5.Maximum = treadmillList[0].getUpperSlope();
                    numberParameter5.Minimum = treadmillList[0].getLowerSlope();
                    numberParameter5.Value = treadmillList[0].getSlope();

                    txParameter6 = new Label();
                    txParameter6.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 300);
                    txParameter6.Size = new System.Drawing.Size(80, 30);
                    txParameter6.Text = "坡度上限：";

                    numberParameter6 = new NumericUpDown();
                    numberParameter6.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 295);
                    numberParameter6.Size = new System.Drawing.Size(80, 30);
                    numberParameter6.Maximum = 10;
                    numberParameter6.Minimum = treadmillList[0].getSlope();
                    numberParameter6.Value = treadmillList[0].getUpperSlope();

                    txParameter7 = new Label();
                    txParameter7.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 340);
                    txParameter7.Size = new System.Drawing.Size(80, 30);
                    txParameter7.Text = "坡度下限：";

                    numberParameter7 = new NumericUpDown();
                    numberParameter7.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 335);
                    numberParameter7.Size = new System.Drawing.Size(80, 30);
                    numberParameter7.Maximum = treadmillList[0].getSlope();
                    numberParameter7.Minimum = 0;
                    numberParameter7.Value = treadmillList[0].getLowerSlope();

                    this.Controls.Add(txDeviceType);
                    this.Controls.Add(txDeviceTypeName);
                    this.Controls.Add(txSection);
                    this.Controls.Add(txSectionNumber);
                    this.Controls.Add(txParameter1);
                    this.Controls.Add(numberParameter1);
                    this.Controls.Add(txParameter2);
                    this.Controls.Add(numberParameter2);
                    this.Controls.Add(txParameter3);
                    this.Controls.Add(numberParameter3);
                    this.Controls.Add(txParameter4);
                    this.Controls.Add(numberParameter4);
                    this.Controls.Add(txParameter5);
                    this.Controls.Add(numberParameter5);
                    this.Controls.Add(txParameter6);
                    this.Controls.Add(numberParameter6);
                    this.Controls.Add(txParameter7);
                    this.Controls.Add(numberParameter7);

                    numberParameter1.ValueChanged += new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged += new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged += new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged += new System.EventHandler(this.numberParameter4_ValueChanged);
                    numberParameter5.ValueChanged += new System.EventHandler(this.numberParameter5_ValueChanged);
                    numberParameter6.ValueChanged += new System.EventHandler(this.numberParameter6_ValueChanged);
                    numberParameter7.ValueChanged += new System.EventHandler(this.numberParameter7_ValueChanged);

                    break;

                case 3:
                    deviceTypeDisplayNow = 3;
                    ellipticalList = devicehelper.setEllipticalParameter(deviceList, planId);
                    for (int i = 0; i < cubeNum; i++)
                    {
                        newCube = new CubeControl(100, 100);
                        int distance = ellipticalList[i].getDistance();
                        int resistance = ellipticalList[i].getResistance();
                        int upperResistance = ellipticalList[i].getUpperResistance();
                        int lowerResistance = ellipticalList[i].getLowerResistance();
                        newCube.setEllipticalWidthHeight(distance, resistance, upperResistance, lowerResistance);
                        cubeList.Add(newCube);
                    }
                    cubeHelper = new CubeHelper(cubeList, Ybase);
                    cubeList = cubeHelper.getList();
                    for (int i = cubeNum - 1; i >= 0; i--)
                    {
                        runMachPanel.Controls.Add(cubeList[i]);
                        cubeList[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.cubeMouseDown);
                        cubeList[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.cubeMouseMove);
                    }

                    operatedSec = 1;

                    txDeviceType = new Label();
                    txDeviceType.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height+20);
                    txDeviceType.Size = new System.Drawing.Size(80, 30);
                    txDeviceType.Text = "设备名：";

                    txDeviceTypeName = new Label();
                    txDeviceTypeName.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height+20);
                    txDeviceType.Size = new System.Drawing.Size(80, 30);
                    txDeviceTypeName.Text = "椭圆机";

                    txSection = new Label();
                    txSection.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 60);
                    txSection.Size = new System.Drawing.Size(80, 30);
                    txSection.Text = "段  号：";

                    txSectionNumber = new Label();
                    txSectionNumber.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 60);
                    txSectionNumber.Size = new System.Drawing.Size(80, 30);
                    txSectionNumber.Text = "1";

                    txParameter1 = new Label();
                    txParameter1.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 100);
                    txParameter1.Size = new System.Drawing.Size(80, 30);
                    txParameter1.Text = "距  离：";

                    numberParameter1 = new NumericUpDown();
                    numberParameter1.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 95);
                    numberParameter1.Size = new System.Drawing.Size(80, 30);
                    numberParameter1.Maximum = 30000;
                    numberParameter1.Minimum = 0;
                    numberParameter1.Value = ellipticalList[0].getDistance();

                    txParameter2 = new Label();
                    txParameter2.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 140);
                    txParameter2.Size = new System.Drawing.Size(80, 30);
                    txParameter2.Text = "阻  力：";

                    numberParameter2 = new NumericUpDown();
                    numberParameter2.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 135);
                    numberParameter2.Size = new System.Drawing.Size(80, 30);
                    numberParameter2.Maximum = ellipticalList[0].getUpperResistance();
                    numberParameter2.Minimum = ellipticalList[0].getLowerResistance();
                    numberParameter2.Value = ellipticalList[0].getResistance();

                    txParameter3 = new Label();
                    txParameter3.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 180);
                    txParameter3.Size = new System.Drawing.Size(80, 30);
                    txParameter3.Text = "阻力上限：";

                    numberParameter3 = new NumericUpDown();
                    numberParameter3.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 175);
                    numberParameter3.Size = new System.Drawing.Size(80, 30);
                    numberParameter3.Maximum = 15;
                    numberParameter3.Minimum = ellipticalList[0].getResistance();
                    numberParameter3.Value = ellipticalList[0].getUpperResistance();

                    txParameter4 = new Label();
                    txParameter4.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 220);
                    txParameter4.Size = new System.Drawing.Size(80, 30);
                    txParameter4.Text = "阻力下限：";

                    numberParameter4 = new NumericUpDown();
                    numberParameter4.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 215);
                    numberParameter4.Size = new System.Drawing.Size(80, 30);
                    numberParameter4.Maximum = ellipticalList[0].getResistance();
                    numberParameter4.Minimum = 1;
                    numberParameter4.Value = ellipticalList[0].getLowerResistance();

                    this.Controls.Add(txDeviceType);
                    this.Controls.Add(txDeviceTypeName);
                    this.Controls.Add(txSection);
                    this.Controls.Add(txSectionNumber);
                    this.Controls.Add(txParameter1);
                    this.Controls.Add(numberParameter1);
                    this.Controls.Add(txParameter2);
                    this.Controls.Add(numberParameter2);
                    this.Controls.Add(txParameter3);
                    this.Controls.Add(numberParameter3);
                    this.Controls.Add(txParameter4);
                    this.Controls.Add(numberParameter4);

                    numberParameter1.ValueChanged += new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged += new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged += new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged += new System.EventHandler(this.numberParameter4_ValueChanged);

                    break;

                case 13:
                    deviceTypeDisplayNow = 13;
                    uprightCycleList = devicehelper.setuprightCycleParameter(deviceList, planId);
                    for (int i = 0; i < cubeNum; i++)
                    {
                        newCube = new CubeControl(100, 100);
                        int distance = uprightCycleList[i].getDistance();
                        int resistance = uprightCycleList[i].getResistance();
                        int upperResistance = uprightCycleList[i].getUpperResistance();
                        int lowerResistance = uprightCycleList[i].getLowerResistance();
                        newCube.setUprightCycleWidthHeight(distance, resistance, upperResistance, lowerResistance);
                        cubeList.Add(newCube);
                    }
                    cubeHelper = new CubeHelper(cubeList, Ybase);
                    cubeList = cubeHelper.getList();
                    for (int i = cubeNum - 1; i >= 0; i--)
                    {
                        runMachPanel.Controls.Add(cubeList[i]);
                        cubeList[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.cubeMouseDown);
                        cubeList[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.cubeMouseMove);
                    }

                    operatedSec = 1;

                    txDeviceType = new Label();
                    txDeviceType.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 20);
                    txDeviceType.Size = new System.Drawing.Size(80, 30);
                    txDeviceType.Text = "设备名：";

                    txDeviceTypeName = new Label();
                    txDeviceTypeName.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 20);
                    txDeviceType.Size = new System.Drawing.Size(80, 30);
                    txDeviceTypeName.Text = "立式健身车";

                    txSection = new Label();
                    txSection.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 60);
                    txSection.Size = new System.Drawing.Size(80, 30);
                    txSection.Text = "段  号：";

                    txSectionNumber = new Label();
                    txSectionNumber.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 60);
                    txSectionNumber.Size = new System.Drawing.Size(80, 30);
                    txSectionNumber.Text = "1";

                    txParameter1 = new Label();
                    txParameter1.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 100);
                    txParameter1.Size = new System.Drawing.Size(80, 30);
                    txParameter1.Text = "距  离：";

                    numberParameter1 = new NumericUpDown();
                    numberParameter1.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 95);
                    numberParameter1.Size = new System.Drawing.Size(80, 30);
                    numberParameter1.Maximum = 30000;
                    numberParameter1.Minimum = 0;
                    numberParameter1.Value = uprightCycleList[0].getDistance();

                    txParameter2 = new Label();
                    txParameter2.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 140);
                    txParameter2.Size = new System.Drawing.Size(80, 30);
                    txParameter2.Text = "阻  力：";

                    numberParameter2 = new NumericUpDown();
                    numberParameter2.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 135);
                    numberParameter2.Size = new System.Drawing.Size(80, 30);
                    numberParameter2.Maximum = uprightCycleList[0].getUpperResistance();
                    numberParameter2.Minimum = uprightCycleList[0].getLowerResistance();
                    numberParameter2.Value = uprightCycleList[0].getResistance();

                    txParameter3 = new Label();
                    txParameter3.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 180);
                    txParameter3.Size = new System.Drawing.Size(80, 30);
                    txParameter3.Text = "阻力上限：";

                    numberParameter3 = new NumericUpDown();
                    numberParameter3.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 175);
                    numberParameter3.Size = new System.Drawing.Size(80, 30);
                    numberParameter3.Maximum = 16;
                    numberParameter3.Minimum = uprightCycleList[0].getResistance();
                    numberParameter3.Value = uprightCycleList[0].getUpperResistance();

                    txParameter4 = new Label();
                    txParameter4.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 220);
                    txParameter4.Size = new System.Drawing.Size(80, 30);
                    txParameter4.Text = "阻力下限：";

                    numberParameter4 = new NumericUpDown();
                    numberParameter4.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 215);
                    numberParameter4.Size = new System.Drawing.Size(80, 30);
                    numberParameter4.Maximum = uprightCycleList[0].getResistance();
                    numberParameter4.Minimum = 1;
                    numberParameter4.Value = uprightCycleList[0].getLowerResistance();

                    this.Controls.Add(txDeviceType);
                    this.Controls.Add(txDeviceTypeName);
                    this.Controls.Add(txSection);
                    this.Controls.Add(txSectionNumber);
                    this.Controls.Add(txParameter1);
                    this.Controls.Add(numberParameter1);
                    this.Controls.Add(txParameter2);
                    this.Controls.Add(numberParameter2);
                    this.Controls.Add(txParameter3);
                    this.Controls.Add(numberParameter3);
                    this.Controls.Add(txParameter4);
                    this.Controls.Add(numberParameter4);

                    numberParameter1.ValueChanged += new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged += new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged += new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged += new System.EventHandler(this.numberParameter4_ValueChanged);

                    break;

                case 14:
                    deviceTypeDisplayNow = 14;
                    recumbentCycleList = devicehelper.setrecumbentCycleParameter(deviceList, planId);
                    for (int i = 0; i < cubeNum; i++)
                    {
                        newCube = new CubeControl(100, 100);
                        int distance = recumbentCycleList[i].getDistance();
                        int resistance = recumbentCycleList[i].getResistance();
                        int upperResistance = recumbentCycleList[i].getUpperResistance();
                        int lowerResistance = recumbentCycleList[i].getLowerResistance();
                        newCube.setRecumbentCycleWidthHeight(distance, resistance, upperResistance, lowerResistance);
                        cubeList.Add(newCube);
                    }
                    cubeHelper = new CubeHelper(cubeList, Ybase);
                    cubeList = cubeHelper.getList();
                    for (int i = cubeNum - 1; i >= 0; i--)
                    {
                        runMachPanel.Controls.Add(cubeList[i]);
                        cubeList[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.cubeMouseDown);
                        cubeList[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.cubeMouseMove);
                    }

                    operatedSec = 1;

                    txDeviceType = new Label();
                    txDeviceType.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 20);
                    txDeviceType.Size = new System.Drawing.Size(80, 30);
                    txDeviceType.Text = "设备名：";

                    txDeviceTypeName = new Label();
                    txDeviceTypeName.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 20);
                    txDeviceType.Size = new System.Drawing.Size(80, 30);
                    txDeviceTypeName.Text = "卧式健身车";

                    txSection = new Label();
                    txSection.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 60);
                    txSection.Size = new System.Drawing.Size(80, 30);
                    txSection.Text = "段  号：";

                    txSectionNumber = new Label();
                    txSectionNumber.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 60);
                    txSectionNumber.Size = new System.Drawing.Size(80, 30);
                    txSectionNumber.Text = "1";

                    txParameter1 = new Label();
                    txParameter1.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 100);
                    txParameter1.Size = new System.Drawing.Size(80, 30);
                    txParameter1.Text = "距  离：";

                    numberParameter1 = new NumericUpDown();
                    numberParameter1.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 95);
                    numberParameter1.Size = new System.Drawing.Size(80, 30);
                    numberParameter1.Maximum = 30000;
                    numberParameter1.Minimum = 0;
                    numberParameter1.Value = recumbentCycleList[0].getDistance();

                    txParameter2 = new Label();
                    txParameter2.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 140);
                    txParameter2.Size = new System.Drawing.Size(80, 30);
                    txParameter2.Text = "阻  力：";

                    numberParameter2 = new NumericUpDown();
                    numberParameter2.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 135);
                    numberParameter2.Size = new System.Drawing.Size(80, 30);
                    numberParameter2.Maximum = recumbentCycleList[0].getUpperResistance();
                    numberParameter2.Minimum = recumbentCycleList[0].getLowerResistance();
                    numberParameter2.Value = recumbentCycleList[0].getResistance();

                    txParameter3 = new Label();
                    txParameter3.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 180);
                    txParameter3.Size = new System.Drawing.Size(80, 30);
                    txParameter3.Text = "阻力上限：";

                    numberParameter3 = new NumericUpDown();
                    numberParameter3.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 175);
                    numberParameter3.Size = new System.Drawing.Size(80, 30);
                    numberParameter3.Maximum = 15;
                    numberParameter3.Minimum = recumbentCycleList[0].getResistance();
                    numberParameter3.Value = recumbentCycleList[0].getUpperResistance();

                    txParameter4 = new Label();
                    txParameter4.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 220);
                    txParameter4.Size = new System.Drawing.Size(80, 30);
                    txParameter4.Text = "阻力下限：";

                    numberParameter4 = new NumericUpDown();
                    numberParameter4.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 215);
                    numberParameter4.Size = new System.Drawing.Size(80, 30);
                    numberParameter4.Maximum = recumbentCycleList[0].getResistance();
                    numberParameter4.Minimum = 1;
                    numberParameter4.Value = recumbentCycleList[0].getLowerResistance();

                    this.Controls.Add(txDeviceType);
                    this.Controls.Add(txDeviceTypeName);
                    this.Controls.Add(txSection);
                    this.Controls.Add(txSectionNumber);
                    this.Controls.Add(txParameter1);
                    this.Controls.Add(numberParameter1);
                    this.Controls.Add(txParameter2);
                    this.Controls.Add(numberParameter2);
                    this.Controls.Add(txParameter3);
                    this.Controls.Add(numberParameter3);
                    this.Controls.Add(txParameter4);
                    this.Controls.Add(numberParameter4);

                    numberParameter1.ValueChanged += new System.EventHandler(this.numberParameter1_ValueChanged);
                    numberParameter2.ValueChanged += new System.EventHandler(this.numberParameter2_ValueChanged);
                    numberParameter3.ValueChanged += new System.EventHandler(this.numberParameter3_ValueChanged);
                    numberParameter4.ValueChanged += new System.EventHandler(this.numberParameter4_ValueChanged);

                    break;

                case 6:
                    deviceTypeDisplayNow = 6;
                    ecpList = devicehelper.setecpParameter(deviceList, planId);
                    for (int i = 0; i < cubeNum; i++)
                    {
                        newCube = new CubeControl(100, 100);
                        int time = ecpList[i].getTime();
                        int exPressure = ecpList[i].getExPressure();
                        int upperExPressure = ecpList[i].getUpperExPressure();
                        int lowerExPressure = ecpList[i].getLowerExPressure();
                        newCube.setECPWidthHeight(time, exPressure, upperExPressure, lowerExPressure);
                        cubeList.Add(newCube);
                    }
                    int LowerR2I = ecpList[0].getLowerR2I();
                    //int width = cubeList[1].Width;
                    cubeHelper = new CubeHelper(cubeList, Ybase);
                    cubeList = cubeHelper.getList();
                    for (int i = cubeNum - 1; i >= 0; i--)
                    {
                        runMachPanel.Controls.Add(cubeList[i]);
                        cubeList[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.cubeMouseDown);
                        cubeList[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.cubeMouseMove);
                    }

                    operatedSec = 1;

                    txDeviceType = new Label();
                    txDeviceType.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 20);
                    txDeviceType.Size = new System.Drawing.Size(80, 30);
                    txDeviceType.Text = "设备名：";

                    txDeviceTypeName = new Label();
                    txDeviceTypeName.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 20);
                    txDeviceType.Size = new System.Drawing.Size(80, 30);
                    txDeviceTypeName.Text = "体外反搏";

                    txSection = new Label();
                    txSection.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 60);
                    txSection.Size = new System.Drawing.Size(80, 30);
                    txSection.Text = "段  号：";

                    txSectionNumber = new Label();
                    txSectionNumber.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 60);
                    txSectionNumber.Size = new System.Drawing.Size(80, 30);
                    txSectionNumber.Text = "1";

                    txParameter1 = new Label();
                    txParameter1.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 100);
                    txParameter1.Size = new System.Drawing.Size(80, 30);
                    txParameter1.Text = "时  间：";

                    numberParameter1 = new NumericUpDown();
                    numberParameter1.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 95);
                    numberParameter1.Size = new System.Drawing.Size(80, 30);
                    numberParameter1.Maximum = 30000;
                    numberParameter1.Minimum = 0;
                    numberParameter1.Value = ecpList[0].getTime();

                    txParameter2 = new Label();
                    txParameter2.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 140);
                    txParameter2.Size = new System.Drawing.Size(80, 30);
                    txParameter2.Text = "期望压力：";

                    numberParameter2 = new NumericUpDown();
                    numberParameter2.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 135);
                    numberParameter2.Size = new System.Drawing.Size(80, 30);
                    numberParameter2.Maximum = ecpList[0].getUpperExPressure();
                    numberParameter2.Minimum = ecpList[0].getLowerExPressure();
                    numberParameter2.Value = ecpList[0].getExPressure();

                    txParameter3 = new Label();
                    txParameter3.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 180);
                    txParameter3.Size = new System.Drawing.Size(80, 30);
                    txParameter3.Text = "压力上限：";

                    numberParameter3 = new NumericUpDown();
                    numberParameter3.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 175);
                    numberParameter3.Size = new System.Drawing.Size(80, 30);
                    numberParameter3.Maximum = 70;
                    numberParameter3.Minimum = ecpList[0].getExPressure();
                    numberParameter3.Value = ecpList[0].getUpperExPressure();

                    txParameter4 = new Label();
                    txParameter4.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 220);
                    txParameter4.Size = new System.Drawing.Size(80, 30);
                    txParameter4.Text = "压力下限：";

                    numberParameter4 = new NumericUpDown();
                    numberParameter4.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 215);
                    numberParameter4.Size = new System.Drawing.Size(80, 30);
                    numberParameter4.Maximum = ecpList[0].getExPressure();
                    numberParameter4.Minimum = 1;
                    numberParameter4.Value = ecpList[0].getLowerExPressure();

                    ////
                    txParameter5 = new Label();
                    txParameter5.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 260);
                    txParameter5.Size = new System.Drawing.Size(80, 30);
                    txParameter5.Text = "R2I偏移：";

                    numberParameter5 = new NumericUpDown();
                    numberParameter5.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 255);
                    numberParameter5.Size = new System.Drawing.Size(80, 30);
                    numberParameter5.Maximum = ecpList[0].getUpperR2I();
                    numberParameter5.Minimum = ecpList[0].getLowerR2I();
                    numberParameter5.Value = ecpList[0].getR2I();

                    txParameter6 = new Label();
                    txParameter6.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 300);
                    txParameter6.Size = new System.Drawing.Size(80, 30);
                    txParameter6.Text = "R2I上限：";

                    numberParameter6 = new NumericUpDown();
                    numberParameter6.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 295);
                    numberParameter6.Size = new System.Drawing.Size(80, 30);
                    numberParameter6.Maximum = 500;
                    numberParameter6.Minimum = ecpList[0].getR2I();
                    numberParameter6.Value = ecpList[0].getUpperR2I();

                    txParameter7 = new Label();
                    txParameter7.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 340);
                    txParameter7.Size = new System.Drawing.Size(80, 30);
                    txParameter7.Text = "R2I下限：";

                    numberParameter7 = new NumericUpDown();
                    numberParameter7.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 335);
                    numberParameter7.Size = new System.Drawing.Size(80, 30);
                    numberParameter7.Maximum = ecpList[0].getR2I();
                    numberParameter7.Minimum = 1;
                    numberParameter7.Value = ecpList[0].getLowerR2I();
                    ///

                    txParameter8 = new Label();
                    txParameter8.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 380);
                    txParameter8.Size = new System.Drawing.Size(80, 30);
                    txParameter8.Text = "R2D偏移：";

                    numberParameter8 = new NumericUpDown();
                    numberParameter8.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 375);
                    numberParameter8.Size = new System.Drawing.Size(80, 30);
                    numberParameter8.Maximum = ecpList[0].getUpperR2D();
                    numberParameter8.Minimum = ecpList[0].getLowerR2D();
                    numberParameter8.Value = ecpList[0].getR2D();

                    txParameter9 = new Label();
                    txParameter9.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 420);
                    txParameter9.Size = new System.Drawing.Size(80, 30);
                    txParameter9.Text = "R2D上限：";

                    numberParameter9 = new NumericUpDown();
                    numberParameter9.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 415);
                    numberParameter9.Size = new System.Drawing.Size(80, 30);
                    numberParameter9.Maximum = 500;
                    numberParameter9.Minimum = ecpList[0].getR2D();
                    numberParameter9.Value = ecpList[0].getUpperR2D();

                    txParameter10 = new Label();
                    txParameter10.Location = new Point(width - 280, labelPanel.Location.Y + labelPanel.Height + 460);
                    txParameter10.Size = new System.Drawing.Size(80, 30);
                    txParameter10.Text = "R2D下限：";

                    numberParameter10 = new NumericUpDown();
                    numberParameter10.Location = new Point(width - 200, labelPanel.Location.Y + labelPanel.Height + 455);
                    numberParameter10.Size = new System.Drawing.Size(80, 30);
                    numberParameter10.Maximum = ecpList[0].getR2D();
                    numberParameter10.Minimum = 1;
                    numberParameter10.Value = ecpList[0].getLowerR2D();

                    ///
                    this.Controls.Add(txDeviceType);
                    this.Controls.Add(txDeviceTypeName);
                    this.Controls.Add(txSection);
                    this.Controls.Add(txSectionNumber);
                    this.Controls.Add(txParameter1);
                    this.Controls.Add(numberParameter1);
                    this.Controls.Add(txParameter2);
                    this.Controls.Add(numberParameter2);
                    this.Controls.Add(txParameter3);
                    this.Controls.Add(numberParameter3);
                    this.Controls.Add(txParameter4);
                    this.Controls.Add(numberParameter4);
                    this.Controls.Add(txParameter5);
                    this.Controls.Add(numberParameter5);
                    this.Controls.Add(txParameter6);
                    this.Controls.Add(numberParameter6);
                    this.Controls.Add(txParameter7);
                    this.Controls.Add(numberParameter7);
                    this.Controls.Add(txParameter8);
                    this.Controls.Add(numberParameter8);
                    this.Controls.Add(txParameter9);
                    this.Controls.Add(numberParameter9);
                    this.Controls.Add(txParameter10);
                    this.Controls.Add(numberParameter10);

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


        public void  addLabelCaseHoverListener(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand; 
        }
        public void  addLabelCaseLeaveListener(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

