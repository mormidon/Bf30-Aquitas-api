﻿using Catalyte.Aquitas.DTOs.Company;
using Catalyte.Aquitas.Providers.Interfaces;
using Catalyte.Aquitas.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.API.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {

        private readonly ILogger<CompaniesController> _logger;
        private readonly ICompanyProvider _companyProvider;

        public CompaniesController(ILogger<CompaniesController> logger, ICompanyProvider companyProvider)
        {
            _logger = logger;
            _companyProvider = companyProvider;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> GetCompanyByIdAsync(int id)
        {
            var response = await _companyProvider.GetCompanyByIdAsync(id);
            return response.ToActionResult();
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyDTO>>> GetCompaniesAsync()
        {
            var response = await _companyProvider.GetCompaniesAsync();
            return response.ToActionResult();
        }

        [HttpPost]
        public async Task<ActionResult<List<CompanyDTO>>> CreateCompany([FromBody] CompanyDTO companyDTO)
        {
            var result = await _companyProvider.CreateCompanyAsync(companyDTO);

            if (result.ResponseType == ResponseTypes.Created)
            {
                return new CreatedResult($"/purchases/{result.ResponseObject.Name}", result.ResponseObject);
            }

            return result.ToActionResult();
        }
    }
}