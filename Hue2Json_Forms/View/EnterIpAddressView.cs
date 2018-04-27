using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rca.Hue2Json.View
{
    public partial class EnterIpAddressView : Form
    {
        Icon m_Icon;
        IPAddress m_ExpectedIp;

        public string ExpectedIp
        {
            get
            {
                return m_ExpectedIp.ToString();
            }
            set
            {
                m_ExpectedIp = IPAddress.Parse(value);
            }
        }

        public IPAddress IpAddress { get; set; }

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
            if (validateInputIp(m_ExpectedIp, out IPAddress inputIp))
            {
                IpAddress = inputIp;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Eingegebene IP-Adresse stimmt nicht mit der der aktuell verbundenen Bridge überein." + Environment.NewLine
                    + Environment.NewLine + "Eingabe: " + txt_IpAddress.Text + Environment.NewLine + "IP der Bridge: " + m_ExpectedIp.ToString(),
                    "Eingebe fehlerhaft", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool validateInputIp(IPAddress expectedIp, out IPAddress inputIp)
        {
            if (!IPAddress.TryParse(txt_IpAddress.Text, out inputIp))
                throw new ArgumentException("Eingegebene IP-Adresse (" + txt_IpAddress.Text + ") nicht im gültigen Format.");

            return expectedIp == inputIp;
        }
    }
}
