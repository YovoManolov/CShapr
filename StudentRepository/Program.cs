using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    class Program
    {
        public static void Main(string[] args)
        {
            StudentData.addStudentsInList();

            long fakultetenN;
            Console.Write("Моля въведете факултетен номер: ");
            String fakNum = Console.ReadLine();
            fakultetenN = long.Parse(fakNum);

            String uverenie =  StudentData.prepareSertificate(fakultetenN);
            Console.WriteLine("\n\nУверение: ");
            Console.WriteLine(uverenie);
            Console.ReadLine();

            StudentData.SaveCertificate(uverenie, "C:/Users/yovo_user/Desktop/uverenie.txt");

        }
        
    }
}
