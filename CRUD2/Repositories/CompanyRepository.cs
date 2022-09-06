using CRUD2.Context;
using CRUD2.Model;
using CRUD2.Repositories.Interfaces;
using Dapper;

namespace CRUD2.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteCompany(int Id)
        {
            var qry = "delete from Company where cId=@id";
            using(var conn=_context.CreateConnection())
            {
                var res = await conn.ExecuteAsync(qry, new { Id });
                return res;
            }
            
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            List<Company> companies = new List<Company>();
            var query = "SELECT * FROM Company";

            using (var connection = _context.CreateConnection())
            {
                var comp = await connection.QueryAsync<Company>(query);
                companies= comp.ToList();
                foreach(var company in companies)
                {
                    var qry = "select * from Employee where cid=@cid";
                    var emp=await connection.QueryAsync<Employee>(qry,new {@cid=company.cId });
                     company.Employees=emp.ToList();
                }
                return companies;
            }
        }

        public async Task<Company> GetCompanyById(int Id)
        {
            var comp=new Company(); 
            var qry = "Select * from Company where cId=@id";
            using( var conn=_context.CreateConnection())
            {
                comp = await conn.QueryFirstOrDefaultAsync<Company>(qry, new { Id });
                var emp=await conn.QueryAsync<Employee>("select * from Employee where cid=@cid", new {@cid= Id });
                comp.Employees=emp.ToList();
            }
            return comp;
        }

        public async Task<int> InsertCompany(CompanyForCreationDto companyForCreationDto)
        {
            var qry = @"insert into Company(cName,cAddress,cCountry)values(@cName,@cAddress,@cCountry);
                      SELECT CAST(SCOPE_IDENTITY() as int)";
            using (var conn = _context.CreateConnection())
            {
                var res = await conn.QuerySingleAsync<int>(qry, companyForCreationDto);
                if(res!=0)
                {
                    var result1 = await AddEmployee(companyForCreationDto.Employees, res);
                }
                return res;
            }
        }
        public async Task<int> AddEmployee(List<Employee> employees, int CompanyId)
        {
            int result = 0;
            using (var connection = _context.CreateConnection())
            {
                if (employees.Count > 0)
                {
                    foreach (Employee employee in employees)
                    {
                        employee.cId = CompanyId;
                        var query = @"INSERT INTO Employee(eName,eAge,ePosition,cId) 
                          VALUES (@eName,@eAge,@ePosition,@cId)";
                        var result1 = await connection.ExecuteAsync(query, employee);
                        result = result + result1;
                    }
                }
                return result;
            }
        }

        public async Task<int> UpdateCompany(CompanyForUpdateDto companyForUpdateDto)
        {
            //int res = 0;
            var qry = "update Company set cName=@cName,cAddress=@cAddress,cCountry=@cCountry where cId=@cId";

            using(var conn = _context.CreateConnection())
            {
                var res=await conn.ExecuteAsync(qry,companyForUpdateDto);
                if (res != 0)
                {
                   var result = await conn.ExecuteAsync(@"delete from Employee where cId=@cId"
                                                           , new { cId = companyForUpdateDto.cId });
                    var result1 = await AddEmployee(companyForUpdateDto.Employees, companyForUpdateDto.cId);
                }
                return res;
            }
        }
       

    }
}

