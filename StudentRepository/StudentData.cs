using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace StudentRepository
{
    public class StudentData
    {
        private static List<Student> TestStudents = new List<Student>();
        private static Dictionary<long, Student> studentD = new Dictionary<Int64, Student>();

        public static void addStudentsInList()
        {
            Student s = new Student("ime1", "prezime1", "familiq", "fak", "ksi",
                "bakalavyr", "prekysnal", 1231233, new DateTime(2009, 4, 24), 3, 10, 41);
            Student s2 = new Student("ime2", "prezime2", "familiq1", "fak2321", "ksi321",
                "bakalavyr32", "prekysnal", 1231234, new DateTime(2004, 4, 24), 3, 10, 41);
            Student s3 = new Student("ime4", "prezime4", "familiq3", "fak2321", "ksi321",
               "bakalavyr32", "aktiven", 1231235, new DateTime(2005, 4, 25), 4, 10, 42);

            TestStudents.Add(s);
            TestStudents.Add(s2);
            TestStudents.Add(s3);

            foreach (Student st in StudentData.TestStudents)
            {
                studentD.Add(st.fakultetenNomer, st);
            }

        }

        public static Student isThereSudent(long fakNum)
        {
            Student s = null;
            s = (Student) from student in TestStudents
                        where student.fakultetenNomer == fakNum
                        select student;

            return s;
        }

        public static String prepareSertificate(long fakultetenN)
        {
            String uverenie;
            Student s = studentD[fakultetenN];

            uverenie = "Студент с име: " + s.ime + " " + s.prezime + " " + s.familiq +
                "\n и факултетен номер: " + s.fakultetenNomer +"поток: "+s.potok + 
                "\nгрупа: " + s.grupa +"\n e бил записан в " + s.kurs + "курс :"+s.kurs + " от специалност : " 
                + s.specialnost
                + "\n,който се обучава за квалификационна степен: " + s.obrazovKvalifSt +
                " придоби статус: " + s.statusNaStudent;
            
            return uverenie;
        }
       
        public static void SaveCertificate(String uverenie,String adresNaFail)
        {
            if (!File.Exists(adresNaFail))
            {
                using (StreamWriter sw = File.CreateText(adresNaFail))
                {
                    try
                    {
                        sw.Write(uverenie);

                    } catch (IOException e) {
                        Console.WriteLine("Пробем с запис в файл");
                        Console.WriteLine(e.ToString());
                    }
                }
            }
            else
            {
               File.WriteAllText(adresNaFail,string.Empty);
               using (StreamWriter sw = File.AppendText(adresNaFail))
               {
                    sw.WriteLine(uverenie);
               }
            }
        }
        
        public static Student findStudentByFakNum(long fakNum)
        {

            Student s = studentD[fakNum];
            return s;
        }
    }
}
