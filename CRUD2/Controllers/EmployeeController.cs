using CRUD2.Model;
using CRUD2.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(CreateEmployee employee)
        {
            var res=await _repo.AddNewEmployee(employee);
            return Ok(res);
        }
    }
}
