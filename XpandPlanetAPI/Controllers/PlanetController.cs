using Microsoft.AspNetCore.Mvc;
using XpandPlanetAPI.Model;
using XpandPlanetAPI.Repositories;

namespace XpandPlanetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetRepository _planetRepository;

        public PlanetController(IPlanetRepository planetRepository)
        {
            this._planetRepository = planetRepository;
        }
        // GET: api/<PlanetController>
        [HttpGet]
        public JsonResult Get()
        {
            var planets = _planetRepository.GetAll();
            return new JsonResult(planets);
        }

        // GET api/<PlanetController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var planets = _planetRepository.Find(id);
            return new JsonResult(planets);
        }

        // PUT api/<PlanetController>/5
        [HttpPut]
        public IActionResult Put(Planet planet)
        {
            _planetRepository.Update(planet);

            return Ok(new
            {
                message = "success"
            });
        }
    }
}
