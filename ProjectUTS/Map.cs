using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace ProjectUTS
{

    public class Map : Label
    {
        public int id;

        public Map(int id)
        {
            this.id = id;
            this.Location = new Point(Convert.ToInt32(Data.progress.Rows[this.id]["positionX"]), Convert.ToInt32(Data.progress.Rows[this.id]["positionY"]));

            this.ForeColor = Color.Black;
            this.Font = new Font("Times New Roman", 9, FontStyle.Bold);
            this.AutoSize = true;
            this.Text = getLevel().ToString();

        }

        //buat ambil level
        public int getLevel()
        {
            return Convert.ToInt32(Data.progress.Rows[this.id]["level"]);
        }
        //get jenis 0-> clay, 1-> iron, 2-> wood, 3-> crop
        public int getJenis()
        {
            return Convert.ToInt32(Data.progress.Rows[this.id]["jenisMap"]);
        }
        //get jumlah produksi per jam
        public int getProductionPerHour()
        {
            return Convert.ToInt32(Data.progress.Rows[this.id]["productionPerHour"]);
        }


        public void addLevel()
        {
            //nambah 1 level otomatis
            Data.progress.Rows[this.id]["level"] = getLevel() + 1;
            this.Text = getLevel().ToString();



        }

        public void setProductionPerHour(int amount)
        {
            //ini ganti langsung sesuai amount -> sesuaiin aja nanti
            Data.progress.Rows[this.id]["productionPerHour"] = amount;


        }




    }
}
