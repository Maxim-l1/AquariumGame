using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumGame.Models
{
    [Serializable]
    class Work
    {
        Random rand = new Random(DateTime.Now.Millisecond);
        List<Fish> FirstColumn;//
        List<Fish> SecondColumn;//
        List<Fish> ThirdColumn;// Клонки з рибками
        List<Fish> FourthColumn;//
        List<Fish> FifthColumn;//
        List<Fish> SixthColumn;//
        List<List<Fish>> Stacks;

        public Work()
        {
            FirstColumn = new List<Fish>();
            SecondColumn = new List<Fish>();
            ThirdColumn = new List<Fish>();
            FourthColumn = new List<Fish>();
            FifthColumn = new List<Fish>();
            SixthColumn = new List<Fish>();
            Stacks = new List<List<Fish>>();
            Stacks.Add(FirstColumn);
            Stacks.Add(SecondColumn);
            Stacks.Add(ThirdColumn);
            Stacks.Add(FourthColumn);
            Stacks.Add(FifthColumn);
            Stacks.Add(SixthColumn);
        }
        public void SetList(List<List<Fish>> Stacks)
            {
            this.Stacks = Stacks;
}
        public List<Fish> GetStack(int index)
        {
            return Stacks[index];
        }

        public List<List<Fish>> GetAll()
        {
            return Stacks;
        }

        public void AddFish() // Додає випадкову рибку в кожну колонку
        {
            var x = rand.Next(100);
            if (0 <= x && x < 40)
                FirstColumn.Add(new SmallFish());
            else if (x >= 40 && x < 70)
                FirstColumn.Add(new MediumFish());
            else if (x >= 70 && x <= 90)
                FirstColumn.Add(new DestroyerFish());
            else
                FirstColumn.Add(new BigFish());
            x = rand.Next(100);
            if (0 <= x && x < 40)
                SecondColumn.Add(new SmallFish());
            else if (x >= 40 && x < 70)
                SecondColumn.Add(new MediumFish());
            else if (x >= 70 && x <= 90)
                SecondColumn.Add(new DestroyerFish());
            else
                SecondColumn.Add(new BigFish());
            x = rand.Next(100);
            if (0 <= x && x < 40)
                ThirdColumn.Add(new SmallFish());
            else if (x >= 40 && x < 70)
                ThirdColumn.Add(new MediumFish());
            else if (x >= 70 && x <= 90)
                ThirdColumn.Add(new DestroyerFish());
            else
                ThirdColumn.Add(new BigFish());
            x = rand.Next(100);
            if (0 <= x && x < 40)
                FourthColumn.Add(new SmallFish());
            else if (x >= 40 && x < 70)
                FourthColumn.Add(new MediumFish());
            else if (x >= 70 && x <= 90)
                FourthColumn.Add(new DestroyerFish());
            else
                FourthColumn.Add(new BigFish());
            x = rand.Next(100);
            if (0 <= x && x < 40)
                FifthColumn.Add(new SmallFish());
            else if (x >= 40 && x < 70)
                FifthColumn.Add(new MediumFish());
            else if (x >= 70 && x <= 90)
                FifthColumn.Add(new DestroyerFish());
            else
                FifthColumn.Add(new BigFish());
            x = rand.Next(100);
            if (0 <= x && x < 40)
                SixthColumn.Add(new SmallFish());
            else if (x >= 40 && x < 70)
                SixthColumn.Add(new MediumFish());
            else if (x >= 70 && x <= 90)
                SixthColumn.Add(new DestroyerFish());
            else
                SixthColumn.Add(new BigFish());

        }
        public void AddFish(List<Fish> s) // Додає випадкву рибку в конкретну колонку
        {
            var x = rand.Next(3);
            if (x == 0)
                s.Add(new SmallFish());
            else if(x == 1)
                s.Add(new MediumFish());
            else if (x == 2)
                s.Add(new DestroyerFish());
            else
                s.Add(new BigFish());

        }

        public Fish GetRandomFish()
        {
            var x = rand.Next(3);
            if (x == 0)
                return new SmallFish();
            else if (x == 1)
                return new MediumFish();
            else if (x == 2)
                return new DestroyerFish();
            else
                return new BigFish();
        }
        public void AddFish(List<Fish> s, Fish f) // Додає конкретну рибку в конкретну колонку
        {
            s.Add(f);
        }

    }
}