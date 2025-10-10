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

            while(false) // true
            {
                Console.WriteLine("+------------+");
                Console.WriteLine("| Manche [{0}] |");
                Console.WriteLine("+------------+");
                Console.WriteLine("");
                Console.WriteLine("YOU ({0}) : {1}");
                // pas fini
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