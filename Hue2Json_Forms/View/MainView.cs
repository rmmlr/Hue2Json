using Rca.Hue2Json.Logging;
using Rca.Hue2Json.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rca.Hue2Json.View
{
    public partial class MainView : Form
    {
        #region Member
        Controller m_Controller;
        #endregion Member

        #region Constructor
        public MainView(string[] args)
        {
            Logger.WriteToLog("Programmstart", LogLevel.Info);

            //Pfad zur Konfigurationsdatei ermitteln
            var configPath = Properties.Settings.Default.DefaultSettingsFileName;
            if (args.Any(x => x.ToLower().Contains(".config")))
            {
                configPath = args.First(x => x.Contains(".config"));
                Logger.WriteToLog("Spezifische Konfiguration: " + configPath, LogLevel.Info);
            }

            //Konfigurationsdatei laden
            ProgramSettings settings = null;
            if (File.Exists(configPath))
            {
                settings = ProgramSettings.FromFile(configPath);
                Logger.WriteToLog("Konfiguration geladen", LogLevel.Info);
            }
            else
            {
                settings = ProgramSettings.CreateDefault();
                Logger.WriteToLog("Standard Konfiguration erzeugt und geladen", LogLevel.Info);
            }

            //Form initialisieren
            InitializeComponent();
            devToolStripMenuItem1.Visible = false;
            setupParameterSelection();
            setAllParameters(true);
            toolStripStatusLabel_Bridge.Text = "keine Bridge verbunden";
            this.Text = "Hue2Json - " + Application.ProductVersion;

            //Controller initialisieren
            m_Controller = new Controller(settings);
            Logger.WriteToLog("Controller initialisiert", LogLevel.Info);


            //DevMode aktivieren
            if (args.Any(x => x.ToLower().Contains("devmode")))
            {
                Logger.WriteToLog("DevMode wird aktiviert", LogLevel.Info);
                m_Controller.DevMode = true;
                devToolStripMenuItem1.Visible = true;
                btn_ReadParameters.Enabled = true;
                btn_ShowParameters.Enabled = true;

                btn_OpenBackupFile.Enabled = true;
                btn_ReadConfig.Enabled = true;
                btn_Remapping.Enabled = true;
                btn_Restore.Enabled = true;
            }

            //Bridge-Simulation aktivieren
            if (args.Any(x => x.ToLower().Contains("sim")))
            {
                Logger.WriteToLog("SimMode wird aktiviert", LogLevel.Info);
                m_Controller.SimMode = true;
            }

            Logger.LogMessageEvent += appendRestoreLogLine;
        }
        #endregion Constructor

        #region Benutzereingaben verarbeiten
        async void sucheBridgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.WriteToLog("Bridge-Suche gestartet", LogLevel.Info);
            Cursor = Cursors.WaitCursor;

            var bridgeInfos = await m_Controller.ScanBridges();

            if (bridgeInfos.Length > 0)
            {
                foreach (var info in bridgeInfos)
                {
                    Logger.WriteToLog("Gefundene Bridge: IP = " + info.IpAddress + "; Name = " + info.Name, LogLevel.Info);
                    var item = new ToolStripMenuItem()
                    {
                        Text = info.GetNameString(),
                        Tag = info
                    };
                    item.Click += connectBridge;

                    bridgeAuswahlToolStripMenuItem.DropDownItems.Add(item);
                }
                bridgeAuswahlToolStripMenuItem.Enabled = true;

                if (bridgeInfos.Length == 1)
                {
                    if (MessageBox.Show("Es wurde eine Philips Hue Bridge im Netzwerk gefunden.\nSoll zu dieser Bridge (" + bridgeInfos[0].Name + ") eine Verbindung hergestellt werden?",
                        "Philips Hue Bridge gefunden", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Bridge verbinden
                        connectBridge(bridgeAuswahlToolStripMenuItem.DropDownItems[0], null);
                    }
                }
                else //Mehr als eine Bridge gefunden
                    MessageBox.Show("Es wurden " + bridgeInfos.Length + " Philips Hue Bridges im Netzwerk gefunden werden.\nÜber die Bridge-Auswahlliste kann eine Verbindung hergestellt werden.",
                        "Philips Hue Bridges gefunden", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Logger.WriteToLog("Keine Bridge/s gefunden", LogLevel.Warning);
                MessageBox.Show("Es konnte keine Philips Hue Bridge im Netzwerk gefunden werden.\nStellen Sie sicher das sich die Philips Hue Bridge im selben Netzwerk befindet.",
                    "Keine Philips Hue Bridge gefunden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Cursor = DefaultCursor;
        }



        void connectBridge(object sender, EventArgs e)
        {
            if (bridgeAuswahlToolStripMenuItem.DropDownItems.Count > 1)
                foreach (ToolStripMenuItem item in bridgeAuswahlToolStripMenuItem.DropDownItems)
                    item.Checked = false;

            var menuItem = (ToolStripMenuItem)sender;
            menuItem.Checked = true;
            var bridge = (BridgeInfo)menuItem.Tag;

            Logger.WriteToLog("Start Verbindungsaufbau zu Bridge mit IP = " + bridge.IpAddress, LogLevel.Info);

            switch (m_Controller.ConnectBridge(bridge))
            {
                case BridgeResult.SuccessfulConnected:
                    connectedBridgeStatus(bridge);
                    break;
                case BridgeResult.UnauthorizedUser:
                case BridgeResult.MissingUser:
                    if (newUser(bridge))
                        connectedBridgeStatus(bridge);
                    else
                        throw new Exception("Fehler beim anlegen eines neuen Bridge-Benutzers.");
                    break;
                default:
                    throw new Exception("Fehler beim Verbinden der Hue Bridge.");
            }
        }

        void btn_ReadParameters_Click(object sender, EventArgs e)
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

            //btn_ShowParameters.Enabled = true;
        }

        void btn_ShowParameters_Click(object sender, EventArgs e)
        {
            m_Controller.VisualizeParameters();

            //var paramView = new ParameterView();
            //paramView.ApplyParameters(m_Controller.Parameters);

            //paramView.ShowDialog();
        }

        void beendenToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        void newUserToolStripMenuItem1_Click(object sender, EventArgs e) => newUser(null);

        private async void speicherbelegungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var capa = await m_Controller.ReadCapabilities();
            var capaView = new CapabilityView(capa);

            capaView.Show();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_Controller.ConnectedBridge == null)
                throw new ArgumentNullException("Keine Bridge verbunden");

            var dlg = new EnterIpAddressView("Bei Reset der Philips Hue Bridge (" + m_Controller.ConnectedBridge.IpAddress + ") werden alle vorgenommenen Einstellungen (verbundene Leuchtmittel, Gruppen, Regeln, etc.) unwiederruflich gelöscht." + Environment.NewLine + "Reset-Vorgang durch Eingabe der IP-Adresse bestätigen:", "Reset der Philips Hue Bridge", SystemIcons.Warning);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_Controller.ResetBridge(dlg.IpAddress);
            }
        }

        private void überToolStripMenuItem1_Click(object sender, EventArgs e) => MessageBox.Show(
                "Hue2Json" + Environment.NewLine + Environment.NewLine +
                "Version: " + Application.ProductVersion + Environment.NewLine +
                "Autor: Ruemmler, Elias",
                "Hue2Json",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        #endregion Benutzereingaben verarbeiten

        #region Hilfsfunktionen
        void appendRestoreLogLine(string message, LogLevel level)
        {
            if (this.InvokeRequired)
            {
                Logger.LogMessageEventHandler del = appendRestoreLogLine;
                BeginInvoke(del, message, level);
            }
            else
            {
                if (level == LogLevel.RestoreInfo)
                    txt_RestoreOutput.AppendText(Environment.NewLine + message);
            }
        }

        void setupParameterSelection()
        {
            //foreach (HueParameterEnum param in Enum.GetValues(typeof(HueParameterEnum)))
            //    if (param.HasDisplayName())
            //        clb_Parameter.Items.Add(param.DisplayName());

            foreach (HueParameterGroupEnum param in Enum.GetValues(typeof(HueParameterGroupEnum)))
            {
                var paramObj = new HueParameterGroup(param);
                if (!paramObj.Hide)
                    clb_Parameter.Items.Add(new HueParameterGroup(param));
            }
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

        bool newUser(BridgeInfo bridge)
        {
            var result = false;
            var source = new CancellationTokenSource();
            var token = source.Token;

            var pressButtonDlg = new BridgeButtonView(source);

            Logger.WriteToLog("Warten auf Link-Button", LogLevel.Info);

            var task = Task.Run(async () => {
                while (true)
                {
                    if (token.IsCancellationRequested || result)
                        break;


                    switch (await m_Controller.CreateUser(bridge))
                    {
                        case BridgeResult.LinkButtonNotPressed:
                            continue;
                        case BridgeResult.UserAlreadyExists:
                            Logger.WriteToLog("Benutzer bereist vorhanden", LogLevel.Error);
                            throw new NotImplementedException();
                        case BridgeResult.UserCreated:
                            Logger.WriteToLog("Neuer Benutzer erfolgreich angelegt", LogLevel.DisplayMessage);
                            result = true;
                            pressButtonDlg.KillForm();
                            break;
                    }

                    Thread.Sleep(100);
                }
            }, token);


            pressButtonDlg.ShowDialog(this);

            MessageBox.Show("Der neue Benutzer wurde erfolgreich auf der Hue Bridge angelegt.", "Autorisierung erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return result;
        }

        void connectedBridgeStatus(BridgeInfo bridge)
        {
            toolStripStatusLabel_Bridge.Text = "Bridge verbunden (" + (bridge).IpAddress + ")";
            Properties.Settings.Default.lastBridgeIp = bridge.IpAddress;
            Properties.Settings.Default.Save();
            btn_ReadParameters.Enabled = true;
            resetToolStripMenuItem.Enabled = true;
            speicherbelegungToolStripMenuItem.Enabled = true;
        }
        #endregion Hilfsfunktionen

        HueParameters backup;

        private void btn_OpenBackupFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Backup-Datei öffnen";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Logger.WriteToLog("Backup-Datei laden (" + openFileDialog1.FileName + ")", LogLevel.RestoreInfo);

                try
                {
                    backup = HueParameters.FromJson(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    Logger.WriteToLog("Fehler beim lesen der Backup-Datei: " + ex.Message, LogLevel.Error);
                    throw ex;
                }
                Logger.WriteToLog("Backup-Datei erfolgreich gelesen", LogLevel.RestoreInfo);
                cbx_ReadConfig.Checked = true;
                btn_ReadConfig.Enabled = true;
            }
            else
            {
                Logger.WriteToLog("Öffnen der Backup-Datei wurde abbgebrochen", LogLevel.Error);
            }
        }

        private void btn_ReadConfig_Click(object sender, EventArgs e)
        {
            m_Controller.ReadParameters(HueParameterGroupEnum.All);
            Logger.WriteToLog("Aktuelle Konfiguration eingelesen", LogLevel.RestoreInfo);
            cbx_ReadConfig.Checked = true;
            btn_Remapping.Enabled = true;
        }

        private void btn_Remapping_Click(object sender, EventArgs e)
        {
            m_Controller.RemapParameters(backup);
        }

        private void btn_Restore_Click(object sender, EventArgs e)
        {
            
        }
    }
}
