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



        private readonly int sorok = 15, oszlopok = 15;
        private readonly Image[,] gridImages;
        private gamestatus gameState;

        public MainWindow()
        {
            InitializeComponent();
            gridImages = SetupGrid();
            gameState = new gamestatus(sorok, oszlopok);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Draw();
            await GameLoop();
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

            for (int i = 0; i < sorok; i++)
            {
                for (int c = 0; c < oszlopok; c++)
                {
                    Image image = new Image
                    {
                        Source = Images.Empty
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
                }
            }
        }
    }
}
