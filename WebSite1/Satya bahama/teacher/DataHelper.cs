using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace StageWebApplication
{
    public class DataHelper
    {
        //Create new method to get data from dababase
        public static string Getdata(string argu)
        {
             try
            {
                string recuperatedData = "";

                //Create Connection
                SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

                //SQL Command
                SqlCommand cmd = new SqlCommand("SELECT UserName FROM dbo.tblEmployee WHERE ID = '" + argu + "'", conn);

                //Open connection
                conn.Open();

                //To read from SQL Server
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    recuperatedData = dr["UserName"].ToString();
                }

                //Close Connections
                dr.Close();
                conn.Close();

                //Return
                return recuperatedData;
            }
            catch (Exception e)
            {
                if (e != null)
                    return "Invalid Request";
                else
                    return "Enter Data";
            }

        }
        public static string PutData(string name, string pass, string email, string gender)
        {

            string s = "Insertion complete";
            //Create Connection
            SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

            //SQL Command
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.tblEmployee(UserName,Pass,Email,Gender) VALUES (@UserName,@Pass,@Email,@Gender)", conn);
            cmd.Parameters.AddWithValue("@UserName", name);
            cmd.Parameters.AddWithValue("@Pass", pass);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Gender", gender);

            





            //Open connection
            conn.Open();
            cmd.ExecuteNonQuery();

            //To read from SQL Server
            
            conn.Close();

            //Return
            return s;

        }

        public static string UpdateData(int id, string name, string pass, string email, string gender)
        {
            try
            {
                string s = "updation complete complete";
                //Create Connection
                SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

                //SQL Command
                SqlCommand cmd = new SqlCommand("update dbo.tblEmployee set UserName='" + name + "', Pass ='" + pass + "', Email ='" + email + "' , Gender='" + gender + "' where ID='" + id + "'", conn);








                //Open connection
                conn.Open();
                cmd.ExecuteNonQuery();

                //To read from SQL Server

                conn.Close();

                //Return
                return s;
            }
            catch( Exception e)
            {
                if (e != null)
                    return "Invalid Request";
                else
                    return "Enter Data";
            }

        }

       

        public static string DelData(int id)
        {

            string s = "deletion complete";
            //Create Connection
            SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

            //SQL Command
            SqlCommand cmd = new SqlCommand("delete dbo.tblEmployee where ID='" + id + "'", conn);








            //Open connection
            conn.Open();
            cmd.ExecuteNonQuery();

            //To read from SQL Server

            conn.Close();

            //Return
            return s;

        }

    }



    //New Method..

}