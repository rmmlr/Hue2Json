namespace Rca.Hue2Json.View
{
    partial class BridgeButtonView
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbl_Message = new System.Windows.Forms.Label();
            this.lbl_ProgressTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 158);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(345, 23);
            this.progressBar.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rca.Hue2Json.Properties.Resources.pushlink_bridgev2;
            this.pictureBox1.Location = new System.Drawing.Point(24, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(282, 214);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Abbrechen";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.cancelForm);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lbl_Message
            // 
            this.lbl_Message.Location = new System.Drawing.Point(173, 19);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(184, 127);
            this.lbl_Message.TabIndex = 5;
            this.lbl_Message.Text = "[Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod " +
    "tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At v" +
    "ero eos et la via.]";
            // 
            // lbl_ProgressTime
            // 
            this.lbl_ProgressTime.AutoSize = true;
            this.lbl_ProgressTime.Location = new System.Drawing.Point(207, 190);
            this.lbl_ProgressTime.Name = "lbl_ProgressTime";
            this.lbl_ProgressTime.Size = new System.Drawing.Size(43, 13);
            this.lbl_ProgressTime.TabIndex = 6;
            this.lbl_ProgressTime.Text = "00:00,0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Verbleibende Zeit:";
            // 
            // BridgeButtonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(369, 250);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_ProgressTime);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(385, 288);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(385, 288);
            this.Name = "BridgeButtonView";
            this.Text = "Hue Bridge Button";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cancelForm);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Label lbl_ProgressTime;
        private System.Windows.Forms.Label label1;
    }
}