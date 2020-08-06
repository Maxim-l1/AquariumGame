using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using AquariumGame.Controllers;
using AquariumGame.Models;
using System.Threading;

namespace AquariumGame.Views
{
    public partial class GameForm : Form
    {
        TestC Game = new TestC();
        Image small = Properties.Resources.small;
        Image medium = Properties.Resources.medium;
        Image big = Properties.Resources.big;
        Image medium_r = Properties.Resources.medium_r;
        Image big_r = Properties.Resources.big_r;
        Image kanat = Properties.Resources.Kanat;
        Image refresh = Properties.Resources.refresh;
        Image danger = Properties.Resources.danger;
        Image[] fishesRes = new Image[4];
        Image[] fishesRes_r = new Image[3];

        List<PictureBox> pictureBoxes = new List<PictureBox>();
        PictureBox[,] fishesTable = new PictureBox[6, 6];
        int[] count = new int[6];
        int getColumn = 0;

        public GameForm()
        {
            InitializeComponent();
            fishesRes[0] = small;
            fishesRes[1] = medium;
            fishesRes[2] = big;
            fishesRes[3] = danger;
            fishesRes_r[0] = small;
            fishesRes_r[1] = medium_r;
            fishesRes_r[2] = big_r;
            CreateTable();
            pictureBox1.Cursor = Cursors.Hand;
            Game.Start();
            PaintGame(Game.GetAll());
            label1.Text = Convert.ToString("Счёт: " + 0);
            IsGameOver.Start();
            AddFishTimer.Start();

        }

        private void GameForm_Paint(object sender, PaintEventArgs e)// метод для отрисовки линий
        {
            Pen p = new Pen(Color.White, 3);// цвет линии и ширина
            Point p1 = new Point(70, 65);// первая точка
            Point p2 = new Point(70, 465);// вторая точка
            e.Graphics.DrawLine(p, p1, p2);

            p = new Pen(Color.White, 3);// цвет линии и ширина
            p1 = new Point(140, 65);// первая точка
            p2 = new Point(140, 465);// вторая точка
            e.Graphics.DrawLine(p, p1, p2);

            p = new Pen(Color.White, 3);// цвет линии и ширина
            p1 = new Point(210, 65);// первая точка
            p2 = new Point(210, 465);// вторая точка
            e.Graphics.DrawLine(p, p1, p2);

            p = new Pen(Color.White, 3);// цвет линии и ширина
            p1 = new Point(280, 65);// первая точка
            p2 = new Point(280, 465);// вторая точка
            e.Graphics.DrawLine(p, p1, p2);

            p = new Pen(Color.White, 3);// цвет линии и ширина
            p1 = new Point(350, 65);// первая точка
            p2 = new Point(350, 465);// вторая точка
            e.Graphics.DrawLine(p, p1, p2);
            e.Graphics.DrawImage(kanat, 0, 440, 422, 50);
        } 

