namespace firstdemo.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext dbcontext;

        public CompanyRepository(AppDbContext appDbContext)
        {
            this.dbcontext=appDbContext;
        }

        public async Task CreateCompanyAsync(Company company)
        {
            await dbcontext.Companies.AddAsync(company);
            await dbcontext.SaveChangesAsync();
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            var company = await dbcontext.Companies.FirstOrDefaultAsync(x=>x.Id==id);
            if(company is null)
            {
                return false;
            }

            dbcontext.Companies.Remove(company);
            await dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Company>> GetCompanies()
        {
            var companies = await dbcontext.Companies.ToListAsync();
            return companies;
        }

        public async Task<Company> GetCompanyByIdAsync(int companyId)
        {
            var company = await dbcontext.Companies.FirstOrDefaultAsync(i=>i.Id==companyId);
            return company;
        }
    }
}
