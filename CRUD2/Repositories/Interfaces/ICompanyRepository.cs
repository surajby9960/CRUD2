using CRUD2.Model;

namespace CRUD2.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
        public Task<Company> GetCompanyById(int id);
        public Task<int> InsertCompany(CompanyForCreationDto companyForCreationDto);
        public Task<int> UpdateCompany(CompanyForUpdateDto companyForUpdateDto);
        public Task<int> DeleteCompany(int id);
      
    }
}
