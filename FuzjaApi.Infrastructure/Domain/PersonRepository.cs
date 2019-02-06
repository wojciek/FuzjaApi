using System;
using System.Linq;
using EnsureThat;
using FuzjaApi.Domain.Models;
using FuzjaApi.Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace FuzjaApi.Infrastructure.Domain
{
    public class PersonRepository : IPersonRepository
    {
        private readonly FuzjaApiDbContext _context;

        public PersonRepository(FuzjaApiDbContext context)
        {
            Ensure.That(context, nameof(context)).IsNotNull();

            _context = context;
        }

        public void Store(Person person)
        {
            try
            {
                _context.Persons.Add(person);
            }
            catch (Exception exceptionEF)
            {
                throw new Exception(exceptionEF.Message);
            }
        }

        public Person Find(int personId)
        {
            Person person = _context.Persons.Include(p => p.Car).FirstOrDefault(x => x.Id == personId);

            Ensure.That(person, nameof(person)).IsNotNull();
            return person;

        }


        public void Delete(Person person)
        {
            _context.Persons.Remove(person);
        }
    }
}
