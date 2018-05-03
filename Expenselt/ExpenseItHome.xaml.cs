using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Expenselt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Page , INotifyPropertyChanged 
    {
        public ExpenseItHome()
        {
            InitializeComponent();
            LastChecked = DateTime.Now;
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set {
                lastChecked = value;
                // Извикване на PropertyChanged
                if (PropertyChanged != null)
                    PropertyChanged(this, e: new PropertyChangedEventArgs("LastChecked"));
            }
        }

        private void Greeting_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greetingMsg);
        }

        private void Navig_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReportPage expenseReportPage =
                                new ExpenseReportPage(this.peopleListBox.SelectedItem);

            this.NavigationService.Navigate(expenseReportPage);
        }

        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
        }
    }
    
}
