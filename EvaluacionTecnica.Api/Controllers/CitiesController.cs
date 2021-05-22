using EvaluacionTecnica.Repository.Cities;
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
    public class CitiesController : ControllerBase
    {
        private CitiesRepository citiesRepo;
        public CitiesController(IConfiguration config) {
            citiesRepo = new CitiesRepository(config);
        }
        // GET: api/<CitiesController>
        [HttpGet]
        public List<CityDto> Get()
        {
            return citiesRepo.GetAll();
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        public CityDto Get(int id)
        {
            return citiesRepo.GetById(id);
        }

        // POST api/<CitiesController>
        [HttpPost]
        public int Post([FromBody] CityDto city)
        {
            return citiesRepo.Save(city);
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        public CityDto Put(int id, [FromBody] CityDto city)
        {
            city.CityID = id;
            return citiesRepo.Update(city);
        }

        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return citiesRepo.Delete(id);
        }
    }
}
