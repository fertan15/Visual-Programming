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

            //sources
            Data.dataSetSources = new sources();
            Data.woodCutter = Data.dataSetSources.Tables["woodCutter"];
            Data.clayPit = Data.dataSetSources.Tables["clayPit"];
            Data.ironMine = Data.dataSetSources.Tables["ironMine"];
            Data.cropLand = Data.dataSetSources.Tables["cropLand"];

            addDataClayPit();
            addDataCropLand();
            addDataIronMine();
            addDataWoodCutter();

            Data.loadProductionMultiplier();



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
        public void addDataWoodCutter()
        {
            //MessageBox.Show("masuk addwoodcutter");
            DataTable woodCutterTable = Data.woodCutter;

            DataRow row1 = woodCutterTable.NewRow();
            row1["level"] = 1;
            row1["wood"] = 40;
            row1["clay"] = 100;
            row1["iron"] = 50;
            row1["crop"] = 60;
            row1["produceTime"] = 260;
            row1["producePerHour"] = 7;
            woodCutterTable.Rows.Add(row1);

            DataRow row2 = woodCutterTable.NewRow();
            row2["level"] = 2;
            row2["wood"] = 65;
            row2["clay"] = 165;
            row2["iron"] = 85;
            row2["crop"] = 100;
            row2["produceTime"] = 620;
            row2["producePerHour"] = 13;
            woodCutterTable.Rows.Add(row2);

            DataRow row3 = woodCutterTable.NewRow();
            row3["level"] = 3;
            row3["wood"] = 110;
            row3["clay"] = 280;
            row3["iron"] = 140;
            row3["crop"] = 165;
            row3["produceTime"] = 1190;
            row3["producePerHour"] = 21;
            woodCutterTable.Rows.Add(row3);

            DataRow row4 = woodCutterTable.NewRow();
            row4["level"] = 4;
            row4["wood"] = 185;
            row4["clay"] = 465;
            row4["iron"] = 235;
            row4["crop"] = 280;
            row4["produceTime"] = 2100;
            row4["producePerHour"] = 31;
            woodCutterTable.Rows.Add(row4);

            DataRow row5 = woodCutterTable.NewRow();
            row5["level"] = 5;
            row5["wood"] = 310;
            row5["clay"] = 780;
            row5["iron"] = 390;
            row5["crop"] = 465;
            row5["produceTime"] = 3560;
            row5["producePerHour"] = 46;
            woodCutterTable.Rows.Add(row5);

            DataRow row6 = woodCutterTable.NewRow();
            row6["level"] = 6;
            row6["wood"] = 520;
            row6["clay"] = 465;
            row6["iron"] = 235;
            row6["crop"] = 280;
            row6["produceTime"] = 5890;
            row6["producePerHour"] = 70;
            woodCutterTable.Rows.Add(row6);

            DataRow row7 = woodCutterTable.NewRow();
            row7["level"] = 7;
            row7["wood"] = 870;
            row7["clay"] = 2170;
            row7["iron"] = 1085;
            row7["crop"] = 1300;
            row7["produceTime"] = 9620;
            row7["producePerHour"] = 98;
            woodCutterTable.Rows.Add(row7);

            DataRow row8 = woodCutterTable.NewRow();
            row8["level"] = 8;
            row8["wood"] = 1450;
            row8["clay"] = 3625;
            row8["iron"] = 1810;
            row8["crop"] = 2175;
            row8["produceTime"] = 15590;
            row8["producePerHour"] = 140;
            woodCutterTable.Rows.Add(row8);

            DataRow row9 = woodCutterTable.NewRow();
            row9["level"] = 9;
            row9["wood"] = 2420;
            row9["clay"] = 6050;
            row9["iron"] = 3025;
            row9["crop"] = 3630;
            row9["produceTime"] = 25150;
            row9["producePerHour"] = 203;
            woodCutterTable.Rows.Add(row9);

            DataRow row10 = woodCutterTable.NewRow();
            row10["level"] = 10;
            row10["wood"] = 4040;
            row10["clay"] = 10105;
            row10["iron"] = 5050;
            row10["crop"] = 6060;
            row10["produceTime"] = 40440;
            row10["producePerHour"] = 280;
            woodCutterTable.Rows.Add(row10);

            DataRow row11 = woodCutterTable.NewRow();
            row11["level"] = 11;
            row11["wood"] = 6750;
            row11["clay"] = 16870;
            row11["iron"] = 8435;
            row11["crop"] = 10125;
            row11["produceTime"] = 64900;
            row11["producePerHour"] = 392;
            woodCutterTable.Rows.Add(row11);

            DataRow row12 = woodCutterTable.NewRow();
            row12["level"] = 12;
            row12["wood"] = 11270;
            row12["clay"] = 28175;
            row12["iron"] = 14090;
            row12["crop"] = 16905;
            row12["produceTime"] = 104050;
            row12["producePerHour"] = 525;
            woodCutterTable.Rows.Add(row12);

            DataRow row13 = woodCutterTable.NewRow();
            row13["level"] = 13;
            row13["wood"] = 18820;
            row13["clay"] = 47055;
            row13["iron"] = 23525;
            row13["crop"] = 28230;
            row13["produceTime"] = 40440;
            row13["producePerHour"] = 166680;
            woodCutterTable.Rows.Add(row13);

            DataRow row14 = woodCutterTable.NewRow();
            row14["level"] = 14;
            row14["wood"] = 31430;
            row14["clay"] = 78580;
            row14["iron"] = 39290;
            row14["crop"] = 47150;
            row14["produceTime"] = 266880;
            row14["producePerHour"] = 889;
            woodCutterTable.Rows.Add(row14);

            DataRow row15 = woodCutterTable.NewRow();
            row15["level"] = 15;
            row15["wood"] = 52490;
            row15["clay"] = 131230;
            row15["iron"] = 65615;
            row15["crop"] = 78740;
            row15["produceTime"] = 427210;
            row15["producePerHour"] = 1120;
            woodCutterTable.Rows.Add(row15);

            DataRow row16 = woodCutterTable.NewRow();
            row16["level"] = 16;
            row16["wood"] = 87660;
            row16["clay"] = 219155;
            row16["iron"] = 109575;
            row16["crop"] = 131490;
            row16["produceTime"] = 683730;
            row16["producePerHour"] = 1400;
            woodCutterTable.Rows.Add(row16);

            DataRow row17 = woodCutterTable.NewRow();
            row17["level"] = 17;
            row17["wood"] = 146395;
            row17["clay"] = 365985;
            row17["iron"] = 182995;
            row17["crop"] = 219590;
            row17["produceTime"] = 1094170;
            row17["producePerHour"] = 1820;
            woodCutterTable.Rows.Add(row17);

            DataRow row18 = woodCutterTable.NewRow();
            row18["level"] = 18;
            row18["wood"] = 244480;
            row18["clay"] = 611195;
            row18["iron"] = 305600;
            row18["crop"] = 366715;
            row18["produceTime"] = 1750880;
            row18["producePerHour"] = 2240;
            woodCutterTable.Rows.Add(row18);

            DataRow row19 = woodCutterTable.NewRow();
            row19["level"] = 19;
            row19["wood"] = 408280;
            row19["clay"] = 1020695;
            row19["iron"] = 510350;
            row19["crop"] = 612420;
            row19["produceTime"] = 2801600;
            row19["producePerHour"] = 2800;
            woodCutterTable.Rows.Add(row19);

            DataRow row20 = woodCutterTable.NewRow();
            row20["level"] = 20;
            row20["wood"] = 681825;
            row20["clay"] = 1704565;
            row20["iron"] = 852280;
            row20["crop"] = 1022740;
            row20["produceTime"] = 4482770;
            row20["producePerHour"] = 3430;
            woodCutterTable.Rows.Add(row20);

        }

        public void addDataClayPit()
        {
            DataTable clayPitTable = Data.clayPit;

            DataRow row1 = clayPitTable.NewRow();
            row1["level"] = 1;
            row1["wood"] = 80;
            row1["clay"] = 40;
            row1["iron"] = 80;
            row1["crop"] = 50;
            row1["produceTime"] = 220;
            row1["producePerHour"] = 7;
            clayPitTable.Rows.Add(row1);

            DataRow row2 = clayPitTable.NewRow();
            row2["level"] = 2;
            row2["wood"] = 135;
            row2["clay"] = 65;
            row2["iron"] = 135;
            row2["crop"] = 85;
            row2["produceTime"] = 550;
            row2["producePerHour"] = 13;
            clayPitTable.Rows.Add(row2);

            DataRow row3 = clayPitTable.NewRow();
            row3["level"] = 3;
            row3["wood"] = 225;
            row3["clay"] = 110;
            row3["iron"] = 225;
            row3["crop"] = 140;
            row3["produceTime"] = 1080;
            row3["producePerHour"] = 21;
            clayPitTable.Rows.Add(row3);

            DataRow row4 = clayPitTable.NewRow();
            row4["level"] = 4;
            row4["wood"] = 375;
            row4["clay"] = 185;
            row4["iron"] = 375;
            row4["crop"] = 235;
            row4["produceTime"] = 1930;
            row4["producePerHour"] = 31;
            clayPitTable.Rows.Add(row4);

            DataRow row5 = clayPitTable.NewRow();
            row5["level"] = 5;
            row5["wood"] = 620;
            row5["clay"] = 310;
            row5["iron"] = 620;
            row5["crop"] = 390;
            row5["produceTime"] = 3290;
            row5["producePerHour"] = 46;
            clayPitTable.Rows.Add(row5);

            DataRow row6 = clayPitTable.NewRow();
            row6["level"] = 6;
            row6["wood"] = 1040;
            row6["clay"] = 520;
            row6["iron"] = 1040;
            row6["crop"] = 650;
            row6["produceTime"] = 5470;
            row6["producePerHour"] = 70;
            clayPitTable.Rows.Add(row6);

            DataRow row7 = clayPitTable.NewRow();
            row7["level"] = 7;
            row7["wood"] = 1735;
            row7["clay"] = 870;
            row7["iron"] = 1735;
            row7["crop"] = 1085;
            row7["produceTime"] = 8950;
            row7["producePerHour"] = 98;
            clayPitTable.Rows.Add(row7);

            DataRow row8 = clayPitTable.NewRow();
            row8["level"] = 8;
            row8["wood"] = 2900;
            row8["clay"] = 1450;
            row8["iron"] = 2900;
            row8["crop"] = 1810;
            row8["produceTime"] = 14520;
            row8["producePerHour"] = 140;
            clayPitTable.Rows.Add(row8);

            DataRow row9 = clayPitTable.NewRow();
            row9["level"] = 9;
            row9["wood"] = 4840;
            row9["clay"] = 2420;
            row9["iron"] = 4840;
            row9["crop"] = 3025;
            row9["produceTime"] = 23430;
            row9["producePerHour"] = 203;
            clayPitTable.Rows.Add(row9);

            DataRow row10 = clayPitTable.NewRow();
            row10["level"] = 10;
            row10["wood"] = 8080;
            row10["clay"] = 4040;
            row10["iron"] = 8080;
            row10["crop"] = 5050;
            row10["produceTime"] = 37690;
            row10["producePerHour"] = 280;
            clayPitTable.Rows.Add(row10);

            DataRow row11 = clayPitTable.NewRow();
            row11["level"] = 11;
            row11["wood"] = 13500;
            row11["clay"] = 6750;
            row11["iron"] = 13500;
            row11["crop"] = 8435;
            row11["produceTime"] = 60510;
            row11["producePerHour"] = 392;
            clayPitTable.Rows.Add(row11);

            DataRow row12 = clayPitTable.NewRow();
            row12["level"] = 12;
            row12["wood"] = 22540;
            row12["clay"] = 11270;
            row12["iron"] = 22540;
            row12["crop"] = 14090;
            row12["produceTime"] = 97010;
            row12["producePerHour"] = 525;
            clayPitTable.Rows.Add(row12);

            DataRow row13 = clayPitTable.NewRow();
            row13["level"] = 13;
            row13["wood"] = 37645;
            row13["clay"] = 18820;
            row13["iron"] = 37645;
            row13["crop"] = 23525;
            row13["produceTime"] = 155420;
            row13["producePerHour"] = 693;
            clayPitTable.Rows.Add(row13);

            DataRow row14 = clayPitTable.NewRow();
            row14["level"] = 14;
            row14["wood"] = 62865;
            row14["clay"] = 31430;
            row14["iron"] = 62865;
            row14["crop"] = 39290;
            row14["produceTime"] = 248870;
            row14["producePerHour"] = 889;
            clayPitTable.Rows.Add(row14);

            DataRow row15 = clayPitTable.NewRow();
            row15["level"] = 15;
            row15["wood"] = 104985;
            row15["clay"] = 52490;
            row15["iron"] = 104985;
            row15["crop"] = 65615;
            row15["produceTime"] = 398390;
            row15["producePerHour"] = 1120;
            clayPitTable.Rows.Add(row15);

            DataRow row16 = clayPitTable.NewRow();
            row16["level"] = 16;
            row16["wood"] = 175320;
            row16["clay"] = 87660;
            row16["iron"] = 175320;
            row16["crop"] = 109575;
            row16["produceTime"] = 637620;
            row16["producePerHour"] = 1400;
            clayPitTable.Rows.Add(row16);

            DataRow row17 = clayPitTable.NewRow();
            row17["level"] = 17;
            row17["wood"] = 292790;
            row17["clay"] = 146395;
            row17["iron"] = 292790;
            row17["crop"] = 182995;
            row17["produceTime"] = 1020390;
            row17["producePerHour"] = 1820;
            clayPitTable.Rows.Add(row17);

            DataRow row18 = clayPitTable.NewRow();
            row18["level"] = 18;
            row18["wood"] = 488955;
            row18["clay"] = 244480;
            row18["iron"] = 488955;
            row18["crop"] = 305600;
            row18["produceTime"] = 1632820;
            row18["producePerHour"] = 2240;
            clayPitTable.Rows.Add(row18);

            DataRow row19 = clayPitTable.NewRow();
            row19["level"] = 19;
            row19["wood"] = 816555;
            row19["clay"] = 408280;
            row19["iron"] = 816555;
            row19["crop"] = 510350;
            row19["produceTime"] = 2612710;
            row19["producePerHour"] = 2800;
            clayPitTable.Rows.Add(row19);

            DataRow row20 = clayPitTable.NewRow();
            row20["level"] = 20;
            row20["wood"] = 1363650;
            row20["clay"] = 681825;
            row20["iron"] = 1363650;
            row20["crop"] = 852280;
            row20["produceTime"] = 4180540;
            row20["producePerHour"] = 3430;
            clayPitTable.Rows.Add(row20);

        }

        public void addDataIronMine()
        {
            DataTable ironMineTable = Data.ironMine;

            DataRow row1 = ironMineTable.NewRow();
            row1["level"] = 1;
            row1["wood"] = 100;
            row1["clay"] = 80;
            row1["iron"] = 30;
            row1["crop"] = 60;
            row1["produceTime"] = 220;
            row1["producePerHour"] = 7;
            ironMineTable.Rows.Add(row1);

            DataRow row2 = ironMineTable.NewRow();
            row2["level"] = 2;
            row2["wood"] = 165;
            row2["clay"] = 135;
            row2["iron"] = 50;
            row2["crop"] = 100;
            row2["produceTime"] = 920;
            row2["producePerHour"] = 13;
            ironMineTable.Rows.Add(row2);

            DataRow row3 = ironMineTable.NewRow();
            row3["level"] = 3;
            row3["wood"] = 280;
            row3["clay"] = 225;
            row3["iron"] = 85;
            row3["crop"] = 165;
            row3["produceTime"] = 1670;
            row3["producePerHour"] = 21;
            ironMineTable.Rows.Add(row3);

            DataRow row4 = ironMineTable.NewRow();
            row4["level"] = 4;
            row4["wood"] = 465;
            row4["clay"] = 375;
            row4["iron"] = 140;
            row4["crop"] = 280;
            row4["produceTime"] = 2880;
            row4["producePerHour"] = 31;
            ironMineTable.Rows.Add(row4);

            DataRow row5 = ironMineTable.NewRow();
            row5["level"] = 5;
            row5["wood"] = 780;
            row5["clay"] = 620;
            row5["iron"] = 235;
            row5["crop"] = 465;
            row5["produceTime"] = 4800;
            row5["producePerHour"] = 46;
            ironMineTable.Rows.Add(row5);

            DataRow row6 = ironMineTable.NewRow();
            row6["level"] = 6;
            row6["wood"] = 1300;
            row6["clay"] = 1040;
            row6["iron"] = 390;
            row6["crop"] = 780;
            row6["produceTime"] = 7880;
            row6["producePerHour"] = 70;
            ironMineTable.Rows.Add(row6);

            DataRow row7 = ironMineTable.NewRow();
            row7["level"] = 7;
            row7["wood"] = 2170;
            row7["clay"] = 1735;
            row7["iron"] = 650;
            row7["crop"] = 1300;
            row7["produceTime"] = 12810;
            row7["producePerHour"] = 98;
            ironMineTable.Rows.Add(row7);

            DataRow row8 = ironMineTable.NewRow();
            row8["level"] = 8;
            row8["wood"] = 3625;
            row8["clay"] = 2900;
            row8["iron"] = 1085;
            row8["crop"] = 2175;
            row8["produceTime"] = 20690;
            row8["producePerHour"] = 140;
            ironMineTable.Rows.Add(row8);

            DataRow row9 = ironMineTable.NewRow();
            row9["level"] = 9;
            row9["wood"] = 6050;
            row9["clay"] = 4840;
            row9["iron"] = 1815;
            row9["crop"] = 3630;
            row9["produceTime"] = 33310;
            row9["producePerHour"] = 203;
            ironMineTable.Rows.Add(row9);

            DataRow row10 = ironMineTable.NewRow();
            row10["level"] = 10;
            row10["wood"] = 10105;
            row10["clay"] = 8080;
            row10["iron"] = 3030;
            row10["crop"] = 6060;
            row10["produceTime"] = 53500;
            row10["producePerHour"] = 280;
            ironMineTable.Rows.Add(row10);

            DataRow row11 = ironMineTable.NewRow();
            row11["level"] = 11;
            row11["wood"] = 16870;
            row11["clay"] = 13500;
            row11["iron"] = 5060;
            row11["crop"] = 10125;
            row11["produceTime"] = 85800;
            row11["producePerHour"] = 392;
            ironMineTable.Rows.Add(row11);

            DataRow row12 = ironMineTable.NewRow();
            row12["level"] = 12;
            row12["wood"] = 28175;
            row12["clay"] = 22540;
            row12["iron"] = 8455;
            row12["crop"] = 16905;
            row12["produceTime"] = 137470;
            row12["producePerHour"] = 525;
            ironMineTable.Rows.Add(row12);

            DataRow row13 = ironMineTable.NewRow();
            row13["level"] = 13;
            row13["wood"] = 47055;
            row13["clay"] = 37645;
            row13["iron"] = 14115;
            row13["crop"] = 28230;
            row13["produceTime"] = 220160;
            row13["producePerHour"] = 693;
            ironMineTable.Rows.Add(row13);

            DataRow row14 = ironMineTable.NewRow();
            row14["level"] = 14;
            row14["wood"] = 78580;
            row14["clay"] = 62865;
            row14["iron"] = 23575;
            row14["crop"] = 47150;
            row14["produceTime"] = 352450;
            row14["producePerHour"] = 889;
            ironMineTable.Rows.Add(row14);

            DataRow row15 = ironMineTable.NewRow();
            row15["level"] = 15;
            row15["wood"] = 131230;
            row15["clay"] = 104985;
            row15["iron"] = 39370;
            row15["crop"] = 78740;
            row15["produceTime"] = 564120;
            row15["producePerHour"] = 1120;
            ironMineTable.Rows.Add(row15);

            DataRow row16 = ironMineTable.NewRow();
            row16["level"] = 16;
            row16["wood"] = 219155;
            row16["clay"] = 175320;
            row16["iron"] = 65745;
            row16["crop"] = 131490;
            row16["produceTime"] = 902790;
            row16["producePerHour"] = 1400;
            ironMineTable.Rows.Add(row16);

            DataRow row17 = ironMineTable.NewRow();
            row17["level"] = 17;
            row17["wood"] = 365985;
            row17["clay"] = 292790;
            row17["iron"] = 109795;
            row17["crop"] = 219590;
            row17["produceTime"] = 1444660;
            row17["producePerHour"] = 1820;
            ironMineTable.Rows.Add(row17);

            DataRow row18 = ironMineTable.NewRow();
            row18["level"] = 18;
            row18["wood"] = 611195;
            row18["clay"] = 488955;
            row18["iron"] = 183360;
            row18["crop"] = 366715;
            row18["produceTime"] = 2311660;
            row18["producePerHour"] = 2240;
            ironMineTable.Rows.Add(row18);

            DataRow row19 = ironMineTable.NewRow();
            row19["level"] = 19;
            row19["wood"] = 1020695;
            row19["clay"] = 816555;
            row19["iron"] = 306210;
            row19["crop"] = 612420;
            row19["produceTime"] = 3698850;
            row19["producePerHour"] = 2800;
            ironMineTable.Rows.Add(row19);

            DataRow row20 = ironMineTable.NewRow();
            row20["level"] = 20;
            row20["wood"] = 1704565;
            row20["clay"] = 1363650;
            row20["iron"] = 511370;
            row20["crop"] = 1022740;
            row20["produceTime"] = 5918370;
            row20["producePerHour"] = 3430;
            ironMineTable.Rows.Add(row20);

        }
        public void addDataCropLand()
        {
            //MessageBox.Show("masuk crop lang");
            DataTable cropLandTable = Data.cropLand;

            DataRow row1 = cropLandTable.NewRow();
            row1["level"] = 1;
            row1["wood"] = 70;
            row1["clay"] = 90;
            row1["iron"] = 70;
            row1["crop"] = 20;
            row1["produceTime"] = 150;
            row1["producePerHour"] = 7;
            cropLandTable.Rows.Add(row1);

            DataRow row2 = cropLandTable.NewRow();
            row2["level"] = 2;
            row2["wood"] = 115;
            row2["clay"] = 150;
            row2["iron"] = 115;
            row2["crop"] = 35;
            row2["produceTime"] = 440;
            row2["producePerHour"] = 13;
            cropLandTable.Rows.Add(row2);

            DataRow row3 = cropLandTable.NewRow();
            row3["level"] = 3;
            row3["wood"] = 195;
            row3["clay"] = 250;
            row3["iron"] = 195;
            row3["crop"] = 55;
            row3["produceTime"] = 900;
            row3["producePerHour"] = 21;
            cropLandTable.Rows.Add(row3);

            DataRow row4 = cropLandTable.NewRow();
            row4["level"] = 4;
            row4["wood"] = 325;
            row4["clay"] = 420;
            row4["iron"] = 325;
            row4["crop"] = 95;
            row4["produceTime"] = 1650;
            row4["producePerHour"] = 31;
            cropLandTable.Rows.Add(row4);

            DataRow row5 = cropLandTable.NewRow();
            row5["level"] = 5;
            row5["wood"] = 545;
            row5["clay"] = 700;
            row5["iron"] = 545;
            row5["crop"] = 155;
            row5["produceTime"] = 2830;
            row5["producePerHour"] = 46;
            cropLandTable.Rows.Add(row5);

            DataRow row6 = cropLandTable.NewRow();
            row6["level"] = 6;
            row6["wood"] = 910;
            row6["clay"] = 1170;
            row6["iron"] = 910;
            row6["crop"] = 260;
            row6["produceTime"] = 4730;
            row6["producePerHour"] = 70;
            cropLandTable.Rows.Add(row6);

            DataRow row7 = cropLandTable.NewRow();
            row7["level"] = 7;
            row7["wood"] = 1520;
            row7["clay"] = 1950;
            row7["iron"] = 1520;
            row7["crop"] = 435;
            row7["produceTime"] = 7780;
            row7["producePerHour"] = 98;
            cropLandTable.Rows.Add(row7);

            DataRow row8 = cropLandTable.NewRow();
            row8["level"] = 8;
            row8["wood"] = 2535;
            row8["clay"] = 3260;
            row8["iron"] = 2535;
            row8["crop"] = 725;
            row8["produceTime"] = 12640;
            row8["producePerHour"] = 140;
            cropLandTable.Rows.Add(row8);

            DataRow row9 = cropLandTable.NewRow();
            row9["level"] = 9;
            row9["wood"] = 4235;
            row9["clay"] = 5445;
            row9["iron"] = 4235;
            row9["crop"] = 1210;
            row9["produceTime"] = 20430;
            row9["producePerHour"] = 203;
            cropLandTable.Rows.Add(row9);

            DataRow row10 = cropLandTable.NewRow();
            row10["level"] = 10;
            row10["wood"] = 7070;
            row10["clay"] = 9095;
            row10["iron"] = 7070;
            row10["crop"] = 2020;
            row10["produceTime"] = 32880;
            row10["producePerHour"] = 280;
            cropLandTable.Rows.Add(row10);

            DataRow row11 = cropLandTable.NewRow();
            row11["level"] = 11;
            row11["wood"] = 11810;
            row11["clay"] = 15185;
            row11["iron"] = 11810;
            row11["crop"] = 3375;
            row11["produceTime"] = 52810;
            row11["producePerHour"] = 392;
            cropLandTable.Rows.Add(row11);

            DataRow row12 = cropLandTable.NewRow();
            row12["level"] = 12;
            row12["wood"] = 19725;
            row12["clay"] = 25360;
            row12["iron"] = 19725;
            row12["crop"] = 5635;
            row12["produceTime"] = 84700;
            row12["producePerHour"] = 525;
            cropLandTable.Rows.Add(row12);

            DataRow row13 = cropLandTable.NewRow();
            row13["level"] = 13;
            row13["wood"] = 32940;
            row13["clay"] = 42350;
            row13["iron"] = 32940;
            row13["crop"] = 9410;
            row13["produceTime"] = 135710;
            row13["producePerHour"] = 693;
            cropLandTable.Rows.Add(row13);

            DataRow row14 = cropLandTable.NewRow();
            row14["level"] = 14;
            row14["wood"] = 55005;
            row14["clay"] = 70720;
            row14["iron"] = 55005;
            row14["crop"] = 15715;
            row14["produceTime"] = 217340;
            row14["producePerHour"] = 889;
            cropLandTable.Rows.Add(row14);

            DataRow row15 = cropLandTable.NewRow();
            row15["level"] = 15;
            row15["wood"] = 91860;
            row15["clay"] = 118105;
            row15["iron"] = 91860;
            row15["crop"] = 26245;
            row15["produceTime"] = 347950;
            row15["producePerHour"] = 1120;
            cropLandTable.Rows.Add(row15);

            DataRow row16 = cropLandTable.NewRow();
            row16["level"] = 16;
            row16["wood"] = 153405;
            row16["clay"] = 197240;
            row16["iron"] = 153405;
            row16["crop"] = 43830;
            row16["produceTime"] = 556910;
            row16["producePerHour"] = 1400;
            cropLandTable.Rows.Add(row16);

            DataRow row17 = cropLandTable.NewRow();
            row17["level"] = 17;
            row17["wood"] = 256190;
            row17["clay"] = 329385;
            row17["iron"] = 256190;
            row17["crop"] = 73195;
            row17["produceTime"] = 891260;
            row17["producePerHour"] = 1820;
            cropLandTable.Rows.Add(row17);

            DataRow row18 = cropLandTable.NewRow();
            row18["level"] = 18;
            row18["wood"] = 427835;
            row18["clay"] = 550075;
            row18["iron"] = 427835;
            row18["crop"] = 122240;
            row18["produceTime"] = 1426210;
            row18["producePerHour"] = 2240;
            cropLandTable.Rows.Add(row18);

            DataRow row19 = cropLandTable.NewRow();
            row19["level"] = 19;
            row19["wood"] = 714485;
            row19["clay"] = 918625;
            row19["iron"] = 714485;
            row19["crop"] = 204140;
            row19["produceTime"] = 2282140;
            row19["producePerHour"] = 2800;
            cropLandTable.Rows.Add(row19);

            DataRow row20 = cropLandTable.NewRow();
            row20["level"] = 20;
            row20["wood"] = 1193195;
            row20["clay"] = 1534105;
            row20["iron"] = 1193195;
            row20["crop"] = 340915;
            row20["produceTime"] = 3651630;
            row20["producePerHour"] = 3430;
            cropLandTable.Rows.Add(row20);

        }

    }
}
