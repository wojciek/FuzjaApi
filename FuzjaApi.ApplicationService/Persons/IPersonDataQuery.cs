using FuzjaApi.Models.Queries.Persons;

namespace FuzjaApi.ApplicationService.Persons
{
    public interface IPersonDataQuery
    {
        PersonsDTO GetPersonData(PersonIdQueryParameter queryCriteria);
    }
}
