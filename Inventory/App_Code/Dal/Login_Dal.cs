using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Viftech;

namespace Inventory.App_Code.Dal
{
    public class Login_Dal
    {
        public virtual DataTable CheckPSIDAndPassword(string PSID, string Password)
        {
            try
            {

                SqlParameter[] param = {
                new SqlParameter("@UserName", Password),
                                 new SqlParameter("@Password", Password)

                               };

                return SqlHelper.ExecuteDataset(vt_Common.PayRollConnectionString, "[Sp_CheckPSIDAndPassword]", param).Tables[0];
            }
            catch (Exception ex)
            {
                //ErrHandler.TryCatchException(ex);
                throw ex;

            }
        }
    }
}