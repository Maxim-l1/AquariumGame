using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumGame.Models
{
    [Serializable]
    class DestroyerFish : Fish
    {
        public int IsSatisfied { private set; get; }
    }
}
