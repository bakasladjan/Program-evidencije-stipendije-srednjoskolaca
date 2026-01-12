using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//
using System.Data;

namespace WSStipendija
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSStipendija : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet DajSveStipendije()
        {
            DataSet stipendijeDataSet = new DataSet();
            stipendijeDataSet.ReadXml(Server.MapPath("~/") + "XML/Stipendije.XML");

            return stipendijeDataSet;
        }


        [WebMethod]
          // metoda koja vraća školu po šifri
          public string DajStipendiju(string SIFRA)
        {
            string NazivStipendije = "";
            DataSet stipendijeDataSet = new DataSet();
            stipendijeDataSet.ReadXml(Server.MapPath("~/") + "XML/Stipendije.XML");
            // filtriranje dataset-a
            DataRow[] result = stipendijeDataSet.Tables[0].Select("Sifra='" + SIFRA + "'");
            NazivStipendije = result[0].ItemArray[1].ToString();

            return NazivStipendije;
        }

        [WebMethod]
          // metoda vraća šifru škole prema unetom nazivu škole

          public string DajSifruStipendije(string naziv)
        {
            string IDStipendije = "";
            DataSet stipendijeDataSet = new DataSet();
            stipendijeDataSet.ReadXml(Server.MapPath("~/") + "XML/Stipendije.XML");
            // filtriranje dataset-a
            DataRow[] result = stipendijeDataSet.Tables[0].Select("Naziv='" + naziv + "'");
            IDStipendije = result[0].ItemArray[0].ToString();

            return IDStipendije;
        }

    }
}