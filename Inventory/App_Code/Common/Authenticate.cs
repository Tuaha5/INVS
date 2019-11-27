using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.App_Code.Common
{
    public class Authenticate
    {
        private static bool login { get; set; }
        public static bool Confirm()
        {
            if (HttpContext.Current.Session["UserID"] != null)
            {
                login = true;
            }
            else
            {
                login = false;
                HttpContext.Current.Response.Redirect("Login.aspx");
            }
            return login;
              
        }
    }
}