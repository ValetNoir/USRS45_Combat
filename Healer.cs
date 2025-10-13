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
        public override void Special(Character target)
        {
            base.Special(target);

            Health += 2;
            Console.WriteLine($"{this.Nom} s'est soigné 2 PV.");
        }
    }
}
