using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectUTS
{
    public partial class upgradeIngfo : Form
    {
        public upgradeIngfo()
        {
            InitializeComponent();
            dataGridView1.DataSource = Data.woodCutter;
            dataGridView2.DataSource = Data.clayPit;
            dataGridView3.DataSource = Data.player;
            dataGridView4.DataSource = Data.cropLand;


        }
    }
}
