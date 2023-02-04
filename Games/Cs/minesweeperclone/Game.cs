using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections;

namespace minesweeperclone
{
    class Box
    {
        public Vector2f position;
        public bool isOpened;
        public bool isMine;
        public int mineCount;
        public bool isMarked;

        // ui
        public RectangleShape uiBox;
        Texture texture;
        public int type;
        public IntRect rect;

        
        public Box(Vector2f position, bool isMine, Texture texture)
        {
            this.position = position;
            this.isMine = isMine;

            this.uiBox = new RectangleShape(new Vector2f(16, 16));
            this.uiBox.Texture = texture;
            this.uiBox.Position = this.position;
            this.uiBox.TextureRect = new IntRect(type,0,10,10);

            this.rect = new IntRect(160 + (int)this.position.X, 80 + (int)this.position.Y, 16, 16);


        }
    }

    class Game
    {
        Sprite board;
        Texture texture;

        Dictionary<Vector2f, Box> boxes;

        RenderTexture renderTexture = new RenderTexture(320, 320);

        public bool LeftClick {get; set;}
        public bool RightClick {get; set;}

        public bool NotFirst {get; set;}
        public bool EnabledClick {get; set;}

        int flagCounter = 0;
        int LIMIT_FLAGS = 80;
        
        Sprite gameOver;
        Sprite youWon;

        bool isWon;
        bool isLose;

        public Game()
        {
            board = new Sprite(renderTexture.Texture);
            board.Position = new Vector2f(640/2 - 320/2, 480/2 - 320/2);

            texture = new Texture("Assets/tileset.png");

            boxes = new Dictionary<Vector2f, Box>();

            EnabledClick = true;

            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    boxes[new Vector2f(x, y)] = new Box(new Vector2f(x * 16, y * 16), false, texture);
                }
            }

            gameOver = new Sprite(new Texture("Assets/game-over.png"));
            youWon = new Sprite(new Texture("Assets/you-won.png"));

