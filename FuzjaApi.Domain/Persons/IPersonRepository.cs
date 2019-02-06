using FuzjaApi.Domain.Models;

namespace FuzjaApi.Domain.Persons
{
    public interface IPersonRepository
    {
        void Store(Person person);

        Person Find(int personId);

        void Delete(Person person);
    }
}
