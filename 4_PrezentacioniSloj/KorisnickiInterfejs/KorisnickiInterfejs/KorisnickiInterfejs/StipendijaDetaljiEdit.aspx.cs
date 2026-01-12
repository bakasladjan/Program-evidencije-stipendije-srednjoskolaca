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
    public partial class StipendijaDetaljiEdit : System.Web.UI.Page
    {
        // atributi
        private string pSifra = "";
        private string pNaziv = "";
        private string pIznos = "";


        FormaStipendijaDetaljiEditClass objFormaStipendijaDetaljiEdit; 

        // nase metode
        private void IsprazniKontrole()
        {
            txbSifra.Text = "";
            txbNaziv.Text = "";
            txbIznos.Text = "";


        }

        private void AktivirajKontrole()
        {
            txbSifra.Enabled = true;
            txbNaziv.Enabled = true;
            txbIznos.Enabled = true;

        }

        private void DeaktivirajKontrole()
        {
            txbSifra.Enabled = false;
            txbNaziv.Enabled = false;
            txbIznos.Enabled = false;

        }

        private void PrikaziPodatke(FormaStipendijaDetaljiEditClass objFormaStipendijaDetaljiEdit)
        {
            // podacima stranice upravlja klasa prezentacione logike, zato se uzimaju iz nje za prikaz
               txbSifra.Text = objFormaStipendijaDetaljiEdit.SifraPreuzeteStipendije;
               txbNaziv.Text = objFormaStipendijaDetaljiEdit.NazivPreuzeteStipendije;
               txbIznos.Text = objFormaStipendijaDetaljiEdit.IznosPreuzeteStipendije;



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

               if (Session["KorisnikImePrezime"] == null)
               {
                    Response.Redirect("Default.aspx");
               }
               
               //u suprotnom uspostavljanje konekcije, i prikaz podataka
               else
               {
                    objFormaStipendijaDetaljiEdit = new FormaStipendijaDetaljiEditClass(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                    pSifra = Request.QueryString["Sifra"].ToString();
                    pNaziv = Request.QueryString["Naziv"];
                    pIznos = Request.QueryString["Iznos"];


                objFormaStipendijaDetaljiEdit.SifraPreuzeteStipendije = pSifra;
                    
                    // OVDE SE NE DOBIJA NAZIV SPOLJA, VEC SE IZRACUNAVA NAZIV na set svojstvu property za sifru UNUTAR KLASE  
                    if (!IsPostBack)
                    {

                         PrikaziPodatke(objFormaStipendijaDetaljiEdit);
                    }
               }
        }

        protected void btnObrisi_Click(object sender, EventArgs e)
        {
            objFormaStipendijaDetaljiEdit.SifraPreuzeteStipendije = txbSifra.Text;
            bool uspehBrisanja = objFormaStipendijaDetaljiEdit.ObrisiStipendiju();
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

        protected void btnIzmeni_Click(object sender, EventArgs e)
        {
            // PREUZIMANJE POCETNIH, STARIH VREDNOSTI - OVDE NEMA POTREBE JER SE URADI NA PAGE LOAD
            //objFormaZvanjeDetaljiEdit.SifraPreuzetogZvanja = txbSifra.Text;
            // - ovo se izracuna iz sifre, pa se ne moze ni dodeliti: objFormaZvanjeDetaljiEdit.NazivPreuzetogZvanja = txbNaziv.Text; 
            AktivirajKontrole();
            txbSifra.Focus();
 
        }

        protected void btnSnimiIzmenu_Click(object sender, EventArgs e)
        {
            objFormaStipendijaDetaljiEdit.SifraIzmenjeneStipendije = txbSifra.Text;
            objFormaStipendijaDetaljiEdit.NazivIzmenjeneStipendije = txbNaziv.Text;
            objFormaStipendijaDetaljiEdit.IznosIzmenjeneStipendije = txbIznos.Text;
            bool uspehIzmene = objFormaStipendijaDetaljiEdit.IzmeniStipendiju();
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