using System.Collections.Generic;
using EnsureThat;
using FuzjaApi.Models.Queries.Persons;

namespace FuzjaApi.ApplicationService.Persons
{
    public class GetPersonsUseCase
    {
        private readonly IPersonsQuery _personQuery;

        public GetPersonsUseCase(IPersonsQuery personQuery)
        {
            Ensure.That(personQuery, nameof(personQuery)).IsNotNull();
            _personQuery = personQuery;
        }

        public List<PersonsDTO> Handle()
        {
            return _personQuery.GetPersons();
        }
    }
}
