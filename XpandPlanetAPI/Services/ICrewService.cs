namespace XpandPlanetAPI.Services
{
    public interface ICrewService
    {
        public Task<int> GetCrewIdByCaptainId(int captainID);
    }
}
