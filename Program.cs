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

        static void Main(string[] args)
        {
            // Welcome header

            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("| Really Fantastic Fighting Game |");
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("");
            Console.WriteLine("Bienvenue dans l'arène !");
            Console.WriteLine("");

            // Player character choice

            Console.WriteLine("Catégories de personnage disponibles :");
            Console.WriteLine("1 - Damager");
            Console.WriteLine("2 - Healer");
            Console.WriteLine("3 - Tank");
            Console.WriteLine("4 - ???");
            Console.WriteLine("Choix :");

            int choice;
            while(true)
            {
                if (int.TryParse(Console.ReadLine(), out choice))
                    if(choice >= 1 || choice <= 4)
                        break;
                Console.WriteLine("Réponse invalide, veuillez réessayer:");
            }
            playerCharacter = createCharacter(choice);

            Console.WriteLine("");
            Console.WriteLine("Tu as choisi de jouer un {0}.", playerCharacter.type);

            // AI character choice

            aiCharacter = createCharacter(random.Next(1, 4));

            Console.WriteLine("Tu vas affronter un {0} joué par une IA.", aiCharacter.type);

            // Main loop

            int mancheCounter = 1;
            while(false) // true
            {
                Console.WriteLine("+------------+");
                Console.WriteLine("| Manche [{0}] |", mancheCounter);
                Console.WriteLine("+------------+");
                Console.WriteLine("");
                Console.WriteLine("[{1}pv] {0} (you)", playerCharacter.type[0], playerCharacter.Health);
                Console.WriteLine("[{1}pv] {0} (IA)", aiCharacter.type[0], aiCharacter.Health);
                Console.WriteLine("");
                Console.WriteLine("Actions possibles :");
                Console.WriteLine("1 - Attaquer");
                Console.WriteLine("2 - Défendre");
                Console.WriteLine("3 - Action spéciale");
                Console.WriteLine("Choix");

                // Code mattéo ici
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
                    return new Custom();
            }
        }
    }
}