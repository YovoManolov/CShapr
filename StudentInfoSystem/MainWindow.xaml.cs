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
using StudentInfoSystem;
using StudentRepository;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Студентска информационна система";
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            GrPD.RowDefinitions.Clear();
            GrPD.Children.Clear();

            GrStInfo.RowDefinitions.Clear();
            GrStInfo.Children.Clear();
        }

      

        private void loadSt_Click(object sender, RoutedEventArgs e)
        {
            Student s = new Student("Петър", "Трашев", "Фитков", "ФКСТ", "КСИ",
                "бакалавър", "прекъснал", 1231234, new DateTime(2004, 4, 24), 3, 10, 41);

            firstName.Text = s.ime;
            secName.Text = s.prezime;
            famName.Text = s.familiq;
            
            fak.Text = s.fakultet;
            spec.Text = s.specialnost;
            switch (s.obrazovKvalifSt)
            {
                case "бакалавър":
                    oks.SelectedItem = oks.Items.GetItemAt(1);
                    break;
                case "магистър":
                    oks.SelectedItem = oks.Items.GetItemAt(2);
                    break;
                case "докторант":
                    oks.SelectedItem = oks.Items.GetItemAt(3);
                    break;
                default:
                    MessageBox.Show("Не беше намерена окс, която да съответства на тази на студента! ");
                    break;
            }

            switch (s.statusNaStudent)
            {
                case "активен":
                    stat.SelectedItem = stat.Items.GetItemAt(1);
                    break;
                case "завършил":
                    stat.SelectedItem = stat.Items.GetItemAt(2);
                    break;
                case "прекъснал":
                    stat.SelectedItem = stat.Items.GetItemAt(3);
                    break;
                default:
                    MessageBox.Show("Не беше намерен статус, който съответства на този на студента! ");
                    break;
            }

            fak.Text = Convert.ToString(s.fakultetenNomer);
            kurs.SelectedItem = kurs.Items.GetItemAt(s.kurs);
            potok.Text = Convert.ToString(s.potok);
            grupa.Text = Convert.ToString(s.grupa);

        }

        private void Activate_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control ctrl in GrPD.Children)
            {
                ctrl.IsEnabled = true;
            }
            foreach (Control ctrl in GrStInfo.Children)
            {
                ctrl.IsEnabled = true;
            }
        }

        private void Deactivate_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control ctrl in GrPD.Children)
            {
                ctrl.IsEnabled = false;
            }

            foreach (Control ctrl in GrStInfo.Children)
            {
                ctrl.IsEnabled = false;
            }
        }
    }
}
