using CRUD2.Context;
using CRUD2.Model;
using CRUD2.Repositories.Interfaces;
using Dapper;

namespace CRUD2.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DapperContext context;
        public EmployeeRepository(DapperContext context)
        {
            this.context = context;
        }
     
        public async Task<int> AddNewEmployee(CreateEmployee employee)
        {
            var query = @"INSERT INTO Employee(eName,eAge,ePosition,cId) 
                          VALUES (@eName,@eAge,@ePosition,@cId)";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, employee);
                return result;

            }
        }
    }
}
