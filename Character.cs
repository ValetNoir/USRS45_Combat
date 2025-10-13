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
            Write($"{this.Nom} se défend.");
            IsParry = true;
        }

        public void TakeDamage(int damage)
        {
            DamageTaken += damage;
        }

        public virtual void Special(Character target)
        {
            Write($"{this.Nom} fait son attaque spéciale !");
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
                Write($"{this.Nom} a pris {DamageTaken} dégats.");
            }

            if (Health <= 0)
            {
                IsDead = true;
                Health = 0;
                Write($"{this.Nom} est mort.");
            }
        }

        public static void Write(string message)
        {
            Console.WriteLine(message);
            System.Threading.Thread.Sleep(250);
        }
    }
}
