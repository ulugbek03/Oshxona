using System;
using System.Collections.Generic;

namespace Oshxona.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public List<int> FoodsId { get; set; } = new List<int>();

        public double Money { get; set; }

        public DateTime OrderDate { get; set; }

    }
}
