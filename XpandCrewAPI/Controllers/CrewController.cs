using Microsoft.AspNetCore.Mvc;
using XpandCrewAPI.Repositories;

namespace XpandCrewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrewController : ControllerBase
    {

        private readonly ICrewRepository _crewRepository;

        public CrewController(ICrewRepository crewRepository)
        {
            this._crewRepository = crewRepository;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var crew = _crewRepository.Find(id);
            return new JsonResult(crew);
        }
 
        [HttpGet("getbycaptain/{id}")]
        public JsonResult GetByCaptain(int id)
        {
            var crew = _crewRepository.Find(id);
            return new JsonResult(crew);
        }


    }
}
