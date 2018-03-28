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
    public partial class ParameterView : Form
    {
        public ParameterView()
        {
            InitializeComponent();
        }

        public void ApplyParameters(HueParameters parameters)
        {
            pyg_Parameters.SelectedObject = parameters;
        }
    }
}
