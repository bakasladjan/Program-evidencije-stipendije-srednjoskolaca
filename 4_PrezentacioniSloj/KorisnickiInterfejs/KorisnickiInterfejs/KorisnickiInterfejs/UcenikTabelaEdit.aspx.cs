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
    public partial class UcenikTabelaEdit : System.Web.UI.Page
    {
        
        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
               gvSpisakUcenikaEdit.DataSource = ds.Tables[0];
               gvSpisakUcenikaEdit.DataBind();

               //postavljanje naziva kolona
               gvSpisakUcenikaEdit.HeaderRow.Cells[1].Text = "JMBG učenika";
               gvSpisakUcenikaEdit.HeaderRow.Cells[2].Text = "Ime i prezime učenika";
               gvSpisakUcenikaEdit.HeaderRow.Cells[3].Text = "Razred učenika";
               gvSpisakUcenikaEdit.HeaderRow.Cells[4].Text = "Škola učenika";
               gvSpisakUcenikaEdit.HeaderRow.Cells[5].Text = "Datum rođenja";
               gvSpisakUcenikaEdit.HeaderRow.Cells[6].Text = "Adresa učenika";
               gvSpisakUcenikaEdit.HeaderRow.Cells[7].Text = "Kontakt telefon";
               gvSpisakUcenikaEdit.HeaderRow.Cells[8].Text = "Naziv stipendije";
               gvSpisakUcenikaEdit.HeaderRow.Cells[9].Text = "Iznos stipendije";

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
               else if (!IsPostBack)
               {
                    FormaUcenikTabelaEditClass formaUcenikTabelaEditObject = new FormaUcenikTabelaEditClass(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                    NapuniGrid(formaUcenikTabelaEditObject.DajPodatkeZaGrid(""));
                    

               }
        }

        protected void gvSpisakUcenikaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("UcenikDetaljiEdit.aspx?JMBGUcenika=" + gvSpisakUcenikaEdit.Rows[gvSpisakUcenikaEdit.SelectedIndex].Cells[1].Text); 
        }

       
    }
}