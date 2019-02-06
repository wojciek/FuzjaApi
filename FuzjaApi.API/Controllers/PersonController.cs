using System.Collections.Generic;
using EnsureThat;
using FuzjaApi.ApplicationService.Cars;
using FuzjaApi.ApplicationService.Persons;
using FuzjaApi.Models.Commands.Persons;
using FuzjaApi.Models.Queries.Cars;
using FuzjaApi.Models.Queries.Persons;
using Microsoft.AspNetCore.Mvc;

namespace FuzjaApi.API.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class PersonController : Controller
    {
        private readonly GetPersonsUseCase _getPersonsUseCase;
        private readonly GetAvailableCarsUseCase _getAvailableCarsUseCase;
        private readonly GetPersonDataUseCase _getPersonDataUseCase;
        private readonly CreatePersonUseCase _createPersonUseCase;

        public PersonController(
            GetPersonsUseCase getPersonsUseCase,
            GetAvailableCarsUseCase getAvailablecarsUseCase,
            GetPersonDataUseCase getPersonDataUseCase,
            CreatePersonUseCase createPersonUseCase)
        {
            Ensure.That(getPersonsUseCase, nameof(getPersonsUseCase)).IsNotNull();
            Ensure.That(getAvailablecarsUseCase, nameof(getAvailablecarsUseCase)).IsNotNull();
            Ensure.That(getPersonDataUseCase, nameof(getPersonDataUseCase)).IsNotNull();
            Ensure.That(createPersonUseCase, nameof(createPersonUseCase)).IsNotNull();

            _getPersonsUseCase = getPersonsUseCase;
            _getAvailableCarsUseCase = getAvailablecarsUseCase;
            _getPersonDataUseCase = getPersonDataUseCase;
            _createPersonUseCase = createPersonUseCase;
        }

        [HttpGet]
        [Route("persons")]
        public IList<PersonsDTO> GetPersons()
        {
            return _getPersonsUseCase.Handle();
        }

        [HttpGet]
        [Route("persons/{personIdQuery}/available-cars")]
        public ICollection<AvailableCarsDTO> GetAvailableCars([FromRoute] int personIdQuery)
        {
            return _getAvailableCarsUseCase.Handle(personIdQuery);
        }

        [HttpGet]
        [Route("persons/{personIdQuery}")]
        public PersonsDTO GetPerson(PersonIdQueryParameter getPersonParamter)
        {
            return _getPersonDataUseCase.Handle(getPersonParamter);
        }

        [HttpPost]
        [Route("person")]
        public void CreateNewPerson([FromBody] CreatePersonCommand command)
        {
            _createPersonUseCase.Handle(command);
        }

        [HttpPut]
        [Route("person/{id}")]
        public void UpdatePerson([FromBody] UpdatePersonCommand command)
        {
            
        }


        [HttpDelete]
        [Route("Person/{personIdQuery}")]
        public void DeletePerson(PersonIdQueryParameter getPersonToDeleteParameter)
        {

        }


        //    Person personToDelete = _context.Persons.Find(id);



        //    //Ensure.That(personToDelete).IsNotNull();

        //    _context.Persons.Remove(personToDelete);

        //    _context.SaveChanges();
        //}







        //[HttpPut]
        //[Route("person/{id}")]
        //public void UpdatePerson([FromBody] PersonDTO personDTO)
        //{

        //    var personObject = _context.Persons.FirstOrDefault(p => p.Id == personDTO.Id);

        //    var carObject = _context.Cars.FirstOrDefault(car => car.Id == personDTO.Car);
        //    Ensure.That(personDTO, nameof(personDTO)).IsNotNull();
        //    Ensure.That(personObject, nameof(personObject)).IsNotNull();
        //    Ensure.That(carObject, nameof(carObject)).IsNotNull();

        //    //dodanie sporawdzania czy osoba istnieje Ensure
        //    personObject.Id = personDTO.Id;
        //    personObject.Name = personDTO.Name;
        //    personObject.City = personDTO.City;
        //    personObject.IsActive = personDTO.IsActive;
        //    personObject.PersonPublicationDate = DateTime.Now;
        //    personObject.Salary = personDTO.Salary;
        //    personObject.Car = carObject;
        //    _context.SaveChanges();
        //}

        //[HttpDelete]
        //[Route("Person/{id}")]
        //public void DeletePerson([FromRoute] int id)
        //{

        //    Person personToDelete = _context.Persons.Find(id);



        //    //Ensure.That(personToDelete).IsNotNull();

        //    _context.Persons.Remove(personToDelete);

        //    _context.SaveChanges();
        //}

        //private bool PersonExists(int id)
        //{
        //    return _context.Persons.Any(e => e.Id == id);
        //}
    }
}