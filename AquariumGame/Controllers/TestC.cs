using System;
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
        public void Addmorefish()
        {
            int count=0;
            foreach (List<Fish> f in work.GetAll())
            {
                if (f.Count==0)
                {
                    count++;
                }
            }
            if (count > 4)
            {
                work.AddFish();
                work.AddFish();
            }
        }
        public List<List<Fish>> GetAll()
        {
            return work.GetAll();
        }
        public void Time()
        {
          
            foreach (List<Fish> f in work.GetAll())
            {
                f.Insert(0,work.GetRandomFish());

            }
            
        }
        public bool GameOver()
        {
            foreach (List<Fish> f in work.GetAll())
            {
                if (f.Count>6)
                {
                    return true;
                }
            }
            return false;
        }
        public void GunSetorGetFish(int ListID) 
        {
            if (work.GetStack(ListID).Count !=0 && gun.Content() == null && work.GetStack(ListID)[work.GetStack(ListID).Count - 1].GetType() != new BigFish().GetType())
            {
               
                gun.Set(work.GetStack(ListID));
            }
            else if(gun.Content() != null)
            {
                List<Fish> f = work.GetStack(ListID);
                
                if (f.Count==0)
                {
                    
                    f.Add(gun.Get());
                }
                else if (gun.Content()!=null && f[f.Count-1].GetType() == new BigFish().GetType() && gun.Content().GetType() == new MediumFish().GetType())// потрібен метод який повертає чи є рибка у gun і яка вона
                {
                    BigFish b = (BigFish)f[f.Count - 1];
                    
                    if (Perevirka((MediumFish)gun.Content()))
                    {
                        f.RemoveAt(f.Count-1);// видаляю рибу
                        gun.Get();
                        gun.Score+=3;
                    }
                    else if (b.IsSatisfied == 1)
                    {
                        f.RemoveAt(f.Count - 1);// видаляю рибу
                        gun.Get();
                        gun.Score += 3;
                    }
                    else
                    {
                        b.Eat((MediumFish)gun.Get());
                    }

                }
                else if (f[f.Count - 1].GetType() == new MediumFish().GetType() && gun.Content().GetType() == new SmallFish().GetType())
                {
                    MediumFish b = (MediumFish)f[f.Count - 1];

                    if (b.IsSatisfied == 1)
                    {
                        f.RemoveAt(f.Count - 1); // видаляю рибу
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

                    Work List = (Work)formatter.Deserialize(fs);

                }

            }
            
        }

        public int GetScore()
        {
            return gun.Score;
        }

    }
}
