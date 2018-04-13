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

            //label1.Text = "1st line" + Environment.NewLine + "another line...";

            Timeout = 60;
            timer.Interval = TIMER_INTERVALL;
            timer.Start();
        }
        #endregion

        #region Internal services
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            timer.Stop();
            m_CancellationSource.Cancel();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Timeout <= 0)
                throw new ArgumentException("Ungültiger Wert für Timeout.");

            m_TimeoutCounter++;

            int progressValue = (int)(m_TimeoutCounter / (double)(Timeout * 10 / TIMER_INTERVALL) );

            if (progressValue > 100)
            {
                timer.Stop();
                m_CancellationSource.Cancel();
            }
            progressBar.Value = progressValue;
        }
        #endregion
    }
}
