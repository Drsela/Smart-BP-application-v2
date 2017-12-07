namespace DTO
{
    public class EmployeeDTO
    {
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

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}