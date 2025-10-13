using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace USRS45_Combat
{
    public class Vampire : Character
    {
        public Vampire()
        {
            Health = 2;
            Damage = 2;
            Nom = "Vampire";
        }

        public override void Special(Character target)
        {
            base.Special(target);
            Health++;
            target.TakeDamage(1);
            Console.WriteLine($"{this.Nom} a volé une vie de {target.Nom}.");
        }
    }
}
