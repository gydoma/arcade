using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Audio;
using System.Media;
using Microsoft.Xna.Framework.Media;

namespace Quoridor
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public GameWindow _window;

        SpriteFont galleryFont;
        SpriteFont small;

        MouseState _mouseState;

        Texture2D bg;
        Texture2D boardbg;
        Texture2D WhitePiece;
        Texture2D BlackPiece;
        Texture2D FieldLight;
        Texture2D FieldDark;
        Texture2D HorizontalWallMark;
        Texture2D VerticalWallMark;
        Texture2D Valid;
        Texture2D Button;

        SoundEffect MoveSF;
        SoundEffect WallSF;
        SoundEffect ButtonSF;

        Rectangle Start;
        Rectangle Info;
        Rectangle Quit;
        Rectangle Menu;
        Rectangle Desk;

        Board Board;

        Player Black;
        Player White;

        public int windowWidth;
        public int windowHeight;

        public string stage;
        public string WallDir;
        public string turn;
        string winner;

        bool released;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _window = Window;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        bool CheckForWalls(string Dir, int x, int y, int num)
        {
            if (Dir == "Horizontal")
            {
                if(x == 0 && y == 0 || x == 8 && y == 8 || x == 0 && y == 8 || y == 0 && x == 8)
                {
                    if (x == y)
                    {
                        if(y == 0)
                        {
                            if (Board.verticalWalls[y][x] == 0) { return true; }
                            else { return false; }
                        }
                        else
                        {
                            if (Board.verticalWalls[y-1][x-1] == 0) { return true; }
                            else { return false; }
                        }
                    }
                    else
                    {
                        if(y > x)
                        {
                            if (Board.verticalWalls[y - 1][x] == 0) { return true; }
                            else { return false; }
                        }
                        else
                        {
                            if (Board.verticalWalls[y][x - 1] == 0) { return true; }
                            else { return false; }
                        }
                    }
                }
                else if(x == 0 || y == 0 || x == 8 || y == 8)
                {
                    if (y == 0)
                    {
                        if (Board.verticalWalls[y][x] == 0 && num == 1 ) { return true; }
                        else if (Board.verticalWalls[y][x-1] == 0 && num == -1 ) { return true; }
                        else { return false; }
                    }
                    else if (y == 8)
                    {
                        if (Board.verticalWalls[y - 1][x] == 0 && num == 1) { return true; }
                        else if (Board.verticalWalls[y - 1][x - 1] == 0 && num == -1) { return true; }
                        else { return false; }
                    }
                    else if (x == 0)
                    {
                        if (Board.verticalWalls[y][x] == 0 && Board.verticalWalls[y - 1][x] == 0 && num == 1) { return true; }
                        else { return false; }
                    }
                    else if (x == 8)
                    {
                        if (Board.verticalWalls[y][x - 1] == 0 && Board.verticalWalls[y - 1][x - 1] == 0 && num == -1) { return true; } 
                        else { return false; }
                    }
                }
                else
                {
                    if (Board.verticalWalls[y][x] == 0 && Board.verticalWalls[y - 1][x] == 0 && num == 1) { return true; }
                    else if (Board.verticalWalls[y][x - 1] == 0 && Board.verticalWalls[y - 1][x - 1] == 0 && num == -1) { return true; }
                    else { return false; }
                }
            }
            else
            {
                if (x == 0 && y == 0 || x == 8 && y == 8 || x == 0 && y == 8 || y == 0 && x == 8)
                {
                    if (x == y)
                    {
                        if (y == 0)
                        {
                            if (Board.horizontalWalls[y][x] == 0) { return true; }
                            else { return false; }
                        }
                        else
                        {
                            if (Board.horizontalWalls[y - 1][x - 1] == 0) { return true; }
                            else { return false; }
                        }
                    }
                    else
                    {
                        if (y > x)
                        {
                            if (Board.horizontalWalls[y - 1][x] == 0) { return true; }
                            else { return false; }
                        }
                        else
                        {
                            if (Board.horizontalWalls[y][x - 1] == 0) { return true; }
                            else { return false; }
                        }
                    }
                }
                else if (x == 0 || y == 0 || x == 8 || y == 8)
                {
                    if (y == 0)
                    {
                        if (Board.horizontalWalls[y][x] == 0 && Board.horizontalWalls[y][x - 1] == 0 && num == 1) { return true; } 
                        else { return false; }
                    }
                    else if (y == 8)
                    {
                        if (Board.horizontalWalls[y - 1][x] == 0 && Board.horizontalWalls[y - 1][x - 1] == 0 && num == -1) { return true; }
                        else { return false; }
                    }
                    else if (x == 0)
                    {
                        if (Board.horizontalWalls[y][x] == 0 && num == 1) { return true; }
                        else if (Board.horizontalWalls[y - 1][x] == 0 && num == -1) { return true; }
                        else { return false; }
                    }
                    else if (x == 8)
                    {
                        if (Board.horizontalWalls[y][x - 1] == 0 && num == 1) { return true; }
                        else if (Board.horizontalWalls[y - 1][x - 1] == 0 && num == -1) { return true; }
                        else { return false; }
                    }
                }
                else
                {
                    if (Board.horizontalWalls[y][x] == 0 && Board.horizontalWalls[y][x - 1] == 0 && num == 1) { return true; }
                    else if (Board.horizontalWalls[y - 1][x] == 0 && Board.horizontalWalls[y - 1][x - 1] == 0 && num == -1) { return true; }
                    else { return false; }
                }
            }
            return false;
        }

        List<Rectangle> ValidMoves(Player player, Player opp)
        {

            List<Rectangle> Valid = new List<Rectangle>();
            int x = player.boardX;
            int y = player.boardY;
            for (int i = -1; i < 2; i = i + 2)
            {
                if (y + i != -1 && y + i != 9)
                {
                    if ((x, y + i) != (opp.boardX, opp.boardY) && CheckForWalls("Vertical", x, y, i) == true)
                    {
                        Valid.Add(new Rectangle(Board.fields[x][y + i].X, Board.fields[x][y + i].Y, 80, 80));
                    }
                    else if ((x, y + i) == (opp.boardX, opp.boardY) && CheckForWalls("Vertical", x, y + i, i) == true && CheckForWalls("Vertical", x, y, i) == true)
                    {
                        if (y + 2 * i != -1 && y + 2 * i != 9) { Valid.Add(new Rectangle(Board.fields[x][y + i * 2].X, Board.fields[x][y + i * 2].Y, 80, 80)); }
                    }
                    else if ((x, y + i) == (opp.boardX, opp.boardY) && CheckForWalls("Vertical", x, y + i, i) == false)
                    {
                        if (y != 0)
                        {
                            if ((x, y + i) == (opp.boardX, opp.boardY) && CheckForWalls("Horizontal", x, y + i, 1) == true)
                            {
                                Valid.Add(new Rectangle(Board.fields[x + 1][y + i].X, Board.fields[x + 1][y + i].Y, 80, 80));
                            }
                        }
                        if (y != 8)
                        {
                            if ((x, y + i) == (opp.boardX, opp.boardY) && CheckForWalls("Horizontal", x, y + i, -1) == true)
                            {
                                Valid.Add(new Rectangle(Board.fields[x - 1][y + i].X, Board.fields[x - 1][y + i].Y, 80, 80));
                            }
                        }
                    }
                }
                if (x + i != -1 && x + i != 9)
                {
                   if ((x+i,y) != (opp.boardX, opp.boardY) && CheckForWalls("Horizontal", x, y, i) == true)
                   {
                        Valid.Add(new Rectangle(Board.fields[x + i][y].X, Board.fields[x + i][y].Y, 80, 80)); 
                   }
                   else if ((x + i, y) == (opp.boardX, opp.boardY) && CheckForWalls("Horizontal", x + i, y, i) == true && CheckForWalls("Horizontal", x, y, i) == true)
                   {
                        if (x + 2 * i != -1 && x + 2 * i != 9) { Valid.Add(new Rectangle(Board.fields[x + i * 2][y].X, Board.fields[x + i * 2][y].Y, 80, 80)); }
                   }
                   else if ((x + i, y) == (opp.boardX, opp.boardY) && CheckForWalls("Horizontal", x + i, y, i) == false)
                   {
                        if(y != 0)
                        {
                            if((x + i, y) == (opp.boardX, opp.boardY) && CheckForWalls("Vertical", x + i, y, 1) == true)
                            {
                                Valid.Add(new Rectangle(Board.fields[x + i][y + 1].X, Board.fields[x + i][y + 1].Y, 80, 80));
                            }
                        }
                        if(y != 8)
                        {
                            if ((x + i, y) == (opp.boardX, opp.boardY) && CheckForWalls("Vertical", x + i, y, -1) == true)
                            {
                                Valid.Add(new Rectangle(Board.fields[x + i][y - 1].X, Board.fields[x + i][y - 1].Y, 80, 80));
                            }
                        }
                   }
                }
            }
            return Valid;
        }

        void PathFinder(Player player, Player opp, int x, int y)
        {

            Point Player_pos;
            Player_pos.X = x;
            Player_pos.Y = y;
            List<Point> MD = new List<Point>();
            List<Point> Visited = new List<Point>();
            List<List<Rectangle>> Valid = new List<List<Rectangle>>();
            int paths = 0;

            while (true)
            {
                Valid.Add(ValidMoves(player, opp));
                for(int i = Valid.Count - 1; i >= 0; i--)
                {
                    for(int j = 0; j < Valid[i].Count; j = 0)
                    {
                        if (Valid[i].Count > 1) { MD.Add(Player_pos); }
                        Player_pos.X = Valid[i][j].X;
                        Player_pos.Y = Valid[i][j].Y;
                        Valid.Add(ValidMoves(player, opp));

                        

                    }
                }
            }
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            windowHeight = _window.ClientBounds.Height;
            windowWidth = _window.ClientBounds.Width;

            Start = new Rectangle(windowWidth / 2 - 550, windowHeight / 2 - 140, 500, 300);
            Info = new Rectangle(windowWidth / 2  + 50, windowHeight / 2 - 140, 500, 300);
            Quit = new Rectangle(windowWidth / 2 - 250, windowHeight / 2 + 200, 500, 300);
            Menu = new Rectangle((int)Math.Round(windowWidth * 0.95) - 350, (int)Math.Round(windowHeight * 0.95) - 300, 400, 200);
            Desk = new Rectangle(windowWidth / 2 - 500, windowHeight / 2 -450, 1000, 900);

            stage = "Menu";

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            galleryFont = Content.Load<SpriteFont>("ButtonFont");
            small = Content.Load<SpriteFont>("galleryFont");
            bg = Content.Load<Texture2D>("bg");
            BlackPiece = Content.Load<Texture2D>("BlackPiece");
            WhitePiece = Content.Load<Texture2D>("WHitePiece");
            FieldDark = Content.Load<Texture2D>("FieldDark");
            FieldLight = Content.Load<Texture2D>("FieldLight");
            boardbg = Content.Load<Texture2D>("board_bg");
            HorizontalWallMark = Content.Load<Texture2D>("HorizontalWallMark");
            VerticalWallMark = Content.Load<Texture2D>("VerticalWallMark");
            Valid = Content.Load<Texture2D>("ValidR");
            Button = Content.Load<Texture2D>("ButtonBg");
            MoveSF = Content.Load<SoundEffect>("wavMoveSF");
            WallSF = Content.Load<SoundEffect>("wavWallSF");
            ButtonSF = Content.Load<SoundEffect>("wavButtonClickSF2");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            _mouseState = Mouse.GetState(); 
            if(_mouseState.LeftButton == ButtonState.Released)
            {
                released = true;
            }

            if(_mouseState.ScrollWheelValue % 240 == 0)
            {
                WallDir = "Horizontal";
            }
            else
            {
                WallDir = "Vertical";
            }

            if (stage == "Menu")
            {
                if(Start.Contains(_mouseState.Position) && _mouseState.LeftButton == ButtonState.Pressed && released == true) {
                    ButtonSF.Play();
                    stage = "Game"; 
                    released = false;
                    Board = new Board(FieldDark, FieldLight, boardbg, windowWidth, windowHeight);
                    Black = new Player(4, 0, Board.fields[4][0].X, Board.fields[4][0].Y, 80);
                    White = new Player(4, 8, Board.fields[4][8].X, Board.fields[4][8].Y, 80);
                    White.validMoves = ValidMoves(White, Black);
                    turn = "White";
                    
                }
                if (Info.Contains(_mouseState.Position) && _mouseState.LeftButton == ButtonState.Pressed && released == true) { stage = "Info"; released = false; ButtonSF.Play();  }
                if (Quit.Contains(_mouseState.Position) && _mouseState.LeftButton == ButtonState.Pressed && released == true) { ButtonSF.Play(); Exit(); }

            }

            if (stage == "Game")
            {
                if (turn == "White") {
                    foreach (Rectangle rect in White.validMoves)
                    {
                        if (rect.Contains(_mouseState.Position) && _mouseState.LeftButton == ButtonState.Pressed && released == true)
                        {
                            MoveSF.Play();
                            White.playerRectangle.X = rect.X;
                            White.playerRectangle.Y = rect.Y;
                            White.boardX = (rect.X - 20 - Board.boardbgR.X) / (Board.fieldSize + Board.gapSize);
                            White.boardY = (rect.Y - 20 - Board.boardbgR.Y) / (Board.fieldSize + Board.gapSize);
                            Black.validMoves = ValidMoves(Black, White);
                            turn = "Black";
                            released = false;
                        }
                    }
                }

                if (turn == "Black")
                {
                    foreach (Rectangle rect in Black.validMoves)
                    {
                        if (rect.Contains(_mouseState.Position) && _mouseState.LeftButton == ButtonState.Pressed && released == true) 
                        {
                            MoveSF.Play();
                            Black.playerRectangle.X = rect.X;
                            Black.playerRectangle.Y = rect.Y;
                            Black.boardX = (rect.X - 20 - Board.boardbgR.X) / (Board.fieldSize + Board.gapSize);
                            Black.boardY = (rect.Y - 20 - Board.boardbgR.Y) / (Board.fieldSize + Board.gapSize);
                            White.validMoves = ValidMoves(White, Black);
                            turn = "White";
                            released = false;
                        }
                            
                    }
                }
                
                for(int i = 0; i < 8; i++)
                {
                    for(int x = 0; x < 8; x++)
                    {
                        
                        Rectangle w = Board.walls[i][x];
                        if (w.Contains(_mouseState.Position) && _mouseState.LeftButton == ButtonState.Pressed && released == true)
                        {
                            if (turn == "White" && White.walls > 0 || turn == "Black" && Black.walls > 0)
                            {
                                if (WallDir == "Horizontal")
                                {
                                    if (x == 0)
                                    {
                                        if (Board.horizontalWalls[i][x] == 0 && Board.horizontalWalls[i][x + 1] == 0)
                                        {
                                            WallSF.Play();
                                            Board.horizontalWalls[i][x] = 1;
                                            if (turn == "White")
                                            {
                                                White.walls--;
                                                Black.validMoves = ValidMoves(Black, White);
                                                turn = "Black";
                                            }
                                            else
                                            {
                                                Black.walls--;
                                                White.validMoves = ValidMoves(White, Black);
                                                turn = "White";
                                            }
                                        }
                                    }
                                    else if (x == 7)
                                    {
                                        if (Board.horizontalWalls[i][x - 1] == 0 && Board.horizontalWalls[i][x] == 0)
                                        {
                                            WallSF.Play();
                                            Board.horizontalWalls[i][x] = 1;
                                            if (turn == "White")
                                            {
                                                White.walls--;
                                                Black.validMoves = ValidMoves(Black, White);
                                                turn = "Black";
                                            }
                                            else
                                            {
                                                Black.walls--;
                                                White.validMoves = ValidMoves(White, Black);
                                                turn = "White";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Board.horizontalWalls[i][x] == 0 && Board.horizontalWalls[i][x - 1] == 0 && Board.horizontalWalls[i][x + 1] == 0)
                                        {
                                            WallSF.Play();
                                            Board.horizontalWalls[i][x] = 1;
                                            if (turn == "White")
                                            {
                                                White.walls--;
                                                Black.validMoves = ValidMoves(Black, White);
                                                turn = "Black";
                                            }
                                            else
                                            {
                                                Black.walls--;
                                                White.validMoves = ValidMoves(White, Black);
                                                turn = "White";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (i == 0)
                                    {
                                        if (Board.verticalWalls[i][x] == 0 && Board.verticalWalls[i + 1][x] == 0)
                                        {
                                            WallSF.Play();
                                            Board.verticalWalls[i][x] = 1;
                                            if (turn == "White")
                                            {
                                                White.walls--;
                                                Black.validMoves = ValidMoves(Black, White);
                                                turn = "Black";
                                            }
                                            else
                                            {
                                                Black.walls--;
                                                White.validMoves = ValidMoves(White, Black);
                                                turn = "White";
                                            }
                                        }
                                    }

                                    else if (i == 7)
                                    {
                                        if (Board.verticalWalls[i - 1][x] == 0 && Board.verticalWalls[i][x] == 0)
                                        {
                                            WallSF.Play();
                                            Board.verticalWalls[i][x] = 1;
                                            if (turn == "White")
                                            {
                                                White.walls--;
                                                Black.validMoves = ValidMoves(Black, White);
                                                turn = "Black";
                                            }
                                            else
                                            {
                                                Black.walls--;
                                                White.validMoves = ValidMoves(White, Black);
                                                turn = "White";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Board.verticalWalls[i + 1][x] == 0 && Board.verticalWalls[i - 1][x] == 0 && Board.verticalWalls[i][x] == 0)
                                        {
                                            WallSF.Play();
                                            Board.verticalWalls[i][x] = 1;
                                            if (turn == "White")
                                            {
                                                White.walls--;
                                                Black.validMoves = ValidMoves(Black, White);
                                                turn = "Black";
                                            }
                                            else
                                            {
                                                Black.walls--;
                                                White.validMoves = ValidMoves(White, Black);
                                                turn = "White";
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }

                if (White.boardY == 0)
                {
                    winner = "White";
                    stage = "Overview";
                }
                else if (Black.boardY == 8)
                {
                    winner = "Black";
                    stage = "Overview";
                }


            }

            if (stage == "Overview" || stage == "Info" ) { 
                if (Menu.Contains(_mouseState.Position) && _mouseState.LeftButton == ButtonState.Pressed && released == true) {
                    ButtonSF.Play();
                    stage = "Menu";
                    released = false;
                } 
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(bg, new Rectangle(0, 0, 1920, 1080), Color.White);

            if (stage == "Menu") { _spriteBatch.Draw(Button, Start, Color.White); }
            if (stage == "Menu") { _spriteBatch.Draw(Button, Info, Color.White); }
            if (stage == "Menu") { _spriteBatch.Draw(Button, Quit, Color.White); }
            if (stage == "Overview" || stage == "Info") { _spriteBatch.Draw(Button, Menu, Color.White); }
            if (stage == "Overview" && winner == "Black") { _spriteBatch.DrawString(galleryFont, "Black Won!", new Vector2(windowWidth/32, windowHeight/2), Color.Black); }
            if (stage == "Overview" && winner == "White") { _spriteBatch.DrawString(galleryFont, "White Won!", new Vector2(windowWidth / 32, windowHeight / 2), Color.White); }
            if (stage == "Menu") { _spriteBatch.DrawString(galleryFont, "Start", new Vector2(Start.X+Start.Width/2-80, Start.Y+Start.Height/2-40), Color.SaddleBrown); }
            if (stage == "Menu") { _spriteBatch.DrawString(galleryFont, "Info", new Vector2(Info.X + Info.Width / 2 - 80, Info.Y + Info.Height / 2 - 40), Color.SaddleBrown); }
            if (stage == "Menu") { _spriteBatch.DrawString(galleryFont, "Quit", new Vector2(Quit.X + Quit.Width / 2 - 80, Quit.Y + Quit.Height / 2 - 40), Color.SaddleBrown); }
            if (stage == "Overview" || stage == "Info") { _spriteBatch.DrawString(galleryFont, "Menu", new Vector2(Menu.X + Menu.Width / 2 - 100, Menu.Y + Menu.Height / 2 - 40), Color.SaddleBrown); }
            if (stage == "Info") { _spriteBatch.Draw(Button, Desk, Color.White); }


            if (stage == "Game" || stage == "Overview")
            {
                _spriteBatch.Draw(boardbg, Board.boardbgR, Color.White);

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        _spriteBatch.Draw(FieldDark, Board.fields[i][j], Color.White);
                        if (i < 8 && j < 8)
                        {
                            if((turn == "Black" && Black.walls > 0 || turn == "White" && White.walls > 0))
                            {
                                if (WallDir == "Horizontal" && stage == "Game")
                                {
                                    if (j == 0)
                                    {
                                        if (Board.horizontalWalls[i][j] == 0 && Board.horizontalWalls[i][j + 1] == 0)
                                        {
                                            _spriteBatch.Draw(HorizontalWallMark, Board.walls[i][j], Color.White);
                                        }
                                    }
                                    else if (j == 7)
                                    {
                                        if (Board.horizontalWalls[i][j - 1] == 0 && Board.horizontalWalls[i][j] == 0)
                                        {
                                            _spriteBatch.Draw(HorizontalWallMark, Board.walls[i][j], Color.White);
                                        }
                                    }
                                    else
                                    {
                                        if (Board.horizontalWalls[i][j] == 0 && Board.horizontalWalls[i][j - 1] == 0 && Board.horizontalWalls[i][j + 1] == 0)
                                        {
                                            _spriteBatch.Draw(HorizontalWallMark, Board.walls[i][j], Color.White);
                                        }
                                    }
                                }
                                else if (WallDir == "Vertical" && stage == "Game")
                                {
                                    if (i == 0)
                                    {
                                        if (Board.verticalWalls[i][j] == 0 && Board.verticalWalls[i + 1][j] == 0)
                                        {
                                            _spriteBatch.Draw(VerticalWallMark, Board.walls[i][j], Color.White);
                                        }
                                    }
                                    else if (i == 7)
                                    {
                                        if (Board.verticalWalls[i - 1][j] == 0 && Board.verticalWalls[i][j] == 0)
                                        {
                                            _spriteBatch.Draw(VerticalWallMark, Board.walls[i][j], Color.White);
                                        }
                                    }
                                    else
                                    {
                                        if (Board.verticalWalls[i + 1][j] == 0 && Board.verticalWalls[i - 1][j] == 0 && Board.verticalWalls[i][j] == 0)
                                        {
                                            _spriteBatch.Draw(VerticalWallMark, Board.walls[i][j], Color.White);
                                        }
                                    }

                                }
                                
                            }
                            if (Board.horizontalWalls[i][j] == 1)
                            {
                                _spriteBatch.Draw(FieldLight, new Rectangle(Board.walls[i][j].X - Board.fieldSize, Board.walls[i][j].Y + 2, Board.fieldSize * 2 + Board.gapSize, Board.gapSize - 4), Color.White);
                            }
                            else if (Board.verticalWalls[i][j] == 1)
                            {
                                _spriteBatch.Draw(FieldLight, new Rectangle(Board.walls[i][j].X + 2, Board.walls[i][j].Y - Board.fieldSize, Board.gapSize - 4, Board.fieldSize * 2 + Board.gapSize), Color.White);
                            }

                        }
                    }
                }

                if (turn == "White" && stage == "Game")
                {
                    foreach (Rectangle r in White.validMoves)
                    {
                        _spriteBatch.Draw(Valid, r, Color.White);
                    }
                }
                else if (turn == "Black" && stage == "Game")
                {
                    foreach (Rectangle r in Black.validMoves)
                    {
                        _spriteBatch.Draw(Valid, r, Color.White);
                    }
                }

                _spriteBatch.Draw(WhitePiece, White.playerRectangle, Color.White);
                _spriteBatch.Draw(BlackPiece, Black.playerRectangle, Color.White);
            }

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }


    public class Board
    {
        public Rectangle[][] fields = new Rectangle[9][];
        public int[][] horizontalWalls = new int[8][];
        public int[][] verticalWalls = new int[8][];
        public Rectangle[][] walls = new Rectangle[8][];
        public Rectangle boardbgR;
        public Texture2D dark;
        public Texture2D light;
        public Texture2D boardbgT;
        public const int fieldSize = 80;
        public const int gapSize = 20;

        
        public Board(Texture2D _dark, Texture2D _light, Texture2D _boardbgT, int wwidth, int wheight)
        {
            dark = _dark;
            light = _light;
            boardbgT = _boardbgT;
            boardbgR = new Rectangle((wwidth - (9 * fieldSize + 10 * gapSize)) / 2, (wheight-(9 * fieldSize + 10 * gapSize))/2, 9 * fieldSize + 10 * gapSize, 9 * fieldSize + 10 * gapSize);
            for (int i = 0; i < 9; i++)
            {
                
                fields[i] = new Rectangle[9];
                if (i < 8)
                {
                    walls[i] = new Rectangle[8];
                    horizontalWalls[i] = new int[8];
                    verticalWalls[i] = new int[8];
                }
                
                for (int j = 0; j < 9; j++)
                {
                    fields[i][j] = new Rectangle(boardbgR.X + i * (fieldSize + gapSize) + gapSize, boardbgR.Y + j * (fieldSize + gapSize) + gapSize, fieldSize, fieldSize);
                    if (j < 8 && i < 8)
                    {
                        walls[i][j] = new Rectangle(boardbgR.X + (j+1) * (fieldSize + gapSize), boardbgR.Y + (i+1) * (fieldSize + gapSize), gapSize, gapSize);
                        horizontalWalls[i][j] = 0;
                        verticalWalls[i][j] = 0;
                    }

                }
            }

        }
    }
    
    public class Player
    {
        public Rectangle playerRectangle;
        public List<Rectangle> validMoves;
        public int boardX;
        public int boardY;
        public int walls = 10;
        public Player(int _boardX, int _boardY, int posX, int posY, int size)
        {
            boardX = _boardX; 
            boardY = _boardY;
            playerRectangle = new Rectangle(posX, posY, size, size);
        }

    }
}