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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Наистина ли искате да затворите програмата ?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            String fullName = null;
            foreach (Control ctrl in gbUser1.Children)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    fullName += ((TextBox)ctrl).Text +" ";
                }
            }

            if(fullName != null)
            {
                MessageBox.Show("Здрасти " + fullName + "!!!\n Това е първа програма на VS 2017!!!");
            }
        }
        
        private void Butt_nFakt(object sender, RoutedEventArgs e)
        {
            int number = int.Parse(nField.Text);
            int fakt = number;
            for (int i = 1; i < number; i++)
            {
                fakt *= i;
            }
            MessageBox.Show("n! = "+ fakt);
        }

        private void Button_nPowerY(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(nField.Text);
            int y = int.Parse(yField.Text);

            MessageBox.Show("n^y = " + (int)Math.Pow(n, y));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, Windows Presentation Foundation!");
            TextBlock1.Text = "CurrentTime = " +DateTime.Now.ToString();
        }
    }
}
