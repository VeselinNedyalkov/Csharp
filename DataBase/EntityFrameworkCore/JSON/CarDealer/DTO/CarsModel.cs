using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class CarsModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int TravelledDistance { get; set; }
        public IEnumerable<int> PartsId { get; set; }
    }
}