        private void GameForm_MouseClick(object sender, MouseEventArgs e) //метод определяет куда произошло нажатие
        {
            if (e.Location.X > 0 && e.Location.X < 70 && e.Location.Y > 65 && e.Location.Y < 465)
            {
                getColumn = 0;
                Game.GunSetorGetFish(0);
                PaintGame(Game.GetAll());
                AddGun(Game.GetFishinGun(), 0);
                label1.Text = Convert.ToString("Счёт: " + Game.GetScore());
            }
            else if (e.Location.X > 70 && e.Location.X < 140 && e.Location.Y > 65 && e.Location.Y < 465)
            {
                getColumn = 1;
                Game.GunSetorGetFish(1);
                PaintGame(Game.GetAll());
                AddGun(Game.GetFishinGun(), 1);
                label1.Text = Convert.ToString("Счёт: " + Game.GetScore());
            }
            else if (e.Location.X > 140 && e.Location.X < 210 && e.Location.Y > 65 && e.Location.Y < 465)
            {
                getColumn = 2;
                Game.GunSetorGetFish(2);
                PaintGame(Game.GetAll());
                AddGun(Game.GetFishinGun(), 2);
                label1.Text = Convert.ToString("Счёт: " + Game.GetScore());
            }
            else if (e.Location.X > 210 && e.Location.X < 280 && e.Location.Y > 65 && e.Location.Y < 465)
            {
                getColumn = 3;
                Game.GunSetorGetFish(3);
                PaintGame(Game.GetAll());
                AddGun(Game.GetFishinGun(), 3);
                label1.Text = Convert.ToString("Счёт: " + Game.GetScore());
            }
            else if (e.Location.X > 280 && e.Location.X < 350 && e.Location.Y > 65 && e.Location.Y < 465)
            {
                getColumn = 4;
                Game.GunSetorGetFish(4);
                PaintGame(Game.GetAll());
                AddGun(Game.GetFishinGun(), 4);
                label1.Text = Convert.ToString("Счёт: " + Game.GetScore());
            }
            else if (e.Location.X > 350 && e.Location.X < 420 && e.Location.Y > 65 && e.Location.Y < 465)
            {
                getColumn = 5;
                Game.GunSetorGetFish(5);
                PaintGame(Game.GetAll());
                AddGun(Game.GetFishinGun(), 5);
                label1.Text = Convert.ToString("Счёт: " + Game.GetScore());
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
            Game.Refresh();
            PaintGame(Game.GetAll());
            AddGun(Game.GetFishinGun(), getColumn);
            label1.Text = Convert.ToString("Счёт: " + Game.GetScore());
        }

        private void PaintGame(List<List<Fish>> fishes) //метод рисует стек
        {
            count = new int[6];
            for (int i = 0; i < 6; i++)
            {
                count[i] = 0;
            }
            for (int i = 0; i < 6; i++)
            {
                foreach (var fish in fishes[i])
                {
                    if (fish.IsSatisfied == 0)
                    {
                        fishesTable[i, count[i]].Image = fishesRes[fish.GetFishType() - 1];
                    }
                    else
                    {
                        fishesTable[i, count[i]].Image = fishesRes_r[fish.GetFishType() - 1];
                    }
                    //Thread.Sleep(50);
                    fishesTable[i, count[i]].Visible = true;
                    count[i]++;
                }
            }
            ChangeVisable();
        } 

        private void Save_Click(object sender, EventArgs e)
        {
            Game.Save();
            MessageBox.Show("Вы успешно сохранили игру!");
        }

        private void Download_Click(object sender, EventArgs e)
        {
            Game.Upload();
            PaintGame(Game.GetAll());
            AddGun(Game.GetFishinGun(), getColumn);
            MessageBox.Show("Вы успешно загрузили игру!");
        }

        private void IsGameOver_Tick(object sender, EventArgs e)
        {
            Game.Time();
            PaintGame(Game.GetAll());
            AddGun(Game.GetFishinGun(), getColumn);
            label1.Text = Convert.ToString("Счёт: " + Game.GetScore());
            if (Game.GameOver() == true)
            {
                MessageBox.Show("Вы проиграли");
                Game.Refresh();
                PaintGame(Game.GetAll());
                AddGun(Game.GetFishinGun(), getColumn);
                label1.Text = Convert.ToString("Счёт: " + Game.GetScore());
            }
        }

        private void CreateTable()
        {
            for (int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    PictureBox picture = new PictureBox();
                    picture.Visible = false;
                    picture.SizeMode = PictureBoxSizeMode.CenterImage;
                    picture.Width = 65;
                    picture.Height = 65;
                    picture.BackColor = Color.Transparent;
                    picture.Location = new Point(5 + (i * 70), 65 + (j * 65));
                    Controls.Add(picture);
                    fishesTable[i, j] = picture;
                }
            }
        }
        private void ChangeVisable()
        {
            for (int i = 0; i < 6; i++)
            {
                for(int j = count[i]; j < 6; j++)
                {
                    fishesTable[i, j].Visible = false;
                }
            }
        }

        private void AddFishTimer_Tick(object sender, EventArgs e)
        {
            Game.Addmorefish();
        }

        private void AddGun(Fish fish, int column)
        {
            if (fish == null)
            {
                gun.Visible = false;
                return;
            }
            gun.Visible = true;
            gun.Image = fishesRes[fish.GetFishType() - 1];
            if (column == 0)
                gun.Location = new Point(5, 480);
            else
                gun.Location = new Point(5 + (5 + column * 70), 480);
        }
    }
}
