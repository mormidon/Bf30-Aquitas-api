using AutoMapper;
using Catalyte.Aquitas.Data.Interfaces;
using Catalyte.Aquitas.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Providers.Providers
{
    public class CompaniesProvider : ICompaniesProvider
    {

        private readonly ICompanyRepository _companyRepository;
        private readonly Mapper _mapper;

        public CompaniesProvider(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
            _mapper = InitializeMapper();
        }

        public Task GetCompaniesAsync()
        {
            var companies = await _productRepository.GetProductsAsync();
        }

        private Mapper InitializeMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
            }));
        }
    }
}
