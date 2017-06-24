using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for Student
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Student : System.Web.Services.WebService
{

    public Student()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [System.Web.Services.WebMethod()]
    public string StudentCode(double code)
    {
        if (code == 1101)
            return "Java,C,C++";
        else
            return "Invalid";
    }

    [System.Web.Services.WebMethod()]
    public string SubjectCode(double code1)
    {
        if (code1 == 1)
            return "SE1012,SE1011,SE1013";
        else
            return "Invalid";
    }
}
