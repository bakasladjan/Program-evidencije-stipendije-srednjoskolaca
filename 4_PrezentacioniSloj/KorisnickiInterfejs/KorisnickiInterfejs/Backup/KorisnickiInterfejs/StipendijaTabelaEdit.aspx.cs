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
    public partial class StipendijaTabelaEdit : System.Web.UI.Page
    {
        
        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakStipendijaEdit.DataSource = ds.Tables[0];
            gvSpisakStipendijaEdit.DataBind();

            //postavljanje naziva kolona
            gvSpisakStipendijaEdit.HeaderRow.Cells[1].Text = "Šifra stipendije";
            gvSpisakStipendijaEdit.HeaderRow.Cells[2].Text = "Naziv stipendije";
            gvSpisakStipendijaEdit.HeaderRow.Cells[3].Text = "Iznos stipendije";

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
                    FormaStipendijaTabelaEditClass objFormaStipendijaTabelaEdit = new FormaStipendijaTabelaEditClass(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                    NapuniGrid(objFormaStipendijaTabelaEdit.DajPodatkeZaGrid(""));
               }
        }

        protected void gvSpisakStipendijaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("StipendijaDetaljiEdit.aspx?Sifra=" + gvSpisakStipendijaEdit.Rows[gvSpisakStipendijaEdit.SelectedIndex].Cells[1].Text); 
        }

       
    }
}