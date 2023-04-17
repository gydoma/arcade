using System;
using System.Numerics;
using System.Xml.Serialization;

namespace TextRPG
{
    class Program
    {
        static Player? player;
        static void SaveOrNewGame()
        {
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderpath = myDocuments + @"\TextRPG";

            if (File.Exists(folderpath + @"\save.dat"))
            {
                int choice;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Do you want to continue your journey?");
                    Console.WriteLine("Type (1) to continue or type (2) to create a new character!");
                    choice = Convert.ToInt32(Console.ReadLine());
                } while (choice != 1 && choice != 2);
                if (choice == 1)
                {
                    string[] beolvasas = File.ReadAllLines(folderpath + @"\save.dat");
                    player = new Player(beolvasas);
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

            string[] Character =
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            };


            Console.WriteLine("Enter your character name:");
            Character[0] = Console.ReadLine()!;
            while (Character[0].Length == 0)
            {
                Console.WriteLine("You can't leave your name blank!");
                Console.WriteLine("Enter your character name:");
                Character[0] = Console.ReadLine()!;
            }

            Console.WriteLine("Choose your character class:\n1. Warrior\n2. Mage\n3. Rogue");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Character[1] = "Warrior";
                    Character[2] = "100";
                    Character[3] = "0";
                    Character[4] = "10";
                    Character[5] = "5";
                    Character[6] = "7";
                    Character[7] = "10";
                    break;

                case 2:
                    Character[1] = "Mage";
                    Character[2] = "50";
                    Character[3] = "100";
                    Character[4] = "5";
                    Character[5] = "10";
                    Character[6] = "5";
                    Character[7] = "10";
                    break;

                case 3:
                    Character[1] = "Rogue";
                    Character[2] = "75";
                    Character[3] = "25";
                    Character[4] = "7";
                    Character[5] = "5";
                    Character[6] = "10";
                    Character[7] = "10";
                    break;
            }
            
            

            SaveGame(Character);

            player = new Player(Character);
            
            Console.WriteLine("Welcome, {0} the {1}!", Character[0], Character[1]);
        }
        static void Main(string[] args)
        {
            SaveOrNewGame();
            

            Console.ReadKey();
        }
    }

    class Player
    {
        public string? Name { get; set; }
        public string? CharacterClass { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Gold { get; set;  }

        public Player(string[] line)
        {
            
            this.Name = line[0]; 
            this.CharacterClass = line[1];
            this.Health = int.Parse(line[2]);
            this.Mana = int.Parse(line[3]);
            this.Strength = int.Parse(line[4]);
            this.Intelligence = int.Parse(line[5]);
            this.Agility = int.Parse(line[6]);
            this.Gold = int.Parse(line[7]);
        }
    }
}
