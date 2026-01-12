using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
     public class FormaStipendijaSpisakClass
     {
          // atributi
          private string _stringKonekcije;

          // property

          // konstruktor
          public FormaStipendijaSpisakClass(string noviStringKonekcije)
          {
               _stringKonekcije = noviStringKonekcije;
          }

          // private metode

          // public metode
          //metoda vraca podatke iz baze za tabelarni prikaz, prima parametar filter
          // gde u zavisnosti od prosledjene vrednosti prikazuju se podaci filtrirano po nazivu ili svi
          public DataSet DajPodatkeZaGrid(string filter)
          {
               DataSet dsPodaci = new DataSet();
               StipendijaDBClass stipendijaDBObject = new StipendijaDBClass(_stringKonekcije);
               if (filter == "")
               {
                    dsPodaci = stipendijaDBObject.DajSveStipendije();
               }
               else
               {
                    dsPodaci = stipendijaDBObject.DajStipendijuPoNazivu(filter);
               }
               return dsPodaci;
          }

     }
}
