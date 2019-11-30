using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.Reflection;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Collections.Specialized;
using System.Linq;
using System.ComponentModel;

namespace Viftech
{
    /// <summary>
    /// Summary description for Common
    /// </summary>
    /// 
    public class vt_Common
    {
        public vt_Common()
        {

        }

        public static string SendStatus;
        
        public static string ConStr
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings["vt_ConnectionString"] == null)
                {
                    return null;
                }
                string myCon = ConfigurationManager.ConnectionStrings["vt_ConnectionString"].ToString();
                return myCon;
            }
        }
        public static void ReloadJS(Page page, string Function)
        {
            ScriptManager.RegisterStartupScript(page, typeof(string), Guid.NewGuid().ToString(), Function, true);
        }
        public static string PayRollConnectionString
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings["vt_PayRollConnection"] == null)
                {
                    return null;
                }
                string myCon = ConfigurationManager.ConnectionStrings["vt_PayRollConnection"].ToString();
                return myCon;
            }
        }

    }
}