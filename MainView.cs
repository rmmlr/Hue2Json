using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rca.Hue2Json
{
    public partial class MainView : Form
    {
        Controller m_Controller;

        public MainView()
        {
            #region Form initialisieren
            InitializeComponent();
            handleBridgeIp();
            setupParameterSelection();
            setAllParameters(true);
            #endregion

            this.Text = "Hue2Json - " + Application.ProductVersion;

#if DEBUG
            btn_ConnectBridge.Enabled = true;
            btn_ReadParameters.Enabled = true;
            btn_ShowParameters.Enabled = true;
#endif


            m_Controller = new Controller();
        }

        public MainView(string[] args) : this()
        {
            if (args.Any(x => x.ToLower().Contains("devmode")))
            {
                m_Controller.DevMode = true;
                m_Controller.LoadParameterFile(@"F:\hue_params_elias.json");
                btn_ShowParameters.Enabled = true;
            }
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

        void setupParameterSelection()
        {
            //foreach (HueParameterEnum param in Enum.GetValues(typeof(HueParameterEnum)))
            //    if (param.HasDisplayName())
            //        clb_Parameter.Items.Add(param.DisplayName());

            foreach (HueParameterGroupEnum param in Enum.GetValues(typeof(HueParameterGroupEnum)))
                clb_Parameter.Items.Add(new HueParameterGroup(param));

            clb_Parameter.DisplayMember = "DisplayName";
            clb_Parameter.ValueMember = "Value";
        }

        /// <summary>
        /// Checkboxen der Parameterauswahl setzen
        /// </summary>
        /// <param name="state">Checkbox-Status</param>
        void setAllParameters(bool state)
        {
            for (int i = 0; i < clb_Parameter.Items.Count; i++)
                clb_Parameter.SetItemChecked(i, state);
        }

        /// <summary>
        /// Abfrage der ausgewählten Parameter
        /// </summary>
        /// <returns>Parameter-Gruppen (flagged enum)</returns>
        HueParameterGroupEnum getSelectedParams()
        {
            HueParameterGroupEnum paras = 0;

            foreach (HueParameterGroup item in clb_Parameter.CheckedItems)
                paras |= item.Value;

            return paras;
        }

        /// <summary>
        /// Abfrage ausgewählter Anonymisierungs-Optionen
        /// </summary>
        /// <returns>Anonymisierungs-Optionen, als Array</returns>
        AnonymizeOptions[] getAnonymizeOptions()
        {
            var opts = new List<AnonymizeOptions>();

            if (cbx_AnonSerials.Checked)
                opts.Add(AnonymizeOptions.Serials);

            if (cbx_AnonNames.Checked)
                opts.Add(AnonymizeOptions.Names);

            return opts.ToArray();
        }

        private async void btn_SearchBridge_Click(object sender, EventArgs e)
        {
            var ips = await m_Controller.ScanBridges();

            if (ips.Length == 1)
            {
                switch (MessageBox.Show("Es wurde im Netzwerk eine Bridge mit der IP " + ips[0] + " gefunden.\nSoll diese verbunden werden?",
                    "Bridge gefunden", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        if (await m_Controller.ConnectBridge(ips[0]))
                        {
                            txt_BridgeIp.Text = ips[0];
                            Properties.Settings.Default.lastBridgeIp = ips[0];
                            Properties.Settings.Default.Save();
                            btn_ConnectBridge.Enabled = false;
                            btn_ReadParameters.Enabled = true;
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

        private async void btn_ConnectBridge_Click(object sender, EventArgs e)
        {
            if (await m_Controller.ConnectBridge(txt_BridgeIp.Text))
            {
                Properties.Settings.Default.lastBridgeIp = txt_BridgeIp.Text;
                Properties.Settings.Default.Save();
                btn_ConnectBridge.Enabled = false;
                btn_ReadParameters.Enabled = true;
            }
        }

        private void btn_ReadParameters_Click(object sender, EventArgs e)
        {
            m_Controller.ReadParameters(getSelectedParams(), getAnonymizeOptions());
            
            if (MessageBox.Show("Parameter wurden erfolgreich ausgelesen.\nSollen diese in eine Datei gespeichert werden?",
                "Bridge gefunden", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                saveFileDialog.Title = "Parameter-Datei speichern";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    m_Controller.SaveParameterFile(saveFileDialog.FileName); //TODO: Ergebnis anzeigen
            }
            else //UNDONE: "Cancel" and "No" Handling!
            {
                //m_Controller.Parameters = null;
            }

            btn_ShowParameters.Enabled = true;
        }

        private void btn_ShowParameters_Click(object sender, EventArgs e)
        {
            m_Controller.VisualizeParameters();

            //var paramView = new ParameterView();
            //paramView.ApplyParameters(m_Controller.Parameters);

            //paramView.ShowDialog();
        }
    }
}
