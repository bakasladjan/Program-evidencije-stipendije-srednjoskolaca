using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using PrezentacionaLogika;
using System.Configuration;
using System.Security.Cryptography;

namespace KorisnickiInterfejs
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

          //metoda za prijavu korisnika na nalog
          protected void btnPRIJAVA_Click(object sender, EventArgs e)
        {
            // provera korisnika 
            FormaLoginClass objFormaLogin = new FormaLoginClass(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            objFormaLogin.KorisnickoIme = txbKorisnickoIme.Text;
            objFormaLogin.Sifra = txbSifra.Text; 
            bool pronadjenKorisnik = objFormaLogin.VazeciKorisnik();

            if (pronadjenKorisnik)
            {
                // TO DO
                    string ImePrezime = objFormaLogin.DajImePrezimeKorisnika();
                    string Status = objFormaLogin.DajStatusKorisnika();
                // ubacivanje korisnika u sesiju
                    Session.Add("KorisnikImePrezime", ImePrezime);
                    Session.Add("KorisnikStatus", Status);

                    if (Status == "admin")
                    {
                         // ucitavanje Welcome admin
                         Response.Redirect("WelcomeAdmin.aspx");
                    }
                    else
                    {
                         // ucitavanje Welcome korisnik
                         Response.Redirect("WelcomeKorisnik.aspx");
                    }

               }
            else
            {
                lblStatus.Text = "KORISNIK NIJE PRONADJEN!"; 
            }

        }
        
        protected void btnOdustani_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}