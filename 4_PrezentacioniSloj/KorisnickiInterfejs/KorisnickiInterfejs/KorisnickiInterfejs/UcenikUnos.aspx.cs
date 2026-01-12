using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data;
using System.Configuration;
using PrezentacionaLogika;
using System.Globalization;
using System.Diagnostics;

namespace KorisnickiInterfejs
{
    public partial class UcenikUnos : System.Web.UI.Page
    {
        // privatni atributi
        FormaUcenikUnosClass _formaUcenikUnosObject; 
        
        // konstruktor


        // nase metode
        private void NapuniCombo()
        {
            // IZDVAJANJE PODATAKA IZ XML POSREDSTVOM WEB SERVISA
            DataSet dsStipendija = new DataSet();
            dsStipendija = _formaUcenikUnosObject.DajPodatkeZaCombo();

            int ukupno = dsStipendija.Tables[0].Rows.Count;

            // PUNJENJE COMBO PODACIMA IZ DATASETA
            ddlStipendija.Items.Add("Izaberite...");
            for (int i = 0; i < ukupno; i++)
            {
                ddlStipendija.Items.Add(dsStipendija.Tables[0].Rows[i].ItemArray[1].ToString());
            }

        }

        private void IsprazniKontrole()
        {
               txbJMBG.Text = "";
               txbImeIPrezimeUcenika.Text = "";
               txbRazred.Text = "";
               txbSkola.Text = "";
               txbDatumRodjenja.Text = "";
               txbAdresaUcenika.Text = "";
               txbKontaktTelefon.Text = "";
               ddlStipendija.Text ="Izaberite...";
               lblStatus.Text = ""; 
        }

          private void IsprazniKontroleNakonUpisa()
          {
               txbJMBG.Text = "";
               txbImeIPrezimeUcenika.Text = "";
               txbRazred.Text = "";
               txbSkola.Text = "";
               txbDatumRodjenja.Text = "";
               txbAdresaUcenika.Text = "";
               txbKontaktTelefon.Text = "";
               ddlStipendija.Text = "Izaberite...";
          }

          // dogadjaji
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
               if (Session["KorisnikImePrezime"] == null)
               {
                    Response.Redirect("Default.aspx");
               }
               else if (!IsPostBack)
               {
                    _formaUcenikUnosObject = new FormaUcenikUnosClass(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                    NapuniCombo();
                   

               }
          }

          // metoda za snimanje unetih podataka 
          protected void btnSnimi_Click(object sender, EventArgs e)
        {
            // ***********preuzimanje vrednosti sa korisnickog interfejsa
            // 2. nacin - preuzimaju atributi klase prezentacione logike
            _formaUcenikUnosObject = new FormaUcenikUnosClass(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            _formaUcenikUnosObject.JMBGUcenika = txbJMBG.Text;
               _formaUcenikUnosObject.ImeIPrezimeUcenika = txbImeIPrezimeUcenika.Text;
               _formaUcenikUnosObject.Razred = txbRazred.Text;
               _formaUcenikUnosObject.Skola = txbSkola.Text;
               _formaUcenikUnosObject.DatumRodjenja = DateTime.Parse(txbDatumRodjenja.Text);
               _formaUcenikUnosObject.AdresaUcenika = txbAdresaUcenika.Text;
               _formaUcenikUnosObject.KontaktTelefon = txbKontaktTelefon.Text;
               _formaUcenikUnosObject.NazivStipendije = ddlStipendija.SelectedValue;
            
            // *********** provera ispravnosti vrednosti
            // 1. provera popunjenosti
            bool SvePopunjeno = _formaUcenikUnosObject.DaLiJeSvePopunjeno();

            // 2. provera ispravnosti - karakteri, vrednost iz domena, jedinstvenost zapisa
            bool JedinstvenZapis = _formaUcenikUnosObject.DaLiJeJedinstvenZapis();


            // 3. provera ispravnosti - provera uskladjenosti podataka sa poslovnim pravilima
            bool UskladjenoSaPoslovnimPravilima = _formaUcenikUnosObject.DaLiSuPodaciUskladjeniSaPoslovnimPravilima();


               // ********** snimanje u bazu podataka
               string porukaStatusaSnimanja = "";
            if (SvePopunjeno)
            {
                    

                    if (JedinstvenZapis)
                    {
                         

                         if (UskladjenoSaPoslovnimPravilima)
                         {


                              // snimanje podataka
                              _formaUcenikUnosObject.SnimiPodatke();
                        // priprema teksta poruke o uspehu snimanja
                        porukaStatusaSnimanja = "USPESNO SNIMLJENI PODACI!";
                         }
                   
                  
                    else 
                    {
                        porukaStatusaSnimanja = "PODACI NISU U SKLADU SA POSLOVNIM PRAVILIMA! U OVOJ ŠKOLI JE POPUNJEN KAPACITET UČENIKA!";
                    }
                }
                else
                {
                    porukaStatusaSnimanja = "VEC POSTOJI UCENIK SA ISTIM JMBG!";
                }
            }
            else
            { 
                // priprema teksta poruke o gresci
                porukaStatusaSnimanja = "NISU SVI PODACI POPUNJENI!";
                txbJMBG.Focus();  
            }


            // ********** obavestavanje korisnika o statusu snimanja
               lblStatus.Text = porukaStatusaSnimanja;
               IsprazniKontroleNakonUpisa();


        }

        protected void btnPonisti_Click(object sender, EventArgs e)
        {
            IsprazniKontrole();
        }

        
    }
}