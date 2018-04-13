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
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ReadParameters = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_AnonNames = new System.Windows.Forms.CheckBox();
            this.cbx_AnonSerials = new System.Windows.Forms.CheckBox();
            this.btn_ShowParameters = new System.Windows.Forms.Button();
            this.btn_OpenBackupFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Backup = new System.Windows.Forms.TabPage();
            this.tabPage_Restore = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Bridge = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bridgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucheBridgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bridgeAuswahlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newUserToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Backup.SuspendLayout();
            this.tabPage_Restore.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clb_Parameter
            // 
            this.clb_Parameter.BackColor = System.Drawing.SystemColors.Control;
            this.clb_Parameter.FormattingEnabled = true;
            this.clb_Parameter.Location = new System.Drawing.Point(37, 37);
            this.clb_Parameter.Name = "clb_Parameter";
            this.clb_Parameter.Size = new System.Drawing.Size(195, 154);
            this.clb_Parameter.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Parameter-Auswahl";
            // 
            // btn_ReadParameters
            // 
            this.btn_ReadParameters.Enabled = false;
            this.btn_ReadParameters.Location = new System.Drawing.Point(37, 295);
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
            this.groupBox1.Location = new System.Drawing.Point(37, 207);
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
            this.btn_ShowParameters.Location = new System.Drawing.Point(37, 324);
            this.btn_ShowParameters.Name = "btn_ShowParameters";
            this.btn_ShowParameters.Size = new System.Drawing.Size(195, 23);
            this.btn_ShowParameters.TabIndex = 8;
            this.btn_ShowParameters.Text = "Parameter anzeigen";
            this.btn_ShowParameters.UseVisualStyleBackColor = true;
            this.btn_ShowParameters.Click += new System.EventHandler(this.btn_ShowParameters_Click);
            // 
            // btn_OpenBackupFile
            // 
            this.btn_OpenBackupFile.Enabled = false;
            this.btn_OpenBackupFile.Location = new System.Drawing.Point(87, 34);
            this.btn_OpenBackupFile.Name = "btn_OpenBackupFile";
            this.btn_OpenBackupFile.Size = new System.Drawing.Size(195, 23);
            this.btn_OpenBackupFile.TabIndex = 9;
            this.btn_OpenBackupFile.Text = "Backup-Datei öffnen...";
            this.btn_OpenBackupFile.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JSON Datei|*.json";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Backup);
            this.tabControl1.Controls.Add(this.tabPage_Restore);
            this.tabControl1.Location = new System.Drawing.Point(12, 40);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(519, 448);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage_Backup
            // 
            this.tabPage_Backup.Controls.Add(this.label2);
            this.tabPage_Backup.Controls.Add(this.clb_Parameter);
            this.tabPage_Backup.Controls.Add(this.groupBox1);
            this.tabPage_Backup.Controls.Add(this.btn_ReadParameters);
            this.tabPage_Backup.Controls.Add(this.btn_ShowParameters);
            this.tabPage_Backup.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Backup.Name = "tabPage_Backup";
            this.tabPage_Backup.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Backup.Size = new System.Drawing.Size(511, 422);
            this.tabPage_Backup.TabIndex = 0;
            this.tabPage_Backup.Text = "Backup";
            this.tabPage_Backup.UseVisualStyleBackColor = true;
            // 
            // tabPage_Restore
            // 
            this.tabPage_Restore.Controls.Add(this.btn_OpenBackupFile);
            this.tabPage_Restore.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Restore.Name = "tabPage_Restore";
            this.tabPage_Restore.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Restore.Size = new System.Drawing.Size(511, 422);
            this.tabPage_Restore.TabIndex = 1;
            this.tabPage_Restore.Text = "Restore";
            this.tabPage_Restore.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Bridge});
            this.statusStrip1.Location = new System.Drawing.Point(0, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(543, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Bridge
            // 
            this.toolStripStatusLabel_Bridge.Name = "toolStripStatusLabel_Bridge";
            this.toolStripStatusLabel_Bridge.Size = new System.Drawing.Size(84, 17);
            this.toolStripStatusLabel_Bridge.Text = "[Status Bridge]";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.bridgeToolStripMenuItem,
            this.überToolStripMenuItem,
            this.devToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(543, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem,
            this.toolStripSeparator1,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // bridgeToolStripMenuItem
            // 
            this.bridgeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sucheBridgeToolStripMenuItem,
            this.bridgeAuswahlToolStripMenuItem});
            this.bridgeToolStripMenuItem.Name = "bridgeToolStripMenuItem";
            this.bridgeToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.bridgeToolStripMenuItem.Text = "Bridge";
            // 
            // sucheBridgeToolStripMenuItem
            // 
            this.sucheBridgeToolStripMenuItem.Name = "sucheBridgeToolStripMenuItem";
            this.sucheBridgeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.sucheBridgeToolStripMenuItem.Text = "Suche Bridge";
            this.sucheBridgeToolStripMenuItem.Click += new System.EventHandler(this.sucheBridgeToolStripMenuItem_Click);
            // 
            // bridgeAuswahlToolStripMenuItem
            // 
            this.bridgeAuswahlToolStripMenuItem.Enabled = false;
            this.bridgeAuswahlToolStripMenuItem.Name = "bridgeAuswahlToolStripMenuItem";
            this.bridgeAuswahlToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.bridgeAuswahlToolStripMenuItem.Text = "Bridge Auswahl";
            // 
            // überToolStripMenuItem
            // 
            this.überToolStripMenuItem.Name = "überToolStripMenuItem";
            this.überToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.überToolStripMenuItem.Text = "Über";
            // 
            // devToolStripMenuItem1
            // 
            this.devToolStripMenuItem1.BackColor = System.Drawing.Color.Violet;
            this.devToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newUserToolStripMenuItem1});
            this.devToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.devToolStripMenuItem1.Name = "devToolStripMenuItem1";
            this.devToolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
            this.devToolStripMenuItem1.Text = "Dev";
            // 
            // newUserToolStripMenuItem1
            // 
            this.newUserToolStripMenuItem1.Name = "newUserToolStripMenuItem1";
            this.newUserToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.newUserToolStripMenuItem1.Text = "NewUser";
            this.newUserToolStripMenuItem1.Click += new System.EventHandler(this.newUserToolStripMenuItem1_Click);
            // 
            // newUserToolStripMenuItem
            // 
            this.newUserToolStripMenuItem.Name = "newUserToolStripMenuItem";
            this.newUserToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 526);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.Text = "Hue2Json";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Backup.ResumeLayout(false);
            this.tabPage_Backup.PerformLayout();
            this.tabPage_Restore.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb_Parameter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ReadParameters;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbx_AnonNames;
        private System.Windows.Forms.CheckBox cbx_AnonSerials;
        private System.Windows.Forms.Button btn_ShowParameters;
        private System.Windows.Forms.Button btn_OpenBackupFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Backup;
        private System.Windows.Forms.TabPage tabPage_Restore;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bridgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Bridge;
        private System.Windows.Forms.ToolStripMenuItem sucheBridgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bridgeAuswahlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem überToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem newUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newUserToolStripMenuItem1;
    }
}

