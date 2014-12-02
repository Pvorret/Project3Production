using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3ProductionLtd
{
    class Order
    {
        public Order(DateTime deadline, double width, double height, double spacing)
        {
            Deadline = deadline;
            Width = width;
            Height = height;
            Spacing = spacing;
        }
        public Order(DateTime deadline, List<Product> products)
        {
            Deadline = deadline;
            _products = products;
        }
        public DateTime Deadline { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Spacing { get; set; }
        public List<Product> _products { get; set; }
    }
}
