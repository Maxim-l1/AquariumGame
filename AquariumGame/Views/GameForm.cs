using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AquariumGame.Controllers;
using AquariumGame.Models;

namespace AquariumGame.Views
{
    public partial class GameForm : Form
    {
        Image small = Properties.Resources.small;
        Image medium = Properties.Resources.medium;
        Image big = Properties.Resources.big;
        Image kanat = Properties.Resources.Kanat;
        Image refresh = Properties.Resources.refresh;
        int[] count = new int[6];

        public GameForm()
        {
            InitializeComponent();
            pictureBox1.Cursor = Cursors.Hand;
            for (int i = 0; i < 6; i++)
            {
                count[i] = 0;
            }
            AddFish(1, 1);
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.White, 3);// цвет линии и ширина
            Point p1 = new Point(70, 5);// первая точка
            Point p2 = new Point(70, 400);// вторая точка
            e.Graphics.DrawLine(p, p1, p2);

            p = new Pen(Color.White, 3);// цвет линии и ширина
            p1 = new Point(140, 5);// первая точка
            p2 = new Point(140, 400);// вторая точка
            e.Graphics.DrawLine(p, p1, p2);

            p = new Pen(Color.White, 3);// цвет линии и ширина
            p1 = new Point(210, 5);// первая точка
            p2 = new Point(210, 400);// вторая точка
            e.Graphics.DrawLine(p, p1, p2);

            p = new Pen(Color.White, 3);// цвет линии и ширина
            p1 = new Point(280, 5);// первая точка
            p2 = new Point(280, 400);// вторая точка
            e.Graphics.DrawLine(p, p1, p2);

            p = new Pen(Color.White, 3);// цвет линии и ширина
            p1 = new Point(350, 5);// первая точка
            p2 = new Point(350, 400);// вторая точка
            e.Graphics.DrawLine(p, p1, p2);
            e.Graphics.DrawImage(kanat, 0, 370, 422, 50);


            //e.Graphics.DrawImage(small, 10, 20, 40, 40);
            //e.Graphics.DrawImage(medium, 80, 15, 50, 50);
            //e.Graphics.DrawImage(big, 145, 5, 65, 65);
            //e.Graphics.DrawImage(small, 220, 20, 40, 40);
            //e.Graphics.DrawImage(medium, 290, 15, 50, 50);
            //e.Graphics.DrawImage(big, 355, 5, 65, 65);
            ////----------------------------------------------
            //e.Graphics.DrawImage(small, 10, 85, 40, 40);
            //e.Graphics.DrawImage(medium, 80, 80, 50, 50);
            //e.Graphics.DrawImage(big, 145, 70, 65, 65);
            //e.Graphics.DrawImage(small, 220, 85, 40, 40);
            //e.Graphics.DrawImage(medium, 290, 80, 50, 50);
            //e.Graphics.DrawImage(big, 355, 70, 65, 65);
        }

        private void GameForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Location.X > 0 && e.Location.X < 70 && e.Location.Y < 400)
            {
                //graphics.Add(this.CreateGraphics());
                //graphics[graphics.Count - 1].DrawImage(small, 10, 20, 40, 40);
            }
            else if (e.Location.X > 70 && e.Location.X < 140 && e.Location.Y < 400)
            {
                //graphics.Add(this.CreateGraphics());
                //graphics[graphics.Count - 1].DrawImage(medium, 80, 15, 50, 50);
            }
            else if (e.Location.X > 140 && e.Location.X < 210 && e.Location.Y < 400)
            {
                //graphics.Add(this.CreateGraphics());
                //graphics[graphics.Count - 1].DrawImage(big, 145, 5, 65, 65);
            }
            else if (e.Location.X > 210 && e.Location.X < 280 && e.Location.Y < 400)
            {
                //MessageBox.Show("4 колонка");
            }
            else if (e.Location.X > 280 && e.Location.X < 350 && e.Location.Y < 400)
            {
                //MessageBox.Show("5 колонка");
            }
            else if (e.Location.X > 350 && e.Location.X < 420 && e.Location.Y < 400)
            {
                //MessageBox.Show("6 колонка");
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            refresh.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = refresh;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            refresh.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = refresh;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PaintGame(List<Stack<Fish>> fishes)
        {
            count = new int[6];
            for (int i = 0; i < 6; i++)
            {
                count[i] = 0;
            }
            for (int i = 0; i < 6; i++)
            {
                foreach(var fish in fishes[i])
                {
                    AddFish(fish.GetFishType(), i);
                }
            }
        }

        private void AddFish(int size, int column)
        {
            switch (column)
            {
                case 1:
                    if (size == 1)
                    {
                        if (count[0] == 0)
                        {
                            g.DrawImage(small, 10, 20, 40, 40);
                            count[0]++;
                        }
                        else
                        {
                            g.DrawImage(small, 10, 20 + (count[0] * 65), 40, 40);
                            count[0]++;
                        }
                    }
                    break;
            }
        }
    }
}
