using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KorisnickiInterfejs
{
    public partial class WelcomeKorisnik : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               if (Session["KorisnikImePrezime"] != null)
               {
                    lblImePrezimeKorisnika.Text = Session["KorisnikImePrezime"].ToString();
               }
               else
               {
                    Response.Redirect("Default.aspx");
               }
     }
    }
}