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
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        private Student currentStudent;
        private String currentUserUsername;
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Студентска информационна система";
            deactivateFormFields();
            enterNotes.IsEnabled = false;
            fakNumGB.IsEnabled = false;
            setImageSource(null);
            //if ((UserRoles)UserData.UserRoleOfCurrUser == UserRoles.ANONYMOS)
            //{
            //    foreach (Control ctrl in GrPD.Children)
            //    {
            //        ctrl.IsEnabled = false;
            //    }

            //    foreach (Control ctrl in GrStInfo.Children)
            //    {
            //        ctrl.IsEnabled = false;
            //    }
            //}
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in GrPD.Children)
            {
                if (element is ListBox)
                {
                    ListBox lb = element as ListBox;
                    lb.SelectedItem = lb.Items[0];
                    lb.ScrollIntoView(lb.Items[0]);
                }
                TextBox textbox = element as TextBox;
                if (textbox != null)
                {
                    textbox.Text = String.Empty;
                }
            }

            foreach (UIElement element in GrStInfo.Children)
            {
                if (element is ListBox)
                {
                    ListBox lb = element as ListBox;
                    lb.SelectedItem = lb.Items[0];
                    lb.ScrollIntoView(lb.Items[0]);
                }
                TextBox textbox = element as TextBox;
                if (textbox != null)
                {
                    textbox.Text = String.Empty;
                }
            }
           
        }

        private void clearForm()
        {
            foreach (UIElement element in GrPD.Children)
            {
                if (element is ListBox)
                {
                    ListBox lb = element as ListBox;
                    lb.SelectedItem = lb.Items[0];
                    lb.ScrollIntoView(lb.Items[0]);
                }
                TextBox textbox = element as TextBox;
                if (textbox != null)
                {
                    textbox.Text = String.Empty;
                }
            }

            foreach (UIElement element in GrStInfo.Children)
            {
                if (element is ListBox)
                {
                    ListBox lb = element as ListBox;
                    lb.SelectedItem = lb.Items[0];
                    lb.ScrollIntoView(lb.Items[0]);
                }
                TextBox textbox = element as TextBox;
                if (textbox != null)
                {
                    textbox.Text = String.Empty;
                }
            }
        }

        private void loadStudent(Student s)
        {
            firstName.Text = s.ime;
            secName.Text = s.prezime;
            famName.Text = s.familiq;

            fak.Text = s.fakultet;
            spec.Text = s.specialnost;
            switch (s.obrazovKvalifSt)
            {
                case "бакалавър":
                    oks.SelectedItem = oks.Items[1];
                    oks.ScrollIntoView(oks.Items[1]);
                    break;
                case "магистър":
                    oks.SelectedItem = oks.Items[2];
                    oks.ScrollIntoView(oks.Items[2]);
                    break;
                case "докторант":
                    oks.SelectedItem = oks.Items[3];
                    oks.ScrollIntoView(oks.Items[3]);
                    break;
                default:
                    MessageBox.Show("Не беше намерена окс, която да съответства на тази на студента! ");
                    break;
            }

            switch (s.statusNaStudent)
            {
                case "активен":
                    stat.SelectedItem = stat.Items[1];
                    stat.ScrollIntoView(stat.Items[1]);
                    break;
                case "завършил":
                    stat.SelectedItem = stat.Items[2];
                    stat.ScrollIntoView(stat.Items[2]);
                    break;
                case "прекъснал":
                    stat.SelectedItem = stat.Items[3];
                    stat.ScrollIntoView(stat.Items[3]);
                    break;
                default:
                    MessageBox.Show("Не беше намерен статус, който съответства на този на студента! ");
                    break;
            }

            fn.Text = Convert.ToString(s.fakultetenNomer);

            kurs.SelectedItem = kurs.Items[s.kurs];
            kurs.ScrollIntoView(kurs.Items[s.kurs]);

            potok.Text = Convert.ToString(s.potok);
            grupa.Text = Convert.ToString(s.grupa);

            setImageSource(currentStudent.imagePath);
          
        }

        private void setImageSource(String imageUri)
        {
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            if (imageUri == null)
            {
                b.UriSource = new Uri("E:/CSharp/StudentInfoSystem/images/default_profile.png");
            }
            else
            {
                b.UriSource = new Uri(imageUri);
            }
            b.EndInit();

            // ... Get Image reference from sender.
            var image = StImage as Image;
            // ... Assign Source.
            image.Source = b;
        }


        //private void StImage(object sender, RoutedEventArgs e)
        //{
        //    // ... Create a new BitmapImage.
        //    BitmapImage b = new BitmapImage();
        //    b.BeginInit();
        //    if (currentStudent == null)
        //    {
        //        b.UriSource = new Uri("E:/CSharp/StudentInfoSystem/images/default_profile.png");
        //    }
        //    else
        //    {
        //        b.UriSource = new Uri(currentStudent.imagePath);
        //    }
        //    b.EndInit();

        //    // ... Get Image reference from sender.
        //    var image = sender as Image;
        //    // ... Assign Source.
        //    image.Source = b;
        //}


        private void loadSt_Click(object sender, RoutedEventArgs e)
        {
            Student s = new Student("Петър", "Трашев", "Фитков", "ФКСТ", "КСИ",
                "бакалавър", "прекъснал", 1231234, new DateTime(2004, 4, 24), 3, 10, 41, "E:/CSharp/StudentInfoSystem/images/200x300.jpg");
          
            loadStudent(s);
        }

        private void activateFormFields()
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

        private void deactivateFormFields()
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

        
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            String username = usernameLogin.Text;
            String password = passLogin.Text;

            User resultU = UserData.isUserPassCorrect(username, password);
            if(resultU == null)
            {
                MessageBox.Show("Потребител с такова потребитслко име или парола не съществува!");
                return;
            }
            else
            {
                currentUserUsername = resultU.Username;
            }

            if(resultU.Role == (int)UserRoles.STUDENT)
            {
                String fakNum = resultU.FakNum;
                Student s = StudentData.findStudentByFakNum(long.Parse(fakNum));
                activateFormFields();
                currentStudent = s;
                loadStudent(s);
            }else if(resultU.Role == (int)UserRoles.PROFESSOR)
            {
                ProffesorSuccess proffesorSuccessPage = new ProffesorSuccess();
                NavigationService.Navigate(proffesorSuccessPage);

                //enterNotes.IsEnabled = true;
                //fakNumGB.IsEnabled = true;
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            clearForm();
            deactivateFormFields();
            UserData.FindUserByUserName(currentUserUsername).Role = (int)UserRoles.ANONYMOS;
        }

        private void enterNotes_Click(object sender, RoutedEventArgs e)
        {
           
        }
        
        private void SearchSt_Click(object sender, RoutedEventArgs e)
        {
            String fn = fakNumByProf.Text;
            Student s = StudentData.findStudentByFakNum(long.Parse(fn));
            activateFormFields();
            loadStudent(s);
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
        
        private void Navig_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
