using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rca.Hue2Json.View
{
    public partial class BridgeButtonView : Form
    {
        #region Constants
        const int TIMER_INTERVALL = 100;
        #endregion

        #region Member
        CancellationTokenSource m_CancellationSource;
        int m_TimeoutCounter;
        TimeSpan m_TimeToCancel;
        #endregion

        #region Properties
        /// <summary>
        /// Wartezeit für Link-Button Betätigung in Sekunden
        /// </summary>
        public int Timeout { get; set; }
        #endregion

        #region Constructor
        public BridgeButtonView(CancellationTokenSource source)
        {
            m_CancellationSource = source;
            InitializeComponent();

            this.Text = "Autorisierung erforderlich...";
            lbl_Message.Text = "Die Autorisierung eines neuen Benutzers auf der Philips Hue Bridge erfordert eine Bestätigung." + Environment.NewLine
                + "Dazu bitte den \"Link-Button\" an der Bridge betätigen.";

            Timeout = 60;
            m_TimeToCancel = new TimeSpan(0, 0, Timeout);
            timer.Interval = TIMER_INTERVALL;
            timer.Start();
        }
        #endregion

        #region Services


        public void KillForm()
        {
            this.Invoke((MethodInvoker)delegate
            {
                // close the form on the forms thread
                this.Close();
                this.Visible = false;
            });
        }

        #endregion Services

        #region Internal services
        private void cancelForm(object sender, EventArgs e)
        {
            timer.Stop();
            m_CancellationSource.Cancel();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Timeout <= 0)
                throw new ArgumentException("Ungültiger Wert für Timeout.");

            m_TimeoutCounter++;

            int progressValue = (int)(m_TimeoutCounter / (double)(Timeout * 10 / TIMER_INTERVALL) );

            if (progressValue > 100)
                cancelForm(sender, e);
            else
            {
                progressBar.Value = progressValue;
                m_TimeToCancel -= new TimeSpan(0, 0, 0, 0, TIMER_INTERVALL);
                lbl_ProgressTime.Text = m_TimeToCancel.ToString(@"mm\:ss\,f");
            }
        }
        #endregion
    }
}
