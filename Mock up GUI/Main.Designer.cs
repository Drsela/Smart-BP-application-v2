using System.Drawing;

namespace PL
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.upperTrackBar = new System.Windows.Forms.TrackBar();
            this.lowerTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.muteButton = new System.Windows.Forms.Button();
            this.monitorRadioButton = new System.Windows.Forms.RadioButton();
            this.diagnoseRadioButton = new System.Windows.Forms.RadioButton();
            this.UpperlimitText = new System.Windows.Forms.TextBox();
            this.LowerlimitText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerTrackBar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            this.chart1.BorderSkin.BorderColor = System.Drawing.Color.Empty;
            chartArea8.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.AxisX.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX.Title = "Tid (s)";
            chartArea8.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea8.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.AxisY.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.Title = "Blodtryk (mmHg)";
            chartArea8.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea8.BackColor = System.Drawing.Color.Black;
            chartArea8.BorderColor = System.Drawing.Color.White;
            chartArea8.BorderWidth = 4;
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            legend8.HeaderSeparatorColor = System.Drawing.Color.White;
            legend8.Name = "Legend1";
            this.chart1.Legends.Add(legend8);
            this.chart1.Location = new System.Drawing.Point(-60, 15);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series8.BorderWidth = 6;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series8.IsVisibleInLegend = false;
            series8.Legend = "Legend1";
            series8.Name = "Blodtryk";
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(1814, 847);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(0, 870);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 160);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Red;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stopButton.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.stopButton.Location = new System.Drawing.Point(1728, 870);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(209, 165);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "EXIT";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(204, 870);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 160);
            this.button3.TabIndex = 3;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(-4, -18);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(404, 154);
            this.button4.TabIndex = 4;
            this.button4.Text = "Calibrate";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.AutoSize = true;
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.button5.Location = new System.Drawing.Point(-4, -10);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(404, 144);
            this.button5.TabIndex = 5;
            this.button5.Text = "Zero point";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // upperTrackBar
            // 
            this.upperTrackBar.Location = new System.Drawing.Point(611, 906);
            this.upperTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.upperTrackBar.Maximum = 270;
            this.upperTrackBar.Minimum = 30;
            this.upperTrackBar.Name = "upperTrackBar";
            this.upperTrackBar.Size = new System.Drawing.Size(375, 56);
            this.upperTrackBar.TabIndex = 6;
            this.upperTrackBar.Value = 144;
            this.upperTrackBar.Scroll += new System.EventHandler(this.upperTrackBar_Scroll);
            // 
            // lowerTrackBar
            // 
            this.lowerTrackBar.Location = new System.Drawing.Point(611, 979);
            this.lowerTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.lowerTrackBar.Maximum = 150;
            this.lowerTrackBar.Minimum = 10;
            this.lowerTrackBar.Name = "lowerTrackBar";
            this.lowerTrackBar.Size = new System.Drawing.Size(375, 56);
            this.lowerTrackBar.TabIndex = 7;
            this.lowerTrackBar.Value = 64;
            this.lowerTrackBar.Scroll += new System.EventHandler(this.lowerTrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(775, 870);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Limits";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(412, 906);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Upper systolic limit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(412, 981);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lower diastolic limit";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.button6.Location = new System.Drawing.Point(1115, 870);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(200, 80);
            this.button6.TabIndex = 11;
            this.button6.Text = "Adjust BP";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Font = new System.Drawing.Font("Arial", 60F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.LimeGreen;
            this.textBox1.Location = new System.Drawing.Point(1677, 80);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(243, 122);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "00";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.Font = new System.Drawing.Font("Arial", 60F, System.Drawing.FontStyle.Bold);
            this.textBox2.ForeColor = System.Drawing.Color.Red;
            this.textBox2.Location = new System.Drawing.Point(1677, 400);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.MaxLength = 3;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(244, 122);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "00";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Black;
            this.textBox3.Font = new System.Drawing.Font("Arial", 60F, System.Drawing.FontStyle.Bold);
            this.textBox3.ForeColor = System.Drawing.Color.Red;
            this.textBox3.Location = new System.Drawing.Point(1677, 240);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.MaxLength = 3;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(243, 122);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "00";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1675, 215);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 30);
            this.label4.TabIndex = 15;
            this.label4.Text = "Systolic";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1675, 377);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 30);
            this.label5.TabIndex = 16;
            this.label5.Text = "Diastolic";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1676, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 30);
            this.label6.TabIndex = 17;
            this.label6.Text = "Pulse";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Black;
            this.textBox4.Font = new System.Drawing.Font("Arial", 60F, System.Drawing.FontStyle.Bold);
            this.textBox4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.textBox4.Location = new System.Drawing.Point(1677, 560);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.MaxLength = 3;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(243, 122);
            this.textBox4.TabIndex = 18;
            this.textBox4.Text = "00";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1677, 537);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 30);
            this.label7.TabIndex = 19;
            this.label7.Text = "Mean";
            // 
            // muteButton
            // 
            this.muteButton.BackColor = System.Drawing.Color.White;
            this.muteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.muteButton.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.muteButton.Location = new System.Drawing.Point(1115, 954);
            this.muteButton.Margin = new System.Windows.Forms.Padding(4);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(200, 80);
            this.muteButton.TabIndex = 20;
            this.muteButton.Text = "Mute";
            this.muteButton.UseVisualStyleBackColor = false;
            this.muteButton.Click += new System.EventHandler(this.muteButton_Click);
            // 
            // monitorRadioButton
            // 
            this.monitorRadioButton.AutoSize = true;
            this.monitorRadioButton.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.monitorRadioButton.ForeColor = System.Drawing.Color.White;
            this.monitorRadioButton.Location = new System.Drawing.Point(1677, 722);
            this.monitorRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.monitorRadioButton.Name = "monitorRadioButton";
            this.monitorRadioButton.Size = new System.Drawing.Size(220, 36);
            this.monitorRadioButton.TabIndex = 21;
            this.monitorRadioButton.TabStop = true;
            this.monitorRadioButton.Text = "Monitor-mode";
            this.monitorRadioButton.UseVisualStyleBackColor = true;
            this.monitorRadioButton.CheckedChanged += new System.EventHandler(this.monitorRadioButton_CheckedChanged);
            // 
            // diagnoseRadioButton
            // 
            this.diagnoseRadioButton.AutoSize = true;
            this.diagnoseRadioButton.Font = new System.Drawing.Font("Arial", 16F);
            this.diagnoseRadioButton.ForeColor = System.Drawing.Color.White;
            this.diagnoseRadioButton.Location = new System.Drawing.Point(1677, 766);
            this.diagnoseRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.diagnoseRadioButton.Name = "diagnoseRadioButton";
            this.diagnoseRadioButton.Size = new System.Drawing.Size(227, 36);
            this.diagnoseRadioButton.TabIndex = 22;
            this.diagnoseRadioButton.TabStop = true;
            this.diagnoseRadioButton.Text = "Diagnose-mode";
            this.diagnoseRadioButton.UseVisualStyleBackColor = true;
            this.diagnoseRadioButton.CheckedChanged += new System.EventHandler(this.diagnoseRadioButton_CheckedChanged);
            // 
            // UpperlimitText
            // 
            this.UpperlimitText.BackColor = System.Drawing.Color.Black;
            this.UpperlimitText.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            this.UpperlimitText.ForeColor = System.Drawing.Color.DodgerBlue;
            this.UpperlimitText.Location = new System.Drawing.Point(994, 887);
            this.UpperlimitText.Margin = new System.Windows.Forms.Padding(4);
            this.UpperlimitText.MaxLength = 3;
            this.UpperlimitText.Name = "UpperlimitText";
            this.UpperlimitText.Size = new System.Drawing.Size(99, 69);
            this.UpperlimitText.TabIndex = 23;
            this.UpperlimitText.Text = "144";
            this.UpperlimitText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LowerlimitText
            // 
            this.LowerlimitText.BackColor = System.Drawing.Color.Black;
            this.LowerlimitText.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            this.LowerlimitText.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LowerlimitText.Location = new System.Drawing.Point(994, 965);
            this.LowerlimitText.Margin = new System.Windows.Forms.Padding(4);
            this.LowerlimitText.MaxLength = 3;
            this.LowerlimitText.Name = "LowerlimitText";
            this.LowerlimitText.Size = new System.Drawing.Size(99, 69);
            this.LowerlimitText.TabIndex = 24;
            this.LowerlimitText.Text = "64";
            this.LowerlimitText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 20F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(840, 813);
            this.label8.MinimumSize = new System.Drawing.Size(100, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 39);
            this.label8.TabIndex = 25;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Arial", 12F);
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 21);
            this.tabControl1.Location = new System.Drawing.Point(1320, 871);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(404, 161);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(396, 132);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "User";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Black;
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(396, 132);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Technician";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1924, 1033);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LowerlimitText);
            this.Controls.Add(this.UpperlimitText);
            this.Controls.Add(this.diagnoseRadioButton);
            this.Controls.Add(this.monitorRadioButton);
            this.Controls.Add(this.muteButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lowerTrackBar);
            this.Controls.Add(this.upperTrackBar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerTrackBar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TrackBar upperTrackBar;
        private System.Windows.Forms.TrackBar lowerTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button muteButton;
        private System.Windows.Forms.RadioButton monitorRadioButton;
        private System.Windows.Forms.RadioButton diagnoseRadioButton;
        private System.Windows.Forms.TextBox UpperlimitText;
        private System.Windows.Forms.TextBox LowerlimitText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

