using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Inventory.App_Code.Common
{
    public class ProcedureCall
    {
        public static DataSet VT_Sp_User()
        {
            using (PracticeEntities db = new  PracticeEntities())
            {
                DataSet a = SqlHelper.ExecuteDataset(db.Database.Connection.ConnectionString, "[dbo].[Sp_User]");
                return a;
            }
          

        }
    }
}