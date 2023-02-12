using System.Data;
using XpandCrewAPI.Model;

namespace XpandPlanetAPI.Services
{
    public class CrewService : ICrewService
    {
        private readonly HttpClient _client;
        private string _crewUrl;

        public CrewService(HttpClient client, IConfiguration _configuration)
        {
            _crewUrl = _configuration.GetValue<string>("AppSettings:CrewURL");
            _client = client;
        }
        public async Task<int> GetCrewIdByCaptainId(int captainID)
        {
            var response = await _client.GetAsync($"{_crewUrl}/{captainID}");

            Crew crew = await response.Content.ReadAsAsync<Crew>();

            return crew.CrewID;
        }
    }
}
