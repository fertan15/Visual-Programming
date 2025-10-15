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
            public static void addClay(int amount)
            {
                player.Rows[0]["clay"] = getClay() + amount;
            }
            public static void addIron(int amount)
            {
                player.Rows[0]["iron"] = getIron() + amount;
            }
            public static void addWood(int amount)
            {
                player.Rows[0]["wood"] = getWood() + amount;
            }
            public static void addCrop(int amount)
            {
                player.Rows[0]["crop"] = getCrop() + amount;
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
            map.WriteXml("saveMap.xml");
            progress.WriteXml("saveProgress.xml");
            player.WriteXml("savePlayer.xml");
        }



    }






}
