using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AquariumGame.Controllers;
namespace AquariumGame.Controllers
{
    public partial class Form2 : Form
    {
        TestC test;
        public Form2()
        {
            InitializeComponent();
            test = new TestC();
          
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string[] word = sender.ToString().Split();


            if (word[2]==label1.Text)
            {
                test.GunSetorGetFish(1);
            }
            if (word[2] == label2.Text)
            {
                test.GunSetorGetFish(2);
            }
            if (word[2] == label3.Text)
            {
                test.GunSetorGetFish(3);
            }
            if (word[2] == label4.Text)
            {
                test.GunSetorGetFish(4);
            }
            if (word[2] == label5.Text)
            {
                test.GunSetorGetFish(5);
            }
            if (word[2] == label6.Text)
            {
                test.GunSetorGetFish(6);
            }
            if (word[2] == label7.Text)
            {
                test.GunSetorGetFish(7);
            }
            if (word[2] == label8.Text)
            {
                test.GunSetorGetFish(8);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            test.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            test.Refresh();
        }
    }
}
