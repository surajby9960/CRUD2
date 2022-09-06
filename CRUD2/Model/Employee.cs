namespace CRUD2.Model
{
    public class Employee
    {

        public int eId { get; set; }
        public string? eName { get; set; }
        public int? eAge { get; set; }
        public string? ePosition { get; set; }
        public int? cId { get; set; }
        public List<Project> projects { get; set; }

    }
    public class CreateEmployee
    {
        public string? eName { get; set; }
        public int? eAge { get; set; }
        public string? ePosition { get; set; }
        public int? cId { get; set; }
    }
    public  class UpdateEmployee: CreateEmployee
    {
        public int eId { get; set; }
    }
    public class Project
    {

    }
}
