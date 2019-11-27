using Inventory.App_Code.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Inventory.App_Code.Bal
{
    public class Login_BAL :Login_Dal
    {
        public override DataTable CheckPSIDAndPassword(string PSID, string Password)
        {
            return base.CheckPSIDAndPassword(PSID, Password);
        }
    }
}