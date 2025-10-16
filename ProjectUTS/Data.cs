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
        public static bool isBagian2Randomized = false;

        public static List<Map> mapList = new List<Map>();

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


//============================FUNCTION INITIALIZE=============================================


        //ini buat ngisi mapList pas awal jalan
        public static void loadMap()
            {
                for(int i = 0; i < totalMap; i++)
                {
                    mapList.Add(new Map(i));
                }
           
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

            }catch(IOException e)
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
                if(map.getJenis() == 0)
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

            foreach (Map map in mapList)
            {
                if (map.getJenis() == 2)
                {
                    acc += map.getProductionPerHour();
                }
            }

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

        public static bool anyUpgrade()
        {
            return Convert.ToBoolean(player.Rows[0]["upgradeInProgress"]);
        }

    }






}
