using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data;
using PrezentacionaLogika;
using System.Configuration;
using System.Diagnostics;

namespace KorisnickiInterfejs
{
    public partial class UcenikDetaljiEdit : System.Web.UI.Page
    {
        // privatni atributi
          private string _JMBGUcenika = "";
          private string _imeIPrezimeUcenika = "";
          private string _razred = "";
          private string _skola = "";
          private string _datumRodjenja = "";
          private string _adresaUcenika = "";
          private string _kontaktTelefon = "";

          FormaUcenikDetaljiEditClass _formaUcenikDetaljiEdit;


          // nase metode
          private void NapuniCombo()
          {
               // IZDVAJANJE PODATAKA IZ XML POSREDSTVOM WEB SERVISA
               DataSet dsStipendija = new DataSet();
               dsStipendija = _formaUcenikDetaljiEdit.DajPodatkeZaCombo();

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
               txbJMBGUcenika.Text = "";
               txbImeIPrezimeUcenika.Text = "";
               txbRazred.Text = "";
               txbSkola.Text = "";
               txbDatumRodjenja.Text = "";
               txbAdresaUcenika.Text = "";
               txbKontaktTelefon.Text = "";
               ddlStipendija.Text = "Izaberite...";

          }

          // metoda koja omogucava izmenu u textbox-u
          private void AktivirajKontrole()
        {
               txbJMBGUcenika.Enabled = true;
               txbImeIPrezimeUcenika.Enabled = true;
               txbRazred.Enabled = true;
               txbSkola.Enabled = true;
               txbDatumRodjenja.Enabled = true;
               txbAdresaUcenika.Enabled = true;
               txbKontaktTelefon.Enabled = true;
               ddlStipendija.Enabled = true;
          }

          // metoda koja onemogucava izmenu podataka u textbox-u
          private void DeaktivirajKontrole()
        {
               txbJMBGUcenika.Enabled = false;
               txbImeIPrezimeUcenika.Enabled = false;
               txbRazred.Enabled = false;
               txbSkola.Enabled = false;
               txbDatumRodjenja.Enabled = false;
               txbAdresaUcenika.Enabled = false;
               txbKontaktTelefon.Enabled = false;
               ddlStipendija.Enabled = false;
          }

          // metoda koja preuzima podatke sa forme i prikazuje ih u textbox-ovima
          private void PrikaziPodatke(FormaUcenikDetaljiEditClass formaUcenikDetaljiEdit)
          {
               // podacima stranice upravlja klasa prezentacione logike, zato se uzimaju iz nje za prikaz
               txbJMBGUcenika.Text = formaUcenikDetaljiEdit.JMBGPreuzetogUcenika;
               txbImeIPrezimeUcenika.Text = formaUcenikDetaljiEdit.ImeIPrezimePreuzetogUcenika;
               txbRazred.Text = formaUcenikDetaljiEdit.RazredPreuzetogUcenika;
               txbSkola.Text = formaUcenikDetaljiEdit.SkolaPreuzetogUcenika;
               txbDatumRodjenja.Text = formaUcenikDetaljiEdit.DatumRodjenjaPreuzetogUcenika;
               txbAdresaUcenika.Text = formaUcenikDetaljiEdit.AdresaPreuzetogUcenika;
               txbKontaktTelefon.Text = formaUcenikDetaljiEdit.KontaktTelefonPreuzetogUcenika;
               ddlStipendija.SelectedValue = formaUcenikDetaljiEdit.NazivStipendijePreuzetogUcenika;

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

          // dogadjaji
          protected void Page_Load(object sender, EventArgs e)
        {
               // provera da li je korisnik prijavljen na nalog
               // nije, preusmeravanje na pocetnu stranicu

               // provera da li je korisnik prijavljen na svoj nalog
               if (Session["KorisnikImePrezime"] == null)
               {
                    Response.Redirect("Default.aspx");
               }
               
               //u suprotnom uspostavljanje konekcije, i prikaz podataka
               
                    _formaUcenikDetaljiEdit = new FormaUcenikDetaljiEditClass(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                   
                         _JMBGUcenika = Request.QueryString["JMBGUcenika"].ToString();
                         _imeIPrezimeUcenika = Request.QueryString["ImeIPrezimeUcenika"];
                         _razred = (Request.QueryString["Razred"]);
                         _skola = (Request.QueryString["Skola"]);
                         _datumRodjenja = (Request.QueryString["DatumRodjenja"]);
                         _adresaUcenika = (Request.QueryString["AdresaUcenika"]);
                         _kontaktTelefon = (Request.QueryString["KontaktTelefon"]);
                         _formaUcenikDetaljiEdit.JMBGPreuzetogUcenika = _JMBGUcenika;

                    //OVDE SE NE DOBIJAJU OSTALI PODACI SPOLJA, VEC SE IZRACUNAVAJU na set svojstvu property za JMBG UNUTAR KLASE  
                    if (!IsPostBack)
                         {
                              PrikaziPodatke(_formaUcenikDetaljiEdit);

                    }
                        
                    //}
               
        }

          // dugme za brisanje podataka iz baze
          protected void btnObrisi_Click(object sender, EventArgs e)
        {
               _formaUcenikDetaljiEdit.JMBGPreuzetogUcenika = txbJMBGUcenika.Text;
            bool uspehBrisanja = _formaUcenikDetaljiEdit.ObrisiUcenika();
            if (uspehBrisanja)
            {
                lblStatus.Text = "Uspesno obrisan zapis!";
                IsprazniKontrole();
            }
            else
            {
                lblStatus.Text = "NEUSPEH BRISANJA zapisa!";
            }
        }

          // dugme koje omogucava da se izvrsi izmena podataka
          protected void btnIzmeni_Click(object sender, EventArgs e)
        {
            
               AktivirajKontrole();
               NapuniCombo();
               ddlStipendija.SelectedValue = _formaUcenikDetaljiEdit.NazivStipendijePreuzetogUcenika;
               txbJMBGUcenika.Focus();
 
        }

          //metoda za izmenu postojecih podataka u bazi podataka
          protected void btnSnimiIzmenu_Click(object sender, EventArgs e)
        {
               // preuzimanje vrednosti
               _formaUcenikDetaljiEdit.JMBGIzmenjenogUcenika = txbJMBGUcenika.Text;
               _formaUcenikDetaljiEdit.ImeIPrezimeIzmenjenogUcenika = txbImeIPrezimeUcenika.Text;
               _formaUcenikDetaljiEdit.RazredIzmenjenogUcenika = txbRazred.Text;
               _formaUcenikDetaljiEdit.SkolaIzmenjenogUcenika = txbSkola.Text;
               _formaUcenikDetaljiEdit.DatumRodjenjaIzmenjenogUcenika = DateTime.Parse(txbDatumRodjenja.Text);
               _formaUcenikDetaljiEdit.AdresaIzmenjenogUcenika = txbAdresaUcenika.Text;
               _formaUcenikDetaljiEdit.KontaktTelefonIzmenjenogUcenika = txbKontaktTelefon.Text;
               _formaUcenikDetaljiEdit.NazivStipendijeIzmenjenogUcenika = ddlStipendija.SelectedValue;

               bool uspehIzmene = _formaUcenikDetaljiEdit.IzmeniUcenika();
            if (uspehIzmene)
            {
                lblStatus.Text = "Uspesno izmenjen zapis!";
                IsprazniKontrole();
            }
            else
            {
                lblStatus.Text = "NEUSPEH BRISANJA zapisa!";
            }
            DeaktivirajKontrole();
        }

     }
}