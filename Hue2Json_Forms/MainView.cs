using Rca.Hue2Json.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rca.Hue2Json
{
    public partial class MainView : Form
    {
        #region Member
        Controller m_Controller;
        #endregion Member

        #region Constructor
        public MainView()
        {
            //Einstellungen laden
            ProgramSettings settings = null;
            if (File.Exists(Properties.Settings.Default.DefaultSettingsFileName))
                settings = ProgramSettings.FromFile(Properties.Settings.Default.DefaultSettingsFileName);
            else
                settings = ProgramSettings.CreateDefault();


            #region Form initialisieren
            InitializeComponent();
            setupParameterSelection();
            setAllParameters(true);
            toolStripStatusLabel_Bridge.Text = "keine Bridge verbunden";
            #endregion

            this.Text = "Hue2Json - " + Application.ProductVersion;


            m_Controller = new Controller(settings);
        }

        public MainView(string[] args) : this()
        {
            if (args.Any(x => x.ToLower().Contains("devmode")))
            {
                m_Controller.DevMode = true;
                btn_ReadParameters.Enabled = true;
                btn_ShowParameters.Enabled = true;
            }

            if (args.Any(x => x.ToLower().Contains("sim")))
            {
                m_Controller.SimMode = true;
            }
        }
        #endregion Constructor

        #region Benutzereingaben verarbeiten
        private async void sucheBridgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bridgeInfos = await m_Controller.ScanBridges();

            if (bridgeInfos.Length > 0)
            {
                foreach (var info in bridgeInfos)
                {
                    var item = new ToolStripMenuItem()
                    {
                        Text = info.GetNameString(),
                        Tag = info
                    };
                    item.Click += connectBridge;

                    bridgeAuswahlToolStripMenuItem.DropDownItems.Add(item);
                }
                bridgeAuswahlToolStripMenuItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Es konnte keine Hue Bridge im Netzwerk gefunden werden.\nStellen Sie sicher das sich die Hue Bridge im selben Netzwerk befindet.", "Keine Hue Bridge gefunden", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private async void connectBridge(object sender, EventArgs e)
        {
            if (bridgeAuswahlToolStripMenuItem.DropDownItems.Count > 1)
                foreach (ToolStripMenuItem item in bridgeAuswahlToolStripMenuItem.DropDownItems)
                    item.Checked = false;

            var menuItem = (ToolStripMenuItem)sender;
            menuItem.Checked = true;

            if (await m_Controller.ConnectBridge(((BridgeInfo)menuItem.Tag).IpAddress))
            {
                toolStripStatusLabel_Bridge.Text = "Bridge verbunden (" + ((BridgeInfo)menuItem.Tag).IpAddress + ")";
                Properties.Settings.Default.lastBridgeIp = ((BridgeInfo)menuItem.Tag).IpAddress;
                Properties.Settings.Default.Save();
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

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion Benutzereingaben verarbeiten

        #region Hilfsfunktionen
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
        #endregion Hilfsfunktionen
    }
}
