using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumGame.Models
{
    [Serializable]
    class BigFish : Fish
    {
        public int IsSatisfied { private set; get; } // Кількість зїдених рибок.

        public BigFish()
        {
            IsSatisfied = 0;
        }

        public void Eat(Fish f) // Зїсти невелику рибку.
        {
            if (f.GetType() == new BigFish().GetType())
                return;
            IsSatisfied++;
        }

    }
}
