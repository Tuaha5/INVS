using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventory
{
    
    public partial class Login : System.Web.UI.Page
    {
        PracticeEntities db = new PracticeEntities();

            protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUserName.Text;
                string password = txtPassword.Text;
                if (username != null | password != null)
                {
                    User usr = db.Users.Where(x => x.Name == username && x.Password == password).FirstOrDefault();
                    if (usr != null)
                    {
                        Session["UserID"] = usr.Id;
                        Session["UserName"] = usr.Name;                        

                        Response.Redirect("Default.aspx");
                    }


                }
                else
                {

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}