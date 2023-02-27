using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Homework14_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static CancellationTokenSource cancelToken = new CancellationTokenSource();
        private static  CancellationToken token = cancelToken.Token;

        public MainWindow()
        {
            InitializeComponent();

        }

        void ChangeTextBox(string value)
        {
            Dispatcher.BeginInvoke(new Action(() => { TextBox.Text = value; }));
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ConnectToDB();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            cancelToken.Cancel();
            ChangeTextBox("Disconnected to DB");
        }

        
        async void ConnectToDB()
        {
            try
            {
                await Task.Run(() =>
                {
                    int x = 10;
                    for (int i = 1; i <= x; i++)
                    {
                        ChangeTextBox("Loading data..." + new string('.', i) + i.ToString() + "from " + x.ToString());
                        Thread.Sleep(4000);

                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                    }
                }
            );
            }
            catch (OperationCanceledException ex)
            {
                ChangeTextBox("Error");
            }
            finally
            {
                cancelToken.Dispose();
            }

        }


       




    }
}
