using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

/// <summary>
/// Summary description for module1
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class module1 : System.Web.Services.WebService
{

    public module1()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string studentreg(string i, string n, string p, string c, string s)
    {

        string s1 = "Course Registration complete";
        int ia = 0, t = 0;
        String k = "0";
        //Create Connection
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

        //SQL Command
        SqlCommand cmd = new SqlCommand("INSERT INTO dbo.datalog(studentid,name,pass,college,subject,keys,indat,totand) VALUES(@studentid,@name,@pass,@college,@subject,@keys,@indat,@totand)", conn);
        cmd.Parameters.AddWithValue("@studentid", i);
        cmd.Parameters.AddWithValue("@name", n);
        cmd.Parameters.AddWithValue("@pass", p);
        cmd.Parameters.AddWithValue("@college", c);
        cmd.Parameters.AddWithValue("@subject", s);
        cmd.Parameters.AddWithValue("@keys", k);
        cmd.Parameters.AddWithValue("@indat", ia);
        cmd.Parameters.AddWithValue("@totand", t);
        conn.Open();
        cmd.ExecuteNonQuery();

        //To read from SQL Server

        conn.Close();
        return s1;
    }
    [WebMethod]
    public string teachreg(string i, string n, string p, string c)
    {
        string s1 = "Teacher Profile Registered";
        int ia = 0, t = 0;
        String k = "0";
        String s = "None";
        //Create Connection
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

        //SQL Command
        SqlCommand cmd = new SqlCommand("INSERT INTO dbo.datalog(studentid,name,pass,college,subject,keys,indat,totand) VALUES(@studentid,@name,@pass,@college,@subject,@keys,@indat,@totand)", conn);
        cmd.Parameters.AddWithValue("@studentid", i);
        cmd.Parameters.AddWithValue("@name", n);
        cmd.Parameters.AddWithValue("@pass", p);
        cmd.Parameters.AddWithValue("@college", c);
        cmd.Parameters.AddWithValue("@subject", s);
        cmd.Parameters.AddWithValue("@keys", k);
        cmd.Parameters.AddWithValue("@indat", ia);
        cmd.Parameters.AddWithValue("@totand", t);
        conn.Open();
        cmd.ExecuteNonQuery();

        //To read from SQL Server

        conn.Close();
        return s1;

    }

}
