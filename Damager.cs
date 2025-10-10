using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USRS45_Combat
{
    public class Damager : Character
    {
        public Damager()
        {
            Health = 3;
            Damage = 2;
            Nom = "Damager";
        }

        public void Special(Character target)
        {
            target.TakeDamage(DamageTaken);
        }
    }
}
