using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProjectUTS
{
    public partial class Form1 : Form
    {
        Map selected; //buat index map yang tak klik skarang soale ganti2
        int multiplier = 1; //buat multiplier production
        int waktu = 300;
        int gameIntervalNormal = 1000;
        bool gakMiskin = false;
        bool clayTrue = true, ironTrue = true, woodTrue = true, cropTrue = true;
        int woodNeeded, clayNeeded, ironNeeded, cropNeeded; //buat dikurangi
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

            // ini tak taruk detailnya disini
            showUpgradeDetails(selected);

        }

        private void upgradeButton_Click(object sender, EventArgs e)
        {
            if(selected == null)
            {
                MessageBox.Show("Pilih map dulu");
                return;
            }
            
            cekResource(selected, selected.getLevel());

            if (gakMiskin)
            {
                updateHarga(selected);

                MessageBox.Show("Upgrade started");
                Data.deleteClay(clayNeeded);
                Data.deleteIron(ironNeeded);
                Data.deleteWood(woodNeeded);
                Data.deleteCrop(cropNeeded);
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
                int produceBaru = Data.getProducePerHour_clayPit(selected.getLevel());
                selected.setProductionPerHour(selected.getProductionPerHour() + produceBaru);
                selected.addLevel();
                countDown.Text = "00:00:00";
                countdowntimer.Stop();
                upgradeButton.Enabled = true;
                selected = null;
                Data.upgradeFinish();           
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
            //if (Data.anyUpgrade())
            //{
            //    //sek masih rodok rodok error
            //    Data.setEstimateTime(waktu/multiplier);

            //}s

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

        public void showDetails(Map selected, int waktus)
        {
            int detik = waktus;
            int hours = detik / 3600;
            detik %= 3600;
            int minutes = detik / 60;
            detik %= 60;

            print(selected, hours, detik, minutes);

        }

        private void print (Map selected, int hours, int detik, int minutes)
        {
            if (selected.getJenis() == 0)
            {
                buildingDetails.Text = "Need " + Data.getClay_clayPit(selected.getLevel()) + " clay, " + Data.getIron_clayPit(selected.getLevel()) + " iron, " + Data.getWood_clayPit(selected.getLevel()) + 
                    " wood, " + Data.getCrop_clayPit(selected.getLevel()) + " crop";
                timeNeeded.Text = hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + detik.ToString("D2");
            }
            else if (selected.getJenis() == 1)
            {
                //iron
                buildingDetails.Text = "Need " + Data.getClay_ironMine(selected.getLevel()) + " clay, " + Data.getIron_ironMine(selected.getLevel()) + " iron, " + Data.getWood_ironMine(selected.getLevel()) +
                    " wood, " + Data.getCrop_ironMine(selected.getLevel()) + " crop";
                timeNeeded.Text = hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + detik.ToString("D2");
            }
            else if (selected.getJenis() == 2)
            {
                //wood
                buildingDetails.Text = "Need " + Data.getClay_woodCutter(selected.getLevel()) + 
                    " clay, " + Data.getIron_woodCutter(selected.getLevel()) + " iron, " 
                    + Data.getWood_woodCutter(selected.getLevel()) +
                    " wood, " + Data.getCrop_woodCutter(selected.getLevel()) + " crop"; 
                timeNeeded.Text = hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + detik.ToString("D2");
            }
            else if (selected.getJenis() == 3)
            {
                //crop
                buildingDetails.Text = buildingDetails.Text = "Need " + Data.getClay_cropLand(selected.getLevel()) +
                    " clay, " + Data.getIron_cropLand(selected.getLevel()) + " iron, "
                    + Data.getWood_cropLand(selected.getLevel()) +
                    " wood, " + Data.getCrop_cropLand(selected.getLevel()) + " crop"; 
                timeNeeded.Text = hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + detik.ToString("D2");
            }
        }

        private void cekResource(Map selected, int lvl)
        {
            //buat cek resource cukup apa enggak
            if(selected.getJenis() == 0)
            {
                if(Data.getClay() < Data.getClay_clayPit(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    clayTrue = false;
                    return;
                }
                else
                {
                    clayTrue = true;
                }
                if (Data.getIron() < Data.getIron_clayPit(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    ironTrue = false;
                    return;
                }
                else
                {
                    ironTrue = true;
                }
                if (Data.getWood() < Data.getWood_clayPit(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    woodTrue = false;
                    return;
                }
                else
                {
                    woodTrue = true;
                }
                if (Data.getCrop() < Data.getCrop_clayPit(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    cropTrue = false;
                    return;
                }
                else
                {
                    cropTrue = true;
                }
                if(cropTrue && ironTrue && woodTrue && clayTrue)
                {
                    gakMiskin = true;
                }
                else
                {
                    gakMiskin = false;
                }
            }
            else if (selected.getJenis() == 1)
            {
                if (Data.getClay() < Data.getClay_ironMine(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    clayTrue = false;
                    return;
                }
                else
                {
                    clayTrue = true;
                }
                if (Data.getIron() < Data.getIron_ironMine(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    ironTrue = false;
                    return;
                }
                else
                {
                    ironTrue = true;
                }
                if (Data.getWood() < Data.getWood_ironMine(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    woodTrue = false;
                    return;
                }
                else
                {
                    woodTrue = true;
                }
                if (Data.getCrop() < Data.getCrop_ironMine(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    cropTrue = false;
                    return;
                }
                else
                {
                    cropTrue = true;
                }
                if (cropTrue && ironTrue && woodTrue && clayTrue)
                {
                    gakMiskin = true;
                }
                else
                {
                    gakMiskin = false;
                }
            }
            else if (selected.getJenis() == 2)
            {
                if (Data.getClay() < Data.getClay_woodCutter(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    clayTrue = false;
                    return;
                }
                else
                {
                    clayTrue = true;
                }
                if (Data.getIron() < Data.getIron_woodCutter(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    ironTrue = false;
                    return;
                }
                else
                {
                    ironTrue = true;
                }
                if (Data.getWood() < Data.getWood_woodCutter(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    woodTrue = false;
                    return;
                }
                else
                {
                    woodTrue = true;
                }
                if (Data.getCrop() < Data.getCrop_woodCutter(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    cropTrue = false;
                    return;
                }
                else
                {
                    cropTrue = true;
                }
                if (cropTrue && ironTrue && woodTrue && clayTrue)
                {
                    gakMiskin = true;
                }
                else
                {
                    gakMiskin = false;
                }
            }
            else if (selected.getJenis() == 3)
            {
                if (Data.getClay() < Data.getClay_cropLand(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    clayTrue = false;
                    return;
                }
                else
                {
                    clayTrue = true;
                }
                if (Data.getIron() < Data.getIron_cropLand(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    ironTrue = false;
                    return;
                }
                else
                {
                    ironTrue = true;
                }
                if (Data.getWood() < Data.getWood_cropLand(lvl))
                {
                    MessageBox.Show("Miskin lu");
                    woodTrue = false;
                    return;
                }
                else
                {
                    woodTrue = true;
                }
                if (Data.getCrop() < Data.getCrop_cropLand(lvl))
                {
                    cropTrue = false;
                    MessageBox.Show("Miskin lu");
                    return;
                }
                else
                {
                    cropTrue = true;
                }
                if (cropTrue && ironTrue && woodTrue && clayTrue)
                {
                    gakMiskin = true;
                }
                else
                {
                    gakMiskin = false;
                }
            }
        }

        private void updateHarga(Map selected)
        {
            if (selected.getJenis() == 0)
            {
                waktu = Data.getProduceTime_clayPit(selected.getLevel());
                clayNeeded = Data.getClay_clayPit(selected.getLevel());
                ironNeeded = Data.getIron_clayPit(selected.getLevel());
                woodNeeded = Data.getWood_clayPit(selected.getLevel());
                cropNeeded = Data.getCrop_clayPit(selected.getLevel());
            }
            else if (selected.getJenis() == 1)
            {
                waktu = Data.getProduceTime_ironMine(selected.getLevel());
                clayNeeded = Data.getClay_ironMine(selected.getLevel());
                ironNeeded = Data.getIron_ironMine(selected.getLevel());
                woodNeeded = Data.getWood_ironMine(selected.getLevel());
                cropNeeded = Data.getCrop_ironMine(selected.getLevel());
            }
            else if (selected.getJenis() == 2)
            {
                waktu = Data.getProduceTime_woodCutter(selected.getLevel());
                clayNeeded = Data.getClay_woodCutter(selected.getLevel());
                ironNeeded = Data.getIron_woodCutter(selected.getLevel());
                woodNeeded = Data.getWood_woodCutter(selected.getLevel());
                cropNeeded = Data.getCrop_woodCutter(selected.getLevel());
            }
            else if (selected.getJenis() == 3)
            {
                waktu = Data.getProduceTime_cropLand(selected.getLevel());
                clayNeeded = Data.getClay_cropLand(selected.getLevel());
                ironNeeded = Data.getIron_cropLand(selected.getLevel());
                woodNeeded = Data.getWood_cropLand(selected.getLevel());
                cropNeeded = Data.getCrop_cropLand(selected.getLevel());
            }
        }

        private void showUpgradeDetails(Map selected)
        {
            if (selected.getJenis() == 0)
            {
                //clay
                showDetails(selected, Data.getProduceTime_clayPit(selected.getLevel()));
            }
            else if (selected.getJenis() == 1)
            {
                //iron
                showDetails(selected, Data.getProduceTime_ironMine(selected.getLevel()));
            }
            else if (selected.getJenis() == 2)
            {
                //wood
                showDetails(selected, Data.getProduceTime_woodCutter(selected.getLevel()));
            }
            else if (selected.getJenis() == 3)
            {
                //crop
                showDetails(selected, Data.getProduceTime_cropLand(selected.getLevel()));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            //save data pas form di tutup
            Data.save();
        }
    }
}
