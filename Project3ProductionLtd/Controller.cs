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
        public static SqlConnection connectToSql() //Lavet af Phillip
        {
            SqlConnection connect = new SqlConnection(
                "Server=ealdb1.eal.local;" +
                "Database=EJL01_DB;" +
                "User Id=ejl01_usr;" +
                "Password=Baz1nga1"
                );
            return connect;

        }
        public static int logIn(string inuserName, string inpassword) //Lavet af Phillip
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

                reader.Read(); 

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
        public static List<Product> getProductsFromDatabaseToProductList() //Lavet af Phillip
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
                            Price = Convert.ToDecimal(reader["Price"]),
                            InStock = Convert.ToInt32(reader["InStock"])
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
        public static List<Product> getRequiredMachineFromProductDB(string productName) //Lavet af Phillip
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
        public static List<Machine> getMachineTimes() //Lavet af Thomas
        {
            SqlConnection connect = connectToSql();
            List<Machine> fullMachineList = new List<Machine>();
            try
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("ReturnMachines", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    Machine machineTimes = new Machine()
                    {
                        Name = Convert.ToString(reader["Machines"]),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        Deadline = Convert.ToDateTime(reader["Deadline"])
                    };
                    fullMachineList.Add(machineTimes);
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
            return fullMachineList;
        }
        public static void getOrdersFromDatabaseToOrderList() //Lavet af Phillip
        {
            SqlConnection connect = connectToSql();
            orderList = new List<Order>();
            try
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("ReturnOrderInformation", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader;
                Order order;
                reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    if ("" == Convert.ToString(reader["ProductNo2"]))
                    {
                        order = new Order();
                        order.Deadline = Convert.ToDateTime(reader["Deadline"]);
                        order.OrderProductName1 = Convert.ToString(reader["ProductNo1"]);
                        order.OrderProductAmount1 = Convert.ToInt32(reader["AmountNo1"]);
                        order.Price = Convert.ToDecimal(reader["Price"]);
                        order.OrderName = Convert.ToString(reader["OrderName"]);
                        order.Confirm = Convert.ToInt32(reader["Confirm"]);
                        order.CustomerName = Convert.ToString(reader["CustomerName"]);
                        orderList.Add(order);
                    }
                    else if (Convert.ToString(reader["ProductNo2"]) != "")
                    {
                        order = new Order();
                        order.Deadline = Convert.ToDateTime(reader["Deadline"]);
                        order.OrderProductName1 = Convert.ToString(reader["ProductNo1"]);
                        order.OrderProductAmount1 = Convert.ToInt32(reader["AmountNo1"]);
                        order.OrderProductName2 = Convert.ToString(reader["ProductNo2"]);
                        order.OrderProductAmount2 = Convert.ToInt32(reader["AmountNo2"]);
                        order.Price = Convert.ToDecimal(reader["Price"]);
                        order.OrderName = Convert.ToString(reader["OrderName"]);
                        order.Confirm = Convert.ToInt32(reader["Confirm"]);
                        order.CustomerName = Convert.ToString(reader["CustomerName"]);
                        orderList.Add(order);
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
        }
        public static Machine getMachinesFromDb(string MachineName) //Lavet af Phillip
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
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                        if (Convert.ToDateTime(reader["EndDate"]) > DateTime.Now)
                        {
                            machine.IsAvailableNow = false;
                            machine.StartDate = Convert.ToDateTime(reader["StartDate"]);
                            machine.EndDate = Convert.ToDateTime(reader["EndDate"]);
                            machine.Deadline = Convert.ToDateTime(reader["Deadline"]);
                        }
                    }
                    if (MachineName == "Svejse" && Convert.ToString(reader["Machines"]).Equals("Svejsestation"))
                    {
                        if (Convert.ToInt32(reader["MachineId"]).Equals(6))
                        {
                            machine.Name = Convert.ToString(reader["Machines"]);
                        }
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                        if (Convert.ToDateTime(reader["EndDate"]) > DateTime.Now)
                        {
                            machine.IsAvailableNow = false;
                            machine.StartDate = Convert.ToDateTime(reader["StartDate"]);
                            machine.EndDate = Convert.ToDateTime(reader["EndDate"]);
                            machine.Deadline = Convert.ToDateTime(reader["Deadline"]);
                        }
                    }
                    if (MachineName == "Bukke" && Convert.ToString(reader["Machines"]).Equals("Bukkemaskine"))
                    {
                        machine.Name = Convert.ToString(reader["Machines"]);
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                        if (Convert.ToDateTime(reader["EndDate"]) > DateTime.Now)
                        {
                            machine.IsAvailableNow = false;
                            machine.StartDate = Convert.ToDateTime(reader["StartDate"]);
                            machine.EndDate = Convert.ToDateTime(reader["EndDate"]);
                            machine.Deadline = Convert.ToDateTime(reader["Deadline"]);
                        }
                    }
                    if (MachineName == "Laser" && Convert.ToString(reader["Machines"]).Equals("Lasercutter"))
                    {
                        machine.Name = Convert.ToString(reader["Machines"]);
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                        if (Convert.ToDateTime(reader["EndDate"]) > DateTime.Now)
                        {
                            machine.IsAvailableNow = false;
                            machine.StartDate = Convert.ToDateTime(reader["StartDate"]);
                            machine.EndDate = Convert.ToDateTime(reader["EndDate"]);
                            machine.Deadline = Convert.ToDateTime(reader["Deadline"]);
                        }
                    }
                    if (MachineName == "CNC" && Convert.ToString(reader["Machines"]).Equals("CNC fræser"))
                    {
                        if(Convert.ToInt32(reader["MachineId"]).Equals(4) )
                        {
                            machine.Name = Convert.ToString(reader["Machines"]);
                        }
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                        if (Convert.ToDateTime(reader["EndDate"]) > DateTime.Now)
                        {
                            machine.IsAvailableNow = false;
                            machine.StartDate = Convert.ToDateTime(reader["StartDate"]);
                            machine.EndDate = Convert.ToDateTime(reader["EndDate"]);
                            machine.Deadline = Convert.ToDateTime(reader["Deadline"]);
                        }
                    }
                    if (MachineName == "Saks" && Convert.ToString(reader["Machines"]).Equals("Maskinsaks"))
                    {
                        machine.Name = Convert.ToString(reader["Machines"]);
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                        if (Convert.ToDateTime(reader["EndDate"]) > DateTime.Now)
                        {
                            machine.IsAvailableNow = false;
                            machine.StartDate = Convert.ToDateTime(reader["StartDate"]);
                            machine.EndDate = Convert.ToDateTime(reader["EndDate"]);
                            machine.Deadline = Convert.ToDateTime(reader["Deadline"]);
                        }
                    }
                    if (MachineName == "Monterings" && Convert.ToString(reader["Machines"]).Equals("Monteringsbænk"))
                    {
                        if (Convert.ToInt32(reader["MachineId"]).Equals(11))
                        {
                            machine.Name = Convert.ToString(reader["Machines"]);
                        }
                        if (Convert.ToDateTime(reader["StartDate"]).Date.Equals(1000 - 01 - 01))
                        {
                            machine.IsAvailableNow = true;
                        }
                        if (Convert.ToDateTime(reader["EndDate"]) > DateTime.Now)
                        {
                            machine.IsAvailableNow = false;
                            machine.StartDate = Convert.ToDateTime(reader["StartDate"]);
                            machine.EndDate = Convert.ToDateTime(reader["EndDate"]);
                            machine.Deadline = Convert.ToDateTime(reader["Deadline"]);
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
        public static int isOrderConfirmed() //Lavet af Phillip
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
        
        public static List<Product> AddProductToTemporaryList(string name, int amount) //Lavet af Nicolaj
        {
            productList = new List<Product>();
            Product product = new Product();
            product.Name = name;
            product.Amount = amount;
            productList.Add(product);
            MessageBox.Show(productList.Count.ToString());
            return AddProductToTemporaryList(name, amount);
        }

        public static void NewOrderToDB(List<Order> NewOrder) //Lavet af Nicolaj
        {

        }
        public static void NewCustomerToDB(string name, string address, string phonNumber, string email) //Lavet af Nicolaj og Thomas
        {
            SqlConnection connect = connectToSql();
            try
            {
                connect.Open();
                SqlCommand sqlCmd = new SqlCommand("newCustomer", connect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@Name", name));
                sqlCmd.Parameters.Add(new SqlParameter("@StreetAddress", address));
                sqlCmd.Parameters.Add(new SqlParameter("@PhoneNumber", address));
                sqlCmd.Parameters.Add(new SqlParameter("@Email", email));
                sqlCmd.ExecuteNonQuery();
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
            
        }
        public static void confirmOrder(string orderName) //Lavet af Thomas
        {
            SqlConnection con = connectToSql();
            try
            {
                con.Open();
                SqlCommand sqlCmd = new SqlCommand("confirmOrder", con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@confirm", 1));
                sqlCmd.Parameters.Add(new SqlParameter("@OrderName", orderName));

                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        public static void newDeadline(string orderName, DateTime deadline) //Lavet af Thomas
        {
            SqlConnection con = connectToSql();
            try
            {
                DateTime newDeadline = new DateTime();
                newDeadline = deadline.AddDays(5);
                con.Open();
                SqlCommand sqlCmd = new SqlCommand("newDeadline", con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@deadline", newDeadline));
                sqlCmd.Parameters.Add(new SqlParameter("@OrderName", orderName));

                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}
