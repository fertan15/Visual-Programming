PENJELASAN YEAH

============ Ferlinda -> kriteria 1 ======================

====== Dataset
    - Table Player -> nyimpan Resource pemain
    - Table MapProgress -> nyimpan data map & level & productionPerHour
    - Table JenisMap -> nyimpan detail jenis map
    - Relation MapProgress - Jenis map
        - di mapProgress ada kodeJenismap -> detail nama jenis map ada di tabel Jenis Map



====== Class Data
nyimpan semua data dalam static biar bisa di pake di smua form and lebih bersih😂

    public static Progress dataSet; 
    public static DataTable map;
    public static DataTable progress;
    public static DataTable player;
    public static int totalMap = 18;  -> total map di game 
    public static bool isThereSavedProgress = false; -> cek ada saved progress ga

    public static List<Map> mapList = new List<Map>(); -> ini list Map buat button levell2 nya yang ada di map


    ================  cara akses resource player

    ==== buat ngambil value ada function get yang langsung ngambil data dari dataset langsung

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
            
    ==== buat set Value -> langsung update ke dataset

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

    ====================== ISI MAPLIST DENGAN MAP BERID 1-18 (TOTALMAP YANG ADA)
    public static void loadMap()
        {
            for(int i = 0; i < totalMap; i++)
            {
                mapList.Add(new Map(i));
            }
        
        }


    ======================= MAIN SAVE AND LOAD FUNCTION

    ==== cuman readXML & writeXML sih

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



====== Class Map
ini inheritan dari Label buat tampilan sekalian nyimpan id sama ada beberapa function

    public int id;

    ==== pas buat baru cuman masukin id trus posisi lgsng ambil dari dataset, trus warna, font smua udah default sama aja
    public Map(int id)
        {
            this.id = id;
            this.Location = new Point(Convert.ToInt32(Data.progress.Rows[this.id]["positionX"]), Convert.ToInt32(Data.progress.Rows[this.id]["positionY"]));

            this.ForeColor = Color.Black;
            this.Font = new Font("Times New Roman", 9, FontStyle.Bold);
            this.AutoSize = true;
            this.Text = getLevel().ToString();

        }
    ============================ FUNCTION
    ==== getFunction

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
    ==== setFunction

        //function add level lgsng ganti text label jadi level terbaru
        public void addLevel()
        {
            //nambah 1 level otomatis
            Data.progress.Rows[this.id]["level"] = getLevel() + 1;
            this.Text = getLevel().ToString();

            //save data
            Data.save();
        }

        public void setProductionPerHour(int amount)
        {
            //ini ganti langsung sesuai amount -> sesuaiin aja nanti
            Data.progress.Rows[this.id]["productionPerHour"] = amount;

            //save data
            Data.save();


        }

======= Class Initialize -> dipanggil skali pas awal mulai aja
ini class cuman buat initialize smua data di Class Data -> biar ga numpuk di main

        ============ initialize dataset, table
        Data.dataSet = new Progress();
        Data.map = Data.dataSet.Tables["JenisMap"];
        Data.progress = Data.dataSet.Tables["MapProgress"];
        Data.player = Data.dataSet.Tables["Player"];

        ============ cek ada file save2an ga kalo ada barti ada savedProgress      
        if (File.Exists("saveMap.xml") && File.Exists("saveProgress.xml") && File.Exists("savePlayer.xml"))
            {
                Data.isThereSavedProgress = true;
            }

        ============ kalo gaada savedProgress masukin data Default kalo ada load trus cek data nya valid ga
            if(!Data.isThereSavedProgress)
            {
                initDefaultData();
                MessageBox.Show("No data Found jadi mulai dari awal");
            }
            else
            {
                bool loaded = Data.load();
                if (loaded)  -
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
        =========== ngasih default data kalo gaada save2an
        public void initDefaultData()

======= MAIN FORM : FORM1

    ====== NARUH LABEL DI FORM SECARA DYNAMIC DAN NGASIH EVENTHANDLER
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
    ===== KEY HANDLER : F3 BUAT BUKA DEBUG
    private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //ini buat debug data yes
            if (e.KeyCode == Keys.F3)
            {
                CheckData b = new CheckData();
                b.ShowDialog();
            }
        }
    ====== EVENT HANDLER LABEL MAP DITEKAN : TEMPORARY 
    private void Map_Click(object sender, EventArgs e)
        {
            //ini set kalo misal map di klik gimana
            Map selected = (Map)sender;

            MessageBox.Show("Map ID: " + selected.id + "\nProduction : "  + selected.getProductionPerHour());
        }










====== CHECK DATA FORM
ini buat debug data -> tekan f3
munculin semua data di dataset

