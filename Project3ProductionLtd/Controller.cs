﻿using System;
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
        
        public int logIn(string username, string password)
        {



        }


        public void connectToSql()
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
