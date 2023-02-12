namespace XpandCrewAPI.Model
{
    public class Crew
    {
        public string CrewID { get; set; }
        public string CrewName { get; set; }
        public string ShuttleID { get; set; }
        public string CaptainFullname { get; set; }
        public List<Robot> robots { get; set; }
    }
}
