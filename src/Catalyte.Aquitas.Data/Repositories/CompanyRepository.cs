using Catalyte.Aquitas.Data.Context;
using Catalyte.Aquitas.Data.Interfaces;
using Catalyte.Aquitas.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {

        private readonly IApparelCtx _ctx;

        public CompanyRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _ctx.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int companyId)
        {
            return await _ctx.Companies.FindAsync(companyId);
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            await _ctx.Companies.AddAsync(company);
            await _ctx.SaveChangesAsync();

            return company;
        }
    }
}
