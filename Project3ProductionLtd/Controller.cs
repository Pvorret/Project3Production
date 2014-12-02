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
    class Controller
    {
        
        public int logIn(string inuserName, string inpassword)
        {
            string userName = inuserName;
            string password = inpassword;
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
                
                int id = int.Parse(Convert.ToString(reader["Id"]));
                
                return id;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 0;
            }

        }


        public static void connectToSql()
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
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
    }
}
