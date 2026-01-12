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

namespace KorisnickiInterfejs
{
    public partial class UcenikStampa : System.Web.UI.Page
    {
          // atributi
          private FormaUcenikSpisakClass _formaUcenikSpisakObject;

        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
               gvSpisakUcenika.DataSource = ds.Tables[0];
               gvSpisakUcenika.DataBind();

               //postavljanje naziva kolona
               gvSpisakUcenika.HeaderRow.Cells[0].Text = "JMBG učenika";
               gvSpisakUcenika.HeaderRow.Cells[1].Text = "Ime i prezime učenika";
               gvSpisakUcenika.HeaderRow.Cells[2].Text = "Razred učenika";
               gvSpisakUcenika.HeaderRow.Cells[3].Text = "Škola Učenika";
               gvSpisakUcenika.HeaderRow.Cells[4].Text = "Datum rođenja";
               gvSpisakUcenika.HeaderRow.Cells[5].Text = "Adresa učenika";
               gvSpisakUcenika.HeaderRow.Cells[6].Text = "Kontakt telefon";
               gvSpisakUcenika.HeaderRow.Cells[7].Text = "Naziv stipendije";
               gvSpisakUcenika.HeaderRow.Cells[8].Text = "Iznos stipendije";

        }

          // metoda koja koja prverava da li je uneta neka vrednost za filter
          // i na osnovu toga se prikazuju rezultati u vidu tabele sa podacima 

          

          protected void Page_Load(object sender, EventArgs e)
        {
               if (Session["KorisnikImePrezime"] == null)
               {
                    Response.Redirect("Default.aspx");
               }
               

               string filter = "";
            _formaUcenikSpisakObject = new FormaUcenikSpisakClass(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
               try
               {
                    if ((Request.QueryString["filter"] == null))
                    {
                         filter = "";
                    }
                    else
                    {
                         filter = Request.QueryString["filter"].ToString();
                    }

                    if (filter.Equals("") || (filter == null))
                    {
                         lblNaslov.Text = "SPISAK SVIH UČENIKA";
                         NapuniGrid(_formaUcenikSpisakObject.DajPodatkeZaGrid(filter));
                    }
                    else
                    {
                         lblNaslov.Text = "FILTRIRANI SPISAK UČENIKA, JMBG = " + filter;
                         NapuniGrid(_formaUcenikSpisakObject.DajPodatkeZaGrid(filter));


                    }
               }
               catch (Exception)
               {
                    lblNaslov.Text = "GREŠKA";
               }

          }
    }
}