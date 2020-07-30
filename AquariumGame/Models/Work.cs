using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumGame.Models
{
    class Work
    {
        Random rand = new Random(DateTime.Now.Millisecond);
        Stack<Fish> FirstColumn;//
        Stack<Fish> SecondColumn;//
        Stack<Fish> ThirdColumn;// Клонки з рибками
        Stack<Fish> FourthColumn;//
        Stack<Fish> FifthColumn;//
        Stack<Fish> SixthColumn;//

        public Work()
        {
            
        }

        public void AddFish() // Додає випадкову рибку в кожну колонку
        {
            var x = rand.Next(3);
            if (x == 0)
                FirstColumn.Push(new SmallFish());
            else if (x == 1)
                FirstColumn.Push(new MediumFish());
            else
                FirstColumn.Push(new BigFish());
            x = rand.Next(3);
            if (x == 0)
                SecondColumn.Push(new SmallFish());
            else if (x == 1)
                SecondColumn.Push(new MediumFish());
            else
                SecondColumn.Push(new BigFish());
            x = rand.Next(3);
            if (x == 0)
                ThirdColumn.Push(new SmallFish());
            else if (x == 1)
                ThirdColumn.Push(new MediumFish());
            else
                ThirdColumn.Push(new BigFish());
            x = rand.Next(3);
            if (x == 0)
                FourthColumn.Push(new SmallFish());
            else if (x == 1)
                FourthColumn.Push(new MediumFish());
            else
                FourthColumn.Push(new BigFish());
            x = rand.Next(3);
            if (x == 0)
                FifthColumn.Push(new SmallFish());
            else if (x == 1)
                FifthColumn.Push(new MediumFish());
            else
                FifthColumn.Push(new BigFish());
            x = rand.Next(3);
            if (x == 0)
                SixthColumn.Push(new SmallFish());
            else if (x == 1)
                SixthColumn.Push(new MediumFish());
            else
                SixthColumn.Push(new BigFish());
            x = rand.Next(3);

        }
        public void AddFish(Stack<Fish> s) // Додає випадкву рибку в конкретну колонку
        {
            var x = rand.Next(3);
            if (x == 0)
                s.Push(new SmallFish());
            else if(x == 1)
                s.Push(new MediumFish());
            else
                s.Push(new BigFish());

        }
        public void AddFish(Stack<Fish> s, Fish f) // Додає конкретну рибку в конкретну колонку
        {
            s.Push(f);
        }

    }
}