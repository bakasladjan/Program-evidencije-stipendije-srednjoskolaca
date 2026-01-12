using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using KlasePodataka;

namespace KlaseMapiranja
{
    public class MaperClass
    {
        // atributi
        private string _stringKonekcije;

        // property

        // konstruktor
        public MaperClass(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

          // metoda vraca sifru škole na osnovu šifre škole iz baze podataka
          public string DajSifruZaWebServis(string IdStipendijeIzBazePodataka)
        {
            string IDStipendijeWS = "";
            StipendijaDBClass stipendijaDBObject = new StipendijaDBClass(_stringKonekcije);
            string nazivStipendijeIzBazePodataka = stipendijaDBObject.DajNazivStipendijePremaSifri(IdStipendijeIzBazePodataka);

            IDStipendijeWS = IdStipendijeIzBazePodataka;

               return IDStipendijeWS;

        }

    }
}
