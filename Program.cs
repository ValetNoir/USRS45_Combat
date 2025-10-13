using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USRS45_Combat
{
    class USRS45_Combat
    {
        static Character playerCharacter;
        static Character aiCharacter;
        static Random random = new Random();
        static string[] choixPossibles = { "a", "d", "s" };

        static void Main(string[] args)
        {
            // Welcome header

            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("| Really Fantastic Fighting Game |");
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("");
            Console.WriteLine("Bienvenue dans l'arène !");
            Console.WriteLine("");

            // Difficulty choice

            bool finPartie = false;
            bool modeDifficile = false;
            string choixDif = "";


            Console.WriteLine("Voulez-vous jouer en mode difficile ('o' pour accepter, autre pour refuser)?");
            choixDif = Console.ReadLine();
            if (choixDif == "o")
            {
                Console.WriteLine("Mode difficile activé.");
                modeDifficile = true;
            }
            else
            {
                Console.WriteLine("Mode facile activé.");
            }

            // Player character choice

            Console.WriteLine("Catégories de personnage disponibles :");
            Console.WriteLine("1 - Damager");
            Console.WriteLine("2 - Healer");
            Console.WriteLine("3 - Tank");
            Console.WriteLine("4 - ???");
            Console.Write("Choix : ");

            int choice;
            while(true)
            {
                if (int.TryParse(Console.ReadLine(), out choice))
                    if(choice >= 1 && choice <= 4)
                        break;
                Console.WriteLine("Réponse invalide, veuillez réessayer:");
            }
            playerCharacter = createCharacter(choice);

            Console.WriteLine("");
            Console.WriteLine("Tu as choisi de jouer un {0}.", playerCharacter.Nom);

            // AI character choice

            //aiCharacter = createCharacter(random.Next(1, 4));
            aiCharacter = createCharacter(3);

            Console.WriteLine("Tu vas affronter un {0} joué par une IA.", aiCharacter.Nom);

            // Main loop

            int mancheCounter = 1;
            while(!playerCharacter.IsDead && !aiCharacter.IsDead)
            {
                Console.WriteLine("+------------+");
                Console.WriteLine("| Manche [{0}] |", mancheCounter);
                Console.WriteLine("+------------+");

                Console.WriteLine("");

                Console.WriteLine("[{1}pv] {0} (you)", playerCharacter.Nom[0], playerCharacter.Health);
                Console.WriteLine("[{1}pv] {0} (IA)", aiCharacter.Nom[0], aiCharacter.Health);

                Console.WriteLine("");

                Console.WriteLine("Quelle action voulez vous faire ?");
                Console.WriteLine("Attaquer (a)");
                Console.WriteLine("Defendre (d)");
                Console.WriteLine("Spécial (s)");
                Console.Write("Choix : ");


                // Player choice

                string choixActionJoueur = "";
                while (true)
                {
                    choixActionJoueur = Console.ReadLine();

                    if (choixPossibles.Contains(choixActionJoueur))
                        break;
                    Console.WriteLine("Choix invalide. Essayez encore.");
                }

                Console.WriteLine("");

                // AI choice

                string choixActionOrdi = "";

                if (!modeDifficile) //ordi en mode random
                {
                    int index = random.Next(2);
                    choixActionOrdi = choixPossibles[index];
                }
                else
                {
                    choixActionOrdi = "s";
                }

                Console.WriteLine($"L'IA a choisi : {choixActionOrdi}.");
                Console.WriteLine("");

                // Action resolution
                // Order : défense -> attaque -> spécial

                if (choixActionOrdi == "d")
                    aiCharacter.Parry();
                if (choixActionJoueur == "d")
                    playerCharacter.Parry();

                if (choixActionOrdi == "a")
                    playerCharacter.TakeDamage(aiCharacter.Damage);
                if (choixActionJoueur == "a")
                    aiCharacter.TakeDamage(playerCharacter.Damage);

                // Gestion des spécials

                // All damages first, for the damager special
                if (choixActionOrdi == "s" && aiCharacter is Tank)
                    aiCharacter.Special(playerCharacter);
                if (choixActionJoueur == "s" && playerCharacter is Tank)
                    playerCharacter.Special(aiCharacter);

                if (choixActionOrdi == "s" && !(aiCharacter is Tank) )
                    aiCharacter.Special(playerCharacter);
                if (choixActionJoueur == "s" && !(playerCharacter is Tank))
                    playerCharacter.Special(aiCharacter);

                // Fin de tour

                aiCharacter.EndOfTurn();
                playerCharacter.EndOfTurn();
            }


        }

        static Character createCharacter(int type)
        {
            switch (type)
            {
                case 1:
                    return new Damager();
                case 2:
                    return new Healer();
                case 3:
                    return new Tank();
                case 4:
                    return new Tank();
                    // return new Custom();
                default:
                    return new Tank();
            }
        }
    }
}