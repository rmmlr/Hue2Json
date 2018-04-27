namespace Rca.Hue2Json.View
{
    partial class CapabilityView
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapabilityView));
            this.cat_Capabilities = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbl_Sensors = new System.Windows.Forms.Label();
            this.lbl_Groups = new System.Windows.Forms.Label();
            this.lbl_Lights = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_Schedules = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.llb_Rules = new System.Windows.Forms.LinkLabel();
            this.lbl_Resourcelinks = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cat_Capabilities)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cat_Capabilities
            // 
            chartArea1.Name = "ChartArea1";
            this.cat_Capabilities.ChartAreas.Add(chartArea1);
            this.cat_Capabilities.Location = new System.Drawing.Point(12, 12);
            this.cat_Capabilities.Name = "cat_Capabilities";
            this.cat_Capabilities.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.cat_Capabilities.Series.Add(series1);
            this.cat_Capabilities.Size = new System.Drawing.Size(572, 300);
            this.cat_Capabilities.TabIndex = 0;
            this.cat_Capabilities.Text = "chart1";
            // 
            // lbl_Sensors
            // 
            this.lbl_Sensors.AutoSize = true;
            this.lbl_Sensors.Location = new System.Drawing.Point(146, 61);
            this.lbl_Sensors.Name = "lbl_Sensors";
            this.lbl_Sensors.Size = new System.Drawing.Size(61, 13);
            this.lbl_Sensors.TabIndex = 5;
            this.lbl_Sensors.Text = "lbl_Sensors";
            // 
            // lbl_Groups
            // 
            this.lbl_Groups.AutoSize = true;
            this.lbl_Groups.Location = new System.Drawing.Point(146, 87);
            this.lbl_Groups.Name = "lbl_Groups";
            this.lbl_Groups.Size = new System.Drawing.Size(57, 13);
            this.lbl_Groups.TabIndex = 6;
            this.lbl_Groups.Text = "lbl_Groups";
            // 
            // lbl_Lights
            // 
            this.lbl_Lights.AutoSize = true;
            this.lbl_Lights.Location = new System.Drawing.Point(146, 35);
            this.lbl_Lights.Name = "lbl_Lights";
            this.lbl_Lights.Size = new System.Drawing.Size(51, 13);
            this.lbl_Lights.TabIndex = 4;
            this.lbl_Lights.Text = "lbl_Lights";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Sensoren:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Gruppen:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(35, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Leuchtmittel:";
            // 
            // lbl_Schedules
            // 
            this.lbl_Schedules.AutoSize = true;
            this.lbl_Schedules.Location = new System.Drawing.Point(403, 33);
            this.lbl_Schedules.Name = "lbl_Schedules";
            this.lbl_Schedules.Size = new System.Drawing.Size(73, 13);
            this.lbl_Schedules.TabIndex = 10;
            this.lbl_Schedules.Text = "lbl_Schedules";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(292, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Timer:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Regeln:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.llb_Rules);
            this.groupBox1.Controls.Add(this.lbl_Resourcelinks);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lbl_Schedules);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbl_Lights);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lbl_Groups);
            this.groupBox1.Controls.Add(this.lbl_Sensors);
            this.groupBox1.Location = new System.Drawing.Point(12, 335);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 120);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bridge-Belegung";
            // 
            // llb_Rules
            // 
            this.llb_Rules.AutoSize = true;
            this.llb_Rules.Location = new System.Drawing.Point(403, 60);
            this.llb_Rules.Name = "llb_Rules";
            this.llb_Rules.Size = new System.Drawing.Size(50, 13);
            this.llb_Rules.TabIndex = 14;
            this.llb_Rules.TabStop = true;
            this.llb_Rules.Text = "llb_Rules";
            this.llb_Rules.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llb_Rules_LinkClicked);
            // 
            // lbl_Resourcelinks
            // 
            this.lbl_Resourcelinks.AutoSize = true;
            this.lbl_Resourcelinks.Location = new System.Drawing.Point(403, 87);
            this.lbl_Resourcelinks.Name = "lbl_Resourcelinks";
            this.lbl_Resourcelinks.Size = new System.Drawing.Size(90, 13);
            this.lbl_Resourcelinks.TabIndex = 13;
            this.lbl_Resourcelinks.Text = "lbl_Resourcelinks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Links:";
            // 
            // CapabilityView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 468);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cat_Capabilities);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(614, 506);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(614, 506);
            this.Name = "CapabilityView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CapabilityView";
            ((System.ComponentModel.ISupportInitialize)(this.cat_Capabilities)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart cat_Capabilities;
        private System.Windows.Forms.Label lbl_Sensors;
        private System.Windows.Forms.Label lbl_Groups;
        private System.Windows.Forms.Label lbl_Lights;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_Schedules;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Resourcelinks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel llb_Rules;
    }
}