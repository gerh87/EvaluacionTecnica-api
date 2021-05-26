using EvaluacionTecnica.Repository.Historical;
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
    public class HistoricalsController : ControllerBase
    {
        private HistoricalRepository historicalRepo;
        public HistoricalsController(IConfiguration config)
        {
            historicalRepo = new HistoricalRepository(config);
        }
    
        [HttpGet("{cityid}")]
        public List<HistoricalInfo> Get(int cityid)
        {
            return historicalRepo.GetHistoricalByCity(cityid);
        }

        [HttpPost]
        public int Post([FromBody] HistoricalDto historical)
        {
            return historicalRepo.Save(historical);
        }

       
    }
}
