namespace ProjectManagement.Application.Contracts.City
{
    public class CityViewModel
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public ushort Scope { get; set; }
        public string State { get; set; }
        public string Position { get; set; }
        public string Province { get; set; }
        public string CreationDate { get; set; }
        public string CurrentTemperature { get; set; }
    }
}
