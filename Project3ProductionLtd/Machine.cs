using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3ProductionLtd
{
    class Machine
    {
        public string Name { get; set; }
        public DateTime TimeUsed { get; set; }
        public DateTime Deadline { get; set; }

        public string AssignWorker(string machine)
        {
            return "Worker Assigned";
        }
        public bool MachineInUse()
        {
            return true;
        }
    }
}
