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
    public class Product
    {
        public string Name { get; set; }
        public DateTime OverallTime { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Spacing { get; set; }
        public string Material { get; set; }
        public double durability { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }

        public List<Machine> machineList = new List<Machine>();
    }
}
