using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Patient
    {
        public string Name;
        public string Surname;
        public string Cpr;
        public int Age;

        public Patient(string name, string surname, string cpr, int age)
        {
            Name = name;
            Surname = surname;
            Cpr = cpr;
            Age = age;
        }
    }
}
