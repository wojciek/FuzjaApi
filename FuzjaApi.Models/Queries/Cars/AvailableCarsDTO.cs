using System;

namespace FuzjaApi.Models.Queries.Cars
{
    public class AvailableCarsDTO
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public DateTime CarPublicationDate { get; set; }
    }
}
