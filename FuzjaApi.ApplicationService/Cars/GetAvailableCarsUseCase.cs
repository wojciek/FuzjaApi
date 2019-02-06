using System.Collections.Generic;
using FuzjaApi.Models.Queries.Cars;

namespace FuzjaApi.ApplicationService.Cars
{
    public class GetAvailableCarsUseCase
    {
        private readonly IAvailableCarsQuery _availableCarsQuery;

        public GetAvailableCarsUseCase(IAvailableCarsQuery availableCarsQuery)
        {
            _availableCarsQuery = availableCarsQuery;
        }


        public List<AvailableCarsDTO> Handle(int queryCriteria)
        {
            return _availableCarsQuery.GetAvailableCars(queryCriteria);
        }
    }
}
