using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using DBUtils;
using System.Configuration;
using System.Data;
using PrezentacionaLogika;
using System.Diagnostics;

namespace KorisnickiInterfejs
{
    public partial class StipendijaTabelarni : System.Web.UI.Page
    {
          // atributi
          private FormaStipendijaSpisakClass _formaStipendijaSpisakObject;

          private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakStipendija.DataSource = ds.Tables[0];
            gvSpisakStipendija.DataBind();

            //postavljanje naziva kolona
            gvSpisakStipendija.HeaderRow.Cells[0].Text = "Šifra stipendije";
            gvSpisakStipendija.HeaderRow.Cells[1].Text = "Naziv stipendije";
            gvSpisakStipendija.HeaderRow.Cells[2].Text = "Iznos stipendije";


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
               if (Session["KorisnikImePrezime"] == null)
               {
                    Response.Redirect("Default.aspx");
               }
               
          }

          // prikaz podataka prema filteru
          protected void btnFiltriraj_Click(object sender, EventArgs e)
        {

               _formaStipendijaSpisakObject = new FormaStipendijaSpisakClass(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
               NapuniGrid(_formaStipendijaSpisakObject.DajPodatkeZaGrid(txbFilter.Text));
        }

          // prikaz svih podataka
          protected void btnSvi_Click(object sender, EventArgs e)
        { 
               _formaStipendijaSpisakObject = new FormaStipendijaSpisakClass(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
               NapuniGrid(_formaStipendijaSpisakObject.DajPodatkeZaGrid(txbFilter.Text));
          }
    }
}