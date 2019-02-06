using System.Collections.Generic;
using FuzjaApi.Models.Queries.Cars;

namespace FuzjaApi.ApplicationService.Cars
{
    public interface IAvailableCarsQuery
    {
        List<AvailableCarsDTO> GetAvailableCars(int queryCriteria);
    }
}
