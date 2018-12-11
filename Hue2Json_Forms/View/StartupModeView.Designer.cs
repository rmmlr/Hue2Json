namespace Rca.Hue2Json.View
{
    partial class StartupModeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupModeView));
            this.btn_Accept = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_Custom = new System.Windows.Forms.RadioButton();
            this.rb_LastOnState = new System.Windows.Forms.RadioButton();
            this.rb_Powerfail = new System.Windows.Forms.RadioButton();
            this.rb_Safety = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_Name = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Accept
            // 
            this.btn_Accept.Location = new System.Drawing.Point(126, 224);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(107, 23);
            this.btn_Accept.TabIndex = 0;
            this.btn_Accept.Text = "Übernehmen";
            this.btn_Accept.UseVisualStyleBackColor = true;
            this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(13, 224);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(107, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Abbrechen";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_Custom);
            this.groupBox1.Controls.Add(this.rb_LastOnState);
            this.groupBox1.Controls.Add(this.rb_Powerfail);
            this.groupBox1.Controls.Add(this.rb_Safety);
            this.groupBox1.Location = new System.Drawing.Point(13, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 163);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Konfiguration";
            // 
            // rb_Custom
            // 
            this.rb_Custom.AutoSize = true;
            this.rb_Custom.Enabled = false;
            this.rb_Custom.Location = new System.Drawing.Point(25, 121);
            this.rb_Custom.Name = "rb_Custom";
            this.rb_Custom.Size = new System.Drawing.Size(60, 17);
            this.rb_Custom.TabIndex = 3;
            this.rb_Custom.TabStop = true;
            this.rb_Custom.Text = "Custom";
            this.rb_Custom.UseVisualStyleBackColor = true;
            this.rb_Custom.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_LastOnState
            // 
            this.rb_LastOnState.AutoSize = true;
            this.rb_LastOnState.Location = new System.Drawing.Point(25, 90);
            this.rb_LastOnState.Name = "rb_LastOnState";
            this.rb_LastOnState.Size = new System.Drawing.Size(90, 17);
            this.rb_LastOnState.TabIndex = 2;
            this.rb_LastOnState.TabStop = true;
            this.rb_LastOnState.Text = "Last On State";
            this.toolTip1.SetToolTip(this.rb_LastOnState, resources.GetString("rb_LastOnState.ToolTip"));
            this.rb_LastOnState.UseVisualStyleBackColor = true;
            this.rb_LastOnState.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_Powerfail
            // 
            this.rb_Powerfail.AutoSize = true;
            this.rb_Powerfail.Location = new System.Drawing.Point(25, 59);
            this.rb_Powerfail.Name = "rb_Powerfail";
            this.rb_Powerfail.Size = new System.Drawing.Size(68, 17);
            this.rb_Powerfail.TabIndex = 1;
            this.rb_Powerfail.TabStop = true;
            this.rb_Powerfail.Text = "Powerfail";
            this.toolTip1.SetToolTip(this.rb_Powerfail, resources.GetString("rb_Powerfail.ToolTip"));
            this.rb_Powerfail.UseVisualStyleBackColor = true;
            this.rb_Powerfail.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_Safety
            // 
            this.rb_Safety.AutoSize = true;
            this.rb_Safety.Location = new System.Drawing.Point(25, 28);
            this.rb_Safety.Name = "rb_Safety";
            this.rb_Safety.Size = new System.Drawing.Size(55, 17);
            this.rb_Safety.TabIndex = 0;
            this.rb_Safety.TabStop = true;
            this.rb_Safety.Text = "Safety";
            this.toolTip1.SetToolTip(this.rb_Safety, "Nach dem Einschalten geht das Leuchtmittel an,\r\nmit 100 % Helligkeit und einer Fa" +
        "rbtemperatur\r\nvon 2700 K (Warmweiß).");
            this.rb_Safety.UseVisualStyleBackColor = true;
            this.rb_Safety.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Einschaltverhalten";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.Location = new System.Drawing.Point(12, 15);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(51, 16);
            this.lbl_Name.TabIndex = 4;
            this.lbl_Name.Text = "label1";
            // 
            // StartupModeView
            // 
            this.AcceptButton = this.btn_Accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(248, 259);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Accept);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartupModeView";
            this.Text = "Einschaltverhalten";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Custom;
        private System.Windows.Forms.RadioButton rb_LastOnState;
        private System.Windows.Forms.RadioButton rb_Powerfail;
        private System.Windows.Forms.RadioButton rb_Safety;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl_Name;
    }
}