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
    static class Controller
    {
        public static List<Order> orderList;
        /*
        public bool setOrderAsConfirmed()
        {
            order = new Order();
            bool orderConfirmed;
        }
        */
        /*
        public Order printOrderList()
        { }
         */
        public static SqlConnection connectToSql()
        {
            SqlConnection connect = new SqlConnection(
                "Server=ealdb1.eal.local;" +
                "Database=EJL01_DB;" +
                "User Id=ejl01_usr;" +
                "Password=Baz1nga1"
                );
            return connect;

        }
        public static int logIn(string inuserName, string inpassword)
        {
            string userName = inuserName;
            string password = inpassword;
            SqlConnection connect = connectToSql();

            try
            {
                connect.Open();

                SqlCommand sqlCmd = new SqlCommand("getLoginId", connect);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                
                sqlCmd.Parameters.Add(new SqlParameter("@UserName", userName));
                sqlCmd.Parameters.Add(new SqlParameter("@Password", password));

                SqlDataReader reader = sqlCmd.ExecuteReader();

                reader.Read(); //Gør at den faktisk kan læse outputtet fra databasen
                
                int id = int.Parse(Convert.ToString(reader["Id"]));
                
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                connect.Close();
                connect.Dispose();
            }
        }
        

        public static List<Order> getOrdersFromDatabaseToOrderList()
        {
            SqlConnection connect = connectToSql();
            orderList = new List<Order>();
            try
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("ReturnOrderInformation", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                Order order = new Order();

                reader = sqlCmd.ExecuteReader();
                int i = -1;
                while(reader.Read())
                {
                    order.productList.Add(new Product() { Name = Convert.ToString(reader["ProductNo1"]), Amount = Convert.ToInt32(reader["AmountNo1"]) });
                    order.productList.Add(new Product() { Name = Convert.ToString(reader["ProductNo2"]), Amount = Convert.ToInt32(reader["AmountNo2"]) });

                    i++;
                    Order newOrder = new Order()
                    {
                        Deadline = Convert.ToDateTime(reader["Deadline"]),
                        Width = Convert.ToDecimal(reader["Width"]),
                        Height = Convert.ToDecimal(reader["Height"]),
                        Spacing = Convert.ToDecimal(reader["Spacing"]),
                        
                        OrderProductName1 = order.productList[i].Name,
                        OrderProductAmount1 = order.productList[i].Amount,
                        OrderProductName2 = order.productList[i].Name,
                        OrderProductAmount2 = order.productList[i].Amount,
                        
                        Price = Convert.ToDecimal(reader["Price"]),
                        OrderName = Convert.ToString(reader["OrderName"])
                    };
                    orderList.Add(newOrder);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connect.Close();
                connect.Dispose();
            }
            return orderList;
        }
    }
}
