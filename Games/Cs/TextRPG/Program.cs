using System;
using System.Numerics;

namespace TextRPG
{
    class Program
    {
        static void SaveOrNewGame()
        {
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderpath = myDocuments + @"\TextRPG";

            if (File.Exists(folderpath + @"\save.dat"))
            {
                Console.WriteLine("Do you want to continue your journey?");
                Console.WriteLine("Type (1) to continue or type (2) to create a new character!");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {

                }
                else
                {
                    NewGame();
                }
            }
            else
            {
                NewGame();
            }
        }
        static void SaveGame(string[] Character)
        {
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TextRPG"));
            string folderpath = myDocuments + @"\TextRPG";
            string filename = Path.Combine(folderpath, "save.dat");
            
            File.WriteAllLines(filename, Character);
        }
        static void NewGame()
        {
            Console.WriteLine("Welcome to TextRPG!");


            Player player = new Player();

            Console.WriteLine("Enter your character name:");
            player.Name = Console.ReadLine();
            while (player.Name.Length == 0)
            {
                Console.WriteLine("You can't leave your name blank!");
                Console.WriteLine("Enter your character name:");
                player.Name = Console.ReadLine();
            }

            Console.WriteLine("Choose your character class:\n1. Warrior\n2. Mage\n3. Rogue");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    player.CharacterClass = "Warrior";
                    player.Health = 100;
                    player.Mana = 0;
                    player.Strength = 10;
                    player.Intelligence = 5;
                    player.Agility = 7;
                    player.Gold = 10;
                    break;

                case 2:
                    player.CharacterClass = "Mage";
                    player.Health = 50;
                    player.Mana = 100;
                    player.Strength = 5;
                    player.Intelligence = 10;
                    player.Agility = 5;
                    player.Gold = 10;
                    break;

                case 3:
                    player.CharacterClass = "Rogue";
                    player.Health = 75;
                    player.Mana = 25;
                    player.Strength = 7;
                    player.Intelligence = 5;
                    player.Agility = 10;
                    player.Gold = 10;
                    break;
            }
            
            string[] Character =
            {
                player.Name,
                player.CharacterClass,
                player.Health.ToString(),
                player.Mana.ToString(),
                player.Strength.ToString(),
                player.Intelligence.ToString(),
                player.Agility.ToString(),
                player.Gold.ToString(),
            };

            SaveGame(Character);
            
            Console.WriteLine("Welcome, {0} the {1}!", player.Name, player.CharacterClass);
        }
        static void Main(string[] args)
        {
            SaveOrNewGame();
            

            Console.ReadKey();
        }
    }

    class Player
    {
        public string Name { get; set; }
        public string CharacterClass { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Gold { get; set;  }
    }
}
