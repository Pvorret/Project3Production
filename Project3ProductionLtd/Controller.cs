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
        public static List<Product> productList;
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
        public static List<Product> getProductsFromDatabaseToProductList()
        {
            SqlConnection connect = connectToSql();
            productList = new List<Product>();
            try
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("ReturnProductInformation", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    if(!Convert.ToString(reader["Name"]).Contains('S'))
                    {
                        Product product = new Product()
                        {
                            Name = Convert.ToString(reader["Name"]),
                            Width = Convert.ToDecimal(reader["Width"]),
                            Height = Convert.ToDecimal(reader["Height"]),
                            Spacing = Convert.ToDecimal(reader["Spacing"]),
                            Price = Convert.ToDecimal(reader["Price"])
                        };
                        productList.Add(product);
                    }
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
            return productList;
        }

        
        public static List<Product> getRequiredMachineFromProductDB(string productName)
        {
            SqlConnection connect = connectToSql();
            List<Product> productChosenMachineList = new List<Product>();

            try
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("ReturnProductInformation", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                reader = sqlCmd.ExecuteReader();
                
                while (reader.Read())
                {
                    if (Convert.ToString(reader["Name"]).Equals(productName))
                    {
                        Product product = new Product();

                        if (Convert.ToInt32(reader["Standse"]) > 0)
                        {
                            product.machineList.Add(getMachinesFromDb("Standse"));
                        }
                        if (Convert.ToInt32(reader["Svejse"]) > 0)
                        {
                            product.machineList.Add(getMachinesFromDb("Svejse"));
                        }
                        if (Convert.ToInt32(reader["Bukke"]) > 0)
                        {
                            product.machineList.Add(getMachinesFromDb("Bukke"));
                        }
                        if (Convert.ToInt32(reader["Laser"]) > 0)
                        {
                            product.machineList.Add(getMachinesFromDb("Laser"));
                        }
                        if (Convert.ToInt32(reader["CNC"]) > 0)
                        {
                            product.machineList.Add(getMachinesFromDb("CNC"));
                        }
                        if (Convert.ToInt32(reader["Saks"]) > 0)
                        {
                            product.machineList.Add(getMachinesFromDb("Saks"));
                        }
                        if (Convert.ToInt32(reader["Monterings"]) > 0)
                        {
                            product.machineList.Add(getMachinesFromDb("Monterings"));
                        }
                        productChosenMachineList.Add(product);
                    }
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
            return productChosenMachineList;
        }
        public static Machine getMachinesFromDb(string MachineName)
        {
            SqlConnection connect = connectToSql();
            Machine machine = new Machine();
            try
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("ReturnMachines", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    if (MachineName == "Standse" && Convert.ToString(reader["Machines"]).Equals("Standsemaskine"))
                    {
                        if (Convert.ToInt32(reader["MachineId"]).Equals(8))
                        {
                            machine.Name = Convert.ToString(reader["Machines"]);
                        }
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01) && Convert.ToDateTime(reader["EndDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                    }
                    if (MachineName == "Svejse" && Convert.ToString(reader["Machines"]).Equals("Svejsestation"))
                    {
                        if (Convert.ToInt32(reader["MachineId"]).Equals(6))
                        {
                            machine.Name = Convert.ToString(reader["Machines"]);
                        }
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01) && Convert.ToDateTime(reader["EndDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                    }
                    if (MachineName == "Bukke" && Convert.ToString(reader["Machines"]).Equals("Bukkemaskine"))
                    {
                        machine.Name = Convert.ToString(reader["Machines"]);
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01) && Convert.ToDateTime(reader["EndDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                    }
                    if (MachineName == "Laser" && Convert.ToString(reader["Machines"]).Equals("Lasercutter"))
                    {
                        machine.Name = Convert.ToString(reader["Machines"]);
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01) && Convert.ToDateTime(reader["EndDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                    }
                    if (MachineName == "CNC" && Convert.ToString(reader["Machines"]).Equals("CNC fræser"))
                    {
                        if(Convert.ToInt32(reader["MachineId"]).Equals(4) )
                        {
                            machine.Name = Convert.ToString(reader["Machines"]);
                        }
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01) && Convert.ToDateTime(reader["EndDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                    }
                    if (MachineName == "Saks" && Convert.ToString(reader["Machines"]).Equals("Maskinsaks"))
                    {
                        machine.Name = Convert.ToString(reader["Machines"]);
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01) && Convert.ToDateTime(reader["EndDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                    }
                    if (MachineName == "Monterings" && Convert.ToString(reader["Machines"]).Equals("Monteringsbænk"))
                    {
                        if (Convert.ToInt32(reader["MachineId"]).Equals(11))
                        {
                            machine.Name = Convert.ToString(reader["Machines"]);
                        }
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01) && Convert.ToDateTime(reader["EndDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                    }
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
            return machine;
        }
        public static int isOrderConfirmed()
        {
            SqlConnection connect = connectToSql();
            int isConfirmed = 0;

            try
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("ReturnOrderInformation", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                reader = sqlCmd.ExecuteReader();


                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["confirm"]).Equals(0))
                    {
                        isConfirmed = isConfirmed + 1;
                    }
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
            return isConfirmed;
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
                int k = -1;
                while (reader.Read())
                {
                    //Der er to løsninger
                    // Løsning 1: Bruger 2 produktlister til at opbevare produkterne i. En til ProductNo1 og en til ProductNo2. - Virker
                    // Løsning 2: Den som der var der før som ikke virker.
                    if ("" == Convert.ToString(reader["ProductNo2"]))
                    {
                        order.product1List.Add(new Product() { Name = Convert.ToString(reader["ProductNo1"]), Amount = Convert.ToInt32(reader["AmountNo1"]) });
                        i++;
                    }

                    else if (Convert.ToString(reader["ProductNo2"]) != "")
                    {
                        order.product1List.Add(new Product() { Name = Convert.ToString(reader["ProductNo1"]), Amount = Convert.ToInt32(reader["AmountNo1"]) });
                        order.product2List.Add(new Product() { Name = Convert.ToString(reader["ProductNo2"]), Amount = Convert.ToInt32(reader["AmountNo2"]) });
                        i++;
                        k++;
                    }

                    if ("" == Convert.ToString(reader["ProductNo2"]))
                    {
                        Order newOrder = new Order()
                        {
                            Deadline = Convert.ToDateTime(reader["Deadline"]),
                            Width = Convert.ToDecimal(reader["Width"]),
                            Height = Convert.ToDecimal(reader["Height"]),
                            Spacing = Convert.ToDecimal(reader["Spacing"]),
                            OrderProductName1 = order.product1List[i].Name,
                            OrderProductAmount1 = order.product1List[i].Amount,
                            Price = Convert.ToDecimal(reader["Price"]),
                            OrderName = Convert.ToString(reader["OrderName"])
                        };
                        orderList.Add(newOrder);
                    }
                    else if (Convert.ToString(reader["ProductNo2"]) != "")
                    {
                        Order anotherOrder = new Order()
                        {
                            Deadline = Convert.ToDateTime(reader["Deadline"]),
                            Width = Convert.ToDecimal(reader["Width"]),
                            Height = Convert.ToDecimal(reader["Height"]),
                            Spacing = Convert.ToDecimal(reader["Spacing"]),

                            OrderProductName1 = order.product1List[i].Name,
                            OrderProductAmount1 = order.product1List[i].Amount,
                            OrderProductName2 = order.product2List[k].Name,
                            OrderProductAmount2 = order.product2List[k].Amount,

                            Price = Convert.ToDecimal(reader["Price"]),
                            OrderName = Convert.ToString(reader["OrderName"])
                        };
                        orderList.Add(anotherOrder);
                    }
                    /*
                     Løsning som ikke helt virker
                    if ("" == Convert.ToString(reader["ProductNo2"]))
                    {
                        order.productList.Add(new Product() { Name = Convert.ToString(reader["ProductNo1"]), Amount = Convert.ToInt32(reader["AmountNo1"]) });
                        if (order.productList.Count > (Convert.ToInt32(reader["OrderID"]) + 1))
                        {
                            //i--;
                            i++;
                        }
                    }

                    else if (Convert.ToString(reader["ProductNo2"]) != "")
                    {
                        order.productList.Add(new Product() { Name = Convert.ToString(reader["ProductNo1"]), Amount = Convert.ToInt32(reader["AmountNo1"]) });
                        order.productList.Add(new Product() { Name = Convert.ToString(reader["ProductNo2"]), Amount = Convert.ToInt32(reader["AmountNo2"]) });
                        k++;
                        if (order.productList.Count > (Convert.ToInt32(reader["OrderID"]) + 1))
                        {
                            i++;
                            k++;
                        }
                    }
                    i++;
                    //if ((i + 1)== order.productList.Count)
                    //{
                    //    i++;
                    //}
                    if(i > k)
                    {
                        i--;
                        k++;
                    }
                    if ("" == Convert.ToString(reader["ProductNo2"]))
                    {
                        Order newOrder = new Order()
                        {
                            Deadline = Convert.ToDateTime(reader["Deadline"]),
                            Width = Convert.ToDecimal(reader["Width"]),
                            Height = Convert.ToDecimal(reader["Height"]),
                            Spacing = Convert.ToDecimal(reader["Spacing"]),
                            OrderProductName1 = order.productList[i].Name,
                            OrderProductAmount1 = order.productList[i].Amount,
                            Price = Convert.ToDecimal(reader["Price"]),
                            OrderName = Convert.ToString(reader["OrderName"])
                        };
                        orderList.Add(newOrder);
                    }
                    else if (Convert.ToString(reader["ProductNo2"]) != "")
                    {
                        Order anotherOrder = new Order()
                        {
                            Deadline = Convert.ToDateTime(reader["Deadline"]),
                            Width = Convert.ToDecimal(reader["Width"]),
                            Height = Convert.ToDecimal(reader["Height"]),
                            Spacing = Convert.ToDecimal(reader["Spacing"]),

                            OrderProductName1 = order.productList[i].Name,
                            OrderProductAmount1 = order.productList[i].Amount,
                            OrderProductName2 = order.productList[k].Name,
                            OrderProductAmount2 = order.productList[k].Amount,

                            Price = Convert.ToDecimal(reader["Price"]),
                            OrderName = Convert.ToString(reader["OrderName"])
                        };
                        orderList.Add(anotherOrder);
                    }
                    */
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
