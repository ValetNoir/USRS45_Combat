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
            IsParry = true;
        }

        public void TakeDamage(int damage)
        {
            DamageTaken = damage;
            Health -= damage;
            if (Health <= 0)
                IsDead = true;
        }

        public virtual void Special(Character target)
        {
        }

        public void Reset()
        {
            DamageTaken = 0;
            IsParry = false;
        }
    }
}
