using System.Collections.Generic;
using FuzjaApi.Models.Queries.Persons;

namespace FuzjaApi.ApplicationService.Persons
{
    public interface IPersonsQuery
    {
        List<PersonsDTO> GetPersons();
        bool CheckIfPersonExist(int personId);
    }
}
