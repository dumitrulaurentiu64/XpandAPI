using Dapper;
using System.Data;
using System.Data.SqlClient;
using XpandPlanetAPI.Model;
using XpandPlanetAPI.Services;

namespace XpandPlanetAPI.Repositories
{
    public class PlanetRepository : IPlanetRepository
    {
        private IDbConnection _db;
        private readonly ICrewService _crewService;

        public PlanetRepository(IConfiguration _configuration, ICrewService crewService)
        {
            _db = new SqlConnection(_configuration.GetConnectionString("ExplorationAppCon"));
            _crewService = crewService;
        }
        public List<Planet> GetAll()
        {
            return _db.Query<Planet>("SELECT * FROM Planet").ToList();
        }

        public Planet Find(int id)
        {
            var planet = this._db.Query<Planet>("SELECT * FROM Planet where PlanetID = @Id", new { id }).SingleOrDefault();
            return planet;
        }

        public Planet Update(Planet planet)
        {
            var response = _crewService.GetCrewIdByCaptainId(planet.CrewID);

            planet.CrewID = response.Result;

            string sql =
               "UPDATE Planet " +
               "SET PlanetDescription = @PlanetDescription, " +
               "PlanetStatus = @PlanetStatus, " +
               "CrewID = @CrewID " +
               "WHERE PlanetID = @PlanetID";
            _db.Execute(sql, planet);
            return planet;
        }
    }
}
