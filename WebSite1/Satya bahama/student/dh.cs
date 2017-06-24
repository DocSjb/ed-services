using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

/// <summary>
/// Summary description for dh
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class dh : System.Web.Services.WebService
{

    public dh()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public String cas(String id, String u, String p,String c, String s, String k)

    {
        string recuperatedData = "";

        //Create Connection
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

        //SQL Command
        SqlCommand cmd = new SqlCommand("SELECT pass FROM dbo.datalog WHERE name = '" + u + "'AND studentid = '" + id + "'AND college = '" + c +"'", conn); 

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

        if (recuperatedData == p)
        {
            SqlCommand cmd2 = new SqlCommand("SELECT totand FROM dbo.datalog WHERE subject = '"+s+"'", conn);
            int i = (int)(cmd2.ExecuteScalar());
            i = i + 1;
            
            SqlCommand cmd1 = new SqlCommand("update dbo.datalog set keys='" +k+"'WHERE subject = '"+s+"'", conn);
            SqlCommand cmd3 = new SqlCommand("update dbo.datalog set totand='" + i + "'WHERE subject = '"+s+"'", conn);
            cmd1.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            conn.Close();
            return "Succesfully Updated";

        }
        else
            return "Access Denied";
        
    }
}
