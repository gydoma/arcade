using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace snakegame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<GridValue, ImageSource> gridvalToImage = new()
        {
            {GridValue.Empty, Images.Empty },
            {GridValue.Snake, Images.Body },
            {GridValue.Food, Images.Food }
        };

        private readonly Dictionary<direction, int> directions = new()
        {
            {direction.up, 0 },
            {direction.right,90 },
            {direction.down, 180},
            {direction.left, 270 }
        };

        private readonly int sorok = 15, oszlopok = 15;
        private readonly Image[,] gridImages;
        private gamestatus gameState;
        private bool gameRunning;

        public MainWindow()
        {
            InitializeComponent();
            gridImages = SetupGrid();
            gameState = new gamestatus(sorok, oszlopok);
        }

        private async Task RunGame()
        {
            Draw();
            await ShowCountDown();
            Overlay.Visibility = Visibility.Hidden;
            await GameLoop();
            await Showgameover();
            gameState = new gamestatus(oszlopok, sorok);
        }

        private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Overlay.Visibility == Visibility.Visible)
            {
                e.Handled = true;
            }
            if(!gameRunning)
            {
                gameRunning = true;
                await RunGame();
                gameRunning = false;
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }

            switch(e.Key)
            {
                case Key.Left:
                    gameState.ChangeDirection(direction.left);
                    break; 
                case Key.Right:
                    gameState.ChangeDirection(direction.right);
                    break;
                case Key.Up:
                    gameState.ChangeDirection(direction.up);
                    break;
                case Key.Down:
                    gameState.ChangeDirection(direction.down);
                    break;
            }
        }

        private async Task GameLoop()
        {
            while(!gameState.GameOver)
            {
                await Task.Delay(100);
                gameState.Move();
                Draw();
            }
        }

        private Image[,] SetupGrid()
        {
            Image[,] images = new Image[sorok, oszlopok];
            GameGrid.Rows = sorok;
            GameGrid.Columns = oszlopok;
            GameGrid.Width = GameGrid.Height * (oszlopok / (double)sorok);

            for (int i = 0; i < sorok; i++)
            {
                for (int c = 0; c < oszlopok; c++)
                {
                    Image image = new Image
                    {
                        Source = Images.Empty,
                        RenderTransformOrigin = new Point(0.5,0.5),
                    };
                    images[i, c] = image;
                    GameGrid.Children.Add(image);

                }
            }
            return images;
        }

        private void Draw()
        {
            DrawGrid(); 
            DrawSnakeHead();
            ScoreText.Text = $"PONT {gameState.Score}";
        }

        private void DrawGrid()
        {
            for (int i = 0; i < sorok; i++)
            {
                for (int c = 0; c < oszlopok; c++)
                {
                    GridValue gridVal = gameState.Grid[i, c];
                    gridImages[i, c].Source = gridvalToImage[gridVal];
                    //gridImages[i, c].RenderTransformOrigin = Transform.Identity;
                }
            }
        }

        private void DrawSnakeHead()
        {
            position headPos = gameState.HeadPosition();
            Image image = gridImages[headPos.Sor, headPos.Oszlop];
            image.Source = Images.Head;

            //int rotation = dirToRotation[gameState.Dir];
            //image.RenderTransform = new RotateTransform(rotation);
        }

        private async Task DrawDeadSnake()
        {
            List<position> positions = new List<position>(gameState.SnakePositions());

            for (int i = 0; i < positions.Count; i++)
            {
                position pos = positions[i];
                ImageSource source = (i == 0) ? Images.DeadHead : Images.DeadBody;
                gridImages[pos.Sor, pos.Oszlop].Source = source;
                await Task.Delay(50);
            }
        }
        private async Task ShowCountDown()
        {
            for(int i = 3; i>=1; i--)
            {
                OverlayText.Text = i.ToString();
                await Task.Delay(500);
            }
        }

        private async Task Showgameover()
        {
            await DrawDeadSnake();
            await Task.Delay(1000);
            Overlay.Visibility = Visibility.Visible;
            OverlayText.Text = "Nyomj meg egy billentyűt a kezdéshez";
        }
    }
}
