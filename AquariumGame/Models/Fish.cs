using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumGame.Models
{
    [Serializable]
    class Fish // Клас створений для того, щоб різних рибок можна було класти в колекцію одного типу.
    {
        public int IsSatisfied { private set; get; }
        public int GetFishType()
        {
            if (this.GetType().ToString() == new SmallFish().GetType().ToString())
                return 1;
            else if (this.GetType().ToString() == new MediumFish().GetType().ToString())
                return 2;
            else if (this.GetType().ToString() == new BigFish().GetType().ToString())
                return 3;
            else if (this.GetType().ToString() == new DestroyerFish().GetType().ToString())
                return 4;
            else
                return 0;
        }
    }
}
