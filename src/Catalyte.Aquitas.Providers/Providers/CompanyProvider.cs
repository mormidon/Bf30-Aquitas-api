using AutoMapper;
using Catalyte.Aquitas.Data.Interfaces;
using Catalyte.Aquitas.Data.Model;
using Catalyte.Aquitas.DTOs.Company;
using Catalyte.Aquitas.Providers.Interfaces;
using Catalyte.Aquitas.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Providers.Providers
{
    public class CompanyProvider : ICompanyProvider
    {

        private readonly ICompanyRepository _companyRepository;
        private readonly Mapper _mapper;

        public CompanyProvider(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
            _mapper = InitializeMapper();
        }

        public async Task<ProviderResponse<List<CompanyDTO>>> GetCompaniesAsync()
        {
            var companies = await _companyRepository.GetCompaniesAsync();

            return new ProviderResponse<List<CompanyDTO>>(
                _mapper.Map<List<CompanyDTO>>(companies.ToList()),
                ResponseTypes.Success,
                Constants.Success);
        }

        public async Task<ProviderResponse<CompanyDTO>> GetCompanyByIdAsync(int companyId)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(companyId);

            return company == default
                ? new ProviderResponse<CompanyDTO>(
                    null,
                    ResponseTypes.NotFound,
                    $"Product with Id:{companyId} not found")
                : new ProviderResponse<CompanyDTO>(
                    _mapper.Map<CompanyDTO>(company),
                    ResponseTypes.Success,
                    Constants.Success);
        }

        public async Task<ProviderResponse<CompanyDTO>> CreateCompanyAsync(CompanyDTO companyDTO)
        {
            var company = _mapper.Map<Company>(companyDTO);
            var savedCompany = await _companyRepository.CreateCompanyAsync(company);

            return new ProviderResponse<CompanyDTO>(
                _mapper.Map<CompanyDTO>(savedCompany),
                ResponseTypes.Created,
                Constants.Success);
        }

        private Mapper InitializeMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company, CompanyDTO>().ReverseMap();
            }));
        }
    }
}
