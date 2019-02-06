using Common.Infrastructure.CQRS;
using FuzjaApi.Domain.Models;

namespace FuzjaApi.Models.Commands.Persons
{
    public class CreatePersonCommand : ICommand
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Salary { get; set; }

        public bool IsActive { get; set; }

        public Car Car { get; set; }
    }
}
