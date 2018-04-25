using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Rca.Hue2Json.View
{
    public partial class CapabilityView : Form
    {
        public HueCapabilities Capabilities { get; set; }

        public CapabilityView(HueCapabilities capabilities)
        {
            Capabilities = capabilities;

            InitializeComponent();

            drawChart();
        }

        private void drawChart()
        {
            cat_Capabilities.Series.Clear();

            cat_Capabilities.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            cat_Capabilities.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            cat_Capabilities.ChartAreas[0].AxisY.Interval = 10;
            cat_Capabilities.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
            cat_Capabilities.ChartAreas[0].AxisY.Minimum = 0;
            cat_Capabilities.ChartAreas[0].AxisY.Maximum = 100;
            cat_Capabilities.ChartAreas[0].AxisY.Title = "Belegung in %";


            cat_Capabilities.Series.Add("lights");
            cat_Capabilities.Series["lights"].Points.AddY(Capabilities.Lights.InUsePercent);
            cat_Capabilities.Series["lights"].IsVisibleInLegend = false;
            cat_Capabilities.Series["lights"].Label = "Leuchtmittel";
            cat_Capabilities.Series["lights"]["MinPixelPointWidth"] = "420";

            cat_Capabilities.Series.Add("sensors");
            cat_Capabilities.Series["sensors"].Points.AddY(Capabilities.Sensors.InUsePercent);
            cat_Capabilities.Series["sensors"].IsVisibleInLegend = false;
            cat_Capabilities.Series["sensors"].Label = "Sensoren";
            cat_Capabilities.Series["sensors"]["MinPixelPointWidth"] = "420";

            cat_Capabilities.Series.Add("groups");
            cat_Capabilities.Series["groups"].Points.AddY(Capabilities.Groups.InUsePercent);
            cat_Capabilities.Series["groups"].IsVisibleInLegend = false;
            cat_Capabilities.Series["groups"].Label = "Gruppen";
            cat_Capabilities.Series["groups"]["MinPixelPointWidth"] = "420";

            cat_Capabilities.Series.Add("schedules");
            cat_Capabilities.Series["schedules"].Points.AddY(Capabilities.Schedules.InUsePercent);
            cat_Capabilities.Series["schedules"].IsVisibleInLegend = false;
            cat_Capabilities.Series["schedules"].Label = "Timer";
            cat_Capabilities.Series["schedules"]["MinPixelPointWidth"] = "420";

            cat_Capabilities.Series.Add("rules");
            cat_Capabilities.Series["rules"].Points.AddY(Capabilities.RulesInUsePercent.Count);
            cat_Capabilities.Series["rules"].IsVisibleInLegend = false;
            cat_Capabilities.Series["rules"].Label = "Regeln";
            cat_Capabilities.Series["rules"]["MinPixelPointWidth"] = "420";


            cat_Capabilities.Update();
            cat_Capabilities.PerformLayout();

            lbl_Lights.Text = Capabilities.Lights.ToString();
            lbl_Sensors.Text = Capabilities.Sensors.ToString();
            lbl_Groups.Text = Capabilities.Groups.ToString();
            lbl_Schedules.Text = Capabilities.Schedules.ToString();
            llb_Rules.Text = Capabilities.RulesInUse.Count + "/" + Capabilities.RulesAvailable.Count + " (" + Capabilities.RulesInUsePercent.Count.ToString("F1") + " %)";
            lbl_Resourcelinks.Text = Capabilities.Resourcelinks.ToString();
        }

        private void llb_Rules_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ruleDetailsView = new CapabilityRuleDetailsView(Capabilities);
            ruleDetailsView.Show();
        }
    }
}
