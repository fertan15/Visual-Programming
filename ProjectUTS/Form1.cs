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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new Initialize();
            Data.loadMap();

            //set ukuran pic box dulu buat antisipasi manusia dajjal

            PictureBox pic = new PictureBox();
            pic.Size = new Size(879, 552);
            pic.Location = new Point(12, 74);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Image = Image.FromFile("Map.png"); 
            pic.BackColor = Color.Transparent;

            placeLabel();
            this.Controls.Add(pic);
    

        }



        public void placeLabel()
        {
            if (Data.mapList == null)
                return;

              //ini buat naruh label pas awal2 mulai 
            foreach(Map m in Data.mapList)
            {
                m.Click += Map_Click;
                this.Controls.Add(m);
            }

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //ini buat debug data yes
            if (e.KeyCode == Keys.F3)
            {
                CheckData b = new CheckData();
                b.ShowDialog();
            }
        }

    
        private void Map_Click(object sender, EventArgs e)
        {
            //ini set kalo misal map di klik gimana
            Map selected = (Map)sender;

            MessageBox.Show("Map ID: " + selected.id + "\nProduction : "  + selected.getProductionPerHour());
        }
    }
}
