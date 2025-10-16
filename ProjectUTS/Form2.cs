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
        Panel cell;
        List<Panel> cells = new List<Panel>();
        Timer gameTick = new Timer();
        Point userPosition = new Point(0, 0);
        Panel clickedCell = new Panel();
        Point clickedPosition;
        Boolean isMoving = false;
        List<Panel> movingPanels = new List<Panel>();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            generateGrid();
            gameTick.Interval = 1000;
            gameTick.Tick += GameTick_Tick;
            gameTick.Start();
        }

        private void GameTick_Tick(object sender, EventArgs e)
        {
            int speed = 10;

            if (movingPanels.Count == 0)
            {
                isMoving = false;
                return;
            }

            List<Panel> panelsToRemove = new List<Panel>();
            bool gridStateChanged = false;

            foreach (Panel movingPanel in movingPanels.ToList())
            {
                Point cellPositionRn = movingPanel.Location;

                if (cellPositionRn.X < userPosition.X * 50)
                {
                    cellPositionRn.X += speed;
                }
                else if (cellPositionRn.X > userPosition.X * 50)
                {
                    cellPositionRn.X -= speed;
                }

                if (cellPositionRn.Y < userPosition.Y * 50)
                {
                    cellPositionRn.Y += speed;
                }
                else if (cellPositionRn.Y > userPosition.Y * 50)
                {
                    cellPositionRn.Y -= speed;
                }

                movingPanel.Location = cellPositionRn;

                if (Math.Abs(movingPanel.Location.X - userPosition.X * 50) < speed && Math.Abs(movingPanel.Location.Y - userPosition.Y * 50) < speed)
                {
                    movingPanel.Location = new Point(userPosition.X * 50, userPosition.Y * 50);

                    if (movingPanel.BackColor == Color.Red)
                    {
                        //Data.addClay(1);
                    }
                    else if (movingPanel.BackColor == Color.Gray)
                    {
                        //Data.addIron(1);
                    }
                    else if (movingPanel.BackColor == Color.Green)
                    {
                        //Data.addWood(1);
                    }
                    else if (movingPanel.BackColor == Color.Yellow)
                    {
                        //Data.addCrop(1);
                    }

                    movingPanel.Visible = false;
                    cells.Remove(movingPanel);
                    panelsToRemove.Add(movingPanel);
                    gridStateChanged = true;
                }
            }

            foreach (Panel panel in panelsToRemove)
            {
                movingPanels.Remove(panel);
            }

            // Save grid when state changes
            if (gridStateChanged)
            {
                Data.saveGrids(cells);
                Data.savedGrid = new List<Panel>(cells);
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
            
            if (loadPanels.Count > 0) // kalo udh ada file
            {
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
                    if (savedPanel.BackColor == Color.Black)
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
            //else if(Data.isBagian2Randomized && Data.savedGrid != null)
            //{
            //    foreach (var savedPanel in Data.savedGrid)
            //    {
            //        Panel newPanel = new Panel();
            //        newPanel.Size = savedPanel.Size;
            //        newPanel.Location = savedPanel.Location;
            //        newPanel.BackColor = savedPanel.BackColor;
            //        newPanel.BorderStyle = savedPanel.BorderStyle;
            //        if(newPanel.BackColor != Color.White)
            //        {
            //            newPanel.Click += Cell_Click;
            //        }
            //        if (savedPanel.BackColor == Color.Black)
            //        {
            //            userPosition = new Point(savedPanel.Location.X / 50, savedPanel.Location.Y / 50);
            //        }
                    
            //        this.Controls.Add(newPanel);
            //        cells.Add(newPanel);
            //    }
            //}         
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Panel selectedPanel = (Panel)sender;
            
            if (!movingPanels.Contains(selectedPanel))
            {
                selectedPanel.BringToFront();
                selectedPanel.Visible = true;
                movingPanels.Add(selectedPanel);
                isMoving = true;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.saveGrids(cells);
            Data.savedGrid = new List<Panel>(cells);
        }
    }
}