            gameOver.Position = new Vector2f(0, 160 - 25);
            youWon.Position = new Vector2f(0, 160 - 25);
        }

        public void GenerateMines()
        {   
            int limit = 0;
            int rowLimit = 0;
            Random random = new Random();

            for (int y = 0; y < 20; y++)
            {
                rowLimit = 0;
                for (int x = 0; x < 20; x++)
                {
                    if(!boxes[new Vector2f(x, y)].isOpened && rowLimit < 4 && !boxes[new Vector2f(x, y)].isMine && limit < 60)
                    {
                        if(random.Next(0,8) >= 6)
                        {
                            rowLimit++;
                            limit++;
                            boxes[new Vector2f(x, y)].isMine = true;
                            boxes[new Vector2f(x, y)].type = 0;
                            // boxes[new Vector2f(x, y)].uiBox.TextureRect = new IntRect(boxes[new Vector2f(x, y)].type * 10, 0, 10, 10);
                        }
                    }
                }
            }
        }

        public void CalculateNumbers()
        {
            Vector2f[] offset = 
            {
                new Vector2f(-1, -1),
                new Vector2f(0, -1),
                new Vector2f(1, -1),
                new Vector2f(-1, 0),
                new Vector2f(1, 0),
                new Vector2f(-1, 1),
                new Vector2f(0, 1),
                new Vector2f(1, 1)
            };
            int mineCounter = 0;

            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    mineCounter = 0;

                    if(!boxes[new Vector2f(x, y)].isMine)
                    {
                        int i = 0;
                        while(i < 8)
                        {
                            if(boxes.ContainsKey(new Vector2f(x + offset[i].X, y + offset[i].Y)))
                            {
                                if(boxes[new Vector2f(x + offset[i].X, y + offset[i].Y)].isMine)
                                {
                                    mineCounter++;
                                }
                            }
                            i++;
                            // boxes[new Vector2f(x, y)].uiBox.TextureRect = new IntRect(boxes[new Vector2f(x, y)].type * 10, 0, 10, 10);
                        }
                        if(mineCounter == 0)
                        {
                            boxes[new Vector2f(x, y)].type = 9;
                        }
                        else
                        {
                            boxes[new Vector2f(x, y)].type = mineCounter;
                        }
                    }
                }
            }
        }

        private void showOthers(Vector2i tilePos)
        {
            if(tilePos.X >= 0 && tilePos.X < 20 && tilePos.Y >= 0 && tilePos.Y < 20)
            {
                
                Queue<Vector2i> queue = new Queue<Vector2i>();
                
                Dictionary<Vector2i, bool> registry = new Dictionary<Vector2i, bool>();

                // 2
                queue.Enqueue(tilePos);
                
                registry[new Vector2i(tilePos.X, tilePos.Y)] = true;

                List<int[]> dirs = new List<int[]>()
                {
                    new int[] {1, 0},
                    new int[] {-1, 0},
                    new int[] {0, 1},
                    new int[] {0, -1},
                    new int[] {1,1},
                    new int[] {1,-1},
                    new int[] {-1,1},
                    new int[] {-1,-1}
                };
                
                while(queue.Count != 0)
                {
                    Vector2i currentTile = queue.Dequeue();

                    foreach (var dir in dirs)
                    {
                        int xx = currentTile.X + dir[0];
                        int yy = currentTile.Y + dir[1];

                        if(registry.ContainsKey(new Vector2i(xx, yy)))
                        {
                            continue;
                        }
                        if(xx >= 0 && xx < 20 && yy >= 0 && yy < 20)
                        {
                            if(
                                !boxes[new Vector2f(xx, yy)].isOpened && boxes[new Vector2f(xx, yy)].type >= 1 && 
                                boxes[new Vector2f(xx, yy)].type < 10 && !boxes[new Vector2f(xx, yy)].isMine
                            )
                            {   
                                boxes[new Vector2f(xx, yy)].uiBox.TextureRect = new IntRect(boxes[new Vector2f(xx, yy)].type * 10, 0, 10, 10);
                                boxes[new Vector2f(xx, yy)].isOpened = true;
                                registry[new Vector2i(xx, yy)] = true;
                            }
                        }
                        if(xx < 0 || xx >= 20 || yy < 0 || yy >= 20)
                        {
                            continue;
                        }
                        
                        registry[new Vector2i(xx, yy)] = true;

                        if(boxes[new Vector2f(xx, yy)].type == 9)
                            queue.Enqueue(new Vector2i(xx, yy));
                    }
                }
            }
        }

        public void ShowAllMines()
        {
            foreach (var box in boxes)
            {
                if(box.Value.isMine)
                {
                    box.Value.uiBox.TextureRect = new IntRect(10 * 10, 0, 10, 10);
                }
            }
        }

        public bool CheckMines()
        {
            foreach (var box in boxes)
            {
                if(box.Value.isMine && !box.Value.isMarked)
                {
                    return false;
                }
            }
            return true;
        }

        public void Update(Vector2i mouseCoords)
        {
            if(EnabledClick)
            {
                foreach (var box in boxes)
                {
                    if(LeftClick && box.Value.rect.Contains((int)mouseCoords.X, (int)mouseCoords.Y) && !box.Value.isOpened)
                    {
                        LeftClick = false;

                        // change view of the clicked box
                        box.Value.isOpened = true;

                        // if it is mine then show game over text on the screen.
                        if(box.Value.isMine)
                        {
                            ShowAllMines();
                            isLose = true;
                            box.Value.type = 10;
                            EnabledClick = false;
                        }

                        if(!NotFirst)
                        {
                            GenerateMines();
                            CalculateNumbers();
                            NotFirst = true;
                        }
                        box.Value.uiBox.TextureRect = new IntRect(box.Value.type * 10,0,10,10);
                        
                        if(box.Value.type == 9)
                        {
                            showOthers(new Vector2i((int)box.Value.position.X/16, (int)box.Value.position.Y/16));
                        }
                    }

                    // set flag
                    if(RightClick && box.Value.rect.Contains((int)mouseCoords.X, (int)mouseCoords.Y) && flagCounter < LIMIT_FLAGS)
                    {
                        RightClick = false;

                        if(!box.Value.isMarked && !box.Value.isOpened)
                        {
                            box.Value.isMarked = true;
                            box.Value.uiBox.TextureRect = new IntRect(11 * 10,0,10,10);
                            flagCounter++;
                        }
                        else if(box.Value.isMarked && !box.Value.isOpened)
                        {
                            box.Value.isMarked = false;
                            box.Value.uiBox.TextureRect = new IntRect(0 * 10,0,10,10);
                            flagCounter--;
                        }


                        if(NotFirst && CheckMines())
                        {
                            isWon = true;
                            EnabledClick = false;
                        }
                    }
                }
            }
        }


        public void Draw(RenderTarget window)
        {
            renderTexture.Clear();

            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    renderTexture.Draw(boxes[new Vector2f(x, y)].uiBox);
                }
            }

            if(isLose)
            {
                renderTexture.Draw(gameOver);
            }
            if(isWon)
            {
                renderTexture.Draw(youWon);
            }

            renderTexture.Display();
            
            window.Draw(board);
        }
    }
}
