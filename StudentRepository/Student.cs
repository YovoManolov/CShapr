using System;

namespace StudentRepository
{
    public class Student
    {
        public String ime ;
        public String prezime;
        public String familiq;
        public String fakultet;
        public String specialnost;
        public String obrazovKvalifSt;
        public String statusNaStudent;
        public long fakultetenNomer;
        public DateTime poslednaZaverkaNaSem;
        public Int32 kurs;
        public Int32 potok;
        public Int32 grupa;
        public String imagePath;

        public Student(string ime, string prezime,
            string familiq, string fakultet,
            string specialnost, string obrazovKvalifSt,
            string statusNaStudent, long fakultetenNomer,
            DateTime poslednaZaverkaNaSem, int kurs,
            int potok, int grupa, String imagePath)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.familiq = familiq;
            this.fakultet = fakultet;
            this.specialnost = specialnost;
            this.obrazovKvalifSt = obrazovKvalifSt;
            this.statusNaStudent = statusNaStudent;
            this.fakultetenNomer = fakultetenNomer;
            this.poslednaZaverkaNaSem = poslednaZaverkaNaSem;
            this.kurs = kurs;
            this.potok = potok;
            this.grupa = grupa;
            this.imagePath = imagePath;
        }

        public Student() { }
        public static Student createNewStudent()
        {
            return null;
        }
    }
}
