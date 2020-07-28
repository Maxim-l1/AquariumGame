using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquariumGame.Views
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
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
        }
    }
}
