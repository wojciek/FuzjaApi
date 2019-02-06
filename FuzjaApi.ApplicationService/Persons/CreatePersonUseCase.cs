using Common.Infrastructure.CQRS;
using EnsureThat;
using FuzjaApi.Domain.Models;
using FuzjaApi.Domain.Persons;
using FuzjaApi.Domain.UnitOfWork;
using FuzjaApi.Models.Commands.Persons;

namespace FuzjaApi.ApplicationService.Persons
{
    public class CreatePersonUseCase : ICommandHandler<CreatePersonCommand>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonUseCase(IPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            Ensure.That(personRepository, nameof(personRepository)).IsNotNull();
            Ensure.That(unitOfWork, nameof(unitOfWork)).IsNotNull();

            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
        }

        public void Handle(CreatePersonCommand command)
        {
            Ensure.That(command, nameof(command)).IsNotNull();

            _personRepository.Store(new Person(command.Name, command.City, command.IsActive, command.Salary, command.Car));
            _unitOfWork.Save();

        }
    }
}
