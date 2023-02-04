using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace minesweeperclone
{
    class Program
    {
        static void Main(string[] args)
        {
            const int WIDTH = 640;
            const int HEIGHT = 480;
            const string TITLE = "Minesweeper";
            
            VideoMode mode = new VideoMode(WIDTH, HEIGHT);
            RenderWindow window = new RenderWindow(mode, TITLE);
            Game game = new Game();
            
            window.SetVerticalSyncEnabled(true);

            window.Closed += (sender, args) => window.Close();

            window.MouseButtonPressed += (sender, args) => 
            {
                if(args.Button == Mouse.Button.Left)
                {
                    game.LeftClick = true;
                }
                if(args.Button == Mouse.Button.Right)
                {
                    game.RightClick = true;
                } 
            };

            while (window.IsOpen)
            {
                window.DispatchEvents();

                Vector2i mousePos = Mouse.GetPosition((Window)window);
                game.Update(mousePos);

                window.Clear(Color.Blue);

                game.Draw(window);
                
                window.Display();
            }
        }
    }
}
