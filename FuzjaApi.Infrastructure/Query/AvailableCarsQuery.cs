using System;
using System.Collections.Generic;
using System.Linq;
using FuzjaApi.ApplicationService.Cars;
using FuzjaApi.Models.Queries.Cars;

namespace FuzjaApi.Infrastructure.Query
{
    public class AvailableCarsQuery : IAvailableCarsQuery
    {
        private readonly FuzjaApiDbContext _context;

        public AvailableCarsQuery(FuzjaApiDbContext context)
        {
            _context = context;
        }

        public List<AvailableCarsDTO> GetAvailableCars(int queryCriteria)
        {
            List<AvailableCarsDTO> results = null;
            if (queryCriteria == 0)
            {
                return results = (from cars in _context.Cars
                                  where !(from persons in _context.Persons
                                          select persons.Car.Id).Contains(cars.Id)
                                  select cars).Select(cars => new AvailableCarsDTO()
                                  {
                                      Id = cars.Id,
                                      CarName = cars.CarName,
                                      CarPublicationDate = cars.CarPublicationDate
                                  }).ToList();
            }
            else
            {
                return results = (from cars in _context.Cars
                                  where !(from persons in _context.Persons
                                          where persons.Id != queryCriteria
                                          select persons.Car.Id).Contains(cars.Id)
                                  select cars).Select(cars => new AvailableCarsDTO()
                                  {
                                      Id = cars.Id,
                                      CarName = cars.CarName,
                                      CarPublicationDate = cars.CarPublicationDate
                                  }).ToList();
            }



        }
    }
}
