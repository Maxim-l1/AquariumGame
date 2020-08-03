using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumGame.Models
{
    [Serializable]
    class Gun
    {
        public Fish shell;
        public int Score { set; get; }
        public Gun() 
        {
            shell = new Fish();
        }

        public Fish Get() // Повертає рибку в пушці
        {
            if (shell.GetType() != new Fish().GetType())
            {
                var temp = shell;
                shell = new Fish();
                return temp;
            }
            return null;

        }

        public void Set(Stack<Fish> fish) // Приймає останню рибку з конкретної колонки
        {
            if (shell.GetType() != new Fish().GetType())
            {
                return;
            }
            else
                shell = fish.Pop();
        }

        public Fish Content()
        {
            if (shell.GetType() != new Fish().GetType())
            {
                return shell;
            }
            return null;
        }
    }
}