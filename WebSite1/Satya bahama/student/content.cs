using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

/// <summary>
/// Summary description for content
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class content : System.Web.Services.WebService
{

    public content()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string coursereg(string d, string c, string s, int y)
    {
        string s1 = "Courses Registered";

        //Create Connection
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

        //SQL Command
        SqlCommand cmd = new SqlCommand("INSERT INTO dbo.course(college,dept,courses,content,year) VALUES(@dept,@college,@courses,@content,@year)", conn);
        cmd.Parameters.AddWithValue("@dept", d);
        cmd.Parameters.AddWithValue("@courses", s);
        cmd.Parameters.AddWithValue("@year", y);
        cmd.Parameters.AddWithValue("@college", c);
        cmd.Parameters.AddWithValue("@content", "none");
        conn.Open();
        cmd.ExecuteNonQuery();

        //To read from SQL Server

        conn.Close();
        return s1;

    }
    [WebMethod]
    public string updatecourse(String d, String c, String s, int y )
    {
        string s1 = "updation complete";
        string s2 = "none";
        //Create Connection
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

        //SQL Command
        SqlCommand cmd = new SqlCommand("update dbo.course set courses ='" + s + "'where dept='" + d + "'and college='" + c + "'and year ='"+y+ "'and content ='"+s2+ "'", conn);
        conn.Open();
        cmd.ExecuteNonQuery();

        //To read from SQL Server

        conn.Close();

        //Return
        return s1;
    }
    [WebMethod]
    public string contentreg(string d, string c, string s, string cn, int y)
    {
        string s1 = "Course Content Registered";

        //Create Connection
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

        //SQL Command
        SqlCommand cmd = new SqlCommand("INSERT INTO dbo.course(college,dept,courses,content,year) VALUES(@dept,@college,@courses,@content,@year)", conn);
        cmd.Parameters.AddWithValue("@dept", d);
        cmd.Parameters.AddWithValue("@courses", s);
        cmd.Parameters.AddWithValue("@year", y);
        cmd.Parameters.AddWithValue("@college", c);
        cmd.Parameters.AddWithValue("@content", cn);
        conn.Open();
        cmd.ExecuteNonQuery();

        //To read from SQL Server

        conn.Close();
        return s1;

    }
    [WebMethod]
    public string updatecontent(String d, String c, String s, String cn, int y)
    {
        string s1 = "updation complete";
        
        //Create Connection
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");

        //SQL Command
        SqlCommand cmd = new SqlCommand("update dbo.course set content ='" + cn + "'where dept='" + d + "'and college='" + c + "'and year ='"+y+ "'and course ='" + c + "'", conn);
        conn.Open();
        cmd.ExecuteNonQuery();

        //To read from SQL Server

        conn.Close();

        //Return
        return s1;
    }
    [WebMethod]
    public string getcourses(string c, string d, int y)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");
        
        string s2 = "none";
        //SQL Command
        SqlCommand cmd = new SqlCommand("SELECT courses FROM dbo.course WHERE college = '" + c + "'AND dept = '" + d + "'AND y = '" + y +"'AND content ='"+s2+ "'", conn);
        conn.Open();
        string s3 = (String)(cmd.ExecuteScalar());
        
        return s3;
        
    }
    [WebMethod]
    public string getcontent(string c, string d, string s, int y)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DRACARYS\SQLEXPRESS;Initial Catalog=test;Integrated Security=SSPI");
        
        //SQL Command
        SqlCommand cmd = new SqlCommand("SELECT content FROM dbo.course WHERE college = '" + c + "'AND dept = '" + d + "'AND y = '" + y + "'AND courses ='" + s + "'", conn);
        conn.Open();
        
        string s3 = (String)(cmd.ExecuteScalar());
        
        return s3;
    }
}
