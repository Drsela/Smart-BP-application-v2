using Mock_up_GUI;

namespace PL
{
    partial class Calibrate
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
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.calibrateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.verticalProgressbar4 = new Mock_up_GUI.VerticalProgressbar();
            this.verticalProgressbar3 = new Mock_up_GUI.VerticalProgressbar();
            this.verticalProgressbar1 = new Mock_up_GUI.VerticalProgressbar();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(666, 29);
            this.label2.TabIndex = 22;
            this.label2.Text = "Apply 10 mmHg preassure and click the Calibrate button.";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(940, 517);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 43);
            this.button1.TabIndex = 21;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // calibrateButton
            // 
            this.calibrateButton.BackColor = System.Drawing.Color.White;
            this.calibrateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.calibrateButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibrateButton.Location = new System.Drawing.Point(139, 517);
            this.calibrateButton.Margin = new System.Windows.Forms.Padding(4);
            this.calibrateButton.Name = "calibrateButton";
            this.calibrateButton.Size = new System.Drawing.Size(140, 43);
            this.calibrateButton.TabIndex = 20;
            this.calibrateButton.Text = "Calibrate";
            this.calibrateButton.UseVisualStyleBackColor = false;
            this.calibrateButton.Click += new System.EventHandler(this.calibrateButton_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(135, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "10 mmHg";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(575, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 24);
            this.label3.TabIndex = 33;
            this.label3.Text = "50 mmHg";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(971, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 24);
            this.label4.TabIndex = 34;
            this.label4.Text = "100 mmHg";
            // 
            // verticalProgressbar4
            // 
            this.verticalProgressbar4.BackColor = System.Drawing.Color.Blue;
            this.verticalProgressbar4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.verticalProgressbar4.Location = new System.Drawing.Point(940, 143);
            this.verticalProgressbar4.MarqueeAnimationSpeed = 2500;
            this.verticalProgressbar4.Name = "verticalProgressbar4";
            this.verticalProgressbar4.Size = new System.Drawing.Size(180, 298);
            this.verticalProgressbar4.TabIndex = 40;
            this.verticalProgressbar4.Value = 99;
            // 
            // verticalProgressbar3
            // 
            this.verticalProgressbar3.Location = new System.Drawing.Point(539, 143);
            this.verticalProgressbar3.MarqueeAnimationSpeed = 10000;
            this.verticalProgressbar3.Name = "verticalProgressbar3";
            this.verticalProgressbar3.Size = new System.Drawing.Size(180, 298);
            this.verticalProgressbar3.TabIndex = 39;
            this.verticalProgressbar3.Value = 50;
            // 
            // verticalProgressbar1
            // 
            this.verticalProgressbar1.Location = new System.Drawing.Point(99, 143);
            this.verticalProgressbar1.Name = "verticalProgressbar1";
            this.verticalProgressbar1.Size = new System.Drawing.Size(180, 298);
            this.verticalProgressbar1.TabIndex = 37;
            this.verticalProgressbar1.Value = 10;
            // 
            // Calibrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1222, 622);
            this.Controls.Add(this.verticalProgressbar4);
            this.Controls.Add(this.verticalProgressbar3);
            this.Controls.Add(this.verticalProgressbar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.calibrateButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Calibrate";
            this.Text = "Calibrate";
            this.Load += new System.EventHandler(this.Calibrate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button calibrateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private VerticalProgressbar verticalProgressbar1;
        private VerticalProgressbar verticalProgressbar3;
        private VerticalProgressbar verticalProgressbar4;
    }
}