using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data;
using KlasePodataka;
using PoslovnaLogika;

namespace PrezentacionaLogika
{
     public class FormaStipendijaUnosClass
     {
          // atributi
          private string _stringKonekcije;
          private string _sifra;
          private string _naziv;
          private int _iznos;


        // property
        public string Sifra
        {
               get { return _sifra; }
               set { _sifra = value; }
          }

          public string Naziv
        {
               get { return _naziv; }
               set { _naziv = value; }
          }
        public int Iznos
        {
            get { return _iznos; }
            set { _iznos = value; }
        }
       

        // konstruktor
        public FormaStipendijaUnosClass(string noviStringKonekcije)
          {
               _stringKonekcije = noviStringKonekcije;
          }

        // private metode

        // public metode


        // metoda koja snima podatke u bazu
        public bool SnimiPodatke()
        {
            bool uspehSnimanja = false;

            StipendijaDBClass stipendijaDBObject = new StipendijaDBClass(_stringKonekcije);

            StipendijaClass novaStipendijaObject = new StipendijaClass();
            novaStipendijaObject.Sifra = _sifra;
            novaStipendijaObject.Naziv = _naziv;
            novaStipendijaObject.Iznos = _iznos;

            uspehSnimanja = stipendijaDBObject.SnimiNovuStipendiju(novaStipendijaObject);

            return uspehSnimanja;
        }






    }
}
