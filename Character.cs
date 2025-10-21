using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace USRS45_Combat
{
    public class Character
    {
        public int Health;
        public  int Damage;
        public string Name;

        public int DamageTaken;

        public bool IsParry = false;
        public bool IsDead = false;

        public void Parry()
        {
            USRS45_Combat.WriteLineWithDelay($"{this.Name} se défend.");
            IsParry = true;
        }

        public void TakeDamage(int damage)
        {
            DamageTaken += damage;
        }

        public virtual void Special(Character target)
        {
            USRS45_Combat.WriteLineWithDelay($"{this.Name} fait son attaque spéciale !");
        }

        public void Reset()
        {
            DamageTaken = 0;
            IsParry = false;
        }

        public void EndOfTurn()
        {
            if (!IsParry && DamageTaken > 0)
            {
                Health -= DamageTaken;
                USRS45_Combat.WriteLineWithDelay($"{this.Name} a pris {DamageTaken} dégats.");
            }

            if (Health <= 0)
            {
                IsDead = true;
                Health = 0;
                USRS45_Combat.WriteLineWithDelay($"{this.Name} est mort.");
            }
        }
    }
}
