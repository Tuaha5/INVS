using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Viftech;

/// <summary>
/// Summary description for User_DLL
/// </summary>
public class User_DLL
{
    public User_DLL()
    {
        //
        // TODO: Add constructor logic here
        // 
    }

    public virtual DataTable Sp_Insert(User_BAL user)
    {
        try
        {
            SqlParameter[] sqlparam =
          {
                new SqlParameter("@UserID", user.UserID),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@FirstName", user.FirstName),
                new SqlParameter("@LastName", user.LastName),
                  new SqlParameter("@CNIC", user.CNIC),
                new SqlParameter("@Passsword", user.Password),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@RoleID", user.RoleID),
                new SqlParameter("@Createddate", Convert.ToDateTime(user.CreatedOn)),
                new SqlParameter("@IsActive", user.Active),
            };

            return SqlHelper.ExecuteDataset(vt_Common.PayRollConnectionString, "CreateUsersp", sqlparam).Tables[0];
            //return dt;
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }
    public virtual DataTable UpdateById(User_BAL user)
    {
        try
        {
            SqlParameter[] sqlparam =
          {
                new SqlParameter("@UserID", user.UserID),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@FirstName", user.FirstName),
                new SqlParameter("@LastName", user.LastName),
                  new SqlParameter("@CNIC", user.CNIC),
                new SqlParameter("@Passsword", user.Password),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@RoleID", user.RoleID),
                new SqlParameter("@Createddate", Convert.ToDateTime(user.CreatedDate)),
                new SqlParameter("@IsActive", user.Active),
            };

            return SqlHelper.ExecuteDataset(vt_Common.PayRollConnectionString, "UpdateUserByID", sqlparam).Tables[0];
            //return dt;
        }
        catch (Exception ex)
        {
            //ErrHandler.TryCatchException(ex);
            throw ex;
        }
    }

    public virtual DataTable GetUserListByCompanyID()
    {
        try
        {
            
            return SqlHelper.ExecuteDataset(vt_Common.PayRollConnectionString, CommandType.StoredProcedure, "Sp_UserbyCompanyID").Tables[0];
        }
        catch (Exception ex)
        {
           // ErrHandler.TryCatchException(ex);
            throw ex;
        }
    }

    public virtual int DeleteUser(int id)
    {
        try
        {
            SqlParameter[] param =
           {
            new SqlParameter("@UserID", id)
        };
            return SqlHelper.ExecuteNonQuery(vt_Common.PayRollConnectionString, CommandType.StoredProcedure, "Sp_deleteUSer", param);

        }
        catch(Exception ex)
        {
          //  ErrHandler.TryCatchException(ex);
            throw ex;
        }
        
    }
    public virtual DataTable GetTerminatedEmployeeCompanyID(int CompanyID)
    {
        try
        {
            SqlParameter[] param = {

                new SqlParameter("@CompanyID", CompanyID)
            };
            return SqlHelper.ExecuteDataset(vt_Common.PayRollConnectionString, "Sp_GetTerminatedEmployeeByCompanyID", param).Tables[0];
        }
        catch (Exception ex)
        {
           // ErrHandler.TryCatchException(ex);
            throw ex;
        }
    }
    public virtual User_BAL GetUserbyID(int userID)
    {
        User_BAL user = new User_BAL();

        SqlParameter[] param =
            {
            new SqlParameter("@UserID", userID),
        };
        using (SqlDataReader dr = SqlHelper.ExecuteReader(vt_Common.PayRollConnectionString, "Sp_GetUserbyID", param))
        {

            if (dr.Read())
            {
                user.UserID = Convert.ToInt32(dr["Id"]);
                user.UserName = dr["UserName"].ToString();
                user.Password = dr["Password"].ToString();
                user.FirstName = dr["FirstName"].ToString();
                user.LastName = dr["LastName"].ToString();
                user.Email = dr["Email"].ToString();                
                user.RoleID =Convert.ToInt32(dr["RoleID"]);
                //user.Active = dr["IsActive"].;
                user.Email = dr["Email"].ToString();
                user.CNIC = dr["CNIC"].ToString();
            }
        }
        return user;
    }


    //public virtual int UpdateUser(User_BAL user)
    //{
    //    try
    //    {
    //        int i;
    //        SqlParameter[] sqlparam =
    //        {
    //           new SqlParameter("@UserID", user.UserID),
    //        new SqlParameter("@CompanyID", user.CompanyID),
    //         new SqlParameter("@UserName", user.UserName),
    //          new SqlParameter("@Passsword", user.Password),
    //           new SqlParameter("@RoleID", user.RoleID),
    //            new SqlParameter("@LastName", user.LastName),
    //             new SqlParameter("@Active", user.Active),
    //             new SqlParameter("@CreatedDate", user.CreatedDate),
    //            new SqlParameter("@Email", user.Email),
    //             new SqlParameter("@FirstName", user.FirstName),
    //             new SqlParameter("@CreatedOn", user.CreatedOn),
    //            new SqlParameter("@CreatedBy", user.CreatedBy),
    //             new SqlParameter("@Deleted", user.Deleted),
    //             new SqlParameter("@UpdatedOn", user.UpdatedOn),
    //             new SqlParameter("@UpdatedBy", user.UpdatedBy),
    //        };
    //        i = SqlHelper.ExecuteNonQuery(vt_Common.PayRollConnectionString, CommandType.StoredProcedure, "Sp_UpdateUser", sqlparam);
    //        return i;

    //        // return SqlHelper.ExecuteDataset(vt_Common.PayRollConnectionString, "CreateandModifyRoles", param).Tables[0];

    //    }
    //    catch (Exception ex)
    //    {
    //        ErrHandler.TryCatchException(ex);
    //        throw ex;
    //    }

    //}


    


    //GetCOmpanyID 


}