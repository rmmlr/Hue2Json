namespace Rca.Hue2Json
{
    partial class ParameterView
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
            this.pyg_Parameters = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // pyg_Parameters
            // 
            this.pyg_Parameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pyg_Parameters.Location = new System.Drawing.Point(0, 0);
            this.pyg_Parameters.Name = "pyg_Parameters";
            this.pyg_Parameters.Size = new System.Drawing.Size(418, 450);
            this.pyg_Parameters.TabIndex = 0;
            // 
            // ParameterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 450);
            this.Controls.Add(this.pyg_Parameters);
            this.Name = "ParameterView";
            this.Text = "ParameterView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pyg_Parameters;
    }
}