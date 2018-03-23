namespace Rca.Hue2Xml
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
            this.btn_SaveParameters = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // clb_Parameter
            // 
            this.clb_Parameter.BackColor = System.Drawing.SystemColors.Control;
            this.clb_Parameter.FormattingEnabled = true;
            this.clb_Parameter.Items.AddRange(new object[] {
            "Leuchtmittel",
            "Gruppen",
            "Timer",
            "Szenen",
            "Sensoren",
            "Regeln",
            "Konfiguration"});
            this.clb_Parameter.Location = new System.Drawing.Point(21, 137);
            this.clb_Parameter.Name = "clb_Parameter";
            this.clb_Parameter.Size = new System.Drawing.Size(167, 109);
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
            this.btn_SearchBridge.Size = new System.Drawing.Size(167, 23);
            this.btn_SearchBridge.TabIndex = 2;
            this.btn_SearchBridge.Text = "Suche Bridge";
            this.btn_SearchBridge.UseVisualStyleBackColor = true;
            this.btn_SearchBridge.Click += new System.EventHandler(this.btn_SearchBridge_Click);
            // 
            // btn_ConnectBridge
            // 
            this.btn_ConnectBridge.Location = new System.Drawing.Point(21, 78);
            this.btn_ConnectBridge.Name = "btn_ConnectBridge";
            this.btn_ConnectBridge.Size = new System.Drawing.Size(167, 23);
            this.btn_ConnectBridge.TabIndex = 3;
            this.btn_ConnectBridge.Text = "Verbinde Bridge";
            this.btn_ConnectBridge.UseVisualStyleBackColor = true;
            this.btn_ConnectBridge.Click += new System.EventHandler(this.btn_ConnectBridge_Click);
            // 
            // txt_BridgeIp
            // 
            this.txt_BridgeIp.Location = new System.Drawing.Point(74, 45);
            this.txt_BridgeIp.Name = "txt_BridgeIp";
            this.txt_BridgeIp.Size = new System.Drawing.Size(114, 20);
            this.txt_BridgeIp.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Parameter-Auswahl";
            // 
            // btn_SaveParameters
            // 
            this.btn_SaveParameters.Location = new System.Drawing.Point(21, 263);
            this.btn_SaveParameters.Name = "btn_SaveParameters";
            this.btn_SaveParameters.Size = new System.Drawing.Size(167, 23);
            this.btn_SaveParameters.TabIndex = 6;
            this.btn_SaveParameters.Text = "Parameter speichern...";
            this.btn_SaveParameters.UseVisualStyleBackColor = true;
            this.btn_SaveParameters.Click += new System.EventHandler(this.btn_SaveParameters_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "XML Datei|*.xml";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 302);
            this.Controls.Add(this.btn_SaveParameters);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_BridgeIp);
            this.Controls.Add(this.btn_ConnectBridge);
            this.Controls.Add(this.btn_SearchBridge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clb_Parameter);
            this.Name = "MainView";
            this.Text = "Hue2Xml v0.1a";
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
        private System.Windows.Forms.Button btn_SaveParameters;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

