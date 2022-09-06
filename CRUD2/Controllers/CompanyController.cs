using CRUD2.Model;
using CRUD2.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _repo;
        public CompanyController(ICompanyRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var comp = await _repo.GetCompanies();
                return Ok(comp); 
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("id")]
        public async Task <IActionResult> GetCompanyById(int id)
        {
            try
            {
                var company = await _repo.GetCompanyById(id);
                return Ok(company);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> InsertCompany(CompanyForCreationDto companyForCreationDto)
        {
            try
            {
                var res=await _repo.InsertCompany(companyForCreationDto);
                return Ok(res);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCompany(CompanyForUpdateDto companyForUpdateDto)
        {
            try
            {
                var res = await _repo.UpdateCompany(companyForUpdateDto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            { 
                var res=await _repo.DeleteCompany(id);
                return Ok(res);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        

    }
}
