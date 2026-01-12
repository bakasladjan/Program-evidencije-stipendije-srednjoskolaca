using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class UcenikClass
    {
        // atributi
          private string _JMBGUcenika;
          private string _imeIPrezimeUcenika;
          private string _razred;
          private string _skola;
          private DateTime _datumRodjenja;
          private string _adresaUcenika;
          private string _kontaktTelefon;
          private StipendijaClass _stipendijaObject;

        // property
        public string JMBGUcenika
        {
               get { return _JMBGUcenika; }
               set { _JMBGUcenika = value; }
        }

        public string ImeIPrezimeUcenika
        {
               get { return _imeIPrezimeUcenika; }
               set { _imeIPrezimeUcenika = value; }
        }

        public string Razred
        {
               get { return _razred; }
               set { _razred = value; }
        }

        public string Skola
        {
               get { return _skola; }
               set { _skola = value; }
        }

        public DateTime DatumRodjenja
        {
               get { return _datumRodjenja; }
               set { _datumRodjenja = value; }
        }

        public string AdresaUcenika
        {
               get { return _adresaUcenika; }
               set { _adresaUcenika = value; }
        }

        public string KontaktTelefon
        {
               get { return _kontaktTelefon; }
               set { _kontaktTelefon = value; }
        }

        public StipendijaClass Stipendija
        {
               get { return _stipendijaObject; }
               set { _stipendijaObject = value; }
        }
    }
}
