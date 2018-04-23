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

            cat_Capabilities.Series.Add("rules");
            cat_Capabilities.Series["rules"].Points.AddY(Capabilities.RulesInUsePercent.Count);
            cat_Capabilities.Series["rules"].IsVisibleInLegend = false;
            cat_Capabilities.Series["rules"].Label = "Regeln";
            //cat_Capabilities.Series["rules"].CustomProperties = "MinPixelPointWidth=150";
            //cat_Capabilities.Series["rules"].SetCustomProperty("MinPixelPointWidth", "80");
            cat_Capabilities.Series["rules"]["MinPixelPointWidth"] = "220";

            cat_Capabilities.Series.Add("actions");
            cat_Capabilities.Series["actions"].Points.AddY(Capabilities.RulesInUsePercent.Actions);
            cat_Capabilities.Series["actions"].IsVisibleInLegend = false;
            cat_Capabilities.Series["actions"].Label = "Aktionen";
            //cat_Capabilities.Series["actions"].SetCustomProperty("MinPixelPointWidth", "80");
            cat_Capabilities.Series["actions"]["MinPixelPointWidth"] = "220";

            cat_Capabilities.Series.Add("conditions");
            cat_Capabilities.Series["conditions"].Points.AddY(Capabilities.RulesInUsePercent.Conditions);
            cat_Capabilities.Series["conditions"].IsVisibleInLegend = false;
            cat_Capabilities.Series["conditions"].Label = "Bedingungen";
            //cat_Capabilities.Series["conditions"].SetCustomProperty("MinPixelPointWidth", "80");
            cat_Capabilities.Series["conditions"]["MinPixelPointWidth"] = "220";

            cat_Capabilities.Update();
            cat_Capabilities.PerformLayout();

            lbl_Rules.Text = Capabilities.RulesInUse.Count + "/" + Capabilities.RulesAvailable.Count + " (" + Capabilities.RulesInUsePercent.Count.ToString("F1") + " %)";
            lbl_Conditions.Text = Capabilities.RulesInUse.Conditions + "/" + Capabilities.RulesAvailable.Conditions + " (" + Capabilities.RulesInUsePercent.Conditions.ToString("F1") + " %)";
            lbl_Actions.Text = Capabilities.RulesInUse.Actions + "/" + Capabilities.RulesAvailable.Actions + " (" + Capabilities.RulesInUsePercent.Actions.ToString("F1") + " %)";

            lbl_ActionsPerRule.Text = Capabilities.MeanActions.ToString("F2");
            lbl_ConditionsPerRule.Text = Capabilities.MeanConditions.ToString("F2");

            double maxValue = Capabilities.RulesInUsePercent.Count;
            string freeSpaceText = (Capabilities.RulesAvailable.Count - Capabilities.RulesInUse.Count) + " Regeln (Regellimit)";
            if (Capabilities.RulesInUsePercent.Conditions > maxValue)
            {
                maxValue = Capabilities.RulesInUsePercent.Conditions;
                freeSpaceText = (Capabilities.RulesAvailable.Conditions - Capabilities.RulesInUse.Conditions) + " Regeln (Bedingungslimit)";
            }
            if (Capabilities.RulesInUsePercent.Actions > maxValue)
                freeSpaceText = (Capabilities.RulesAvailable.Actions - Capabilities.RulesInUse.Actions) + " Regeln (Aktionslimit)";
            

            lbl_FreeSpace.Text = freeSpaceText;
        }



    }
}
