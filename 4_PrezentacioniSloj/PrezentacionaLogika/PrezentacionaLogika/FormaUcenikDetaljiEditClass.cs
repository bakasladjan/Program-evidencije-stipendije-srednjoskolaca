using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaUcenikDetaljiEditClass
    {
   // privatni atributi
        private string _stringKonekcije;
        private UcenikDBClass _ucenikDBObject;

        private UcenikClass _preuzetiUcenikObject;
        private UcenikClass _izmenjeniUcenikObject;

          private string _JMBGPreuzetogUcenika;
          private string _imeIPrezimePreuzetogUcenika;
          private string _razredPreuzetogUcenika;
          private string _skolaPreuzetogUcenika;
          private DateTime _datumRodjenjaPreuzetogUcenika;
          private string _adresaPreuzetogUcenika;
          private string _kontaktTelefonPreuzetogUcenika;
          private string _nazivStipendijePreuzetogUcenika;


          private string _JMBGIzmenjenogUcenika;
          private string _imeIPrezimeIzmenjenogUcenika;
          private string _razredIzmenjenogUcenika;
          private string _skolaIzmenjenogUcenika;
          private DateTime _datumRodjenjaIzmenjenogUcenika;
          private string _adresaIzmenjenogUcenika;
          private string _kontaktTelefonIzmenjenogUcenika;
          private string _nazivStipendijeIzmenjenogUcenika;


        // PROPERTY

        public string JMBGPreuzetogUcenika
        {
            get { return _JMBGPreuzetogUcenika; }
            set {
                    _JMBGPreuzetogUcenika = value;
                    _imeIPrezimePreuzetogUcenika = DajImeIPrezimeUcenika(_JMBGPreuzetogUcenika);
                    _razredPreuzetogUcenika = DajRazredUcenika(_JMBGPreuzetogUcenika);
                    _skolaPreuzetogUcenika = DajSkoluUcenika(_JMBGPreuzetogUcenika);
                    _datumRodjenjaPreuzetogUcenika = DateTime.Parse(DajDatumRodjenjaUcenika(_JMBGPreuzetogUcenika).ToString());
                    _adresaPreuzetogUcenika = DajAdresuUcenika(_JMBGPreuzetogUcenika);
                    _kontaktTelefonPreuzetogUcenika = DajKontaktTelefonUcenika(_JMBGPreuzetogUcenika);
                    _nazivStipendijePreuzetogUcenika = DajNazivStipendije(_JMBGPreuzetogUcenika);


            }
          }

          public string ImeIPrezimePreuzetogUcenika
          {
          get { return _imeIPrezimePreuzetogUcenika; }
          
          }

        public string RazredPreuzetogUcenika
        {
            get { return _razredPreuzetogUcenika; }
            
        }
        public string SkolaPreuzetogUcenika
        {
            get { return _skolaPreuzetogUcenika; }
            
        }

        public string DatumRodjenjaPreuzetogUcenika
          {
               get { return _datumRodjenjaPreuzetogUcenika.ToString(); }
             
          }

          public string AdresaPreuzetogUcenika
          {
               get { return _adresaPreuzetogUcenika; }
              
          }

         

          public string KontaktTelefonPreuzetogUcenika
          {
               get { return _kontaktTelefonPreuzetogUcenika; }
            
          }

          public string NazivStipendijePreuzetogUcenika
          {
               get { return _nazivStipendijePreuzetogUcenika; }
              
          }

       

        public string JMBGIzmenjenogUcenika
          {
           get { return _JMBGIzmenjenogUcenika; }
           set { _JMBGIzmenjenogUcenika = value; }

           }


          public string ImeIPrezimeIzmenjenogUcenika
          {
            get { return _imeIPrezimeIzmenjenogUcenika; }
            set { _imeIPrezimeIzmenjenogUcenika = value; }
          }
          public string RazredIzmenjenogUcenika
          {
            get { return _razredIzmenjenogUcenika; }
            set { _razredIzmenjenogUcenika = value; }

          }

          public string SkolaIzmenjenogUcenika
          {
            get { return _skolaIzmenjenogUcenika; }
            set { _skolaIzmenjenogUcenika = value; }

          }

        public DateTime DatumRodjenjaIzmenjenogUcenika
          {
               get { return _datumRodjenjaIzmenjenogUcenika; }
               set { _datumRodjenjaIzmenjenogUcenika = value; }

          }

          public string AdresaIzmenjenogUcenika
          {
               get { return _adresaIzmenjenogUcenika; }
               set { _adresaIzmenjenogUcenika = value; }

          }

          

          public string KontaktTelefonIzmenjenogUcenika
          {
               get { return _kontaktTelefonIzmenjenogUcenika; }
               set { _kontaktTelefonIzmenjenogUcenika = value; }

          }


          public string NazivStipendijeIzmenjenogUcenika
          {
               get { return _nazivStipendijeIzmenjenogUcenika; }
               set { _nazivStipendijeIzmenjenogUcenika = value; }

          }

       

        // konstruktor
        public FormaUcenikDetaljiEditClass(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
            _ucenikDBObject = new UcenikDBClass(_stringKonekcije);
        }

          // privatne metode
          public DataSet DajPodatkeZaCombo()
          {
               DataSet dsPodaci = new DataSet();
               StipendijaDBClass stipendijaDBObject = new StipendijaDBClass(_stringKonekcije);

               dsPodaci = stipendijaDBObject.DajSveStipendije();

               return dsPodaci;
          }

          private string DajImeIPrezimeUcenika(string pomSifra)
        {
            string pomImeIPrezime ="";
            DataSet dsPodaci = new DataSet();
            pomImeIPrezime = _ucenikDBObject.DajImeIPrezimeUcenikaPoJMBG(pomSifra); 

            return pomImeIPrezime;
        }
        private string DajRazredUcenika(string pomSifra)
        {
            string pomRazredUcenika = "";
            DataSet dsPodaci = new DataSet();
            pomRazredUcenika = _ucenikDBObject.DajRazredPoJMBG(pomSifra);

            return pomRazredUcenika;
        }

        private string DajSkoluUcenika(string pomSifra)
        {
            string pomSkola = "";
            DataSet dsPodaci = new DataSet();
            pomSkola = _ucenikDBObject.DajSkoluPoJMBG(pomSifra);

            return pomSkola;
        }

        private DateTime DajDatumRodjenjaUcenika(string pomSifra)
          {
               DateTime pomDatumRodjenja = DateTime.Today;
               DataSet dsPodaci = new DataSet();
               pomDatumRodjenja = _ucenikDBObject.DajDatumRodjenjaPoJMBG(pomSifra);

               return pomDatumRodjenja;
          }

          private string DajAdresuUcenika(string pomSifra)
          {
               string pomAdresa = "";
               DataSet dsPodaci = new DataSet();
               pomAdresa = _ucenikDBObject.DajAdresuUcenikaPoJMBG(pomSifra);

               return pomAdresa;
          }

          

          private string DajKontaktTelefonUcenika(string pomSifra)
          {
               string pomKontaktTelefon = "";
               DataSet dsPodaci = new DataSet();
               pomKontaktTelefon = _ucenikDBObject.DajKontaktTelefonPoJMBG(pomSifra);

               return pomKontaktTelefon;
          }

          private string DajNazivStipendije(string pomSifra)
          {
               string pomNaziv = "";
               DataSet dsPodaci = new DataSet();
               pomNaziv = _ucenikDBObject.DajNazivStipendijePoJMBG(pomSifra);

               return pomNaziv;
          }

       

        // javne metode
        //metoda za brisanje učenika
        public bool ObrisiUcenika()
        {
            // učenik koji je trenutno u atributima dat, TJ. preuzet JMBG je bitan
            bool uspehBrisanja = false;
            uspehBrisanja = _ucenikDBObject.ObrisiUcenika(_JMBGPreuzetogUcenika);  

            return uspehBrisanja;

        }

          // metoda za azurriranje podataka postojeceg učenika
          public bool IzmeniUcenika()
        {
               bool uspehIzmene = false;
               _preuzetiUcenikObject = new UcenikClass();
               _izmenjeniUcenikObject = new UcenikClass();
               _preuzetiUcenikObject.ImeIPrezimeUcenika = _imeIPrezimePreuzetogUcenika;
               _preuzetiUcenikObject.JMBGUcenika = _JMBGPreuzetogUcenika;
               _preuzetiUcenikObject.Razred = _razredPreuzetogUcenika;
               _preuzetiUcenikObject.Skola = _skolaPreuzetogUcenika;
               _preuzetiUcenikObject.DatumRodjenja = _datumRodjenjaPreuzetogUcenika;
               _preuzetiUcenikObject.AdresaUcenika = _adresaPreuzetogUcenika;
               _preuzetiUcenikObject.KontaktTelefon = _kontaktTelefonPreuzetogUcenika;

               StipendijaClass stipendijaObject = new StipendijaClass();

               StipendijaDBClass stipendijaDBObject = new StipendijaDBClass(_stringKonekcije);
               stipendijaObject.Sifra = stipendijaDBObject.DajSifruStipendijePoNazivu(_nazivStipendijePreuzetogUcenika);
               stipendijaObject.Naziv = _nazivStipendijePreuzetogUcenika;



            _preuzetiUcenikObject.Stipendija = stipendijaObject;

               _izmenjeniUcenikObject.ImeIPrezimeUcenika = _imeIPrezimeIzmenjenogUcenika;
               _izmenjeniUcenikObject.JMBGUcenika = _JMBGIzmenjenogUcenika;
               _izmenjeniUcenikObject.Razred = _razredIzmenjenogUcenika;
               _izmenjeniUcenikObject.Skola = _skolaIzmenjenogUcenika;
               _izmenjeniUcenikObject.DatumRodjenja = _datumRodjenjaIzmenjenogUcenika;
               _izmenjeniUcenikObject.AdresaUcenika = _adresaIzmenjenogUcenika;
               _izmenjeniUcenikObject.KontaktTelefon = _kontaktTelefonIzmenjenogUcenika;

            StipendijaClass novaStipendijaObject = new StipendijaClass();

            StipendijaDBClass novaStipendijaDBObject = new StipendijaDBClass(_stringKonekcije);
            novaStipendijaObject.Sifra = novaStipendijaDBObject.DajSifruStipendijePoNazivu(_nazivStipendijeIzmenjenogUcenika);
            novaStipendijaObject.Naziv = _nazivStipendijeIzmenjenogUcenika;


            _izmenjeniUcenikObject.Stipendija = novaStipendijaObject;

               uspehIzmene = _ucenikDBObject.IzmeniUcenika(_preuzetiUcenikObject, _izmenjeniUcenikObject);  

            return uspehIzmene;
        }
    }
}
