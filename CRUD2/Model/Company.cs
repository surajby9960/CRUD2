namespace CRUD2.Model
{
    public class Company
    {
        public int cId { get; set; }
        public string? cName { get; set; }
        public string? cAddress { get; set; }
        public string? cCountry { get; set; }
        public List<Employee>? Employees { get; set; } 
       
    }
    public class CompanyForCreationDto
    {
        public string? cName { get; set; }
        public string? cAddress { get; set; }
        public string? cCountry { get; set; }
       
        public List<Employee> Employees { get; set; }
    }
    public class CompanyForUpdateDto : CompanyForCreationDto
    {
        public int cId { get; set; }
    }
}
    

