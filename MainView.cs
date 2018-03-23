using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rca.Hue2Xml
{
    public partial class MainView : Form
    {
        Controller m_Controller;

        public MainView()
        {
            #region Form initialisieren
            InitializeComponent();
            handleBridgeIp();
            setAllParameters(true);
            #endregion

            m_Controller = new Controller();
        }

        /// <summary>
        /// Bridge-IP aus Einstellungen in Textbox übernehmen
        /// </summary>
        void handleBridgeIp()
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.lastBridgeIp))
            {
                txt_BridgeIp.Text = Properties.Settings.Default.lastBridgeIp;
                btn_ConnectBridge.Enabled = true;
            }
        }

        /// <summary>
        /// Checkboxen der Parameterauswahl setzen
        /// </summary>
        /// <param name="state">Checkbox-Status</param>
        void setAllParameters(bool state)
        {
            for (int i = 0; i < clb_Parameter.Items.Count; i++)
            {
                clb_Parameter.SetItemChecked(i, state);
            }
        }

        private void btn_SearchBridge_Click(object sender, EventArgs e)
        {
            var ips = m_Controller.SearchBridges();

            if (ips.Length == 1)
            {
                switch (MessageBox.Show("Es wurde im Netzwerk eine Bridge mit der IP " + ips[0] + " gefunden.\nSoll diese verbunden werden?",
                    "Bridge gefunden", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        if (m_Controller.ConnectBridge(ips[0]))
                        {
                            txt_BridgeIp.Text = ips[0];
                            Properties.Settings.Default.lastBridgeIp = ips[0];
                            Properties.Settings.Default.Save();
                            btn_ConnectBridge.Enabled = false;
                        }
                        break;
                    case DialogResult.No:
                        txt_BridgeIp.Text = ips[0];
                        btn_ConnectBridge.Enabled = true;
                        break;
                    default: //Cancel
                        return;
                }
            }
            else
            {
                //Meherere Bridges gefunden
                throw new NotImplementedException();
            }
        }

        private void btn_ConnectBridge_Click(object sender, EventArgs e)
        {
            if (m_Controller.ConnectBridge(txt_BridgeIp.Text))
            {
                Properties.Settings.Default.lastBridgeIp = txt_BridgeIp.Text;
                Properties.Settings.Default.Save();
                btn_ConnectBridge.Enabled = false;
            }
        }

        private void btn_SaveParameters_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Parameter-datei speichern";
            saveFileDialog1.ShowDialog();
        }
    }
}
