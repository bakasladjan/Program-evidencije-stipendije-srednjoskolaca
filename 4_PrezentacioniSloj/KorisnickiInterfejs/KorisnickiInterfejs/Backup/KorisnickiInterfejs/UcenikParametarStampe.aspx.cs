using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KorisnickiInterfejs
{
    public partial class UcenikParametarStampe : System.Web.UI.Page
    {
          protected void Page_PreInit(object sender, EventArgs e)
          {
               if (Session["KorisnikStatus"].ToString() == "admin")
               {
                    // Ako je korisnik administrator, koristite Admin.Master
                    this.MasterPageFile = "~/Admin.Master";

               }
               else if (Session["KorisnikStatus"].ToString() == "korisnik")
               {
                    // Inače, koristite Korisnik.Master
                    this.MasterPageFile = "~/Korisnik.Master";

               }
               else
               {
                    Debug.WriteLine("Nije ni korisnik ni admin - greška!");
               }
          }

          protected void Page_Load(object sender, EventArgs e)
        {
               // provera da li je korisnik prijavljen na svoj nalog
               if (Session["KorisnikImePrezime"] == null)
               {
                    Response.Redirect("Default.aspx");
               }
               
               
          }

          // preusmeravanje na stranicu za stampu i prosleđivanje fitera kao parametar
          protected void btnFilterStampa_Click(object sender, EventArgs e)
        {
            Response.Redirect("UcenikStampa.aspx?filter=" + txbFilter.Text); 
        }
    }
}