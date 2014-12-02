using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3ProductionLtd
{
    class Product
    {
        public string Name { get; set; }
        public DateTime OverallTime { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Spacing { get; set; }
        public string Material { get; set; }
        public double durability { get; set; }
        public List<Machine> machineList = new List<Machine>();


        public bool setProdMachineDeadline()
        {


            return true;
        }

    }
}
