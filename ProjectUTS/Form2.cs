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
    public partial class Form2 : Form
    {
        Boolean randomized = false;
        Panel cell; //individual cell di grid
        List<Panel> cells = new List<Panel>(); //list cells di grid
        Timer gameTick = new Timer(); //timer buat game tick
        Timer cropTimer = new Timer(); //timer buat crop
        Point userPosition = new Point(0, 0); // posisi user di grid (0 soalnya nanti di set pas generate grid)
        Panel clickedCell = new Panel(); //panel yg di klik
        Point clickedPosition; // posisi panel yg di klik
        Boolean isMoving = false; // flag buat ngecek ada panel yg lagi gerak apa gk
        List<Panel> movingPanels = new List<Panel>(); //list panel yg lagi gerak
        int multiplier = 1;
        int totalconsumed = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            generateGrid();
            cropTimer.Interval = 1000;
            cropTimer.Tick += CropTimer_Tick;

            gameTick.Interval = 1000;
            gameTick.Tick += GameTick_Tick;
            gameTick.Start();

            
        }

        private void CropTimer_Tick(object sender, EventArgs e)
        {
            if (isMoving)
            {
                int numberOfmovingPanels = movingPanels.Count;
                int cropConsumed = numberOfmovingPanels * 500;

                if (Convert.ToInt32(Data.player.Rows[0]["crop"]) < cropConsumed)
                {
                    movingPanels.Clear();
                    isMoving = false;
                    MessageBox.Show("Not enough crop to continue moving!");
                    return;
                }

                Data.player.Rows[0]["crop"] = Convert.ToInt32(Data.player.Rows[0]["crop"]) - cropConsumed;
                totalconsumed += cropConsumed;
                cropsConsumedLabel.Text = totalconsumed.ToString();

            }
            else
            {
                cropsConsumedLabel.Text = "0";
                totalconsumed = 0;
                cropTimer.Stop();
            }
        }

        private void GameTick_Tick(object sender, EventArgs e)
        {
            int speed = 10;
            multiplierLabel.Text = multiplier.ToString() + "x";
            clayMultiplierLabel.Text = Data.clayPitMultiplier.ToString("0.00") + "x";
            ironMultiplierLabel.Text = Data.mineMultiplier.ToString("0.00") + "x";
            woodMultiplierLabel.Text = Data.forestMultiplier.ToString("0.00") + "x";
            cropMultiplierLabel.Text = Data.farmMultiplier.ToString("0.00") + "x";


            if (movingPanels.Count == 0)
            {
                isMoving = false;
                return;
            }

            List<Panel> panelsToRemove = new List<Panel>();
            bool gridStateChanged = false;

            //===================== KRITERIA 3 NO 2 (ANIMASI) =========================

            foreach (Panel movingPanel in movingPanels.ToList())
            {
                Point cellPositionRn = movingPanel.Location;

                if (cellPositionRn.X < userPosition.X * 50) //ke kiri
                {
                    cellPositionRn.X += speed;
                }
                else if (cellPositionRn.X > userPosition.X * 50)
                {
                    cellPositionRn.X -= speed; // ke kanan
                }

                if (cellPositionRn.Y < userPosition.Y * 50)
                {
                    cellPositionRn.Y += speed; // ke bawah
                }
                else if (cellPositionRn.Y > userPosition.Y * 50)
                {
                    cellPositionRn.Y -= speed; // ke atas
                }

                movingPanel.Location = cellPositionRn; //panel yg skrg gerak di update

                if (Math.Abs(movingPanel.Location.X - userPosition.X * 50) < speed && Math.Abs(movingPanel.Location.Y - userPosition.Y * 50) < speed)
                {
                    movingPanel.Location = new Point(userPosition.X * 50, userPosition.Y * 50);

                    if (movingPanel.BackColor == Color.Red || movingPanel.BackColor.ToArgb() == Color.Red.ToArgb())
                    {
                        Data.clayPitMultiplier += 0.25;
                        
                    }
                    else if (movingPanel.BackColor == Color.Gray || movingPanel.BackColor.ToArgb() == Color.Gray.ToArgb())
                    {
                        Data.mineMultiplier += 0.25;

                    }
                    else if (movingPanel.BackColor == Color.Green || movingPanel.BackColor.ToArgb() == Color.Green.ToArgb())
                    {
                        Data.forestMultiplier += 0.25;

                    }
                    else if (movingPanel.BackColor == Color.Yellow || movingPanel.BackColor.ToArgb() == Color.Yellow.ToArgb())
                    {
                        Data.farmMultiplier += 0.25;

                    }

                    Data.saveProductionMultiplier();

                    movingPanel.Visible = false;
                    cells.Remove(movingPanel);
                    panelsToRemove.Add(movingPanel);
                }
            }

            foreach (Panel panel in panelsToRemove)
            {
                movingPanels.Remove(panel);
            }
            isMoving = movingPanels.Count > 0;
        }

        void generateGrid()
        {
            int gridWidth = 10;
            int gridHeight = 10;

            Random random = new Random();
            var color = Color.White;
            Boolean userGenerated = false;
            
            var loadPanels = Data.loadGrids();

            //============================= KRITERIA 3 NO 1 (LOAD MAP DARI FILE) =============================

            if (loadPanels.Count > 0) // kalo udh ada file grid di load
            {                         //klo misal count 0 berarti gk ada file grid, pergi ke line 173 buat load baru
                foreach (var savedPanel in loadPanels)
                {
                    Panel newPanel = new Panel();
                    newPanel.Size = savedPanel.Size;
                    newPanel.Location = savedPanel.Location;
                    newPanel.BackColor = savedPanel.BackColor;
                    newPanel.BorderStyle = savedPanel.BorderStyle;
                    if(newPanel.BackColor != Color.White)
                    {
                        newPanel.Click += Cell_Click;
                    }
                    if (savedPanel.BackColor.ToArgb() == Color.Black.ToArgb())
                    {
                        userPosition = new Point(savedPanel.Location.X / 50, savedPanel.Location.Y / 50);
                    }

                    this.Controls.Add(newPanel);
                    cells.Add(newPanel);
                }
                Data.savedGrid = new List<Panel>(cells);
                Data.isBagian2Randomized = true;
            }
            else if(!Data.isBagian2Randomized)
            {
                for (int i = 0; i < gridHeight; i++)           //ini tak buat 50% something 50%empty biar gk terlalu rame
                {
                    for (int j = 0; j < gridWidth; j++)
                    {
                        int rand = random.Next(0, 100);

                        if(rand <= 10 && !userGenerated)
                        {
                            color = Color.Black; // player
                            userGenerated = true;
                        } else if(rand > 10 && rand < 20)
                        {
                            color = Color.Red; // Clay
                        } else if(rand > 20 && rand <= 30)
                        {
                            color = Color.Green; // Wood

                        } else if(rand > 30 && rand <= 40)
                        {
                            color = Color.Yellow; // Crop

                        } else if (rand > 40 && rand <= 50)
                        {
                            color = Color.Gray; // Iron
                        }
                        else
                        {
                            color = Color.White; // Empty
                        }

                        if (color == Color.Black)
                        {
                            userPosition = new Point(j, i); // marking lokasi user
                        }

                        cell = new Panel();
                        cell.Size = new Size(50, 50);
                        cell.Location = new Point(j * 50, i * 50);
                        cell.BackColor = color;
                        cell.BorderStyle = BorderStyle.FixedSingle;
                        if( color != Color.White)
                        {
                            cell.Click += Cell_Click;
                        }
                        this.Controls.Add(cell);
                        cells.Add(cell);
                        
                    }
                }
                Data.savedGrid = new List<Panel>(cells);
                Data.isBagian2Randomized = true;
            }      
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Panel selectedPanel = (Panel)sender;
            
            if (selectedPanel.BackColor == Color.Black || selectedPanel.BackColor.ToArgb() == Color.Black.ToArgb())
            {
                MessageBox.Show("das you goofy!");
                return;
            }

            if (!movingPanels.Contains(selectedPanel) && selectedPanel.BackColor.ToArgb() != Color.White.ToArgb())
            {
                selectedPanel.BringToFront(); // biar gk di belakang panel lain
                selectedPanel.Visible = true; //gataw cuma jaga jaga
                movingPanels.Add(selectedPanel); //masukin ke list panel yg moving
                isMoving = true; // flag kalo ada panel yg lagi gerak
                cropTimer.Start(); // start crop timer
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.saveGrids(cells);
            Data.savedGrid = new List<Panel>(cells);
            Data.saveProductionMultiplier();
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
                gameTick.Interval = 1000 / multiplier;
            }
            if (e.KeyCode == Keys.D2)
            {
                multiplier = 2;
                gameTick.Interval = 1000 / multiplier;
            }
            if (e.KeyCode == Keys.D3)
            {
                multiplier = 3;
                gameTick.Interval = 1000 / multiplier;
            }
            if (e.KeyCode == Keys.D4)
            {
                multiplier = 4;
                gameTick.Interval = 1000 / multiplier;
            }
            if (e.KeyCode == Keys.D5)
            {
                multiplier = 5;
                gameTick.Interval = 1000 / multiplier;
            }
            if (e.KeyCode == Keys.D6)
            {
                multiplier = 6;
                gameTick.Interval = 1000 / multiplier;
            }
            if (e.KeyCode == Keys.D7)
            {
                multiplier = 7;
                gameTick.Interval = 1000 / multiplier;
            }
            if (e.KeyCode == Keys.D8)
            {
                multiplier = 8;
                gameTick.Interval = 1000 / multiplier;
            }
            if (e.KeyCode == Keys.D9)
            {
                multiplier = 9;
                gameTick.Interval = 1000 / multiplier;
            }
            if (e.KeyCode == Keys.D0) // iki 10 ko
            {
                multiplier = 10;
                gameTick.Interval = 1000 / multiplier;
            }
            
        }
    }
}
