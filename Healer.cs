using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USRS45_Combat
{
    public class Healer : Character
    {
        public Healer()
        {
            Health = 4;
            Damage = 1;
            Nom = "Healer";
        }
        public void Special()
        {
            Health++;
        }
    }
}
