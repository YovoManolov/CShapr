using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace StudentRepository
{
    public class StudentData
    {
        private static List<Student> TestStudents = new List<Student>()
        {
         new Student("Йово", "Пламенов", "Манолов", "ФКСТ", "КСИ",
                "бакалавър", "активен", 1231233, new DateTime(2009, 4, 24), 3, 10, 41),
         new Student("Петър", "Трашев", "Фитков", "ФКСТ", "КСИ",
            "бакалавър", "прекъснал", 1231234, new DateTime(2004, 4, 24), 3, 10, 41),
         new Student("Тодор", "Димитров", "Страшимиров", "ФКСТ", "КСИ",
           "бакалавър", "активен", 1231235, new DateTime(2005, 4, 25), 4, 10, 42)
        };

        private static Dictionary<long, Student> studentD = new Dictionary<Int64, Student>()
        {
            {TestStudents.ElementAt(0).fakultetenNomer, TestStudents.ElementAt(0)},
            {TestStudents.ElementAt(1).fakultetenNomer, TestStudents.ElementAt(1)},
            {TestStudents.ElementAt(2).fakultetenNomer, TestStudents.ElementAt(2)}
        };

        
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
                "\n и факултетен номер: " + s.fakultetenNomer +", поток: "+s.potok + 
                "\nгрупа: " + s.grupa +" e бил записан в " + s.kurs + "курс и изучава специалност : " 
                + s.specialnost
                + "\nОбучава се за квалификационна степен: " + s.obrazovKvalifSt +"."+
                "\nTекущ статус: " + s.statusNaStudent +".";
            
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
