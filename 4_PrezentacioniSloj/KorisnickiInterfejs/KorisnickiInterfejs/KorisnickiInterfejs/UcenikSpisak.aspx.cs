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
using System.Diagnostics;

namespace KorisnickiInterfejs
{
    public partial class UcenikSpisak : System.Web.UI.Page
    {
        // atributi
        private FormaUcenikSpisakClass _formaUcenikSpisakObject;

        // konstruktor


        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvUcenici.DataSource = ds.Tables[0];
               gvUcenici.DataBind();

               // postavljanje naziva kolona
               gvUcenici.HeaderRow.Cells[0].Text = "JMBG učenika";
               gvUcenici.HeaderRow.Cells[1].Text = "Ime i prezime učenika";
               gvUcenici.HeaderRow.Cells[2].Text = "Razred učenika";
               gvUcenici.HeaderRow.Cells[3].Text = "Škola učenika";
               gvUcenici.HeaderRow.Cells[4].Text = "Datum rođenja";
               gvUcenici.HeaderRow.Cells[5].Text = "Adresa učenika";
               gvUcenici.HeaderRow.Cells[6].Text = "Kontakt telefon";
               gvUcenici.HeaderRow.Cells[7].Text = "Naziv stipendije";
               gvUcenici.HeaderRow.Cells[8].Text = "Iznos stipendije";

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
               _formaUcenikSpisakObject = new FormaUcenikSpisakClass(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
               if (Session["KorisnikImePrezime"] == null)
               {
                    Response.Redirect("Default.aspx");
               }
               
          }

          // prikaz uputa prema filteru - datum
          protected void btnFiltriraj_Click(object sender, EventArgs e)
        {
            NapuniGrid(_formaUcenikSpisakObject.DajPodatkeZaGrid(txbFilter.Text));   
        }

          // prikaz svih uputa
          protected void btnSvi_Click(object sender, EventArgs e)
        {
               txbFilter.Text = "";
            NapuniGrid(_formaUcenikSpisakObject.DajPodatkeZaGrid(""));   
        }
    }
}