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
    public partial class EnterIpAddressView : Form
    {
        Icon m_Icon;

        public string IpAddress { get; set; }

        public EnterIpAddressView(string text, string caption, Icon icon)
        {
            InitializeComponent();

            Text = caption;
            lbl_Message.Text = text;
            m_Icon = icon;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawIcon(m_Icon, 27, 27);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            IpAddress = txt_IpAddress.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
