using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectUTS
{
    public static class Data
    {
        public static Progress dataSet;
        public static DataTable map;
        public static DataTable progress;
        public static DataTable player;
        public static int totalMap = 18;
        public static bool isThereSavedProgress = false;

        public static List<Map> mapList = new List<Map>();

        //source e
        public static sources dataSetSources;
        public static DataTable woodCutter;
        public static DataTable clayPit;
        public static DataTable ironMine;
        public static DataTable cropLand;

        //============================INVENTORY=============================================

        //buat liat / mau pake current Inventory
        public static int getClay()
        {
            return Convert.ToInt32(player.Rows[0]["clay"]);
        }
        public static int getIron()
        {
            return Convert.ToInt32(player.Rows[0]["iron"]);
        }
        public static int getWood()
        {
            return Convert.ToInt32(player.Rows[0]["wood"]);
        }
        public static int getCrop()
        {
            return Convert.ToInt32(player.Rows[0]["crop"]);
        }

        //kalo mau otak atik inventory -> di add sih kalo maw lgsng modif bikin lagi aja
        public static void addClay(double amount)
        {
            player.Rows[0]["clay"] = Convert.ToDouble(player.Rows[0]["clay"]) + amount;
        }
        public static void addIron(double amount)
        {
            player.Rows[0]["iron"] = Convert.ToDouble(player.Rows[0]["iron"]) + amount;
        }
        public static void addWood(double amount)
        {
            player.Rows[0]["wood"] = Convert.ToDouble(player.Rows[0]["wood"]) + amount;
        }
        public static void addCrop(double amount)
        {
            player.Rows[0]["crop"] = Convert.ToDouble(player.Rows[0]["crop"]) + amount;
        }

        public static void deleteClay(double amount)
        {
            player.Rows[0]["clay"] = Convert.ToDouble(player.Rows[0]["clay"]) - amount;
        }
        public static void deleteIron(double amount)
        {
            player.Rows[0]["iron"] = Convert.ToDouble(player.Rows[0]["iron"]) - amount;
        }
        public static void deleteWood(double amount)
        {
            player.Rows[0]["wood"] = Convert.ToDouble(player.Rows[0]["wood"]) - amount;
        }
        public static void deleteCrop(double amount)
        {
            player.Rows[0]["crop"] = Convert.ToDouble(player.Rows[0]["crop"]) - amount;
        }


        //============================FUNCTION INITIALIZE=============================================


        //ini buat ngisi mapList pas awal jalan
        public static void loadMap()
        {
            mapList.Clear();
            for (int i = 0; i < totalMap; i++)
            {
                mapList.Add(new Map(i));
            }
            MessageBox.Show("map berhasil load");
        }


        //============================SAVE AND LOAD YEAH=============================================

        public static bool load()
        {
            try
            {

                map.ReadXml("saveMap.xml");
                progress.ReadXml("saveProgress.xml");
                player.ReadXml("savePlayer.xml");
                return true;

            }
            catch (IOException e)
            {
                return false;
            }
        }

        public static void save()
        {
            //save current time as last online
            player.Rows[0]["lastOnline"] = DateTime.Now;

            map.WriteXml("saveMap.xml");
            progress.WriteXml("saveProgress.xml");
            player.WriteXml("savePlayer.xml");
        }

        //============================GET TOTAL PRODUCTION PER HOUR=============================================
        public static int getAllClayProduction()
        {
            int acc = 0;

            foreach (Map map in mapList)
            {
                if (map.getJenis() == 0)
                {
                    acc += map.getProductionPerHour();
                }
            }

            return acc;
        }

        public static int getAllIronProduction()
        {
            int acc = 0;

            foreach (Map map in mapList)
            {
                if (map.getJenis() == 1)
                {
                    acc += map.getProductionPerHour();
                }
            }

            return acc;
        }

        public static int getAllWoodProduction()
        {
            int acc = 0;
            int woodCount = 0; // Tambahkan penghitung untuk Kayu

            // Tampilkan jumlah Map List. HARUS 18.
            //MessageBox.Show($"MapList Count: {mapList.Count}", "DEBUG JUMLAH MAP");

            foreach (Map map in mapList)
            {
                int mapJenis = map.getJenis();

                // 🚨 Tampilkan Jenis Map yang Diharapkan (untuk ID 8, 9, 10, 11)
                if (map.id >= 8 && map.id <= 11)
                {
                    //MessageBox.Show($"ID: {map.id}, Jenis yang Dibaca: {mapJenis}", "DEBUG JENIS WOOD");
                }
                // -------------------------------------------------------------

                if (mapJenis == 2) // Perbandingan ini gagal
                {
                    int mapProd = map.getProductionPerHour();
                    acc += mapProd;
                    woodCount++;
                }
            }

            // Tampilkan hasil akhir
            //MessageBox.Show($"Total Map Kayu yang Ditemukan: {woodCount}. Total Produksi: {acc}", "DEBUG HASIL AKHIR");

            return acc;
        }

        public static int getAllCropProduction()
        {
            int acc = 0;

            foreach (Map map in mapList)
            {
                if (map.getJenis() == 3)
                {
                    acc += map.getProductionPerHour();
                }
            }

            return acc;
        }


        //============================= BUAT SAVE DATA UPGRADE PAS KLUAR=============================
        public static void upgrade(int id, int waktu)
        {
            player.Rows[0]["upgradeInProgress"] = true;
            player.Rows[0]["idMapUpgrade"] = id;
            player.Rows[0]["EstimateTimeFinishUpgrade"] = getEstimateTime(waktu);
        }

        public static DateTime getEstimateTime(int waktu)
        {
            DateTime now = DateTime.Now;
            return now.AddSeconds(waktu);
        }

        public static void setEstimateTime(int waktu)
        {
            DateTime now = DateTime.Now;
            player.Rows[0]["EstimateTimeFinishUpgrade"] = now.AddSeconds(waktu);
        }


        public static void upgradeFinish()
        {
            player.Rows[0]["upgradeInProgress"] = false;
            player.Rows[0]["idMapUpgrade"] = -1;
            player.Rows[0]["EstimateTimeFinishUpgrade"] = DateTime.Now;
        }

        //public static bool anyUpgrade()
        //{
        //    return Convert.ToBoolean(player.Rows[0]["upgradeInProgress"]);
        //}

        //get oll dr table woodCutter
        public static int getWood_woodCutter(int index)
        {
            if (index >= 0 && index < woodCutter.Rows.Count)
            {
                DataRow row = woodCutter.Rows[index];
                return Convert.ToInt32(row["wood"]);
            }
            return 0;
        }
        public static int getIron_woodCutter(int index)
        {
            if (index >= 0 && index < woodCutter.Rows.Count)
            {
                DataRow row = woodCutter.Rows[index];
                return Convert.ToInt32(row["iron"]);
            }
            return 0;
        }
        public static int getClay_woodCutter(int index)
        {
            if (index >= 0 && index < woodCutter.Rows.Count)
            {
                DataRow row = woodCutter.Rows[index];
                return Convert.ToInt32(row["clay"]);
            }
            return 0;
        }
        public static int getCrop_woodCutter(int index)
        {
            if (index >= 0 && index < woodCutter.Rows.Count)
            {
                DataRow row = woodCutter.Rows[index];
                return Convert.ToInt32(row["crop"]);
            }
            return 0;
        }
        public static int getProduceTime_woodCutter(int index)
        {
            if (index >= 0 && index < woodCutter.Rows.Count)
            {
                DataRow row = woodCutter.Rows[index];
                return Convert.ToInt32(row["produceTime"]);
            }
            return 0;
        }
        public static int getProducePerHour_woodCutter(int index)
        {
            if (index >= 0 && index < woodCutter.Rows.Count)
            {
                DataRow row = woodCutter.Rows[index];
                return Convert.ToInt32(row["producePerHour"]);
            }
            return 0;
        }


        //get get an dr clayPit
        public static int getWood_clayPit(int index)
        {
            if (index >= 0 && index < clayPit.Rows.Count)
            {
                DataRow row = clayPit.Rows[index];
                return Convert.ToInt32(row["wood"]);
            }
            return 0;
        }
        public static int getIron_clayPit(int index)
        {
            if (index >= 0 && index < clayPit.Rows.Count)
            {
                DataRow row = clayPit.Rows[index];
                return Convert.ToInt32(row["iron"]);
            }
            return 0;
        }
        public static int getClay_clayPit(int index)
        {
            if (index >= 0 && index < clayPit.Rows.Count)
            {
                DataRow row = clayPit.Rows[index];
                return Convert.ToInt32(row["clay"]);
            }
            return 0;
        }
        public static int getCrop_clayPit(int index)
        {
            if (index >= 0 && index < clayPit.Rows.Count)
            {
                DataRow row = clayPit.Rows[index];
                return Convert.ToInt32(row["crop"]);
            }
            return 0;
        }
        public static int getProduceTime_clayPit(int index)
        {
            if (index >= 0 && index < clayPit.Rows.Count)
            {
                DataRow row = clayPit.Rows[index];
                return Convert.ToInt32(row["produceTime"]);
            }
            return 0;
        }
        public static int getProducePerHour_clayPit(int index)
        {
            if (index >= 0 && index < clayPit.Rows.Count)
            {
                DataRow row = clayPit.Rows[index];
                return Convert.ToInt32(row["producePerHour"]);
            }
            return 0;
        }

        //get getan dr ironMine
        public static int getWood_ironMine(int index)
        {
            if (index >= 0 && index < ironMine.Rows.Count)
            {
                DataRow row = ironMine.Rows[index];
                return Convert.ToInt32(row["wood"]);
            }
            return 0;
        }
        public static int getIron_ironMine(int index)
        {
            if (index >= 0 && index < ironMine.Rows.Count)
            {
                DataRow row = ironMine.Rows[index];
                return Convert.ToInt32(row["iron"]);
            }
            return 0;
        }
        public static int getClay_ironMine(int index)
        {
            if (index >= 0 && index < ironMine.Rows.Count)
            {
                DataRow row = ironMine.Rows[index];
                return Convert.ToInt32(row["clay"]);
            }
            return 0;
        }
        public static int getCrop_ironMine(int index)
        {
            if (index >= 0 && index < ironMine.Rows.Count)
            {
                DataRow row = ironMine.Rows[index];
                return Convert.ToInt32(row["crop"]);
            }
            return 0;
        }
        public static int getProduceTime_ironMine(int index)
        {
            if (index >= 0 && index < ironMine.Rows.Count)
            {
                DataRow row = ironMine.Rows[index];
                return Convert.ToInt32(row["produceTime"]);
            }
            return 0;
        }
        public static int getProducePerHour_ironMine(int index)
        {
            if (index >= 0 && index < ironMine.Rows.Count)
            {
                DataRow row = ironMine.Rows[index];
                return Convert.ToInt32(row["producePerHour"]);
            }
            return 0;
        }

        //get getan dr cropLand
        public static int getWood_cropLand(int index)
        {
            if (index >= 0 && index < cropLand.Rows.Count)
            {
                DataRow row = cropLand.Rows[index];
                return Convert.ToInt32(row["wood"]);
            }
            return 0;
        }
        public static int getIron_cropLand(int index)
        {
            if (index >= 0 && index < cropLand.Rows.Count)
            {
                DataRow row = cropLand.Rows[index];
                return Convert.ToInt32(row["iron"]);
            }
            return 0;
        }
        public static int getClay_cropLand(int index)
        {
            if (index >= 0 && index < cropLand.Rows.Count)
            {
                DataRow row = cropLand.Rows[index];
                return Convert.ToInt32(row["clay"]);
            }
            return 0;
        }
        public static int getCrop_cropLand(int index)
        {
            if (index >= 0 && index < cropLand.Rows.Count)
            {
                DataRow row = cropLand.Rows[index];
                return Convert.ToInt32(row["crop"]);
            }
            return 0;
        }
        public static int getProduceTime_cropLand(int index)
        {
            if (index >= 0 && index < cropLand.Rows.Count)
            {
                DataRow row = cropLand.Rows[index];
                return Convert.ToInt32(row["produceTime"]);
            }
            return 0;
        }
        public static int getProducePerHour_cropLand(int index)
        {
            if (index >= 0 && index < cropLand.Rows.Count)
            {
                DataRow row = cropLand.Rows[index];
                return Convert.ToInt32(row["producePerHour"]);
            }
            return 0;
        }

        public static void CalculateOfflineProduction()
        {
            DateTime lastOnline = Convert.ToDateTime(player.Rows[0]["LastOnline"]);
            TimeSpan durationOffline = DateTime.Now - lastOnline;
            double hoursOffline = durationOffline.TotalHours;

            MessageBox.Show(
                "Last Online: " + lastOnline.ToString() +
                "\nCurrent Time: " + DateTime.Now.ToString() +
                "\nTotal Jam Offline: " + hoursOffline.ToString("F2") + " jam",
                "DEBUG WAKTU OFFLINE"
            );

            if (hoursOffline <= 0)
                return;

            int initialWood = getWood();
            int woodProductionPerHour = getAllWoodProduction();

            double totalWoodGained_Raw = woodProductionPerHour * hoursOffline;

            int totalWoodGained_Int = (int)Math.Floor(totalWoodGained_Raw);

            addWood(totalWoodGained_Int);

            MessageBox.Show(
                "Awal Wood: " + initialWood +
                "\nProd/Jam: " + woodProductionPerHour +
                "\nTotal Wood Didapat: " + totalWoodGained_Int +
                "\nWood Baru: " + getWood(),
                "DEBUG PRODUKSI OFFLINE (WOOD)"
            );

            int initialClay = getClay();
            int clayProductionPerHour = getAllClayProduction();

            double totalClayGained_Raw = clayProductionPerHour * hoursOffline;

            int totalClayGained_Int = (int)Math.Floor(totalWoodGained_Raw);

            addClay(totalClayGained_Int); 
            MessageBox.Show(
                "Awal Clay: " + initialClay +
                "\nProd/Jam: " + clayProductionPerHour +
                "\nTotal Clay Didapat: " + totalClayGained_Int +
                "\nClay Baru: " + getClay(),
                "DEBUG PRODUKSI OFFLINE (CLAY)"
            );

            int initialIron = getIron();
            int ironProductionPerHour = getAllIronProduction();
            double totalironGained_Raw = ironProductionPerHour * hoursOffline;
            int totalironGained_Int = (int)Math.Floor(totalironGained_Raw);
            addIron(totalironGained_Int);
            MessageBox.Show(
                "Awal iron: " + initialIron +
                "\nProd/Jam: " + ironProductionPerHour +
                "\nTotal iron Didapat: " + totalironGained_Int +
                "\nIron  Baru: " + getIron(),
                "DEBUG PRODUKSI OFFLINE (iron)"
            );

            int initialCrop = getCrop();
            int cropProductionPerHour = getAllIronProduction();

            double totalcropGained_Raw = cropProductionPerHour * hoursOffline;

            int totalcropGained_Int = (int)Math.Floor(totalcropGained_Raw);

            addCrop(totalcropGained_Int);
            MessageBox.Show(
                "Awal crop: " + initialCrop +
                "\nProd/Jam: " + cropProductionPerHour +
                "\nTotal crop Didapat: " + totalcropGained_Int +
                "\ncrop  Baru: " + getCrop(),
                "DEBUG PRODUKSI OFFLINE (crop)"
            );
        }
        public static bool checkOfflineUpgradeCompletion()
        {
            if (Convert.ToBoolean(player.Rows[0]["upgradeInProgress"]))
            {
                MessageBox.Show("masuk upgrade oflenn");
                DateTime finishTime = Convert.ToDateTime(player.Rows[0]["EstimateTimeFinishUpgrade"]);

                if (finishTime <= DateTime.Now)
                {
                    int idMap = Convert.ToInt32(player.Rows[0]["idMapUpgrade"]);

                    Map completedMap = Data.mapList.FirstOrDefault(m => m.id == idMap);

                    if (completedMap != null)
                    {
                        completedMap.addLevel();
                    }

                    upgradeFinish();

                    MessageBox.Show($"Upgrade Map ID {idMap} Selesai saat Anda offline!", "Upgrade Selesai");
                    return true;
                }
            }
            return false;
        }




    }
}
