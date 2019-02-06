using Common.Infrastructure.CQRS;

namespace FuzjaApi.Models.Queries.Persons
{
    public class PersonIdQueryParameter : IQuery<PersonsDTO>, ICommand
    {
        public int PersonIdQuery { get; set; }
    }
}
