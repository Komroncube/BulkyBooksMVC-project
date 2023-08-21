namespace firstdemo.Interfaces
{
    public interface ICompanyRepository
    {
        public Task CreateCompanyAsync(Company company);
        public Task<bool> DeleteCompanyAsync(int company);
        public Task<Company> GetCompanyByIdAsync(int companyId);
        public Task<List<Company>> GetCompanies();
    }
}
