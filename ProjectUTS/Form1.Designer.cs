namespace ProjectUTS
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mapProgressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.countdowntimer = new System.Windows.Forms.Timer(this.components);
            this.production_box = new System.Windows.Forms.GroupBox();
            this.cropPerHour = new System.Windows.Forms.Label();
            this.woodPerHour = new System.Windows.Forms.Label();
            this.ironPerHour = new System.Windows.Forms.Label();
            this.clayPerHour = new System.Windows.Forms.Label();
            this.cropBox = new System.Windows.Forms.Label();
            this.woodBox = new System.Windows.Forms.Label();
            this.ironBox = new System.Windows.Forms.Label();
            this.clayBox = new System.Windows.Forms.Label();
            this.buildingBox = new System.Windows.Forms.GroupBox();
            this.timeNeeded = new System.Windows.Forms.Label();
            this.buildingDetails = new System.Windows.Forms.Label();
            this.upgradeButton = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.GroupBox();
            this.countDown = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mapProgressBindingSource)).BeginInit();
            this.production_box.SuspendLayout();
            this.buildingBox.SuspendLayout();
            this.Timer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clay";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Iron";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(131, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Wood";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(200, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Crop";
            // 
            // mapProgressBindingSource
            // 
            this.mapProgressBindingSource.DataMember = "MapProgress";
            // 
            // countdowntimer
            // 
            this.countdowntimer.Interval = 1000;
            this.countdowntimer.Tick += new System.EventHandler(this.countdowntimer_Tick);
            // 
            // production_box
            // 
            this.production_box.Controls.Add(this.cropPerHour);
            this.production_box.Controls.Add(this.woodPerHour);
            this.production_box.Controls.Add(this.ironPerHour);
            this.production_box.Controls.Add(this.clayPerHour);
            this.production_box.Controls.Add(this.cropBox);
            this.production_box.Controls.Add(this.woodBox);
            this.production_box.Controls.Add(this.ironBox);
            this.production_box.Controls.Add(this.clayBox);
            this.production_box.Location = new System.Drawing.Point(1017, 12);
            this.production_box.Name = "production_box";
            this.production_box.Size = new System.Drawing.Size(233, 190);
            this.production_box.TabIndex = 5;
            this.production_box.TabStop = false;
            this.production_box.Text = "Production Per Hour";
            // 
            // cropPerHour
            // 
            this.cropPerHour.AutoSize = true;
            this.cropPerHour.Location = new System.Drawing.Point(57, 113);
            this.cropPerHour.Name = "cropPerHour";
            this.cropPerHour.Size = new System.Drawing.Size(10, 13);
            this.cropPerHour.TabIndex = 7;
            this.cropPerHour.Text = ".";
            // 
            // woodPerHour
            // 
            this.woodPerHour.AutoSize = true;
            this.woodPerHour.Location = new System.Drawing.Point(64, 87);
            this.woodPerHour.Name = "woodPerHour";
            this.woodPerHour.Size = new System.Drawing.Size(10, 13);
            this.woodPerHour.TabIndex = 6;
            this.woodPerHour.Text = ".";
            // 
            // ironPerHour
            // 
            this.ironPerHour.AutoSize = true;
            this.ironPerHour.Location = new System.Drawing.Point(49, 58);
            this.ironPerHour.Name = "ironPerHour";
            this.ironPerHour.Size = new System.Drawing.Size(10, 13);
            this.ironPerHour.TabIndex = 5;
            this.ironPerHour.Text = ".";
            // 
            // clayPerHour
            // 
            this.clayPerHour.AutoSize = true;
            this.clayPerHour.Location = new System.Drawing.Point(49, 29);
            this.clayPerHour.Name = "clayPerHour";
            this.clayPerHour.Size = new System.Drawing.Size(10, 13);
            this.clayPerHour.TabIndex = 4;
            this.clayPerHour.Text = ".";
            // 
            // cropBox
            // 
            this.cropBox.AutoSize = true;
            this.cropBox.Location = new System.Drawing.Point(16, 113);
            this.cropBox.Name = "cropBox";
            this.cropBox.Size = new System.Drawing.Size(35, 13);
            this.cropBox.TabIndex = 3;
            this.cropBox.Text = "Crop :";
            // 
            // woodBox
            // 
            this.woodBox.AutoSize = true;
            this.woodBox.Location = new System.Drawing.Point(16, 87);
            this.woodBox.Name = "woodBox";
            this.woodBox.Size = new System.Drawing.Size(42, 13);
            this.woodBox.TabIndex = 2;
            this.woodBox.Text = "Wood :";
            // 
            // ironBox
            // 
            this.ironBox.AutoSize = true;
            this.ironBox.Location = new System.Drawing.Point(16, 58);
            this.ironBox.Name = "ironBox";
            this.ironBox.Size = new System.Drawing.Size(31, 13);
            this.ironBox.TabIndex = 1;
            this.ironBox.Text = "Iron :";
            // 
            // clayBox
            // 
            this.clayBox.AutoSize = true;
            this.clayBox.Location = new System.Drawing.Point(16, 29);
            this.clayBox.Name = "clayBox";
            this.clayBox.Size = new System.Drawing.Size(33, 13);
            this.clayBox.TabIndex = 0;
            this.clayBox.Text = "Clay :";
            // 
            // buildingBox
            // 
            this.buildingBox.Controls.Add(this.timeNeeded);
            this.buildingBox.Controls.Add(this.buildingDetails);
            this.buildingBox.Controls.Add(this.upgradeButton);
            this.buildingBox.Location = new System.Drawing.Point(1017, 220);
            this.buildingBox.Name = "buildingBox";
            this.buildingBox.Size = new System.Drawing.Size(233, 445);
            this.buildingBox.TabIndex = 0;
            this.buildingBox.TabStop = false;
            this.buildingBox.Text = "Building Details";
            // 
            // timeNeeded
            // 
            this.timeNeeded.AutoSize = true;
            this.timeNeeded.Location = new System.Drawing.Point(16, 87);
            this.timeNeeded.Name = "timeNeeded";
            this.timeNeeded.Size = new System.Drawing.Size(10, 13);
            this.timeNeeded.TabIndex = 9;
            this.timeNeeded.Text = ".";
            // 
            // buildingDetails
            // 
            this.buildingDetails.AutoSize = true;
            this.buildingDetails.Location = new System.Drawing.Point(16, 30);
            this.buildingDetails.Name = "buildingDetails";
            this.buildingDetails.Size = new System.Drawing.Size(10, 13);
            this.buildingDetails.TabIndex = 8;
            this.buildingDetails.Text = ".";
            // 
            // upgradeButton
            // 
            this.upgradeButton.Location = new System.Drawing.Point(52, 353);
            this.upgradeButton.Name = "upgradeButton";
            this.upgradeButton.Size = new System.Drawing.Size(131, 37);
            this.upgradeButton.TabIndex = 0;
            this.upgradeButton.Text = "Upgrade";
            this.upgradeButton.UseVisualStyleBackColor = true;
            this.upgradeButton.Click += new System.EventHandler(this.upgradeButton_Click);
            // 
            // Timer
            // 
            this.Timer.Controls.Add(this.countDown);
            this.Timer.Location = new System.Drawing.Point(13, 688);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(1139, 57);
            this.Timer.TabIndex = 6;
            this.Timer.TabStop = false;
            this.Timer.Text = "Countdown";
            // 
            // countDown
            // 
            this.countDown.AutoSize = true;
            this.countDown.Location = new System.Drawing.Point(20, 28);
            this.countDown.Name = "countDown";
            this.countDown.Size = new System.Drawing.Size(10, 13);
            this.countDown.TabIndex = 0;
            this.countDown.Text = ".";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 816);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.buildingBox);
            this.Controls.Add(this.production_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.mapProgressBindingSource)).EndInit();
            this.production_box.ResumeLayout(false);
            this.production_box.PerformLayout();
            this.buildingBox.ResumeLayout(false);
            this.buildingBox.PerformLayout();
            this.Timer.ResumeLayout(false);
            this.Timer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource mapProgressBindingSource;
        private System.Windows.Forms.Timer countdowntimer;
        private System.Windows.Forms.GroupBox production_box;
        private System.Windows.Forms.GroupBox buildingBox;
        private System.Windows.Forms.Button upgradeButton;
        private System.Windows.Forms.Label cropPerHour;
        private System.Windows.Forms.Label woodPerHour;
        private System.Windows.Forms.Label ironPerHour;
        private System.Windows.Forms.Label clayPerHour;
        private System.Windows.Forms.Label cropBox;
        private System.Windows.Forms.Label woodBox;
        private System.Windows.Forms.Label ironBox;
        private System.Windows.Forms.Label clayBox;
        private System.Windows.Forms.Label timeNeeded;
        private System.Windows.Forms.Label buildingDetails;
        private System.Windows.Forms.GroupBox Timer;
        private System.Windows.Forms.Label countDown;
        private System.Windows.Forms.Timer gameTimer;
    }
}

