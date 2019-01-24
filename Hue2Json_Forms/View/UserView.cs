using Q42.HueApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rca.Hue2Json.View
{
    public partial class UserView : Form
    {
        public List<WhiteList> Users { get; set; }

        public UserView(List<WhiteList> users)
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;

            Users = users;



            var dummy = users[0];
            string creationDate = dummy.CreateDate;
            string id = dummy.Id;
            string lastUseDate = dummy.LastUsedDate;
            string name = dummy.Name;

        }
    }
}
