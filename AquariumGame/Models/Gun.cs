﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumGame.Models
{
    class Gun
    {
        Fish shell;
        public Gun()
        {
            shell = new Fish();
        }

        public Fish Get()
        {
            if (shell != new Fish())
            {
                var temp = shell;
                shell = new Fish();
                return temp;
            }
            return null;

        }

        public void Set(Fish fish)
        {
            if (shell != new Fish())
            {
                return;
            }
            else
                shell = fish;
        }
    }
}