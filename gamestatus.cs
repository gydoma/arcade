using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snakegame
{
    public class gamestatus
    {
        public int Sorok { get; }
        public int Oszlopok { get; }
        public GridValue[,] Grid { get; }
        public direction Dir { get; private set; }
        public int Score { get; private set; }
        public bool GameOver { get; private set; }

        
        private readonly LinkedList<direction> dirChanges = new LinkedList<direction>();
        private readonly LinkedList<position> snakepositions = new LinkedList<position>();
        private readonly Random rnd= new Random();

        public gamestatus(int sorok, int oszlopok)
        {
            Sorok= sorok;
            Oszlopok= oszlopok;
            Grid = new GridValue [sorok, oszlopok];
            Dir = direction.right;

            AddSnake();
            AddFood();
           

        }

        private void AddSnake()
        {
            int s = Sorok / 2;
            for (int o = 0; o <= 3; o++)
            {
                Grid[s, o] = GridValue.Snake;
                snakepositions.AddFirst(new position(s, o));
            }
        }

        private IEnumerable<position> EmptyPositions()
        {
            for (int s = 0; s < Sorok; s++)
            {
                for (int o = 0; o < Oszlopok; o++)
                {
                    if (Grid[s, o]== GridValue.Empty)
                    {
                        yield return new position(s,o);
                    }
                }
            }
        }

        private void AddFood()
        {
            List<position> empty = new List<position>(EmptyPositions());

            if (empty.Count == 0)
            {
                return;
            }

            position pos = empty[rnd.Next(empty.Count)];
            Grid[pos.Sor, pos.Oszlop] = GridValue.Food;

        }

        public position HeadPosition()
        {
            return snakepositions.First.Value;
        }
        public position TailPosition()
        {
            return snakepositions.Last.Value;
        }

        public IEnumerable<position> SnakePositions()
        {
            return snakepositions;
        }
        private void AddHead(position pos)
        {
            snakepositions.AddFirst(pos);
            Grid[pos.Sor, pos.Oszlop] = GridValue.Snake;
        }

        private void RemoveTail()
        {
            position tail = snakepositions.Last.Value;
            Grid[tail.Sor, tail.Oszlop] = GridValue.Empty;
            snakepositions.RemoveLast();

        }

        private direction GetLastDirection()
        {
            if(dirChanges.Count == 0)
            {
                return Dir;
            }
            return dirChanges.Last.Value;
        }

        private bool CanChangeDirection(direction newDir)
        {
            if (dirChanges.Count == 2)
            {
                return false;
            }
            direction lastDir = GetLastDirection();
            return newDir != lastDir && newDir != lastDir.Opposite();
        }
        public void ChangeDirection(direction dir)
        {
            if(CanChangeDirection(dir))
            {
                dirChanges.AddLast(dir);
            }
        }
        private bool OutsideGride(position pos)
        {
            return pos.Sor < 0 || pos.Oszlop >= Oszlopok || pos.Sor < 0 || pos.Oszlop >= Oszlopok;

        }

        private GridValue WillHit (position newheadpos)
        {
            if (OutsideGride(newheadpos))
            {
                return GridValue.Outside;
            }

            if (newheadpos == TailPosition())
            {
                return GridValue.Empty;
            }
            return Grid[newheadpos.Sor, newheadpos.Oszlop];
        }

        public void Move()
        {
            if(dirChanges.Count> 0)
            {
                Dir = dirChanges.First.Value;
                dirChanges.RemoveFirst();

            }

            position newheadpos = HeadPosition().Translate(Dir);
            GridValue hit = WillHit(newheadpos);

            if (hit == GridValue.Outside || hit == GridValue.Snake)
            {
                GameOver = true;
            }

            else if (hit == GridValue.Empty)
            {
                RemoveTail();
                AddHead(newheadpos);
            }

            else if (hit == GridValue.Food)
            {
                AddHead(newheadpos);
                Score++;
                AddFood();
            }
        }
    }
}
