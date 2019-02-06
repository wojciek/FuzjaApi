using System.Collections.Generic;
using System.Linq;
using FuzjaApi.ApplicationService.Persons;
using FuzjaApi.Models.Queries.Persons;
using Microsoft.EntityFrameworkCore;

namespace FuzjaApi.Infrastructure.Query
{
    public class PersonsQuery : IPersonsQuery
    {
        private readonly FuzjaApiDbContext _context;

        public PersonsQuery(FuzjaApiDbContext context)
        {
            _context = context;
        }

        public List<PersonsDTO> GetPersons()

        {
            return _context.Persons
                .Include(x => x.Car).Select(r => new PersonsDTO()
                {
                    Id = r.Id,
                    Car = r.Car,
                    City = r.City,
                    IsActive = r.IsActive,
                    Name = r.Name,
                    Salary = r.Salary
                }).ToList();
        }

        public bool CheckIfPersonExist(int personId)
        {
            return _context.Persons.FirstOrDefault(x => x.Id == personId) != null ? true : false;
        }
    }
}
