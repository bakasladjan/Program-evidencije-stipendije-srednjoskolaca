using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//
using System.Data; 

namespace KadrovskiPodaci
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OgranicenjaStipendije : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet DajSvaOgranjcenja()
        {
            DataSet dsOgranicenja = new DataSet();
            dsOgranicenja.ReadXml(Server.MapPath("~/") + "XML/OgranicenjaStipendije.XML");

            return dsOgranicenja;
        }


        [WebMethod]
          // metoda koja vraca maksimalan broj učenika koji mogu da se ispisu
          public int DajMaxBrojUcenika(string pomSifra)
          {
              int maxBrojUcenika = 0;
              DataSet dsOgranicenja = new DataSet();
              dsOgranicenja.ReadXml(Server.MapPath("~/") + "XML/OgranicenjaStipendije.XML");
              // filtriranje dataset-a
              DataRow[] result = dsOgranicenja.Tables[0].Select("Sifra='" + pomSifra + "'");
               if (result.Length > 0 && result[0].ItemArray.Length > 1)
               {
                    maxBrojUcenika = int.Parse(result[0].ItemArray[1].ToString());
               }
               else
               {
                    // Dodajte kod za upravljanje situacijom kada nema dovoljno elemenata u nizu.
                    maxBrojUcenika = int.MaxValue;
               }

                 return maxBrojUcenika;
          }

     }
}