using Catalyte.Aquitas.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Data.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompanyByIdAsync(int companyId);

        Task<IEnumerable<Company>> GetCompaniesAsync();

        Task<Company> CreateCompanyAsync(Company company);
    }
}
