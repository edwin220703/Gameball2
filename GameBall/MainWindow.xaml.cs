using System.Windows;
using System.Windows.Controls;

namespace GameBall
{
    //Participantes: Edwin De Peña, Kevin Acosta y Florangel Perez
    public partial class MainWindow : Window
    {
        private static bool GameOver = false;
        private static Thread thread_Play;
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }


        public void Initialize()
        {
            Canvas.SetTop(img_Ball, (canvas_Table.Height / 2) - 60);
            btn_Stop.IsEnabled = false;
        }


        public void Loop()
        {
            thread_Play = new Thread(() =>
            {
                while (GameOver != true)
                {
                    for (int i = 0; i < Convert.ToInt16(canvas_Table.ActualWidth - 20); i += 5)
                    {
                        try
                        {
                            Dispatcher.Invoke(new Action(() =>
                            {
                                Canvas.SetLeft(img_Ball, i);
                            }));

                            Thread.Sleep(20);

                        }
                        catch (Exception ex)
                        {
                            Dispatcher.Invoke(new Action(() =>
                            {
                                Canvas.SetLeft(img_Ball, 0);
                            }));
                        }

                    }

                    for (int i = Convert.ToInt16(canvas_Table.ActualWidth - 20); i > 10; i -= 5)
                    {
                        try
                        {
                            Dispatcher.Invoke(new Action(() =>
                            {
                                Canvas.SetLeft(img_Ball, i);
                            }));

                            Thread.Sleep(20);
                        }
                        catch (Exception ex)
                        {
                            Dispatcher.Invoke(new Action(() =>
                            {
                                Canvas.SetLeft(img_Ball, 0);
                            }));
                        }

                    }
                }
            });

            thread_Play.Start();
        }

        private void btn_Star_Click(object sender, RoutedEventArgs e)
        {
            GameOver = false;
            Loop();
            btn_Star.IsEnabled = false;
            btn_Stop.IsEnabled = true;
        }

        private void btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            GameOver = true;
            btn_Star.IsEnabled = true;
        }

        
    }
}