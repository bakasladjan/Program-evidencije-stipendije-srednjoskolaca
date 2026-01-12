using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaStipendijaTabelaEditClass
    {
        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public FormaStipendijaTabelaEditClass(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet dsPodaci = new DataSet();
            StipendijaDBClass objStipendijaDB = new StipendijaDBClass(pStringKonekcije);            
            if (filter.Equals(""))
            {
                dsPodaci = objStipendijaDB.DajSveStipendije(); 
            }
            else
            {
                dsPodaci = objStipendijaDB.DajStipendijuPoNazivu(filter); 
            }
            return dsPodaci;
        }
    }
}
