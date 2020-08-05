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
        public Work work;
        Gun gun;
        
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
                if (f.Count<2)
                {
                    count++;
                }
            }
            if (count > 5)
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

        public Fish GetFishinGun()
        {


            return gun.Content();
        }
        public void DestroyerFish(int ListID)
        {
            
                List<Fish> f = work.GetStack(ListID);

                List<Fish> f1 = new List<Fish>();
                List<Fish> f2 = new List<Fish>();
                if (ListID > 0 && ListID < 6)
                {
                    f1 = work.GetStack(ListID - 1);
                }
                if (ListID >= 0 && ListID < 5)
                {
                    f2 = work.GetStack(ListID + 1);
                }
                int count = f.Count;
                if (f1.Count != 0)
                {
                if(f1.Count == f.Count+1)
                {
                    f1.RemoveAt(count);

                    f1.RemoveAt(count - 1);

                    if (f1.Count >2)
                    {
                        f1.RemoveAt(count - 2);
                    }
                }
                  else  if (f1.Count == f.Count )
                    {
                        
                        f1.RemoveAt(count-1);
                    if (f1.Count>1)
                    {
                        f1.RemoveAt(count - 2);
                    }
                    }
                    else if (f1.Count == f.Count -1)
                    {
                       

                        f1.RemoveAt(count - 2);
                    }
                   
                }
                if (f2.Count != 0)
                {
                if (f2.Count == f.Count + 1)
                {
                    f2.RemoveAt(count);

                    f2.RemoveAt(count - 1);
                    if (f2.Count>2)
                    {
                        f2.RemoveAt(count - 2);
                    }
                }
               else  if (f2.Count == f.Count)
                    {
                     

                        f2.RemoveAt(count-1);
                    if (f2.Count>1)
                    {
                        f2.RemoveAt(count - 2);
                    }
                    }
                    else if (f2.Count == f.Count -1)
                    {
                       

                        f2.RemoveAt(count - 2);
                    }
                 
                }
                f.RemoveAt(f.Count - 1);
            if(f.Count!=0)
            f.RemoveAt(f.Count - 1);
           

            
            
        }
        public void GunSetorGetFish(int ListID) 
        {
            
            if (work.GetStack(ListID).Count !=0 && gun.Content() == null && work.GetStack(ListID)[work.GetStack(ListID).Count - 1].GetType() != new BigFish().GetType())
            {
               if(work.GetStack(ListID)[work.GetStack(ListID).Count - 1].GetType() == new DestroyerFish().GetType())
               { DestroyerFish(ListID);
                }
               else                
                gun.Set(work.GetStack(ListID));
            }
            else if(gun.Content() != null)
            {
                List<Fish> f = work.GetStack(ListID);

               
                if (f.Count == 0)
                {

                    f.Add(gun.Get());
                }

                else if (gun.Content() != null && f[f.Count - 1].GetType() == new BigFish().GetType() && gun.Content().GetType() == new MediumFish().GetType())// потрібен метод який повертає чи є рибка у gun і яка вона
                {
                    BigFish b = (BigFish)f[f.Count - 1];

                    if (Perevirka((MediumFish)gun.Content()))
                    {
                        f.RemoveAt(f.Count - 1);// видаляю рибу
                        gun.Get();
                        gun.Score += 3;
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
            BinaryFormatter formatter = new BinaryFormatter();

            
            using (FileStream fs = new FileStream("Save.txt", FileMode.OpenOrCreate))
            {
                
                 formatter.Serialize(fs, work.GetAll());

                
            }
            
        }
        public void Upload()
        {
            
                BinaryFormatter  formatter = new BinaryFormatter();


                using (FileStream fs = new FileStream("Save.txt", FileMode.OpenOrCreate))
                {

                    work.SetList((List<List<Fish>>)formatter.Deserialize(fs));

                }

            
            
        }

        public int GetScore()
        {
            return gun.Score;
        }

    }
}
