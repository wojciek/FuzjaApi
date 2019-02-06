using System.Linq;
using EnsureThat;
using FuzjaApi.ApplicationService.Persons;
using FuzjaApi.Models.Queries.Persons;
using Microsoft.EntityFrameworkCore;

namespace FuzjaApi.Infrastructure.Query
{
    public class GetPersonDataQuery : IPersonDataQuery
    {
        private readonly FuzjaApiDbContext _context;

        public GetPersonDataQuery(FuzjaApiDbContext context)
        {
            _context = context;
        }

        public PersonsDTO GetPersonData(PersonIdQueryParameter queryCriteria)
        {
            Ensure.That(queryCriteria.ToString(), nameof(queryCriteria)).IsNotNull();

            return _context.Persons.Select(person => new PersonsDTO()
            {
                Id = person.Id,
                Car = person.Car,
                City = person.City,
                IsActive = person.IsActive,
                Salary = person.Salary,
                Name = person.Name
            }).Include(p => p.Car).FirstOrDefault(a => a.Id == queryCriteria.PersonIdQuery);
        }
    }
}
