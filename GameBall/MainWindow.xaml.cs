using System.Windows;
using System.Windows.Controls;

namespace GameBall
{
    //Participantes: Edwin De Peña, Kevin Acosta y Florangel Perez
    public partial class MainWindow : Window
    {
        private static double _hCanvas;
        private static double _wCanvas;
        private static bool _gameOver = true;
        private static int speedX = 10;
        private static int speedY = 10;
        private static Thread thread1;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            _gameOver = false;
            _hCanvas = canvas_Table.Height;
            _wCanvas = canvas_Table.Width;
            Canvas.SetTop(img_Ball, _hCanvas / 2);
            Canvas.SetLeft(img_Ball, _wCanvas / 2);
        }


        public void Update()
        {
            thread1 = new Thread(() =>
            {
                while (_gameOver != true)
                {
                    Logic();
                    Thread.Sleep(20);
                }
            });

            thread1.Start();
        }

        public void Logic()
        {
            try
            {
                Dispatcher.Invoke(new Action(() =>
                {

                    if (Canvas.GetLeft(img_Ball) > _wCanvas)
                    {
                        speedX = Convert.ToInt16($"-{new Random().Next(10, 20)}");

                    }

                    if (Canvas.GetLeft(img_Ball) < 0)
                    {
                        speedX = new Random().Next(10, 20);

                    }
                    if (Canvas.GetTop(img_Ball) > _hCanvas)
                    {
                        speedY = Convert.ToInt16($"-{new Random().Next(10, 20)}");
                    }

                    if (Canvas.GetTop(img_Ball) < 0)
                    {
                        speedY = new Random().Next(10, 20);
                    }

                    Canvas.SetLeft(img_Ball, Canvas.GetLeft(img_Ball) + speedX);
                    Canvas.SetTop(img_Ball, Canvas.GetTop(img_Ball) + speedY);

                    canvas_Table.UpdateLayout();
                }));

            }
            catch (Exception ex)
            {
    
            }
        }

        private void btn_Star_Click(object sender, RoutedEventArgs e)
        {
            btn_Star.IsEnabled = false;
            btn_Stop.IsEnabled = true;
            _gameOver = false;
            Update();

        }

        private void btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            btn_Star.IsEnabled = true;
            btn_Stop.IsEnabled = false;
            _gameOver = true;
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            thread1.Interrupt();
        }
    }
}