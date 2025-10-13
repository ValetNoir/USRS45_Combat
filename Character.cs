using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine($"{this.Nom} is parrying.");
            IsParry = true;
        }

        public void TakeDamage(int damage)
        {
            DamageTaken += damage;
            Health -= damage;
            Console.WriteLine($"{this.Nom} took {damage} damages.");
            if (Health <= 0)
            {
                IsDead = true;
                Health = 0;
                Console.WriteLine($"{this.Nom} is dead.");
            }
        }

        public virtual void Special(Character target)
        {
            Console.WriteLine($"{this.Nom} is doing his special attack!");
        }

        public void Reset()
        {
            DamageTaken = 0;
            IsParry = false;
        }
    }
}
