<%@ WebHandler Language="C#" Class="Getupload_Email" %>

using System;
using System.Web;
using cld.Classes;

public class Getupload_Email : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
      //  zues z2 = new zues();
      //  var pp = context.Request["vid"];
       Registration zz = new Registration();
        System.Collections.Generic.List<Email4> kk = zz.getEmails();
        ser.MaxJsonLength = Int32.MaxValue;

        context.Response.ContentType = "application/json";
        context.Response.Write(ser.Serialize(kk));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}