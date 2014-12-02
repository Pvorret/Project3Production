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
        public double Width { get; set; }
        public double Height { get; set; }
        public double Spacing { get; set; }
        public List<Product> _products { get; set; }
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
        /*
        public Order()
        {
            SqlConnection connect = new SqlConnection(
                "Server=ealdb1.eal.local;" +
                "Database=EJL01_DB;" +
                "User Id=ejl01_usr;" +
                "Password=Baz1nga1"
                );
            try
            {
                connect.Open();

                SqlCommand sqlCmd = new SqlCommand("getLoginId", connect);

                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add(new SqlParameter("@UserName", userName));
                sqlCmd.Parameters.Add(new SqlParameter("@Password", password));

                SqlDataReader reader = sqlCmd.ExecuteReader();

                reader.Read(); //Gør at den faktisk kan læse outputtet fra databasen
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                
            }
         
        }
         */ 
    }
}
