using Common.Infrastructure.CQRS;
using EnsureThat;
using FuzjaApi.Domain.Persons;
using FuzjaApi.Domain.UnitOfWork;
using FuzjaApi.Models.Queries.Persons;

namespace FuzjaApi.ApplicationService.Persons
{
    public class DeletePersonUseCase : ICommandHandler<PersonIdQueryParameter>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonUseCase(IPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            Ensure.That(personRepository, nameof(personRepository)).IsNotNull();
            Ensure.That(unitOfWork, nameof(unitOfWork)).IsNotNull();

            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
        }
        public void Handle(PersonIdQueryParameter personId)
        {

            _personRepository.Delete(_personRepository.Find(personId.PersonIdQuery));
            _unitOfWork.Save();
        }
    }
}
