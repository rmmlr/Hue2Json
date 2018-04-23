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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cat_Capabilities = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_Conditions = new System.Windows.Forms.Label();
            this.lbl_Actions = new System.Windows.Forms.Label();
            this.lbl_Rules = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_ActionsPerRule = new System.Windows.Forms.Label();
            this.lbl_FreeSpace = new System.Windows.Forms.Label();
            this.lbl_ConditionsPerRule = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cat_Capabilities)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cat_Capabilities
            // 
            chartArea2.Name = "ChartArea1";
            this.cat_Capabilities.ChartAreas.Add(chartArea2);
            this.cat_Capabilities.Location = new System.Drawing.Point(12, 12);
            this.cat_Capabilities.Name = "cat_Capabilities";
            this.cat_Capabilities.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.cat_Capabilities.Series.Add(series2);
            this.cat_Capabilities.Size = new System.Drawing.Size(345, 300);
            this.cat_Capabilities.TabIndex = 0;
            this.cat_Capabilities.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Regeln:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bedingungen:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Aktionen:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Conditions);
            this.groupBox1.Controls.Add(this.lbl_Actions);
            this.groupBox1.Controls.Add(this.lbl_Rules);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 335);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 113);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bridge-Belegung";
            // 
            // lbl_Conditions
            // 
            this.lbl_Conditions.AutoSize = true;
            this.lbl_Conditions.Location = new System.Drawing.Point(191, 53);
            this.lbl_Conditions.Name = "lbl_Conditions";
            this.lbl_Conditions.Size = new System.Drawing.Size(72, 13);
            this.lbl_Conditions.TabIndex = 5;
            this.lbl_Conditions.Text = "lbl_Conditions";
            // 
            // lbl_Actions
            // 
            this.lbl_Actions.AutoSize = true;
            this.lbl_Actions.Location = new System.Drawing.Point(191, 79);
            this.lbl_Actions.Name = "lbl_Actions";
            this.lbl_Actions.Size = new System.Drawing.Size(58, 13);
            this.lbl_Actions.TabIndex = 6;
            this.lbl_Actions.Text = "lbl_Actions";
            // 
            // lbl_Rules
            // 
            this.lbl_Rules.AutoSize = true;
            this.lbl_Rules.Location = new System.Drawing.Point(191, 27);
            this.lbl_Rules.Name = "lbl_Rules";
            this.lbl_Rules.Size = new System.Drawing.Size(50, 13);
            this.lbl_Rules.TabIndex = 4;
            this.lbl_Rules.Text = "lbl_Rules";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_ActionsPerRule);
            this.groupBox2.Controls.Add(this.lbl_FreeSpace);
            this.groupBox2.Controls.Add(this.lbl_ConditionsPerRule);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(13, 456);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 113);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Durchschnittswerte";
            // 
            // lbl_ActionsPerRule
            // 
            this.lbl_ActionsPerRule.AutoSize = true;
            this.lbl_ActionsPerRule.Location = new System.Drawing.Point(190, 53);
            this.lbl_ActionsPerRule.Name = "lbl_ActionsPerRule";
            this.lbl_ActionsPerRule.Size = new System.Drawing.Size(96, 13);
            this.lbl_ActionsPerRule.TabIndex = 5;
            this.lbl_ActionsPerRule.Text = "lbl_ActionsPerRule";
            // 
            // lbl_FreeSpace
            // 
            this.lbl_FreeSpace.AutoSize = true;
            this.lbl_FreeSpace.Location = new System.Drawing.Point(190, 79);
            this.lbl_FreeSpace.Name = "lbl_FreeSpace";
            this.lbl_FreeSpace.Size = new System.Drawing.Size(75, 13);
            this.lbl_FreeSpace.TabIndex = 6;
            this.lbl_FreeSpace.Text = "lbl_FreeSpace";
            // 
            // lbl_ConditionsPerRule
            // 
            this.lbl_ConditionsPerRule.AutoSize = true;
            this.lbl_ConditionsPerRule.Location = new System.Drawing.Point(190, 27);
            this.lbl_ConditionsPerRule.Name = "lbl_ConditionsPerRule";
            this.lbl_ConditionsPerRule.Size = new System.Drawing.Size(110, 13);
            this.lbl_ConditionsPerRule.TabIndex = 4;
            this.lbl_ConditionsPerRule.Text = "lbl_ConditionsPerRule";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Aktionen je Regel:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Verfügbarer Speicher (Prognosse):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Bedingungen je Regel:";
            // 
            // CapabilityView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 581);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cat_Capabilities);
            this.Name = "CapabilityView";
            this.Text = "CapabilityView - Rules";
            ((System.ComponentModel.ISupportInitialize)(this.cat_Capabilities)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart cat_Capabilities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Conditions;
        private System.Windows.Forms.Label lbl_Actions;
        private System.Windows.Forms.Label lbl_Rules;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_ActionsPerRule;
        private System.Windows.Forms.Label lbl_FreeSpace;
        private System.Windows.Forms.Label lbl_ConditionsPerRule;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}