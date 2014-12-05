using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace Project3ProductionLtd
{
    class Machine
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
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
