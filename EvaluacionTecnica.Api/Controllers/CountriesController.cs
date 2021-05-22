using EvaluacionTecnica.Repository.Countries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EvaluacionTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private  CountriesRepository countryRepo;
        public CountriesController(IConfiguration config) {
            countryRepo = new CountriesRepository(config);
        }

        [HttpGet]
        public List<CountryDto> Get()
        {
            return countryRepo.GetAll();
        }

        [HttpGet("{id}")]
        public CountryDto Get(int id)
        {
            return countryRepo.GetById(id);
        }

        [HttpPost]
        public int Post([FromBody] CountryDto country)
        {
            return countryRepo.Save(country);
        }

        [HttpPut("{id}")]
        public CountryDto Put(int id, [FromBody] CountryDto country)
        {
            country.CountryID = id;
            return countryRepo.Update(country);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return countryRepo.Delete(id);
        }
    }
}
