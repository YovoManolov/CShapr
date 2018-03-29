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
using StudentRepository;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for ProffesorSuccess.xaml
    /// </summary>
    public partial class ProffesorSuccess : Page
    {
        private Dictionary<long, Student> stDict = new Dictionary<long, Student>();
        public ProffesorSuccess()
        {
            InitializeComponent();
            loadStudentList();
        }

        public void  loadStudentList()
        {
            stDict = StudentData.getAllStudents();
            
            foreach ( Student st in stDict.Values)
            {
                ProfStList.Items.Add(st.ime);
            }
        }

        private void FnFilter_Click(object sender, RoutedEventArgs e)
        {
            var fakToCompare = stFn.Text;

            List<String> resultFromFilter = (List<String>) from student in stDict.Values.ToList()
                                            where student.fakultetenNomer == Convert.ToInt64(fakToCompare)
                                            select student.ime;

            ProfStList.Items.Clear();
            foreach (String ime in resultFromFilter)
            {
                ProfStList.Items.Add(ime);
            }
        }
    }
}
