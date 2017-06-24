using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

/// <summary>
/// Summary description for orientation
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class orientation : System.Web.Services.WebService
{

    public orientation()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string studentreg(string i, string n, string c, string d)
    {

        
        
        //Create Connection
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");
        SqlCommand cmd2 = new SqlCommand("SELECT seatcnt FROM dbo.seats WHERE dept='" + d + "'AND college='" + c + "'", conn);
	conn.Open();
        int i2 = (int)(cmd2.ExecuteScalar()); //getting seat count
        if (i2 != 0)
        {
            //SQL Command
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.dataorient(studentid,name,college,dept) VALUES(@studentid,@name,@college,@dept)", conn);
            cmd.Parameters.AddWithValue("@studentid", i);
            cmd.Parameters.AddWithValue("@name", n);
            cmd.Parameters.AddWithValue("@college", c);
            cmd.Parameters.AddWithValue("@dept", d);
            
            cmd.ExecuteNonQuery();

            int i3 = i2 - 1;
            SqlCommand cmd3 = new SqlCommand("update dbo.seats set seatcnt ='" + i3 + "'where dept='" + d + "'and college='" + c + "'", conn);
            //To read from SQL Server
            cmd3.ExecuteNonQuery();
            conn.Close();
            String s2 = "Registered. Number of seats left = " + i3;
            return s2;
        }
        else
            return "Seats Finished";
    }
    [WebMethod]
    public string seatreg(string d, string c, int s)
    {
        string s1 = "Seats Registered";
        
        //Create Connection
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

        //SQL Command
        SqlCommand cmd = new SqlCommand("INSERT INTO dbo.seats(dept,college,seatcnt) VALUES(@dept,@college,@seatcnt)", conn);
        cmd.Parameters.AddWithValue("@dept", d);
        cmd.Parameters.AddWithValue("@seatcnt", s);
        
        cmd.Parameters.AddWithValue("@college", c);
       
        conn.Open();
        cmd.ExecuteNonQuery();

        //To read from SQL Server

        conn.Close();
        return s1;

    }
    [WebMethod]
    public string updateseat(String d, String c, int s )
    {
        string s1 = "updation complete";
        //Create Connection
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

        //SQL Command
        SqlCommand cmd = new SqlCommand("update dbo.seats set seatcnt ='" + s + "'where dept='" + d + "'and college='" + c + "'", conn);
        conn.Open();
        cmd.ExecuteNonQuery();

        //To read from SQL Server

        conn.Close();

        //Return
        return s1;
    }

}
