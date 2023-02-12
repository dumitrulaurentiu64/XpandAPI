namespace XpandPlanetAPI.Model
{
    //public enum StatusEnum
    //{
    //    TODO = 1,
    //    EnRoute = 2,
    //    OK = 3,
    //    NotOK = 4
    //}
    public class Planet
    {
        public int PlanetID { get; set; }
        public string PlanetName { get; set; }
        public string PlanetDescription { get; set; }
        public string ImagePath { get; set; }
        public int PlanetStatus { get; set; }
        public int CrewID { get; set; }
    }
}
