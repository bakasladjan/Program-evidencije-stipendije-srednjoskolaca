using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaUcenikTabelaEditClass
    {
        // atributi
        private string _stringKonekcije;

        // property

        // konstruktor
        public FormaUcenikTabelaEditClass(string noviStringKonekcije)
        {
               _stringKonekcije = noviStringKonekcije;
        }

          // private metode

          // public metode
          //metoda vraca podatke iz baze za tabelarni prikaz, prima parametar filter
          // gde u zavisnosti od prosledjene vrednosti prikazuju se podaci filtrirano po JMBG ili svi
          public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet dsPodaci = new DataSet();
            UcenikDBClass ucenikDBObject = new UcenikDBClass(_stringKonekcije);            
            if (filter.Equals(""))
            {
                dsPodaci = ucenikDBObject.DajSveUcenike(); 
            }
            else
            {
                dsPodaci = ucenikDBObject.DajUcenikaPoJMBG(filter); 
            }
            return dsPodaci;
        }
    }
}
