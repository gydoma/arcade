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
    }
}
