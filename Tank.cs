using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USRS45_Combat
{
    public class Tank : Character
    {
        public Tank()
        {
            Health = 5;
            Damage = 1;
            Nom = "Tank";
        }

        public override void Special(Character target)
        {
            base.Special(target);
            TakeDamage(1);
            target.TakeDamage(Damage + 1);
        }
    }
}
