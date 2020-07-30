using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquariumGame.Models;
using AquariumGame.Views;
namespace AquariumGame.Controllers
{
    class TestC
    {
        Work work;
        Gun gun;
        public void Start() // початок гри
        {
           work = new Work();
            work.AddFish();
            work.AddFish();
            gun = new Gun();
        }
        public void GunSetorGetFish(int StackID ) 
        {
            if (gun.Get() == null)// потрібен метод який повертає чи є рибка у gun і яка вона
            {
                //gun.Set(work.GetStak(StackID));// потрібно передати id бо нема доступу до стеків і в класі work добавити метод що повертає стек по id  
                //на view добавити обработчик що буде вертати номер колонки
            }
            else
            {
                //Stack<Fish> f =  work.GetStak(StackID);
                //if (f.Peek().GetType().Name == "BigFish" && gun.Get().GetType().Name == "MediumFish")// потрібен метод який повертає чи є рибка у gun і яка вона
                //{
                //    BigFish b = (BigFish)f.Peek();
                //    if (b.IsSatisfied == 1)
                //    {
                //        f.Pop();// видаляю рибу
                //    }
                //    else 
                //    {
                //        b.Eat(gun.Get());
                //    }

                //}
                //else if (f.Peek().GetType().Name == "MediumFish" && gun.Get().GetType().Name == "SmallFish")
                //{
                //    MediumFish b = (MediumFish)f.Peek();
                    
                //    if (b.IsSatisfied == 1)
                //    {
                //        f.Pop();// видаляю рибу
                //    }
                //    else
                //    {
                //        b.Eat((SmallFish)gun.Get());
                //    }
                //}
            }



        }
        public void Fun()
        {

        }

    }
}
