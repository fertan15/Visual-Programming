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
    public partial class CheckData : Form
    {
        public CheckData()
        {
            InitializeComponent();
            dataGridView1.DataSource = Data.progress;
            dataGridView2.DataSource = Data.map;
            dataGridView3.DataSource = Data.player;
        }

    }
}
