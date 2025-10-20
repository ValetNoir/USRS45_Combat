using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace USRS45_Combat
{
    class USRS45_Combat
    {
        static Character playerCharacter;
        static Character aiCharacter;
        static Random random = new Random();
        static string[] choixPossibles = { "d", "a", "s" };

        static void Main(string[] args)
        {
            // Welcome header

            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("| Really Fantastic Fighting Game |");
            Write("+--------------------------------+");
            Write("");
            Write("Bienvenue dans l'arène !");
            Write("");

            // Difficulty choice

            bool finPartie = false;
            bool modeDifficile = false;
            string choixDif = "";


            Write("Voulez-vous jouer en mode difficile ('o' pour accepter, autre pour refuser)?");
            choixDif = Console.ReadLine();
            if (choixDif == "o")
            {
                Write("Mode difficile activé.");
                modeDifficile = true;
            }
            else
            {
                Write("Mode facile activé.");
            }

            Write("");

            // Player character choice

            Write("Catégories de personnage disponibles :");
            Write("1 - Damager");
            Write("2 - Healer");
            Write("3 - Tank");
            Write("4 - Vampire");
            Console.Write("Choix : ");

            int choice;
            while(true)
            {
                if (int.TryParse(Console.ReadLine(), out choice))
                    if(choice >= 1 && choice <= 4)
                        break;
                Write("Réponse invalide, veuillez réessayer:");
            }
            playerCharacter = createCharacter(choice);

            Write("");

            Write($"Tu as choisi de jouer un {playerCharacter.Nom}.");

            // AI character choice

            aiCharacter = createCharacter(random.Next(1, 5));

            Write($"Tu vas affronter un {aiCharacter.Nom} joué par une IA.");
            
            Write("");

            // Main loop

            int mancheCounter = 1;
            while(!playerCharacter.IsDead && !aiCharacter.IsDead)
            {
                Console.WriteLine("+------------+");
                Console.WriteLine($"| Manche [{mancheCounter}] |");
                Write("+------------+");

                Write("");

                Write($"[{playerCharacter.Health}pv] {playerCharacter.Nom[0]} (you)");
                Write($"[{aiCharacter.Health}pv] {aiCharacter.Nom[0]} (IA)");

                Write("");

                Write("Quelle action voulez vous faire ?");
                Write("Attaquer (a)");
                Write("Defendre (d)");
                Write("Spécial (s)");
                Console.Write("Choix : ");


                // Player choice

                string choixActionJoueur = "";
                while (true)
                {
                    choixActionJoueur = Console.ReadLine();

                    if (choixPossibles.Contains(choixActionJoueur))
                        break;
                    Write("Choix invalide. Essayez encore.");
                }

                Write("");

                // AI choice

                string choixActionOrdi;
                if (!modeDifficile) //ordi en mode random
                {
                    int index = random.Next(0, 3);
                    choixActionOrdi = choixPossibles[index];
                }
                else // ordi offensif
                {
                    int index = random.Next(1, 3);
                    choixActionOrdi = choixPossibles[index];
                }

                Write($"L'IA a choisi : {choixActionOrdi}.");
                Write("");

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

                if (choixActionOrdi == "s" && !(aiCharacter is Damager) )
                    aiCharacter.Special(playerCharacter);
                if (choixActionJoueur == "s" && !(playerCharacter is Damager))
                    playerCharacter.Special(aiCharacter);

                // Damager go last
                if (choixActionOrdi == "s" && aiCharacter is Damager)
                    aiCharacter.Special(playerCharacter);
                if (choixActionJoueur == "s" && playerCharacter is Damager)
                    playerCharacter.Special(aiCharacter);

                // Fin de tour

                aiCharacter.EndOfTurn();
                playerCharacter.EndOfTurn();

                aiCharacter.Reset();
                playerCharacter.Reset();

                Write("");

                System.Threading.Thread.Sleep(500);
            }

            Write($"[{playerCharacter.Health}pv] {playerCharacter.Nom[0]} (you)");
            Write($"[{aiCharacter.Health}pv] {aiCharacter.Nom[0]} (IA)");

            if (playerCharacter.IsDead && aiCharacter.IsDead)
                Write("Les deux adversaires se sont tués en même temps ! Égalité.");
            else if (playerCharacter.IsDead)
                Write("Vous avez perdu...");
            else if (aiCharacter.IsDead)
                Write("Vous avez gagné !!!!");

            Console.ReadLine(); // Empêche le terminal de se fermer
        }

        public static void Write(string message)
        {
            Console.WriteLine(message);
            System.Threading.Thread.Sleep(100);
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
                    return new Vampire();
                default:
                    return new Tank();
            }
        }
    }
}