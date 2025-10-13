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
        public string Nom;

        public int DamageTaken;

        public bool IsParry = false;
        public bool IsDead = false;

        public void Parry()
        {
            Console.WriteLine($"{this.Nom} se défend.");
            IsParry = true;
        }

        public void TakeDamage(int damage)
        {
            DamageTaken += damage;
        }

        public virtual void Special(Character target)
        {
            Console.WriteLine($"{this.Nom} fait son attaque spéciale !");
        }

        public void EndOfTurn()
        {
            if (!IsParry && DamageTaken > 0)
            {
                Health -= DamageTaken;
                Console.WriteLine($"{this.Nom} a pris {DamageTaken} dégats.");
            }

            if (Health <= 0)
            {
                IsDead = true;
                Health = 0;
                Console.WriteLine($"{this.Nom} est mort.");
            }

            DamageTaken = 0;
            IsParry = false;
        }
    }
}
