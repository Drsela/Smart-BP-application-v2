using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Employee
    {
        public int ID;
        public string Name;
        public string Surname;

        public Employee(int id, string name, string surname)
        {
            ID = id;
            Name = name;
            Surname = surname;
        }

        public int Id
        {
            get => ID;
            set => ID = value;
        }

        public string Name1
        {
            get => Name;
            set => Name = value;
        }

        public string Surname1
        {
            get => Surname;
            set => Surname = value;
        }
    }
}
