﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AquariumGame.Models;
using AquariumGame.Views;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace AquariumGame.Controllers
{
    class TestC
    {
        Work work;
        Gun gun;
        BinaryFormatter formatter;
        public void Start() // початок гри
        {
           work = new Work();
            work.AddFish();
            work.AddFish();
            gun = new Gun();

        }

        public bool Perevirka(MediumFish a)
        {
            if (a.IsSatisfied==1)
            {
                return true;
            }
            return false;



        }

        public void Time()
        {
            List<Fish[]> list = new List<Fish[]>();
            foreach (Stack<Fish> f in work.GetAll())
            {
                Fish[] fish = new Fish[f.Count];
                f.CopyTo(fish,0);
                list.Add(fish);
                
            }
            list.Reverse();
            work.AddFish();
            int i = 0;
            foreach (Stack<Fish> f in work.GetAll())
            {
                f.Concat(list[i]);
                i++;
            }

        }
        public bool GameOver()
        {
            foreach (Stack<Fish> f in work.GetAll())
            {
                if (f.Count>6)
                {
                    return true;
                }
            }
            return false;
        }
        public void GunSetorGetFish(int StackID) 
        {
            if (gun.Content() == null)
            {
               
                gun.Set(work.GetStack(StackID));
            }
            else
            {
                Stack<Fish> f = work.GetStack(StackID);
               
               
                if (f.Peek().GetType() == new BigFish().GetType() && gun.Content().GetType() == new MediumFish().GetType())// потрібен метод який повертає чи є рибка у gun і яка вона
                {
                    BigFish b = (BigFish)f.Peek();
                    
                    if (Perevirka((MediumFish)gun.Content()))
                    {
                        f.Pop();// видаляю рибу
                        gun.Get();
                        gun.Score+=3;
                    }
                    else if (b.IsSatisfied == 1)
                    {
                        f.Pop();// видаляю рибу
                        gun.Get();
                        gun.Score += 3;
                    }
                    else
                    {
                        b.Eat((MediumFish)gun.Get());
                    }

                }
                else if (f.Peek().GetType() == new MediumFish().GetType() && gun.Content().GetType() == new SmallFish().GetType())
                {
                    MediumFish b = (MediumFish)f.Peek();

                    if (b.IsSatisfied == 1)
                    {
                        f.Pop();// видаляю рибу
                        gun.Get();
                        gun.Score += 3;
                    }
                    else
                    {
                        b.Eat((SmallFish)gun.Get());
                    }
                }
            }



        }
        public void Refresh() // перестворити
        {
            Start();
           
        }


        public void Save()
        {
             formatter = new BinaryFormatter();

            
            using (FileStream fs = new FileStream("Save.txt", FileMode.OpenOrCreate))
            {
                
                formatter.Serialize(fs, work);

                
            }
            
        }
        public void Upload()
        {
            if (File.Exists("Save.txt"))
            {
                formatter = new BinaryFormatter();


                using (FileStream fs = new FileStream("Save.txt", FileMode.OpenOrCreate))
                {

                    Work stack = (Work)formatter.Deserialize(fs);

                }

            }
            
        }

        public int GetScore()
        {
            return gun.Score;
        }

    }
}
