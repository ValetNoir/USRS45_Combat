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
        static string[] possibleChoices = { "d", "a", "s" };

        static void Main(string[] args)
        {
            // Welcome header

            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("| Really Fantastic Fighting Game |");
            WriteLineWithDelay("+--------------------------------+");
            WriteLineWithDelay("");
            WriteLineWithDelay("Bienvenue dans l'arène !");
            WriteLineWithDelay("");

            // Difficulty choice

            bool endGame = false;
            bool hardMode = false;


            WriteLineWithDelay("Voulez-vous jouer en mode difficile ('o' pour accepter, autre pour refuser)?");
            if (Console.ReadLine() == "o")
            {
                WriteLineWithDelay("Mode difficile activé.");
                hardMode = true;
            }
            else
            {
                WriteLineWithDelay("Mode facile activé.");
            }

            WriteLineWithDelay("");

            // Player character choice

            WriteLineWithDelay("Catégories de personnage disponibles :");
            WriteLineWithDelay("1 - Damager");
            WriteLineWithDelay("2 - Healer");
            WriteLineWithDelay("3 - Tank");
            WriteLineWithDelay("4 - Vampire");
            Console.Write("Choix : ");

            int playerCharacterChoice;
            while(true)
            {
                if (int.TryParse(Console.ReadLine(), out playerCharacterChoice))
                    if(playerCharacterChoice >= 1 && playerCharacterChoice <= 4)
                        break;
                WriteLineWithDelay("Réponse invalide, veuillez réessayer:");
            }
            playerCharacter = createCharacter(playerCharacterChoice);

            WriteLineWithDelay("");

            WriteLineWithDelay($"Tu as choisi de jouer un {playerCharacter.Name}.");

            // AI character choice

            aiCharacter = createCharacter(random.Next(1, 5));

            WriteLineWithDelay($"Tu vas affronter un {aiCharacter.Name} joué par une IA.");
            
            WriteLineWithDelay("");

            // Main loop

            int roundCounter = 1;
            while(!playerCharacter.IsDead && !aiCharacter.IsDead)
            {
                Console.WriteLine("+------------+");
                Console.WriteLine($"| Manche [{roundCounter}] |");
                WriteLineWithDelay("+------------+");

                WriteLineWithDelay("");

                WriteLineWithDelay($"[{playerCharacter.Health}pv] {playerCharacter.Name[0]} (you)");
                WriteLineWithDelay($"[{aiCharacter.Health}pv] {aiCharacter.Name[0]} (IA)");

                WriteLineWithDelay("");

                WriteLineWithDelay("Quelle action voulez vous faire ?");
                WriteLineWithDelay("Attaquer (a)");
                WriteLineWithDelay("Defendre (d)");
                WriteLineWithDelay("Spécial (s)");
                Console.Write("Choix : ");


                // Player choice

                string playerActionChoice = "";
                while (true)
                {
                    playerActionChoice = Console.ReadLine();

                    if (possibleChoices.Contains(playerActionChoice))
                        break;
                    WriteLineWithDelay("Choix invalide. Essayez encore.");
                }

                WriteLineWithDelay("");

                // AI choice

                string aiActionChoice;
                if (!hardMode) // random
                {
                    int index = random.Next(0, 3);
                    aiActionChoice = possibleChoices[index];
                }
                else // random (-defense)
                {
                    int index = random.Next(1, 3);
                    aiActionChoice = possibleChoices[index];
                }

                WriteLineWithDelay($"L'IA a choisi : {aiActionChoice}.");
                WriteLineWithDelay("");

                // Action resolution
                // Order : defense -> attack -> special

                if (aiActionChoice == "d")
                    aiCharacter.Parry();
                if (playerActionChoice == "d")
                    playerCharacter.Parry();

                if (aiActionChoice == "a")
                    playerCharacter.TakeDamage(aiCharacter.Damage);
                if (playerActionChoice == "a")
                    aiCharacter.TakeDamage(playerCharacter.Damage);

                // Specials handling

                if (aiActionChoice == "s" && !(aiCharacter is Damager) )
                    aiCharacter.Special(playerCharacter);
                if (playerActionChoice == "s" && !(playerCharacter is Damager))
                    playerCharacter.Special(aiCharacter);

                // Damager go last
                if (aiActionChoice == "s" && aiCharacter is Damager)
                    aiCharacter.Special(playerCharacter);
                if (playerActionChoice == "s" && playerCharacter is Damager)
                    playerCharacter.Special(aiCharacter);

                // End of turn

                aiCharacter.EndOfTurn();
                playerCharacter.EndOfTurn();

                aiCharacter.Reset();
                playerCharacter.Reset();

                WriteLineWithDelay("");

                System.Threading.Thread.Sleep(500);
            }

            WriteLineWithDelay($"[{playerCharacter.Health}pv] {playerCharacter.Name[0]} (you)");
            WriteLineWithDelay($"[{aiCharacter.Health}pv] {aiCharacter.Name[0]} (IA)");

            if (playerCharacter.IsDead && aiCharacter.IsDead)
                WriteLineWithDelay("Les deux adversaires se sont tués en même temps ! Égalité.");
            else if (playerCharacter.IsDead)
                WriteLineWithDelay("Vous avez perdu...");
            else if (aiCharacter.IsDead)
                WriteLineWithDelay("Vous avez gagné !!!!");

            Console.ReadLine(); // Stop window from closing
        }

        public static void WriteLineWithDelay(string message)
        {
            Console.WriteLine(message);
            System.Threading.Thread.Sleep(200);
        }

        static Character createCharacter(int type)
        {
            // Could be an enum
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
                    Console.WriteLine("Program.cs (createCharacter): default shouldn't be reached");
                    return new Tank();
            }
        }
    }
}