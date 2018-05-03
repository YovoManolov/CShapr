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
using System.ComponentModel;
using System.Collections.ObjectModel;
using StudentRepository;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for ProffesorSuccess.xaml
    /// </summary>
    public partial class ProffesorSuccess : Page /*INotifyPropertyChanged*/
    {
        private Dictionary<long, Student> stDict = new Dictionary<long, Student>();
        private ObservableCollection<Student> strudentsOC = new ObservableCollection<Student>();

        public ProffesorSuccess()
        {
            InitializeComponent();
            loadStudentList();
            ProfStList.ItemsSource = strudentsOC;
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //public List ProfStListProp
        //{
        //    get { }
        //    set
        //    {   
        //    }
        //}

        public void  loadStudentList()
        {
            stDict = StudentData.getAllStudents();
            foreach ( Student st in stDict.Values)
            {
                strudentsOC.Add(st);
            }
        }

        private void FnFilter_Click(object sender, RoutedEventArgs e)
        {
            String fakToCompare = stFn.Text;

            List<Student> sL = (from st in stDict.Values.ToList()
                                where st.fakultetenNomer == Int64.Parse(fakToCompare)
                                select st).ToList();

            ProfStList.Items.Clear();
            foreach(Student s in sL)
            {
                ProfStList.Items.Add((String)s.ime);
            }
           
        }

        //string greetingMsg;
        //greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
        //    MessageBox.Show("Hi " + greetingMsg);
    }
}
