namespace Rca.Hue2Json
{
    partial class MainView
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
            this.clb_Parameter = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SearchBridge = new System.Windows.Forms.Button();
            this.btn_ConnectBridge = new System.Windows.Forms.Button();
            this.txt_BridgeIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ReadParameters = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_AnonNames = new System.Windows.Forms.CheckBox();
            this.cbx_AnonSerials = new System.Windows.Forms.CheckBox();
            this.btn_ShowParameters = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clb_Parameter
            // 
            this.clb_Parameter.BackColor = System.Drawing.SystemColors.Control;
            this.clb_Parameter.FormattingEnabled = true;
            this.clb_Parameter.Location = new System.Drawing.Point(21, 137);
            this.clb_Parameter.Name = "clb_Parameter";
            this.clb_Parameter.Size = new System.Drawing.Size(195, 154);
            this.clb_Parameter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bridge IP";
            // 
            // btn_SearchBridge
            // 
            this.btn_SearchBridge.Location = new System.Drawing.Point(21, 16);
            this.btn_SearchBridge.Name = "btn_SearchBridge";
            this.btn_SearchBridge.Size = new System.Drawing.Size(195, 23);
            this.btn_SearchBridge.TabIndex = 2;
            this.btn_SearchBridge.Text = "Suche Bridge";
            this.btn_SearchBridge.UseVisualStyleBackColor = true;
            this.btn_SearchBridge.Click += new System.EventHandler(this.btn_SearchBridge_Click);
            // 
            // btn_ConnectBridge
            // 
            this.btn_ConnectBridge.Enabled = false;
            this.btn_ConnectBridge.Location = new System.Drawing.Point(21, 78);
            this.btn_ConnectBridge.Name = "btn_ConnectBridge";
            this.btn_ConnectBridge.Size = new System.Drawing.Size(195, 23);
            this.btn_ConnectBridge.TabIndex = 3;
            this.btn_ConnectBridge.Text = "Verbinde Bridge";
            this.btn_ConnectBridge.UseVisualStyleBackColor = true;
            this.btn_ConnectBridge.Click += new System.EventHandler(this.btn_ConnectBridge_Click);
            // 
            // txt_BridgeIp
            // 
            this.txt_BridgeIp.Location = new System.Drawing.Point(74, 45);
            this.txt_BridgeIp.Name = "txt_BridgeIp";
            this.txt_BridgeIp.Size = new System.Drawing.Size(142, 20);
            this.txt_BridgeIp.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Parameter-Auswahl";
            // 
            // btn_ReadParameters
            // 
            this.btn_ReadParameters.Enabled = false;
            this.btn_ReadParameters.Location = new System.Drawing.Point(21, 395);
            this.btn_ReadParameters.Name = "btn_ReadParameters";
            this.btn_ReadParameters.Size = new System.Drawing.Size(195, 23);
            this.btn_ReadParameters.TabIndex = 6;
            this.btn_ReadParameters.Text = "Parameter auslesen";
            this.btn_ReadParameters.UseVisualStyleBackColor = true;
            this.btn_ReadParameters.Click += new System.EventHandler(this.btn_ReadParameters_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "JSON Datei|*.json";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_AnonNames);
            this.groupBox1.Controls.Add(this.cbx_AnonSerials);
            this.groupBox1.Location = new System.Drawing.Point(21, 307);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 68);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Anonymisierung";
            // 
            // cbx_AnonNames
            // 
            this.cbx_AnonNames.AutoSize = true;
            this.cbx_AnonNames.Location = new System.Drawing.Point(13, 42);
            this.cbx_AnonNames.Name = "cbx_AnonNames";
            this.cbx_AnonNames.Size = new System.Drawing.Size(60, 17);
            this.cbx_AnonNames.TabIndex = 1;
            this.cbx_AnonNames.Text = "Namen";
            this.cbx_AnonNames.UseVisualStyleBackColor = true;
            // 
            // cbx_AnonSerials
            // 
            this.cbx_AnonSerials.AutoSize = true;
            this.cbx_AnonSerials.Checked = true;
            this.cbx_AnonSerials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_AnonSerials.Location = new System.Drawing.Point(13, 19);
            this.cbx_AnonSerials.Name = "cbx_AnonSerials";
            this.cbx_AnonSerials.Size = new System.Drawing.Size(99, 17);
            this.cbx_AnonSerials.TabIndex = 0;
            this.cbx_AnonSerials.Text = "Seriennummern";
            this.cbx_AnonSerials.UseVisualStyleBackColor = true;
            // 
            // btn_ShowParameters
            // 
            this.btn_ShowParameters.Enabled = false;
            this.btn_ShowParameters.Location = new System.Drawing.Point(22, 430);
            this.btn_ShowParameters.Name = "btn_ShowParameters";
            this.btn_ShowParameters.Size = new System.Drawing.Size(195, 23);
            this.btn_ShowParameters.TabIndex = 8;
            this.btn_ShowParameters.Text = "Parameter anzeigen";
            this.btn_ShowParameters.UseVisualStyleBackColor = true;
            this.btn_ShowParameters.Click += new System.EventHandler(this.btn_ShowParameters_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 465);
            this.Controls.Add(this.btn_ShowParameters);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_ReadParameters);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_BridgeIp);
            this.Controls.Add(this.btn_ConnectBridge);
            this.Controls.Add(this.btn_SearchBridge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clb_Parameter);
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.Text = "Hue2Json";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb_Parameter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SearchBridge;
        private System.Windows.Forms.Button btn_ConnectBridge;
        private System.Windows.Forms.TextBox txt_BridgeIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ReadParameters;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbx_AnonNames;
        private System.Windows.Forms.CheckBox cbx_AnonSerials;
        private System.Windows.Forms.Button btn_ShowParameters;
    }
}

