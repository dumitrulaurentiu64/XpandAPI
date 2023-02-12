using XpandPlanetAPI.Model;

namespace XpandPlanetAPI.Repositories
{
    public interface IPlanetRepository
    {
        public List<Planet> GetAll();
        public Planet Update(Planet planet);

        public Planet Find(int id);
    }
}
