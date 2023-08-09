using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebApplication1.class1
{
    public class function1
    {
        public static string Base64Decode1(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static double datediff1(DateTime date1,DateTime date2)
        {
            double i = 0;
            i = (date2.Date - date1.Date).TotalDays;
            return i;
        }

        public static void popUpMsgBox(string msg1, Page page1, Object obj1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("')};");
            sb.Append("");
            sb.Append("</script>");
            page1.ClientScript.RegisterClientScriptBlock(obj1.GetType(), "alert", sb.ToString());
        }

        public static void popUpMsgBox_Redir(string msg1, Page page1, Object obj1, string url1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(msg1);
            sb.Append("');window.location='" + url1 + "';};");
            sb.Append("");
            sb.Append("</script>");
            page1.ClientScript.RegisterClientScriptBlock(obj1.GetType(), "alert", sb.ToString());
        }
    }
}