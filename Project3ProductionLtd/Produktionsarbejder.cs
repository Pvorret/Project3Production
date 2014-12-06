using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3ProductionLtd {
    class Produktionsarbejder {
        public string Name { get; set; }
        public List<Machine> machineList { get; set; }

        public Produktionsarbejder(string name) {
            Name = name;
        }
    }
}
