using System.Xml;
using System;


namespace DBUtils
{
     public class XmlHelper
     {
          private string xmlFilePath;

          public XmlHelper(string filePath)
          {
               xmlFilePath = filePath;
          }

          public void DodajNovuStipendiju(string sifra, string naziv, int iznos)
          {
               XmlDocument xmlDoc = new XmlDocument();
               xmlDoc.Load(xmlFilePath);

               XmlElement novaStipendijaElement = xmlDoc.CreateElement("Stipendija");
            novaStipendijaElement.SetAttribute("Sifra", sifra);
            novaStipendijaElement.SetAttribute("Naziv", naziv);
            novaStipendijaElement.SetAttribute("Iznos", iznos.ToString());


            xmlDoc.DocumentElement?.AppendChild(novaStipendijaElement);

               xmlDoc.Save(xmlFilePath);
          }

          public void DodajNovuStipendijuSaOgranicenjem(string sifra, int maxBrUcenika)
          {
               XmlDocument xmlDoc = new XmlDocument();
               xmlDoc.Load(xmlFilePath);

               XmlElement novaStipendijaElement = xmlDoc.CreateElement("OgranicenjeStipendije");
               novaStipendijaElement.SetAttribute("Sifra", sifra);
               novaStipendijaElement.SetAttribute("MaxBrUcenika", maxBrUcenika.ToString());

               xmlDoc.DocumentElement?.AppendChild(novaStipendijaElement);

               xmlDoc.Save(xmlFilePath);


               // Dodajemo debug ispis da bismo proverili da li se maxBrUcenika ispravno dodaje u XML fajl
               System.Diagnostics.Debug.WriteLine("Dodato ogranicenje: Sifra=" + sifra + ", MaxBrUcenika=" + maxBrUcenika);
          }
     }
}
