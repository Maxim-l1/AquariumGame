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
        TestC Game = new TestC();
        Image small = Properties.Resources.small;
        Image medium = Properties.Resources.medium;
        Image big = Properties.Resources.big;
        Image kanat = Properties.Resources.Kanat;
        Image refresh = Properties.Resources.refresh;
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        int[] count = new int[6];

        public GameForm()
        {
            InitializeComponent();
            pictureBox1.Cursor = Cursors.Hand;
            Game.Start();
     
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
        } //метод для отрисовки линий

        private void GameForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Location.X > 0 && e.Location.X < 70 && e.Location.Y < 400)
            {
                Game.GunSetorGetFish(0);
               
            }
            else if (e.Location.X > 70 && e.Location.X < 140 && e.Location.Y < 400)
            {
                Game.GunSetorGetFish(1);
                
            }
            else if (e.Location.X > 140 && e.Location.X < 210 && e.Location.Y < 400)
            {
                Game.GunSetorGetFish(2);
              
            }
            else if (e.Location.X > 210 && e.Location.X < 280 && e.Location.Y < 400)
            {
                Game.GunSetorGetFish(3);
                
            }
            else if (e.Location.X > 280 && e.Location.X < 350 && e.Location.Y < 400)
            {
                Game.GunSetorGetFish(4);
                
            }
            else if (e.Location.X > 350 && e.Location.X < 420 && e.Location.Y < 400)
            {
                Game.GunSetorGetFish(5);
                
            }

        } //метод определяет куда произошло нажатие

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
            Game.Refresh();
        }

        private void PaintGame(List<Stack<Fish>> fishes)
        {
            count = new int[6];
            for (int i = 0; i < 6; i++)
            {
                count[i] = 0;
            }
            foreach(var x in pictureBoxes)
            {
                x.Visible = false;
                x.Dispose();
            }
            pictureBoxes.Clear();

            for (int i = 0; i < 6; i++)
            {
                foreach (var fish in fishes[i])
                {
                    AddFish(fish.GetFishType(), i);
                }
            }
        } //метод рисует стек

        private void AddFish(int size, int column)
        {
            switch (column)
            {
                case 1:
                    if (size == 1)
                    {
                        if (count[0] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = small;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(5, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[0]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = small;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(5, 5 + (count[0] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[0]++;
                        }
                    }
                    else if (size == 2)
                    {
                        if (count[0] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = medium;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(5, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[0]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = medium;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(5, 5 + (count[0] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[0]++;
                        }
                    }
                    else if (size == 3)
                    {
                        if (count[0] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = big;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(5, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[0]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = big;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(5, 5 + (count[0] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[0]++;
                        }
                    }
                    break;
                case 2:
                    if (size == 1)
                    {
                        if (count[1] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = small;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(75, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[1]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = small;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(75, 5 + (count[1] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[1]++;
                        }
                    }
                    else if (size == 2)
                    {
                        if (count[1] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = medium;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(75, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[1]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = medium;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(75, 5 + (count[1] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[1]++;
                        }
                    }
                    else if (size == 3)
                    {
                        if (count[1] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = big;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(75, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[1]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = big;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(75, 5 + (count[1] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[1]++;
                        }
                    }
                    break;
                case 3:
                    if (size == 1)
                    {
                        if (count[2] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = small;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(145, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[2]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = small;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(145, 5 + (count[2] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[2]++;
                        }
                    }
                    else if (size == 2)
                    {
                        if (count[2] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = medium;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(145, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[2]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = medium;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(145, 5 + (count[2] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[2]++;
                        }
                    }
                    else if (size == 3)
                    {
                        if (count[2] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = big;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(145, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[2]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = big;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(145, 5 + (count[2] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[2]++;
                        }
                    }
                    break;
                case 4:
                    if (size == 1)
                    {
                        if (count[3] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = small;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(215, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[3]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = small;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(215, 5 + (count[3] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[3]++;
                        }
                    }
                    else if (size == 2)
                    {
                        if (count[3] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = medium;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(215, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[3]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = medium;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(215, 5 + (count[3] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[3]++;
                        }
                    }
                    else if (size == 3)
                    {
                        if (count[3] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = big;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(215, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[3]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = big;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(215, 5 + (count[3] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[3]++;
                        }
                    }
                    break;
                case 5:
                    if (size == 1)
                    {
                        if (count[4] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = small;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(285, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[4]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = small;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(285, 5 + (count[4] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[4]++;
                        }
                    }
                    else if (size == 2)
                    {
                        if (count[4] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = medium;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(285, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[4]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = medium;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(285, 5 + (count[4] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[4]++;
                        }
                    }
                    else if (size == 3)
                    {
                        if (count[4] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = big;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(285, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[4]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = big;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(285, 5 + (count[4] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[4]++;
                        }
                    }
                    break;
                case 6:
                    if (size == 1)
                    {
                        if (count[5] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = small;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(355, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[5]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = small;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(355, 5 + (count[5] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[5]++;
                        }
                    }
                    else if (size == 2)
                    {
                        if (count[5] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = medium;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(355, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[5]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = medium;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(355, 5 + (count[5] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[5]++;
                        }
                    }
                    else if (size == 3)
                    {
                        if (count[5] == 0)
                        {
                            PictureBox New = new PictureBox();
                            New.Image = big;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(355, 5);
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[5]++;
                        }
                        else
                        {
                            PictureBox New = new PictureBox();
                            New.Image = big;
                            New.SizeMode = PictureBoxSizeMode.CenterImage;
                            New.Width = 65;
                            New.Height = 65;
                            New.Location = new Point(355, 5 + (count[5] * 65));
                            New.BackColor = Color.Transparent;
                            Controls.Add(New);
                            pictureBoxes.Add(new PictureBox());
                            count[5]++;
                        }
                    }
                    break;
            }
        } //вспомогательный метод для отрисовки стека

       
    }
}
