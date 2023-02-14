using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace FlappyBird
{
    

    public class Game1 : Game
    {
        private GameWindow _window;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Random rnd = new Random();

        Point mousePos;

        SpriteFont gameFont;

        Texture2D bg;
        Texture2D topPillar;
        Texture2D bottomPillar;
        Texture2D warning;
        Texture2D start;
        Texture2D[] bird = new Texture2D[2];
        Texture2D[] lightning = new Texture2D[3];
        Texture2D Quit;
        Texture2D GameOver;

        SoundEffect JumpSF;
        SoundEffect GameOverSF;
        SoundEffect ButtonSF;
       
        Rectangle birdRectangle;
        Rectangle StartButton;
        Rectangle QuitButton;
        Rectangle[] lightnings = new Rectangle[3];
        Rectangle[] warnings = new Rectangle[3];

        string stage = "Menu";

        int state = 0;
        int lstate = 0;
        int score;
        int highscore = 0;
        int f;
        int s;

        float Ocounter = 0f;
        float Bcounter = 0f;
        float TitleCounter = 0f;
        float obs;
        float beams;
        float speed;
        float rt;
        
        double grav = 1;

        bool lArrow = false;
        bool rArrow = false;
        bool Space = false;
        bool lvlup = false;
        bool wrning = false;

        List<Gates> obstacles = new List<Gates>();


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _window = Window;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        void Setup()
        {
            grav = 1;
            Ocounter = 3;
            obs = 3f;
            speed = 300f;
            beams = 10f;
            rt = 2;
            IsMouseVisible = false;
            stage = "Running";
        }

        void Running(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Space == false)
            {
                JumpSF.Play();
                grav = -7.5;
                state = 1;
                Space = true;
            }

            birdRectangle.Y = birdRectangle.Y + ((int)grav);
            grav = grav + 0.225;

            if (grav > 0) { state = 0; }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && birdRectangle.X > 150 && lArrow == false)
            {
                birdRectangle.X = birdRectangle.X - 150;
                lArrow = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && birdRectangle.X < 450 && rArrow == false)
            {
                birdRectangle.X = birdRectangle.X + 150;
                rArrow = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Left)) { lArrow = false; }
            if (Keyboard.GetState().IsKeyUp(Keys.Right)) { rArrow = false; }
            if (Keyboard.GetState().IsKeyUp(Keys.Space)) { Space = false; }

            Ocounter = Ocounter + (float)gameTime.ElapsedGameTime.TotalSeconds;
            Bcounter = Bcounter + (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Ocounter > obs)
            {
                Ocounter = Ocounter - obs;
                Gates gate = new Gates();
                obstacles.Add(gate);
            }

            if (Bcounter > beams && wrning == false)
            {
                f = rnd.Next(0, 2);
                s = rnd.Next(1, 3);
                if (f == s) { f = 0; }
                warnings[f].Y = 700;
                warnings[s].Y = 700;
                wrning = true;
            }

            if (Bcounter > beams + rt)
            {
                lightnings[f].Y = 200;
                lightnings[s].Y = 200;
            }

            if (Bcounter > beams + rt + 1)
            {
                Bcounter = Bcounter - beams;
                lightnings[f].Y = 3000;
                lightnings[s].Y = 3000;
                warnings[f].Y = 3000;
                warnings[s].Y = 3000;
                wrning = false;
            }

            for (int i = 0; i < obstacles.Count; i++)
            {
                Gates obstacle = obstacles[i];
                obstacle.topP.X -= (int)(speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                obstacle.BottomP.X -= (int)(speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

                if (birdRectangle.Intersects(obstacle.topP) || birdRectangle.Intersects(obstacle.BottomP) || birdRectangle.Y > 1080 || birdRectangle.Intersects(lightnings[0]) || birdRectangle.Intersects(lightnings[1]) || birdRectangle.Intersects(lightnings[2])) 
                {
                    
                    stage = "Over";
                    GameOverSF.Play();
                }

                if (obstacle.topP.X < birdRectangle.X && obstacle.point == true) 
                { 
                    score++;
                    obstacle.point = false;
                }
            }
            
            if (score % 10 == 0 && lvlup == false)
            {
                obs = obs - 0.25f;
                speed = speed + 25;
                lvlup = true;
                beams = beams - 0.5f;
                if (rt > 0.25f) { rt = rt - 0.25f;  }
            }

            if (score % 10 != 0)
            {
                lvlup = false;
            }

            if (lstate == 2) { lstate = 0; }
            else { lstate++;  }
        }



        void Over(GameTime gameTime)
        {

            TitleCounter = TitleCounter + (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (TitleCounter > 2)
            {
                if (score > highscore) { highscore = score; }
                birdRectangle.Y = 150;
                birdRectangle.X = 300;
                lightnings[0].Y = 3000;
                lightnings[1].Y = 3000;
                lightnings[2].Y = 3000;
                warnings[0].Y = 3000;
                warnings[1].Y = 3000;
                warnings[2].Y = 3000;
                IsMouseVisible = true;
                stage = "Menu";
                obstacles.Clear();
                Bcounter = 0;
                TitleCounter = 0;
                score = 0;
            }
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            StartButton = new Rectangle(_graphics.PreferredBackBufferWidth/2 - 250, _graphics.PreferredBackBufferHeight / 12 * 2, 500, 300);
            QuitButton = new Rectangle(_graphics.PreferredBackBufferWidth / 2 -  250, _graphics.PreferredBackBufferHeight / 12 * 6, 500, 300);
            birdRectangle = new Rectangle(300, 150, 112, 74);
            lightnings[0] = new Rectangle(150, 3000, 100, 800);
            lightnings[1] = new Rectangle(300, 3000, 100, 800);
            lightnings[2] = new Rectangle(450, 3000, 100, 800);
            warnings[0] = new Rectangle(150, 3000, 100, 100);
            warnings[1] = new Rectangle(300, 3000, 100, 100);
            warnings[2] = new Rectangle(450, 3000, 100, 100);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gameFont = Content.Load<SpriteFont>("galleryFont");
            bird[0] = Content.Load<Texture2D>("BirdBase-removebg-preview");
            bird[1] = Content.Load<Texture2D>("BirdFly-removebg-preview");
            topPillar = Content.Load<Texture2D>("Top-Pillar-B");
            bottomPillar = Content.Load<Texture2D>("Bottom-Pillar-B");
            warning = Content.Load<Texture2D>("Warning-removebg-preview");
            start = Content.Load<Texture2D>("Start5");
            bg = Content.Load<Texture2D>("bg1920x1080");
            lightning[0] = Content.Load<Texture2D>("lightning_1-removebg-preview");
            lightning[1] = Content.Load<Texture2D>("lightning_2-removebg-preview");
            lightning[2] = Content.Load<Texture2D>("lightning_3-removebg-preview");
            Quit = Content.Load<Texture2D>("Quit");
            GameOver = Content.Load<Texture2D>("GameOver-removebg-preview");
            JumpSF = Content.Load<SoundEffect>("wavJumpSF");
            ButtonSF = Content.Load<SoundEffect>("wavButtonClickSF2");
            GameOverSF = Content.Load<SoundEffect>("wavGameOverSF");

        }

        protected override void Update(GameTime gameTime)
        {
            mousePos = Mouse.GetState().Position;

            if (stage == "Menu")
            {
                if (StartButton.Contains(mousePos) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    ButtonSF.Play();
                    Setup();
                    IsMouseVisible = false;
                }
                if (QuitButton.Contains(mousePos) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    ButtonSF.Play();
                    Exit();
                }
            }
            if(stage == "Running")
            {
                
                Running(gameTime);
            }
            if(stage == "Over")
            {
                
                Over(gameTime);
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(bg, new Vector2(0, 0), Color.White);
            if (stage == "Menu") { _spriteBatch.Draw(start, StartButton, Color.White); }
            if (stage == "Menu") { _spriteBatch.Draw(Quit, QuitButton, Color.White); }
            if (stage == "Menu") { _spriteBatch.DrawString(gameFont, "Highscore: " + highscore.ToString(), new Vector2(_window.ClientBounds.Width / 2 - 100, 900), Color.Black); }
            if (stage == "Over") { _spriteBatch.Draw(GameOver, new Rectangle(_window.ClientBounds.Width / 2 - 1450 / 2, _window.ClientBounds.Height / 2 - 300 / 2, 1450, 300), Color.White);  }
            if (stage == "Running") 
            {
                foreach (Gates obs in obstacles)
                {
                    _spriteBatch.Draw(topPillar, obs.topP, Color.White);
                    _spriteBatch.Draw(bottomPillar, obs.BottomP, Color.White);

                }
            }

            if (stage == "Running") { _spriteBatch.Draw(bird[state], birdRectangle, Color.White); }
            if (stage == "Running") { _spriteBatch.DrawString(gameFont, score.ToString(), new Vector2(_window.ClientBounds.Width / 2, _window.ClientBounds.Width / 12 - 10), Color.White); }
            if (stage == "Running") { _spriteBatch.Draw(lightning[lstate], lightnings[0], Color.White); }
            if (stage == "Running") { _spriteBatch.Draw(lightning[lstate], lightnings[1], Color.White); }
            if (stage == "Running") { _spriteBatch.Draw(lightning[lstate], lightnings[2], Color.White); }
            if (stage == "Running") { _spriteBatch.Draw(warning, warnings[0], Color.White); }
            if (stage == "Running") { _spriteBatch.Draw(warning, warnings[1], Color.White); }
            if (stage == "Running") { _spriteBatch.Draw(warning, warnings[2], Color.White); }

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }

    public class Gates
    {
        Random rnd = new Random();
        public Rectangle topP;
        public Rectangle BottomP;
        public bool point;

        public Gates()
        {
            int y = rnd.Next(100, 701) * -1;
            int gap = rnd.Next(200, 301);

            topP = new Rectangle(2000, y, 240, 800);
            BottomP = new Rectangle(2000, y+800+gap, 240, 800);
            point = true;
        }
    }
}