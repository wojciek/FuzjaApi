using Common.Infrastructure.CQRS;
using EnsureThat;
using FuzjaApi.Models.Queries.Persons;

namespace FuzjaApi.ApplicationService.Persons
{
    public class GetPersonDataUseCase : IQueryHandler<PersonIdQueryParameter, PersonsDTO>
    {
        private readonly IPersonDataQuery _personDataQuery;

        public GetPersonDataUseCase(IPersonDataQuery personDataQuery)
        {
            Ensure.That(personDataQuery, nameof(personDataQuery)).IsNotNull();

            _personDataQuery = personDataQuery;
        }

        public PersonsDTO Handle(PersonIdQueryParameter queryCriteria)
        {
            return _personDataQuery.GetPersonData(queryCriteria);
        }
    }
}
