using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for Dataret
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Dataret : System.Web.Services.WebService
{

    public Dataret()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod]
    public string Getdata(string codes)
    {
        return StageWebApplication.DataHelper.Getdata(codes);

    }
    [WebMethod]
    public string Putdata(string n, string e, string p, string g)
    {
        return StageWebApplication.DataHelper.PutData(n, p, e , g);
    }
    [WebMethod]

    public string UpdateData(int i, string n, string e, string p, string g)
    {
        try {
            return StageWebApplication.DataHelper.UpdateData(i, n, e, p, g);
        }
        catch (Exception ex)
        {
            if (ex != null)
                return "Invalid Request";
            else
                return "Enter Data";
        }
        }
    [WebMethod]
    public string DelData(int i)
    {
        return StageWebApplication.DataHelper.DelData(i);
    }
}
