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
    class Order
    {

        public DateTime Deadline { get; set; }
        public string OrderName { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Spacing { get; set; }
        public decimal Price { get; set; }
        
        public List<Product> product1List = new List<Product>();
        public List<Product> product2List = new List<Product>();
        
        public string OrderProductName1 { get; set; }
        public int OrderProductAmount1 { get; set; }
        public string OrderProductName2 { get; set; }
        public int OrderProductAmount2 { get; set; }
        public int Confirm { get; set; }
        public string CustomerName { get; set; }
        
        public Order(DateTime deadline, decimal width, decimal height, decimal spacing)
        {
            Deadline = deadline;
            Width = width;
            Height = height;
            Spacing = spacing;
        }
        public Order(DateTime deadline, List<Product> product1, List<Product> product2)
        {
            Deadline = deadline;
            product1List = product1;
            product2List = product2;
        }
        
        public Order()
        { 
        
        }
        
     }
}
