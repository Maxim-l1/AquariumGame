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
                    }
                    else if (b.IsSatisfied == 1)
                    {
                        f.Pop();// видаляю рибу
                        gun.Get();
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
             formatter = new BinaryFormatter();


            using (FileStream fs = new FileStream("Save.txt", FileMode.OpenOrCreate))
            {
              
                Work stack = (Work)formatter.Deserialize(fs);
               
            }


        }



    }
}
