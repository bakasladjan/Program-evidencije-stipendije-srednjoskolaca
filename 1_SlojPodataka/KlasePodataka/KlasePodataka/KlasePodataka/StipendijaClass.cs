using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class StipendijaClass
    {
        // atributi
          private string _sifra;
          private string _naziv;
          private int _iznos;


        // property
        public string Sifra
             {
                 get
                 {
                     return _sifra;
                 }
                 set
                 {
                     _sifra = value;
                 }
             }

             public string Naziv
             {
                 get
                 {
                     return _naziv;
                 }
                 set
                 {
                     _naziv = value;
                 }
             }

        public int Iznos
        {
            get
            {
                return _iznos;
            }
            set
            {
                _iznos = value;
            }
        }

        


        // konstruktor
        public StipendijaClass()
        {
               _sifra = "";
               _naziv = "";
               _iznos = 0;



        }

        // privatne metode

        // javne metode
    }
}
