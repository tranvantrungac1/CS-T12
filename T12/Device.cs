using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T12
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Device()
        {
        }

        public Device(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
        public override string? ToString()
        {
            return $"{Id} {Name} {Quantity}";
        }
    }
}
