using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

/// <summary>
/// Summary description for crypto
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class crypto : System.Web.Services.WebService
{


    public crypto()
    {


        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public String cas(String id, String u, String p, String c)

    {
        try
        {
            string recuperatedData = "";

            //Create Connection
            SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

            //SQL Command
            SqlCommand cmd = new SqlCommand("SELECT pass FROM dbo.datalog WHERE name = '" + u + "'AND studentid = '" + id + "'AND college = '" + c + "'", conn);

            //Open connection
            conn.Open();

            //To read from SQL Server
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                recuperatedData = dr["pass"].ToString();
            }

            //Close Connections
            dr.Close();
            conn.Close();
            if (recuperatedData == p)
            {
                using (System.Security.Cryptography.RNGCryptoServiceProvider rg = new System.Security.Cryptography.RNGCryptoServiceProvider())
                {
                    byte[] rno = new byte[5];
                    rg.GetBytes(rno);
                    int randomvalue = BitConverter.ToInt32(rno, 0);
                    string s = "" + randomvalue;
                    return s;

                }
            }
            else
                return "Access Denied";
        }
        catch (SqlException e)
        {
            return "Invalid REquest" + e;
        }
    }


  
   

}
