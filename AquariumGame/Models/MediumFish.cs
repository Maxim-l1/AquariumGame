using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumGame.Models
{
    [Serializable]
    class MediumFish : Fish // Середня рибка. Може їсти маленьких рибок.
    {
        public int IsSatisfied { private set; get; } // Кількість зїдених рибок

        public MediumFish()
        {
            IsSatisfied = 0;
        }

        public void Eat(SmallFish sf) //Їсть маленьку рибку
        {
            IsSatisfied++;
        }
    }
}
