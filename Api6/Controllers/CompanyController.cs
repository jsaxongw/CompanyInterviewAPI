using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Api6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var startingData = JsonSerializer.Deserialize<List<CompanyModel>>(System.IO.File.ReadAllText("StartingData.json"), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            return Ok(startingData);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([Required] string id)
        {
            var startingData = JsonSerializer.Deserialize<List<CompanyModel>>(System.IO.File.ReadAllText("StartingData.json"), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            var data = new Dictionary<string, CompanyModel>(startingData.ToDictionary(company => company.Id));

            var company = data[id];

            _logger.LogInformation("Retrieved Company {id}", id);
            return Ok(company);
        }

        [HttpPost]
        [Route("/actions/buyout")]
        public IActionResult BuyoutCompany([FromBody] BuyoutRequest buyoutRequest)
        {
            var startingData = JsonSerializer.Deserialize<List<CompanyModel>>(System.IO.File.ReadAllText("StartingData.json"), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            var data = new Dictionary<string, CompanyModel>(startingData.ToDictionary(company => company.Id));

            var parentCompany = data[buyoutRequest.ParentCompanyId];
            var childCompany = data[buyoutRequest.ChildCompanyId];

            childCompany.ParentId = parentCompany.Id;
            childCompany.CompanyName += " Now Owned By " + parentCompany.CompanyName;
            childCompany.Phone += ", " + parentCompany.Phone;

            _logger.LogInformation("Buyout Succeeded Parent: {parent}, Child: {child}", parentCompany.Id, childCompany.Id);

            return Ok();
        }
    }
}