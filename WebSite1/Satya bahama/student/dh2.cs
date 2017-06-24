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
public class dh2 : System.Web.Services.WebService
{

    public dh2()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public String cas(String i, String u, String p, String c, String s, String k)

    {
        string recuperatedData = "";

        //Create Connection
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

        //SQL Command
        SqlCommand cmd = new SqlCommand("SELECT pass FROM dbo.datalog WHERE studentid = '" + i + "'AND name ='"+u+"'AND college ='"+c+"'AND subject ='"+s+"'", conn);

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
            SqlCommand cmd4 = new SqlCommand("SELECT keys FROM dbo.datalog WHERE name = '" + u + "'AND studentid ='" + i + "'AND college ='" + c + "'AND subject ='" + s + "'", conn);
            String s1 = (string)(cmd4.ExecuteScalar());
            if (s1 == k)
            {
                SqlCommand cmd2 = new SqlCommand("SELECT indat FROM dbo.datalog WHERE name = '" + u + "'AND studentid ='" + i + "'AND college ='" + c + "'AND subject ='" + s + "'", conn);
                int i1 = (int)(cmd2.ExecuteScalar());
                i1 = i1 + 1;


                SqlCommand cmd3 = new SqlCommand("update dbo.datalog set indat='" + i1 + "'WHERE name = '" + u + "'AND studentid ='" + i + "'AND college ='" + c + "'AND subject ='" + s + "'", conn);

                cmd3.ExecuteNonQuery();

                conn.Close();
                return "Succesfully Updated";
            }
            else
                return "Invalid Key";

        }
        else
            return "Access Denied";

    }
    [WebMethod]
    public String getat(String id, String u, String p, String c, String s)
    {
        string recuperatedData = "";

        //Create Connection
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

        //SQL Command
        SqlCommand cmd = new SqlCommand("SELECT pass FROM dbo.datalog WHERE name = '" + u + "'AND studentid = '"+id+"'AND college = '"+c+"'AND subject = '"+s+"'", conn);

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
            SqlCommand cmd2 = new SqlCommand("SELECT indat FROM dbo.datalog WHERE name = '" + u + "'AND studentid = '" + id + "'AND college = '" + c + "'AND subject = '" + s + "'", conn);
            int i = (int)(cmd2.ExecuteScalar());
            i = i + 1;
            SqlCommand cmd3 = new SqlCommand("SELECT totand FROM dbo.datalog WHERE name = '" + u + "'AND studentid = '" + id + "'AND college = '" + c + "'AND subject = '" + s + "'", conn);
            int j = (int)(cmd2.ExecuteScalar());
            j = j + 1;
            int at = ((i / j) * 100);
            return "" + at + "%";
        }
        else
            return "Invalid";

        }
}
