using System;
using System.Collections.Generic;
using System.Linq;

namespace USRS45_Combat
{
    class USRS45_Combat
    {
        static void Main(string[] args)
        {
            //test 
            bool finPartie = false;
            string choixAction = "";
            string choixOrdi = "";
            bool choixValide = false;
            bool modeDifficile = false;
            string choixDif = "";


            Console.WriteLine("Le jeu est en mode facile. Voulez-vous jouer en mode difficile (d pour accepter, autre pour refuser)? ");
            choixDif = Console.ReadLine();
            if (choixDif == "d")
            {
                modeDifficile = true;
            }


            while (finPartie == false)
            {
                Console.WriteLine("Quelle Action voulez vous faire");
                Console.WriteLine("Attaquer (a)");
                Console.WriteLine("Defendre (d)");
                Console.WriteLine("Spécial (s)");

                choixValide = false;
                while (!choixValide)
                {
                    choixAction = Console.ReadLine();

                    if (choixAction == "a")
                    {
                        TakeDamage(Joueur.Damage);
                        choixValide = true;
                    }
                    else if (choixAction == "d")
                    {

                        choixValide = true;
                    }
                    else if (choixAction == "s")
                    {

                        choixValide = true;
                    }
                    else
                    {
                        Console.WriteLine("Choix invalide. Essayez encore.");
                    }
                }

                if (!modeDifficile)
                {
                    //ordi en mode random
                    string[] difchoix = { "a", "d", "s" };
                    Random rnd = new Random();
                    int index = rnd.Next(2);
                    choixOrdi = difchoix[index];
                }
                else
                {

                }



            }
        }
    }
}