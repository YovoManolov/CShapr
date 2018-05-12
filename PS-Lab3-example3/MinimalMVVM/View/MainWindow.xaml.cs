using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MinimalMVVM.ViewModel;

namespace MinimalMVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PresenterToLC psToLC = new PresenterToLC();
        Presenter ps = new Presenter();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = psToLC;
        }

        private void ChangeDC(object sender, RoutedEventArgs e)
        {
            if(this.DataContext is PresenterToLC)
            {
                this.DataContext = ps;
            }
            else 
            {
                this.DataContext = psToLC;
            }
        }
    }
}
