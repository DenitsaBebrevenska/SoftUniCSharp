using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Engine
    {
        public string Model { get; set; }
        public int Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine()
        {
            Displacement = "n/a";
            Efficiency = "n/a";
        }
        public Engine(string model, int power) : this()
        {
            Model = model;
            Power = power;
        }

        public override string ToString()
        {
            return $"{Model}:\r\n" +
                   $"   Power: {Power}\r\n" +
                   $"   Displacement: {Displacement}\r\n" +
                   $"   Efficiency: {Efficiency}";

        }
    }
}
