using Dapper;
using System.Data;
using System.Data.SqlClient;
using XpandCrewAPI.Model;

namespace XpandCrewAPI.Repositories
{
    public class CrewRepository : ICrewRepository
    {
        private IDbConnection _db;

        public CrewRepository(IConfiguration _configuration)
        {
            this._db = new SqlConnection(_configuration.GetConnectionString("ExplorationAppCon"));
        }

        public Crew Find(int id)
        {
            var crew = this._db.Query<Crew>("SELECT * FROM Crew where CrewID = @Id", new { id }).SingleOrDefault();

            var robots = this._db.Query<Robot>("SELECT * FROM Robot where CrewID = @Id", new { id }).ToList();

            crew.robots = robots;

            return crew;
        }
    }
}
