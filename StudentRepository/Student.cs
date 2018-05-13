using System;

namespace StudentRepository
{
    public class Student
    {
        public int StudentId { get; set; }
        public string ime { get; set; }
        public string Surname { get; set; }
        public string FamilyName { get; set; }
        public String fakultet { get; set; }
        public String specialnost { get; set; }
        public String obrazovKvalifSt { get; set; }
        public String statusNaStudent { get; set; }
        public long fakultetenNomer { get; set; }
        public DateTime poslednaZaverkaNaSem;
        public Int32 kurs;
        public Int32 potok;
        public Int32 grupa;
        public byte[] Photo { get; set; }

    public Student() { }

    public Student(string ime, string Surname,
            string FamilyName, string fakultet,
            string specialnost, string obrazovKvalifSt,
            string statusNaStudent, long fakultetenNomer,
            DateTime poslednaZaverkaNaSem, int kurs,
            int potok, int grupa, byte[] Photo)
        {
            this.ime = ime;
            this.Surname = Surname;
            this.FamilyName = FamilyName;
            this.fakultet = fakultet;
            this.specialnost = specialnost;
            this.obrazovKvalifSt = obrazovKvalifSt;
            this.statusNaStudent = statusNaStudent;
            this.fakultetenNomer = fakultetenNomer;
            this.poslednaZaverkaNaSem = poslednaZaverkaNaSem;
            this.kurs = kurs;
            this.potok = potok;
            this.grupa = grupa;
            this.Photo = Photo;
        }

    }
}
