using Inventory.App_Code.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viftech;

namespace Inventory
{
    public partial class userform : System.Web.UI.Page
    {
        PracticeEntities db = new PracticeEntities();
        User_BAL BAL = new User_BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //EMS_Session EMS = (EMS_Session)Session["EMS_Session"];
                using (PracticeEntities db = new PracticeEntities())
                {
                    string msg = "";
                    int CompID = 0;
                 

                    BAL.UserID = Convert.ToInt32(ViewState["hdnID"]);
                    var query = db.Users.Where(x => x.UserName == txtUserName.Text && x.Isactive == true).ToList();
                   // var query1 = db.vt_tbl_Employee.Where(x => x.EmployeeName == txtUserName.Text && x.CompanyID == CompID).ToList();
                    if (query.Count == 0)
                    {
                        BAL.UserName = txtUserName.Text;
                        BAL.Password = txtPassword.Text;
                        BAL.FirstName = txtFirstName.Text;
                        BAL.LastName = txtLastName.Text;
                        BAL.Email = txtEmail.Text;
                        BAL.CNIC = txtcnic.Text;
                        BAL.RoleID =2;
                        if (BAL.UserID > 0)
                        {                            
                            BAL.CreatedDate = DateTime.Now;
                            BAL.Active = true;
                            BAL.UpdateById(BAL);
                        }
                        else
                        {
                            BAL.CreatedOn = DateTime.Now;
                            BAL.Active = true;
                            BAL.Sp_Insert(BAL);
                        }
                        vt_Common.ReloadJS(this.Page, "$('#UserForm').modal('hide');");
                        LoadGrid();
                        msg = "Record Save Successfully";
                        MsgBox.Show(Page, MsgBox.success, "Message ", msg);
                    }
                    else
                    {
                        msg = "Record is already exist";
                        MsgBox.Show(Page, MsgBox.danger, "Message ", msg);
                    }
                    
                    UpView.Update();
                    Update.Update();
                    //Response.Redirect("userform.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }
        public void LoadGrid()
        {
            using (PracticeEntities db = new PracticeEntities())
            {
                DataSet ds = ProcedureCall.VT_Sp_User();
                if (ds != null)
                {
                    GridUser.DataSource = ds;
                    GridUser.DataBind();
                }
             

            }
            //vt_Common.Bind_GridView(GridUser, BAL.GetUserListByCompanyID());

            //Previous One
            //using (vt_EMSEntities db = new vt_EMSEntities())
            //{
            //    var Query = db.Sp_UserbyCompanyID(Session["CompanyId"] == null ? 0 : (int)Session["CompanyId"]).ToList();
            //    GridUser.DataSource = Query;
            //    GridUser.DataBind();

            //}

        }
        protected void BtnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                vt_Common.ReloadJS(this.Page, "$('#UserForm').modal();");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void lbtnEdit_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument.ToString() != "")
            {
                User_BAL UserBAL = BAL.GetUserbyID(Convert.ToInt32(e.CommandArgument));
                ViewState["hdnID"] = UserBAL.UserID;             
                txtFirstName.Text = UserBAL.FirstName;
                txtLastName.Text = UserBAL.LastName;
                txtEmail.Text = UserBAL.Email;
                txtPassword.Text = UserBAL.Password;
                txtcnic.Text = UserBAL.CNIC;
                txtUserName.Text = UserBAL.UserName;
                vt_Common.ReloadJS(this.Page, "$('#UserForm').modal();");
                Update.Update();
            }

        }

      
        protected void GridUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                vt_Common.ReloadJS(this.Page, "$('#UserForm').modal('hide');");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void lnkDelete_Command1(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandArgument.ToString() != "")
                {
                    User_BAL us = BAL.GetUserbyID(Convert.ToInt32(e.CommandArgument));
                    MsgDelete.Text = us.UserID.ToString();

                    vt_Common.ReloadJS(this.Page, "$('#Delete').modal();");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btndeletemodal_Command(object sender, CommandEventArgs e)
        {
            try
            {
                BAL.UserID = Convert.ToInt32(MsgDelete.Text);
                vt_Common.ReloadJS(this.Page, "$('#Delete').modal('hide')");
                BAL.DeleteUser(BAL.UserID);
                MsgBox.Show(Page, MsgBox.success, "Message ", "Successfully Deleted");
                LoadGrid();
                UpView.Update();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}