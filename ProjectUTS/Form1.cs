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
        Map selected; //buat index map yang tak klik skarang soale ganti2
        int multiplier = 1; //buat multiplier production
        int waktu = 300;
        int gameIntervalNormal = 1000;
        bool gakMiskin = true;
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
            gameTimer.Start();



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
            if (e.KeyCode == Keys.F2)
            {
                upgradeIngfo b = new upgradeIngfo();
                b.ShowDialog();
            }

            if (e.KeyCode == Keys.D1)
            {
                multiplier = 1;
                
            }
            if(e.KeyCode == Keys.D2)
            {
                multiplier = 2;
            }
            if(e.KeyCode == Keys.D3)
            {
                multiplier = 3;
            }
            if(e.KeyCode == Keys.D4)
            {
                multiplier = 4;
            }
            if(e.KeyCode == Keys.D5)
            {
                multiplier = 5;
            }
            if(e.KeyCode == Keys.D6)
            {
                multiplier = 6;
            }
            if(e.KeyCode == Keys.D7)
            {
                multiplier = 7;
            }
            if(e.KeyCode == Keys.D8)
            {
                multiplier = 8;
            }
            if(e.KeyCode == Keys.D9)
            {
                multiplier = 9;
            }
            if(e.KeyCode == Keys.D0) // iki 10 ko
            {
                multiplier = 10;
            }
        }


        private void Map_Click(object sender, EventArgs e)
        {
            //ini set kalo misal map di klik gimana
            selected = (Map)sender;

            MessageBox.Show("Map ID: " + selected.id + "\nProduction : "  + selected.getProductionPerHour());

            // ini tak taruk detailnya disini
            showDetails(selected.getJenis());

        }

        private void upgradeButton_Click(object sender, EventArgs e)
        {
            if(selected == null)
            {
                MessageBox.Show("Pilih map dulu");
                return;
            }

            if(Data.getClay() < 1)
            {
                gakMiskin = false;
                MessageBox.Show("minggir lu miskin");
                return;
            }
            else
            { 
                gakMiskin = true; 
            }
            if (Data.getIron() < 1)
            {
                gakMiskin = false;
                MessageBox.Show("minggir lu miskin");
                return;
            }
            else
            {
                gakMiskin = true;
            }
            if (Data.getWood() < 1)
            {
                gakMiskin = false;
                MessageBox.Show("minggir lu miskin");
                return;
            }
            else
            {
                gakMiskin = true;
            }
            if (Data.getCrop() < 1)
            {
                gakMiskin = false;
                MessageBox.Show("minggir lu miskin");
                return;
            }
            else
            {
                gakMiskin = true;
            }
            if (gakMiskin)
            {
                Data.addClay(-1);
                Data.addIron(-1);
                Data.addWood(-1);
                Data.addCrop(-1);
                upgradeButton.Enabled = false;

                countdowntimer.Start();
                gakMiskin = true;
                //mulai upgrade -> buat save di dataset
                Data.upgrade(selected.id, waktu);
            }
                
        }

        private void countdowntimer_Tick(object sender, EventArgs e)
        {
            int detik = waktu;
            int hours = detik / 3600;
            detik %= 3600;
            int minutes = detik / 60;
            detik %= 60;
            countDown.Text = hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + detik.ToString("D2");
            waktu--;

            if (waktu <= 0)
            {
                selected.addLevel();
                selected.setProductionPerHour(20); //nambah produksi bang
                countDown.Text = "00:00:00";
                countdowntimer.Stop();
                upgradeButton.Enabled = true;
                selected = null;
                Data.upgradeFinish();
                //tes
                waktu = 3;                
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            refresh();
        }


        public void refresh()
        {
            gameTimer.Interval = gameIntervalNormal / multiplier; // biar cepet kalo multiplier gede
            countdowntimer.Interval = gameIntervalNormal / multiplier;
            if (Data.anyUpgrade())
            {
                //sek masih rodok rodok error
                Data.setEstimateTime(waktu/multiplier);

            }

            clayPerHour.Text = Data.getAllClayProduction().ToString();
            ironPerHour.Text = Data.getAllIronProduction().ToString();
            woodPerHour.Text = Data.getAllWoodProduction().ToString();
            cropPerHour.Text = Data.getAllCropProduction().ToString();

            Data.addClay(Convert.ToDouble(Data.getAllClayProduction()) / 3600 * multiplier);
            Data.addIron(Convert.ToDouble(Data.getAllIronProduction()) / 3600 * multiplier);
            Data.addWood(Convert.ToDouble(Data.getAllWoodProduction()) / 3600 * multiplier);
            Data.addCrop(Convert.ToDouble(Data.getAllCropProduction()) / 3600 * multiplier);


            clayInven.Text = Data.getClay().ToString();
            ironInven.Text = Data.getIron().ToString();
            woodInven.Text = Data.getWood().ToString();
            cropInven.Text = Data.getCrop().ToString();
        }

        public void showDetails(int id)
        {

            if(id == 0)
            {
                //clay
                buildingDetails.Text = "hohoho";
                timeNeeded.Text = "ko keset pepega";
            }
            else if(id == 1)
            {
                //iron
                buildingDetails.Text = "";
                timeNeeded.Text = "";
            }
            else if(id == 2)
            {
                //wood
                buildingDetails.Text = "";
                timeNeeded.Text = "";
            }
            else if(id == 3)
            {
                //crop
                buildingDetails.Text = "";
                timeNeeded.Text = "";
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            //save data pas form di tutup
            Data.save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}
