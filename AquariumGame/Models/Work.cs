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
            var x = rand.Next(3);
            if (x == 0)
                FirstColumn.Add(new SmallFish());
            else if (x == 1)
                FirstColumn.Add(new MediumFish());
            else
                FirstColumn.Add(new BigFish());
            x = rand.Next(3);
            if (x == 0)
                SecondColumn.Add(new SmallFish());
            else if (x == 1)
                SecondColumn.Add(new MediumFish());
            else
                SecondColumn.Add(new BigFish());
            x = rand.Next(3);
            if (x == 0)
                ThirdColumn.Add(new SmallFish());
            else if (x == 1)
                ThirdColumn.Add(new MediumFish());
            else
                ThirdColumn.Add(new BigFish());
            x = rand.Next(3);
            if (x == 0)
                FourthColumn.Add(new SmallFish());
            else if (x == 1)
                FourthColumn.Add(new MediumFish());
            else
                FourthColumn.Add(new BigFish());
            x = rand.Next(3);
            if (x == 0)
                FifthColumn.Add(new SmallFish());
            else if (x == 1)
                FifthColumn.Add(new MediumFish());
            else
                FifthColumn.Add(new BigFish());
            x = rand.Next(3);
            if (x == 0)
                SixthColumn.Add(new SmallFish());
            else if (x == 1)
                SixthColumn.Add(new MediumFish());
            else
                SixthColumn.Add(new BigFish());
            x = rand.Next(3);

        }
        public void AddFish(List<Fish> s) // Додає випадкву рибку в конкретну колонку
        {
            var x = rand.Next(3);
            if (x == 0)
                s.Add(new SmallFish());
            else if(x == 1)
                s.Add(new MediumFish());
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
            else
                return new BigFish();
        }
        public void AddFish(List<Fish> s, Fish f) // Додає конкретну рибку в конкретну колонку
        {
            s.Add(f);
        }

    }
}