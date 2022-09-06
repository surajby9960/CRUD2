using CRUD2.Model;

namespace CRUD2.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<int> AddNewEmployee(CreateEmployee employee);
    }
}
