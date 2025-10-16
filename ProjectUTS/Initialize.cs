using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ProjectUTS
{
    internal class Initialize
    {
        public Initialize()
        {

            Data.dataSet = new Progress();
            Data.map = Data.dataSet.Tables["JenisMap"];
            Data.progress = Data.dataSet.Tables["MapProgress"];
            Data.player = Data.dataSet.Tables["Player"];
            Data.savedGrid = new List<Panel>();


            if (File.Exists("saveMap.xml") && File.Exists("saveProgress.xml") && File.Exists("savePlayer.xml"))
            {
                Data.isThereSavedProgress = true;
                


            }
            

            if(!Data.isThereSavedProgress)
            {
                initDefaultData();
                //MessageBox.Show("No data Found jadi mulai dari awal");
            }
            else
            {
                bool loaded = Data.load();
                if (loaded)
                {
                    MessageBox.Show("Data founded, Lanjutin dari trakhir maen!");
                    if(Data.progress.Rows.Count != Data.totalMap || Data.player.Rows.Count < 1 || Data.map.Rows.Count != 4)
                    {
                        MessageBox.Show("Data ga sesuai ama default ntah napa Jadi bakal ngulang dari awal yeah");
                        initDefaultData();
                    }
                }
                else
                {
                    MessageBox.Show("Data korup jadi mulai dari awal yeah");
                    initDefaultData();
                }


            }
        }


        public void initDefaultData()
        {


            //add data map
            DataRow mapRow = Data.map.NewRow();
            mapRow["id"] = 0;
            mapRow["nama"] = "Clay";
            Data.map.Rows.Add(mapRow);

            mapRow = Data.map.NewRow();
            mapRow["id"] = 1;
            mapRow["nama"] = "Iron";
            Data.map.Rows.Add(mapRow);

            mapRow = Data.map.NewRow();
            mapRow["id"] = 2;
            mapRow["nama"] = "Wood";
            Data.map.Rows.Add(mapRow);

            mapRow = Data.map.NewRow();
            mapRow["id"] = 3;
            mapRow["nama"] = "Crop";
            Data.map.Rows.Add(mapRow);

            //add map objek
            int[,] loc = new int[18, 2];

            loc[0, 0] = 456; loc[0, 1] = 210;
            loc[1, 0] = 564; loc[1, 1] = 222;
            loc[2, 0] = 683; loc[2, 1] = 494;
            loc[3, 0] = 342; loc[3, 1] = 526;
            loc[4, 0] = 243; loc[4, 1] = 188;
            loc[5, 0] = 640; loc[5, 1] = 280;
            loc[6, 0] = 725; loc[6, 1] = 219;
            loc[7, 0] = 809; loc[7, 1] = 280;
            loc[8, 0] = 651; loc[8, 1] = 142;
            loc[9, 0] = 354; loc[9, 1] = 118;
            loc[10, 0] = 540; loc[10, 1] = 429;
            loc[11, 0] = 514; loc[11, 1] = 534;
            loc[12, 0] = 523; loc[12, 1] = 121;
            loc[13, 0] = 769; loc[13, 1] = 376;
            loc[14, 0] = 131; loc[14, 1] = 278;
            loc[15, 0] = 282; loc[15, 1] = 279;
            loc[16, 0] = 284; loc[16, 1] = 367;
            loc[17, 0] = 145; loc[17, 1] = 385;
            int[] jenisMap = new int[18] { 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3 };

            //masukin ke dataTable progress
            for (int i = 0; i < 18; i++)
            {
                DataRow progressRow = Data.progress.NewRow();
                progressRow["id"] = i;
                progressRow["jenisMap"] = jenisMap[i];
                progressRow["level"] = 0;
                progressRow["PositionX"] = loc[i, 0];
                progressRow["PositionY"] = loc[i, 1];
                progressRow["productionPerHour"] = 8;  //isi sinni base production nya
                Data.progress.Rows.Add(progressRow);

            }


            //set Player
            DataRow playerRow = Data.player.NewRow();
            playerRow["id"] = 0;
            playerRow["clay"] = 0;
            playerRow["iron"] = 0;
            playerRow["wood"] = 0;
            playerRow["crop"] = 0;
            playerRow["upgradeInProgress"] = false;
            playerRow["idMapUpgrade"] = -1;
            playerRow["EstimateTimeFinishUpgrade"] = DateTime.Now;
            playerRow["LastOnline"] = DateTime.Now;
            Data.player.Rows.Add(playerRow);

        }
    }
}
