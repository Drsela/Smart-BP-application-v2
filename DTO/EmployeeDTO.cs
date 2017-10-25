using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public EmployeeDTO()
        {
            ID = 0;
            Name = "NA";
            Surname = "NA";
        }
        public EmployeeDTO(int id, string name, string surname)
        {
            ID = id;
            Name = name;
            Surname = surname;
        }
    }
}
