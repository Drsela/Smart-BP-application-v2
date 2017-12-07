namespace DAL
{
    public class Patient
    {
        public int Age;
        public string Cpr;
        public string Name;
        public string Surname;

        public Patient(string name, string surname, string cpr, int age)
        {
            Name = name;
            Surname = surname;
            Cpr = cpr;
            Age = age;
        }
    }
}