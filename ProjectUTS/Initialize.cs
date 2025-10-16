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
            Data.woodCutter = Data.dataSetSources.Tables["woodCutter"];



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
            DataTable woodCutterTable = Data.woodCutter;

            DataRow row1 = woodCutterTable.NewRow();
            row1["level"] = 1;
            row1["woodWoodCutter"] = 40;
            row1["clayWoodCutter"] = 100;
            row1["ironWoodCutter"] = 50;
            row1["cropWoodCutter"] = 60;
            row1["produceTimeWoodCutter"] = 260;
            row1["producePerHourWoodCutter"] = 7;
            woodCutterTable.Rows.Add(row1);

            DataRow row2 = woodCutterTable.NewRow();
            row2["level"] = 2;
            row2["woodWoodCutter"] = 65;
            row2["clayWoodCutter"] = 165;
            row2["ironWoodCutter"] = 85;
            row2["cropWoodCutter"] = 100;
            row2["produceTimeWoodCutter"] = 620;
            row2["producePerHourWoodCutter"] = 13;
            woodCutterTable.Rows.Add(row2);

            DataRow row3 = woodCutterTable.NewRow();
            row3["level"] = 3;
            row3["woodWoodCutter"] = 110;
            row3["clayWoodCutter"] = 280;
            row3["ironWoodCutter"] = 140;
            row3["cropWoodCutter"] = 165;
            row3["produceTimeWoodCutter"] = 1190;
            row3["producePerHourWoodCutter"] = 21;
            woodCutterTable.Rows.Add(row3);

            DataRow row4 = woodCutterTable.NewRow();
            row4["level"] = 4;
            row4["woodWoodCutter"] = 185;
            row4["clayWoodCutter"] = 465;
            row4["ironWoodCutter"] = 235;
            row4["cropWoodCutter"] = 280;
            row4["produceTimeWoodCutter"] = 2100;
            row4["producePerHourWoodCutter"] = 31;
            woodCutterTable.Rows.Add(row4);

            DataRow row5 = woodCutterTable.NewRow();
            row5["level"] = 5;
            row5["woodWoodCutter"] = 310;
            row5["clayWoodCutter"] = 780;
            row5["ironWoodCutter"] = 390;
            row5["cropWoodCutter"] = 465;
            row5["produceTimeWoodCutter"] = 3560;
            row5["producePerHourWoodCutter"] = 46;
            woodCutterTable.Rows.Add(row5);

            DataRow row6 = woodCutterTable.NewRow();
            row6["level"] = 6;
            row6["woodWoodCutter"] = 520;
            row6["clayWoodCutter"] = 465;
            row6["ironWoodCutter"] = 235;
            row6["cropWoodCutter"] = 280;
            row6["produceTimeWoodCutter"] = 5890;
            row6["producePerHourWoodCutter"] = 70;
            woodCutterTable.Rows.Add(row6);

            DataRow row7 = woodCutterTable.NewRow();
            row7["level"] = 7;
            row7["woodWoodCutter"] = 870;
            row7["clayWoodCutter"] = 2170;
            row7["ironWoodCutter"] = 1085;
            row7["cropWoodCutter"] = 1300;
            row7["produceTimeWoodCutter"] = 9620;
            row7["producePerHourWoodCutter"] = 98;
            woodCutterTable.Rows.Add(row7);

            DataRow row8 = woodCutterTable.NewRow();
            row8["level"] = 8;
            row8["woodWoodCutter"] = 1450;
            row8["clayWoodCutter"] = 3625;
            row8["ironWoodCutter"] = 1810;
            row8["cropWoodCutter"] = 2175;
            row8["produceTimeWoodCutter"] = 15590;
            row8["producePerHourWoodCutter"] = 140;
            woodCutterTable.Rows.Add(row8);

            DataRow row9 = woodCutterTable.NewRow();
            row9["level"] = 9;
            row9["woodWoodCutter"] = 2420;
            row9["clayWoodCutter"] = 6050;
            row9["ironWoodCutter"] = 3025;
            row9["cropWoodCutter"] = 3630;
            row9["produceTimeWoodCutter"] = 25150;
            row9["producePerHourWoodCutter"] = 203;
            woodCutterTable.Rows.Add(row9);

            DataRow row10 = woodCutterTable.NewRow();
            row10["level"] = 10;
            row10["woodWoodCutter"] = 4040;
            row10["clayWoodCutter"] = 10105;
            row10["ironWoodCutter"] = 5050;
            row10["cropWoodCutter"] = 6060;
            row10["produceTimeWoodCutter"] = 40440;
            row10["producePerHourWoodCutter"] = 280;
            woodCutterTable.Rows.Add(row10);

            DataRow row11 = woodCutterTable.NewRow();
            row11["level"] = 11;
            row11["woodWoodCutter"] = 6750;
            row11["clayWoodCutter"] = 16870;
            row11["ironWoodCutter"] = 8435;
            row11["cropWoodCutter"] = 10125;
            row11["produceTimeWoodCutter"] = 64900;
            row11["producePerHourWoodCutter"] = 392;
            woodCutterTable.Rows.Add(row11);

            DataRow row12 = woodCutterTable.NewRow();
            row12["level"] = 12;
            row12["woodWoodCutter"] = 11270;
            row12["clayWoodCutter"] = 28175;
            row12["ironWoodCutter"] = 14090;
            row12["cropWoodCutter"] = 16905;
            row12["produceTimeWoodCutter"] = 104050;
            row12["producePerHourWoodCutter"] = 525;
            woodCutterTable.Rows.Add(row12);

            DataRow row13 = woodCutterTable.NewRow();
            row13["level"] = 13;
            row13["woodWoodCutter"] = 18820;
            row13["clayWoodCutter"] = 47055;
            row13["ironWoodCutter"] = 23525;
            row13["cropWoodCutter"] = 28230;
            row13["produceTimeWoodCutter"] = 40440;
            row13["producePerHourWoodCutter"] = 166680;
            woodCutterTable.Rows.Add(row13);

            DataRow row14 = woodCutterTable.NewRow();
            row14["level"] = 14;
            row14["woodWoodCutter"] = 31430;
            row14["clayWoodCutter"] = 78580;
            row14["ironWoodCutter"] = 39290;
            row14["cropWoodCutter"] = 47150;
            row14["produceTimeWoodCutter"] = 266880;
            row14["producePerHourWoodCutter"] = 889;
            woodCutterTable.Rows.Add(row14);

            DataRow row15 = woodCutterTable.NewRow();
            row15["level"] = 15;
            row15["woodWoodCutter"] = 52490;
            row15["clayWoodCutter"] = 131230;
            row15["ironWoodCutter"] = 65615;
            row15["cropWoodCutter"] = 78740;
            row15["produceTimeWoodCutter"] = 427210;
            row15["producePerHourWoodCutter"] = 1120;
            woodCutterTable.Rows.Add(row15);

            DataRow row16 = woodCutterTable.NewRow();
            row16["level"] = 16;
            row16["woodWoodCutter"] = 87660;
            row16["clayWoodCutter"] = 219155;
            row16["ironWoodCutter"] = 109575;
            row16["cropWoodCutter"] = 131490;
            row16["produceTimeWoodCutter"] = 683730;
            row16["producePerHourWoodCutter"] = 1400;
            woodCutterTable.Rows.Add(row16);

            DataRow row17 = woodCutterTable.NewRow();
            row17["level"] = 17;
            row17["woodWoodCutter"] = 146395;
            row17["clayWoodCutter"] = 365985;
            row17["ironWoodCutter"] = 182995;
            row17["cropWoodCutter"] = 219590;
            row17["produceTimeWoodCutter"] = 1094170;
            row17["producePerHourWoodCutter"] = 1820;
            woodCutterTable.Rows.Add(row17);

            DataRow row18 = woodCutterTable.NewRow();
            row18["level"] = 18;
            row18["woodWoodCutter"] = 244480;
            row18["clayWoodCutter"] = 611195;
            row18["ironWoodCutter"] = 305600;
            row18["cropWoodCutter"] = 366715;
            row18["produceTimeWoodCutter"] = 1750880;
            row18["producePerHourWoodCutter"] = 2240;
            woodCutterTable.Rows.Add(row18);

            DataRow row19 = woodCutterTable.NewRow();
            row19["level"] = 19;
            row19["woodWoodCutter"] = 408280;
            row19["clayWoodCutter"] = 1020695;
            row19["ironWoodCutter"] = 510350;
            row19["cropWoodCutter"] = 612420;
            row19["produceTimeWoodCutter"] = 2801600;
            row19["producePerHourWoodCutter"] = 2800;
            woodCutterTable.Rows.Add(row19);

            DataRow row20 = woodCutterTable.NewRow();
            row20["level"] = 20;
            row20["woodWoodCutter"] = 681825;
            row20["clayWoodCutter"] = 1704565;
            row20["ironWoodCutter"] = 852280;
            row20["cropWoodCutter"] = 1022740;
            row20["produceTimeWoodCutter"] = 4482770;
            row20["producePerHourWoodCutter"] = 3430;
            woodCutterTable.Rows.Add(row20);

        }

        public void addDataClayPit()
        {
            DataTable clayPitTable = Data.clayPit;

            DataRow row1 = clayPitTable.NewRow();
            row1["level"] = 1;
            row1["woodClayPit"] = 80;
            row1["clayClayPit"] = 40;
            row1["ironClayPit"] = 80;
            row1["cropClayPit"] = 50;
            row1["produceTimeClayPit"] = 220;
            row1["producePerHourClayPit"] = 7;
            clayPitTable.Rows.Add(row1);

            DataRow row2 = clayPitTable.NewRow();
            row2["level"] = 2;
            row2["woodClayPit"] = 135;
            row2["clayClayPit"] = 65;
            row2["ironClayPit"] = 135;
            row2["cropClayPit"] = 85;
            row2["produceTimeClayPit"] = 550;
            row2["producePerHourClayPit"] = 13;
            clayPitTable.Rows.Add(row2);

            DataRow row3 = clayPitTable.NewRow();
            row3["level"] = 3;
            row3["woodClayPit"] = 225;
            row3["clayClayPit"] = 110;
            row3["ironClayPit"] = 225;
            row3["cropClayPit"] = 140;
            row3["produceTimeClayPit"] = 1080;
            row3["producePerHourClayPit"] = 21;
            clayPitTable.Rows.Add(row3);

            DataRow row4 = clayPitTable.NewRow();
            row4["level"] = 4;
            row4["woodClayPit"] = 375;
            row4["clayClayPit"] = 185;
            row4["ironClayPit"] = 375;
            row4["cropClayPit"] = 235;
            row4["produceTimeClayPit"] = 1930;
            row4["producePerHourClayPit"] = 31;
            clayPitTable.Rows.Add(row4);

            DataRow row5 = clayPitTable.NewRow();
            row5["level"] = 5;
            row5["woodClayPit"] = 620;
            row5["clayClayPit"] = 310;
            row5["ironClayPit"] = 620;
            row5["cropClayPit"] = 390;
            row5["produceTimeClayPit"] = 3290;
            row5["producePerHourClayPit"] = 46;
            clayPitTable.Rows.Add(row5);

            DataRow row6 = clayPitTable.NewRow();
            row6["level"] = 6;
            row6["woodClayPit"] = 1040;
            row6["clayClayPit"] = 520;
            row6["ironClayPit"] = 1040;
            row6["cropClayPit"] = 650;
            row6["produceTimeClayPit"] = 5470;
            row6["producePerHourClayPit"] = 70;
            clayPitTable.Rows.Add(row6);

            DataRow row7 = clayPitTable.NewRow();
            row7["level"] = 7;
            row7["woodClayPit"] = 1735;
            row7["clayClayPit"] = 870;
            row7["ironClayPit"] = 1735;
            row7["cropClayPit"] = 1085;
            row7["produceTimeClayPit"] = 8950;
            row7["producePerHourClayPit"] = 98;
            clayPitTable.Rows.Add(row7);

            DataRow row8 = clayPitTable.NewRow();
            row8["level"] = 8;
            row8["woodClayPit"] = 2900;
            row8["clayClayPit"] = 1450;
            row8["ironClayPit"] = 2900;
            row8["cropClayPit"] = 1810;
            row8["produceTimeClayPit"] = 14520;
            row8["producePerHourClayPit"] = 140;
            clayPitTable.Rows.Add(row8);

            DataRow row9 = clayPitTable.NewRow();
            row9["level"] = 9;
            row9["woodClayPit"] = 4840;
            row9["clayClayPit"] = 2420;
            row9["ironClayPit"] = 4840;
            row9["cropClayPit"] = 3025;
            row9["produceTimeClayPit"] = 23430;
            row9["producePerHourClayPit"] = 203;
            clayPitTable.Rows.Add(row9);

            DataRow row10 = clayPitTable.NewRow();
            row10["level"] = 10;
            row10["woodClayPit"] = 8080;
            row10["clayClayPit"] = 4040;
            row10["ironClayPit"] = 8080;
            row10["cropClayPit"] = 5050;
            row10["produceTimeClayPit"] = 37690;
            row10["producePerHourClayPit"] = 280;
            clayPitTable.Rows.Add(row10);

            DataRow row11 = clayPitTable.NewRow();
            row11["level"] = 11;
            row11["woodClayPit"] = 13500;
            row11["clayClayPit"] = 6750;
            row11["ironClayPit"] = 13500;
            row11["cropClayPit"] = 8435;
            row11["produceTimeClayPit"] = 60510;
            row11["producePerHourClayPit"] = 392;
            clayPitTable.Rows.Add(row11);

            DataRow row12 = clayPitTable.NewRow();
            row12["level"] = 12;
            row12["woodClayPit"] = 22540;
            row12["clayClayPit"] = 11270;
            row12["ironClayPit"] = 22540;
            row12["cropClayPit"] = 14090;
            row12["produceTimeClayPit"] = 97010;
            row12["producePerHourClayPit"] = 525;
            clayPitTable.Rows.Add(row12);

            DataRow row13 = clayPitTable.NewRow();
            row13["level"] = 13;
            row13["woodClayPit"] = 37645;
            row13["clayClayPit"] = 18820;
            row13["ironClayPit"] = 37645;
            row13["cropClayPit"] = 23525;
            row13["produceTimeClayPit"] = 155420;
            row13["producePerHourClayPit"] = 693;
            clayPitTable.Rows.Add(row13);

            DataRow row14 = clayPitTable.NewRow();
            row14["level"] = 14;
            row14["woodClayPit"] = 62865;
            row14["clayClayPit"] = 31430;
            row14["ironClayPit"] = 62865;
            row14["cropClayPit"] = 39290;
            row14["produceTimeClayPit"] = 248870;
            row14["producePerHourClayPit"] = 889;
            clayPitTable.Rows.Add(row14);

            DataRow row15 = clayPitTable.NewRow();
            row15["level"] = 15;
            row15["woodClayPit"] = 104985;
            row15["clayClayPit"] = 52490;
            row15["ironClayPit"] = 104985;
            row15["cropClayPit"] = 65615;
            row15["produceTimeClayPit"] = 398390;
            row15["producePerHourClayPit"] = 1120;
            clayPitTable.Rows.Add(row15);

            DataRow row16 = clayPitTable.NewRow();
            row16["level"] = 16;
            row16["woodClayPit"] = 175320;
            row16["clayClayPit"] = 87660;
            row16["ironClayPit"] = 175320;
            row16["cropClayPit"] = 109575;
            row16["produceTimeClayPit"] = 637620;
            row16["producePerHourClayPit"] = 1400;
            clayPitTable.Rows.Add(row16);

            DataRow row17 = clayPitTable.NewRow();
            row17["level"] = 17;
            row17["woodClayPit"] = 292790;
            row17["clayClayPit"] = 146395;
            row17["ironClayPit"] = 292790;
            row17["cropClayPit"] = 182995;
            row17["produceTimeClayPit"] = 1020390;
            row17["producePerHourClayPit"] = 1820;
            clayPitTable.Rows.Add(row17);

            DataRow row18 = clayPitTable.NewRow();
            row18["level"] = 18;
            row18["woodClayPit"] = 488955;
            row18["clayClayPit"] = 244480;
            row18["ironClayPit"] = 488955;
            row18["cropClayPit"] = 305600;
            row18["produceTimeClayPit"] = 1632820;
            row18["producePerHourClayPit"] = 2240;
            clayPitTable.Rows.Add(row18);

            DataRow row19 = clayPitTable.NewRow();
            row19["level"] = 19;
            row19["woodClayPit"] = 816555;
            row19["clayClayPit"] = 408280;
            row19["ironClayPit"] = 816555;
            row19["cropClayPit"] = 510350;
            row19["produceTimeClayPit"] = 2612710;
            row19["producePerHourClayPit"] = 2800;
            clayPitTable.Rows.Add(row19);

            DataRow row20 = clayPitTable.NewRow();
            row20["level"] = 20;
            row20["woodClayPit"] = 1363650;
            row20["clayClayPit"] = 681825;
            row20["ironClayPit"] = 1363650;
            row20["cropClayPit"] = 852280;
            row20["produceTimeClayPit"] = 4180540;
            row20["producePerHourClayPit"] = 3430;
            clayPitTable.Rows.Add(row20);

        }

        public void addDataIronMine()
        {
            DataTable ironMineTable = Data.ironMine;

            DataRow row1 = ironMineTable.NewRow();
            row1["level"] = 1;
            row1["woodIronMine"] = 100;
            row1["clayIronMine"] = 80;
            row1["ironIronMine"] = 30;
            row1["cropIronMine"] = 60;
            row1["produceTimeIronMine"] = 220;
            row1["producePerHourIronMine"] = 7;
            ironMineTable.Rows.Add(row1);

            DataRow row2 = ironMineTable.NewRow();
            row2["level"] = 2;
            row2["woodIronMine"] = 165;
            row2["clayIronMine"] = 135;
            row2["ironIronMine"] = 50;
            row2["cropIronMine"] = 100;
            row2["produceTimeIronMine"] = 920;
            row2["producePerHourIronMine"] = 13;
            ironMineTable.Rows.Add(row2);

            DataRow row3 = ironMineTable.NewRow();
            row3["level"] = 3;
            row3["woodIronMine"] = 280;
            row3["clayIronMine"] = 225;
            row3["ironWoodCutter"] = 85;
            row3["cropIronMine"] = 165;
            row3["produceTimeIronMine"] = 1670;
            row3["producePerHourIronMine"] = 21;
            ironMineTable.Rows.Add(row3);

            DataRow row4 = ironMineTable.NewRow();
            row4["level"] = 4;
            row4["woodIronMine"] = 465;
            row4["clayIronMine"] = 375;
            row4["ironIronMine"] = 140;
            row4["cropIronMine"] = 280;
            row4["produceTimeIronMine"] = 2880;
            row4["producePerHourIronMine"] = 31;
            ironMineTable.Rows.Add(row4);

            DataRow row5 = ironMineTable.NewRow();
            row5["level"] = 5;
            row5["woodIronMine"] = 780;
            row5["clayIronMine"] = 620;
            row5["ironIronMine"] = 235;
            row5["cropIronMine"] = 465;
            row5["produceTimeIronMine"] = 4800;
            row5["producePerHourIronMine"] = 46;
            ironMineTable.Rows.Add(row5);

            DataRow row6 = ironMineTable.NewRow();
            row6["level"] = 6;
            row6["woodIronMine"] = 1300;
            row6["clayIronMine"] = 1040;
            row6["ironIronMine"] = 390;
            row6["cropIronMine"] = 780;
            row6["produceTimeIronMine"] = 7880;
            row6["producePerHourIronMine"] = 70;
            ironMineTable.Rows.Add(row6);

            DataRow row7 = ironMineTable.NewRow();
            row7["level"] = 7;
            row7["woodIronMine"] = 2170;
            row7["clayIronMine"] = 1735;
            row7["ironWoodCutter"] = 650;
            row7["cropIronMine"] = 1300;
            row7["produceTimeIronMine"] = 12810;
            row7["producePerHourIronMine"] = 98;
            ironMineTable.Rows.Add(row7);

            DataRow row8 = ironMineTable.NewRow();
            row8["level"] = 8;
            row8["woodIronMine"] = 3625;
            row8["clayIronMine"] = 2900;
            row8["ironIronMine"] = 1085;
            row8["cropIronMine"] = 2175;
            row8["produceTimeIronMine"] = 20690;
            row8["producePerHourIronMine"] = 140;
            ironMineTable.Rows.Add(row8);

            DataRow row9 = ironMineTable.NewRow();
            row9["level"] = 9;
            row9["woodIronMine"] = 6050;
            row9["clayIronMine"] = 4840;
            row9["ironWoodCutter"] = 1815;
            row9["cropIronMine"] = 3630;
            row9["produceTimeIronMine"] = 33310;
            row9["producePerHourIronMine"] = 203;
            ironMineTable.Rows.Add(row9);

            DataRow row10 = ironMineTable.NewRow();
            row10["level"] = 10;
            row10["woodIronMine"] = 10105;
            row10["clayIronMine"] = 8080;
            row10["ironIronMine"] = 3030;
            row10["cropIronMine"] = 6060;
            row10["produceTimeIronMine"] = 53500;
            row10["producePerHourIronMine"] = 280;
            ironMineTable.Rows.Add(row10);

            DataRow row11 = ironMineTable.NewRow();
            row11["level"] = 11;
            row11["woodIronMine"] = 16870;
            row11["clayIronMine"] = 13500;
            row11["ironIronMine"] = 5060;
            row11["cropIronMine"] = 10125;
            row11["produceTimeIronMine"] = 85800;
            row11["producePerHourIronMine"] = 392;
            ironMineTable.Rows.Add(row11);

            DataRow row12 = ironMineTable.NewRow();
            row12["level"] = 12;
            row12["woodIronMine"] = 28175;
            row12["clayIronMine"] = 22540;
            row12["ironIronMine"] = 8455;
            row12["cropIronMine"] = 16905;
            row12["produceTimeIronMine"] = 137470;
            row12["producePerHourIronMine"] = 525;
            ironMineTable.Rows.Add(row12);

            DataRow row13 = ironMineTable.NewRow();
            row13["level"] = 13;
            row13["woodIronMine"] = 47055;
            row13["clayIronMine"] = 37645;
            row13["ironIronMine"] = 14115;
            row13["cropIronMine"] = 28230;
            row13["produceTimeIronMine"] = 220160;
            row13["producePerHourIronMine"] = 693;
            ironMineTable.Rows.Add(row13);

            DataRow row14 = ironMineTable.NewRow();
            row14["level"] = 14;
            row14["woodIronMine"] = 78580;
            row14["clayIronMine"] = 62865;
            row14["ironIronMine"] = 23575;
            row14["cropIronMine"] = 47150;
            row14["produceTimeIronMine"] = 352450;
            row14["producePerHourIronMine"] = 889;
            ironMineTable.Rows.Add(row14);

            DataRow row15 = ironMineTable.NewRow();
            row15["level"] = 15;
            row15["woodIronMine"] = 131230;
            row15["clayIronMine"] = 104985;
            row15["ironIronMine"] = 39370;
            row15["cropIronMine"] = 78740;
            row15["produceTimeIronMine"] = 564120;
            row15["producePerHourIronMine"] = 1120;
            ironMineTable.Rows.Add(row15);

            DataRow row16 = ironMineTable.NewRow();
            row16["level"] = 16;
            row16["woodIronMine"] = 219155;
            row16["clayIronMine"] = 175320;
            row16["ironIronMine"] = 65745;
            row16["cropIronMine"] = 131490;
            row16["produceTimeIronMine"] = 902790;
            row16["producePerHourIronMine"] = 1400;
            ironMineTable.Rows.Add(row16);

            DataRow row17 = ironMineTable.NewRow();
            row17["level"] = 17;
            row17["woodIronMine"] = 365985;
            row17["clayIronMine"] = 292790;
            row17["ironIronMine"] = 109795;
            row17["cropIronMine"] = 219590;
            row17["produceTimeIronMine"] = 1444660;
            row17["producePerHourIronMine"] = 1820;
            ironMineTable.Rows.Add(row17);

            DataRow row18 = ironMineTable.NewRow();
            row18["level"] = 18;
            row18["woodIronMine"] = 611195;
            row18["clayIronMine"] = 488955;
            row18["ironIronMine"] = 183360;
            row18["cropIronMine"] = 366715;
            row18["produceTimeIronMine"] = 2311660;
            row18["producePerHourIronMine"] = 2240;
            ironMineTable.Rows.Add(row18);

            DataRow row19 = ironMineTable.NewRow();
            row19["level"] = 19;
            row19["woodIronMine"] = 1020695;
            row19["clayIronMine"] = 816555;
            row19["ironIronMine"] = 306210;
            row19["cropIronMine"] = 612420;
            row19["produceTimeIronMine"] = 3698850;
            row19["producePerHourIronMine"] = 2800;
            ironMineTable.Rows.Add(row19);

            DataRow row20 = ironMineTable.NewRow();
            row20["level"] = 20;
            row20["woodIronMine"] = 1704565;
            row20["clayIronMine"] = 1363650;
            row20["ironIronMine"] = 511370;
            row20["cropIronMine"] = 1022740;
            row20["produceTimeIronMine"] = 5918370;
            row20["producePerHourIronMine"] = 3430;
            ironMineTable.Rows.Add(row20);

        }
        public void addDataCropLand()
        {
            DataTable cropLandTable = Data.cropLand;

            DataRow row1 = cropLandTable.NewRow();
            row1["level"] = 1;
            row1["woodCropLand"] = 70;
            row1["clayCropLand"] = 90;
            row1["ironCropLand"] = 70;
            row1["cropCropLand"] = 20;
            row1["produceTimeCropLand"] = 150;
            row1["producePerHourCropLand"] = 7;
            cropLandTable.Rows.Add(row1);

            DataRow row2 = cropLandTable.NewRow();
            row2["level"] = 2;
            row2["woodCropLand"] = 115;
            row2["clayCropLand"] = 150;
            row2["ironCropLand"] = 115;
            row2["cropCropLand"] = 35;
            row2["produceTimeCropLand"] = 440;
            row2["producePerHourCropLand"] = 13;
            cropLandTable.Rows.Add(row2);

            DataRow row3 = cropLandTable.NewRow();
            row3["level"] = 3;
            row3["woodCropLand"] = 195;
            row3["clayCropLand"] = 250;
            row3["ironCropLand"] = 195;
            row3["cropCropLand"] = 55;
            row3["produceTimeCropLand"] = 900;
            row3["producePerHourCropLand"] = 21;
            cropLandTable.Rows.Add(row3);

            DataRow row4 = cropLandTable.NewRow();
            row4["level"] = 4;
            row4["woodCropLand"] = 325;
            row4["clayCropLand"] = 420;
            row4["ironCropLand"] = 325;
            row4["cropCropLand"] = 95;
            row4["produceTimeCropLand"] = 1650;
            row4["producePerHourCropLand"] = 31;
            cropLandTable.Rows.Add(row4);

            DataRow row5 = cropLandTable.NewRow();
            row5["level"] = 5;
            row5["woodCropLand"] = 545;
            row5["clayCropLand"] = 700;
            row5["ironCropLand"] = 545;
            row5["cropCropLand"] = 155;
            row5["produceTimeCropLand"] = 2830;
            row5["producePerHourCropLand"] = 46;
            cropLandTable.Rows.Add(row5);

            DataRow row6 = cropLandTable.NewRow();
            row6["level"] = 6;
            row6["woodCropLand"] = 910;
            row6["clayCropLand"] = 1170;
            row6["ironCropLand"] = 910;
            row6["cropCropLand"] = 260;
            row6["produceTimeCropLand"] = 4730;
            row6["producePerHourCropLand"] = 70;
            cropLandTable.Rows.Add(row6);

            DataRow row7 = cropLandTable.NewRow();
            row7["level"] = 7;
            row7["woodCropLand"] = 1520;
            row7["clayCropLand"] = 1950;
            row7["ironCropLand"] = 1520;
            row7["cropCropLand"] = 435;
            row7["produceTimeCropLand"] = 7780;
            row7["producePerHourCropLand"] = 98;
            cropLandTable.Rows.Add(row7);

            DataRow row8 = cropLandTable.NewRow();
            row8["level"] = 8;
            row8["woodCropLand"] = 2535;
            row8["clayCropLand"] = 3260;
            row8["ironCropLand"] = 2535;
            row8["cropCropLand"] = 725;
            row8["produceTimeCropLand"] = 12640;
            row8["producePerHourCropLand"] = 140;
            cropLandTable.Rows.Add(row8);

            DataRow row9 = cropLandTable.NewRow();
            row9["level"] = 9;
            row9["woodCropLand"] = 4235;
            row9["clayCropLand"] = 5445;
            row9["ironCropLand"] = 4235;
            row9["cropCropLand"] = 1210;
            row9["produceTimeCropLand"] = 20430;
            row9["producePerHourCropLand"] = 203;
            cropLandTable.Rows.Add(row9);

            DataRow row10 = cropLandTable.NewRow();
            row10["level"] = 10;
            row10["woodCropLand"] = 7070;
            row10["clayCropLand"] = 9095;
            row10["ironCropLand"] = 7070;
            row10["cropCropLand"] = 2020;
            row10["produceTimeCropLand"] = 32880;
            row10["producePerHourCropLand"] = 280;
            cropLandTable.Rows.Add(row10);

            DataRow row11 = cropLandTable.NewRow();
            row11["level"] = 11;
            row11["woodCropLand"] = 11810;
            row11["clayCropLand"] = 15185;
            row11["ironCropLand"] = 11810;
            row11["cropCropLand"] = 3375;
            row11["produceTimeCropLand"] = 52810;
            row11["producePerHourCropLand"] = 392;
            cropLandTable.Rows.Add(row11);

            DataRow row12 = cropLandTable.NewRow();
            row12["level"] = 12;
            row12["woodCropLand"] = 19725;
            row12["clayCropLand"] = 25360;
            row12["ironCropLand"] = 19725;
            row12["cropCropLand"] = 5635;
            row12["produceTimeCropLand"] = 84700;
            row12["producePerHourCropLand"] = 525;
            cropLandTable.Rows.Add(row12);

            DataRow row13 = cropLandTable.NewRow();
            row13["level"] = 13;
            row13["woodCropLand"] = 32940;
            row13["clayCropLand"] = 42350;
            row13["ironCropLand"] = 32940;
            row13["cropCropLand"] = 9410;
            row13["produceTimeCropLand"] = 135710;
            row13["producePerHourCropLand"] = 693;
            cropLandTable.Rows.Add(row13);

            DataRow row14 = cropLandTable.NewRow();
            row14["level"] = 14;
            row14["woodCropLand"] = 55005;
            row14["clayCropLand"] = 70720;
            row14["ironCropLand"] = 55005;
            row14["cropCropLand"] = 15715;
            row14["produceTimeCropLand"] = 217340;
            row14["producePerHourCropLand"] = 889;
            cropLandTable.Rows.Add(row14);

            DataRow row15 = cropLandTable.NewRow();
            row15["level"] = 15;
            row15["woodCropLand"] = 91860;
            row15["clayCropLand"] = 118105;
            row15["ironCropLand"] = 91860;
            row15["cropCropLand"] = 26245;
            row15["produceTimeCropLand"] = 347950;
            row15["producePerHourCropLand"] = 1120;
            cropLandTable.Rows.Add(row15);

            DataRow row16 = cropLandTable.NewRow();
            row16["level"] = 16;
            row16["woodCropLand"] = 153405;
            row16["clayCropLand"] = 197240;
            row16["ironCropLand"] = 153405;
            row16["cropCropLand"] = 43830;
            row16["produceTimeCropLand"] = 556910;
            row16["producePerHourCropLand"] = 1400;
            cropLandTable.Rows.Add(row16);

            DataRow row17 = cropLandTable.NewRow();
            row17["level"] = 17;
            row17["woodCropLand"] = 256190;
            row17["clayCropLand"] = 329385;
            row17["ironCropLand"] = 256190;
            row17["cropCropLand"] = 73195;
            row17["produceTimeCropLand"] = 891260;
            row17["producePerHourCropLand"] = 1820;
            cropLandTable.Rows.Add(row17);

            DataRow row18 = cropLandTable.NewRow();
            row18["level"] = 18;
            row18["woodCropLand"] = 427835;
            row18["clayCropLand"] = 550075;
            row18["ironCropLand"] = 427835;
            row18["cropCropLand"] = 122240;
            row18["produceTimeCropLand"] = 1426210;
            row18["producePerHourCropLand"] = 2240;
            cropLandTable.Rows.Add(row18);

            DataRow row19 = cropLandTable.NewRow();
            row19["level"] = 19;
            row19["woodCropLand"] = 714485;
            row19["clayCropLand"] = 918625;
            row19["ironCropLand"] = 714485;
            row19["cropCropLand"] = 204140;
            row19["produceTimeCropLand"] = 2282140;
            row19["producePerHourCropLand"] = 2800;
            cropLandTable.Rows.Add(row19);

            DataRow row20 = cropLandTable.NewRow();
            row20["level"] = 20;
            row20["woodCropLand"] = 1193195;
            row20["clayCropLand"] = 1534105;
            row20["ironCropLand"] = 1193195;
            row20["cropCropLand"] = 340915;
            row20["produceTimeCropLand"] = 3651630;
            row20["producePerHourCropLand"] = 3430;
            cropLandTable.Rows.Add(row20);

        }

    }
}
