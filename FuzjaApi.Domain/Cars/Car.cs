using System;

namespace FuzjaApi.Domain.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string CarName { get; set; }

        public DateTime CarPublicationDate { get; set; }
    }
}
