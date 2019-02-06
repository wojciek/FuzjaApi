using Common.Infrastructure.CQRS;
using EnsureThat;
using FuzjaApi.Domain.Models;
using FuzjaApi.Domain.Persons;
using FuzjaApi.Domain.UnitOfWork;
using FuzjaApi.Models.Commands.Persons;

namespace FuzjaApi.ApplicationService.Persons
{
    public class UpdatePersonUseCase : ICommandHandler<UpdatePersonCommand>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonsQuery _personsQuery;

        public UpdatePersonUseCase(IPersonRepository personRepository, IUnitOfWork unitOfWork, IPersonsQuery personsQuery)
        {
            Ensure.That(personRepository, nameof(personRepository)).IsNotNull();
            Ensure.That(unitOfWork, nameof(unitOfWork)).IsNotNull();
            Ensure.That(personsQuery, nameof(personsQuery)).IsNotNull();

            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _personsQuery = personsQuery;
        }


        public void Handle(UpdatePersonCommand command)
        {
            bool isUserExist = _personsQuery.CheckIfPersonExist(command.Id);

            Ensure.That(isUserExist, nameof(isUserExist)).IsTrue();

            Person person = _personRepository.Find(command.Id);

            person.Update(
                command.Name,
                command.City,
                command.IsActive,
                command.Salary,
                command.Car);

            _unitOfWork.Save();


        }
    }
}
