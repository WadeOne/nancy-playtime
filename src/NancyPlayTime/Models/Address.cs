namespace NancyPlayTime.Models
{
    public class Address
    {
        public string City { get; set; }
        
        public string Street { get; set; }

        public int BuildingNumber { get; set; }

        public ResidenceType ResidenceType { get; set; }
    }
}