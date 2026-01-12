using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using DBUtils;
using System.Configuration;
using PrezentacionaLogika;
using System.Diagnostics;

namespace KorisnickiInterfejs
{
    public partial class StipendijaUnos : System.Web.UI.Page
    {
          // privatni atributi
          FormaStipendijaUnosClass _formaStipendijaUnosObject;

          private void IsprazniKontrole()
          {
               txbSifra.Text = "";
               txbNaziv.Text = "";
               txbIznos.Text = "";


          }

          private void IsprazniKontroleNakonUpisa()
          {
               txbSifra.Text = "";
               txbNaziv.Text = "";
               txbIznos.Text = "";

        }

  
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
               else if (!IsPostBack)
               {
                    _formaStipendijaUnosObject = new FormaStipendijaUnosClass(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                    
               }
          }

          // preuzimanje vrednosti iz textboxa i upis u bazu podataka
          protected void btnSnimi_Click(object sender, EventArgs e)
        {
            _formaStipendijaUnosObject = new FormaStipendijaUnosClass(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);

            _formaStipendijaUnosObject.Sifra = txbSifra.Text;
            _formaStipendijaUnosObject.Naziv = txbNaziv.Text;
            _formaStipendijaUnosObject.Iznos = int.Parse(txbIznos.Text);



            XmlHelper xmlHelper = new XmlHelper(Server.MapPath("Stipendije.xml"));
               xmlHelper.DodajNovuStipendiju(_formaStipendijaUnosObject.Sifra, _formaStipendijaUnosObject.Naziv, _formaStipendijaUnosObject.Iznos);



            _formaStipendijaUnosObject.SnimiPodatke();
               lblStatus.Text = "Snimljeno";
               IsprazniKontroleNakonUpisa();
          }

          protected void btnOdustani_Click(object sender, EventArgs e)
        {
               IsprazniKontrole();
               Response.Redirect("WelcomeAdmin.aspx");
          }
    }
}