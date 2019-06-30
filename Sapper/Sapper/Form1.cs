using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper
{
    public partial class Form1 : Form
    {
        private int height = 9;
        private int width = 9;
        private int bombsCount = 10;
        private Cell[,] cells;
        private int cellSize = 30;
        private Graphics g;
        private Brush brush = Brushes.LightGray;
        private Random rnd = new Random();
        Icon icon1 = new Icon("flag.ico");
        Icon icon2 = new Icon("mina.ico");
        private bool win;
        int sec, minutes;

        public Form1(int wdt, int hgt, int bombs)
        {
            InitializeComponent();
            height = hgt;
            width = wdt;
            bombsCount = bombs;
            CreateArray();
            CreateBombs();
            ArrangeNums();
            labelTime.Text = "0:0";
            timer.Start();
            this.ClientSize = new Size(height * (cellSize + 7), width * (cellSize + 3));
            panel1.ClientSize = new Size(height * cellSize + 1, width * cellSize + 1);
            g = panel1.CreateGraphics();
        }

        private void FillPanel()
        {
            for (int i = 1; i < height+1; i++)
                for (int j = 1; j < width+1; j++)
                {
                    g.FillRectangle(brush, i * cellSize, j * cellSize, cellSize, cellSize);
                    g.DrawRectangle(new Pen(Color.Black),i * cellSize, j * cellSize, cellSize, cellSize);
                }
        }

        private void CreateArray()
        {
            cells = new Cell[height + 2, width + 2];
            for (int i = 0; i < height + 2; i++)
                for (int j = 0; j < width + 2; j++)
                {
                    cells[i, j] = new Cell {Obj = "0",Status = 0 };
                }
        }

        private void CreateBombs()
        {
            for (int i = 0; i < bombsCount; i++)
            {
                int row = rnd.Next(1, height-2);
                int col = rnd.Next(1, width-2);
                if (cells[row, col].Obj != "*")
                    cells[row, col].Obj = "*";
                else
                    i--;
            }
        }

        private void ArrangeNums()
        {
            for (int i = 1; i < height + 1; i++)
                for (int j = 1; j < width + 1; j++)
                {
                    int bombs = 0;
                    for (int dx = -1; dx <= 1; dx++)
                        for (int dy = -1; dy <= 1; dy++)
                            if (cells[i + dx, j + dy].Obj == "*")
                                bombs++;
                    if (cells[i, j].Obj != "*")
                        cells[i, j].Obj = bombs.ToString();
                }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            FillPanel();
        }

        private void button_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void NewGame()
        {
            for (int i = 1; i < height + 1; i++)
                for (int j = 1; j < width + 1; j++)
                    Coloring(i, j);
            Thread.Sleep(4000);
            sec = 0;
            minutes = 0;
            timer.Start();

            for (int i = 1; i < height + 1; i++)
                for (int j = 1; j < width + 1; j++)
                {
                    cells[i, j].Obj = "";
                    cells[i, j].Status = 0;
                }
            FillPanel();
            CreateBombs();
            ArrangeNums();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int row = e.X / cellSize;
            int col = e.Y / cellSize;
            int x = row * cellSize;
            int y = col * cellSize;
            if (row != 0 && col != 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (cells[row, col].Status == 0)
                    {
                        if (cells[row, col].Obj == "*")
                            GameOver();
                        else
                        {
                            cells[row, col].Status = 1;
                            Coloring(row, col);
                            if (cells[row,col].Obj == "0")
                                OpenEmptyCells(row, col);
                        }
                    }
                }
                else 
                {
                    if (cells[row, col].Status == 0)
                    {
                        cells[row, col].Status = 2;
                        g.DrawIcon(icon1, new Rectangle(x, y, cellSize, cellSize));
                    }
                    else if (cells[row,col].Status == 2)
                    {
                        cells[row, col].Status = 0;
                        Coloring(row, col);
                    }    
                }
            }
        }

        private void OpenEmptyCells(int row, int col)
        {
            for (int dx = -1; dx <= 1; dx++)
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (cells[row + dx, col + dy].Status != 1)
                    {
                        if (row + dx != 0 && col + dy != 0)
                        {
                            cells[row + dx, col + dy].Status = 1;
                            Coloring(row + dx, col + dy);
                        }
                        if (cells[row + dx, col + dy].Obj == "0" && row!=2 && row!= height  && col!=2 && col!=width)
                            OpenEmptyCells(row + dx, col + dy);
                    }
                }
        }

        private void GameOver()
        {
            timer.Stop();
            MessageBox.Show("Вы проиграли");
            NewGame();
        }

        private void Coloring(int row, int col)
        {
            g.FillRectangle(Brushes.White, row * cellSize, col * cellSize, cellSize - 1, cellSize - 1);
            switch (cells[row, col].Obj)
            {
                case "0":break;
                case "*": g.DrawIcon(icon2, new Rectangle(row*cellSize, col*cellSize, cellSize, cellSize));break;
                case "1":  g.DrawString(cells[row, col].Obj, new Font("Courier New", 12), Brushes.Blue, row * cellSize + 5, col * cellSize + 5);break;
                case "2": g.DrawString(cells[row, col].Obj, new Font("Courier New", 12), Brushes.Green, row * cellSize + 5, col * cellSize + 5); break;
                case "3": g.DrawString(cells[row, col].Obj, new Font("Courier New", 12), Brushes.Red, row * cellSize + 5, col * cellSize + 5); break;
                case "4": g.DrawString(cells[row, col].Obj, new Font("Courier New", 12), Brushes.Yellow, row * cellSize + 5, col * cellSize + 5); break;
                default: g.DrawString(cells[row, col].Obj, new Font("Courier New", 12), Brushes.Purple, row * cellSize + 5, col * cellSize + 5); break;

            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //sec++;
            //if (sec >= 60)
            //    sec -= 60;
            //minutes = sec / 60;
            //labelTime.Text = $"{minutes}:{sec}";
            //win = true;
            //for (int i = 1; i < height + 1; i++)
            //    for (int j = 1; j < width + 1; j++)
            //        if (cells[i, j].Status == 0)
            //            win = false;
            //if (win)
            //{
            //    MessageBox.Show("Вы выиграли!");
            //    NewGame();
            //}
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Menu().Show();
        }

        public class Cell
        {
            public string Obj;
            public int Status;
            //0 - закрыта
            //1 - открыта
            //2 - флаг
        }
    }
}
