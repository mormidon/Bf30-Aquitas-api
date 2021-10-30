using Catalyte.Aquitas.DTOs.Company;
using Catalyte.Aquitas.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Providers.Interfaces
{
    public interface ICompanyProvider
    {
        Task<ProviderResponse<List<CompanyDTO>>> GetCompaniesAsync();

        Task<ProviderResponse<CompanyDTO>> GetCompanyByIdAsync(int companyId);

        Task<ProviderResponse<CompanyDTO>> CreateCompanyAsync(CompanyDTO companyDTO);
    }
}
