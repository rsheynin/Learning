using System;
using System.Collections.Generic;
using TaxiFair.Domain;
using TaxiFair.Domain.Repository;

namespace TaxiFair.Application.Repository
{
    public class CarRepository : ICarRepository
    {
        public IEnumerable<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public Car Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}