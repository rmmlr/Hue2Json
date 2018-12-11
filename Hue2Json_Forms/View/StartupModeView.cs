using Rca.Hue2Json.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rca.Hue2Json.View
{
    public partial class StartupModeView : Form
    {
        public StartupMode Startup { get; set; }

        public string LightName { get; set; }

        public StartupModeView()
        {
            InitializeComponent();
        }

        public void Init()
        {

            lbl_Name.Text = LightName;

            switch (Startup)
            {
                case StartupMode.Custom:
                    rb_Custom.Checked = true;
                    break;
                case StartupMode.LastOnState:
                    rb_LastOnState.Checked = true;
                    break;
                case StartupMode.Powerfail:
                    rb_Powerfail.Checked = true;
                    break;
                case StartupMode.Safety:
                    rb_Safety.Checked = true;
                    break;
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Safety.Checked)
                Startup = StartupMode.Safety;
            if (rb_Custom.Checked)
                Startup = StartupMode.Custom;
            if (rb_LastOnState.Checked)
                Startup = StartupMode.LastOnState;
            if (rb_Powerfail.Checked)
                Startup = StartupMode.Powerfail;

        }
    }
}
