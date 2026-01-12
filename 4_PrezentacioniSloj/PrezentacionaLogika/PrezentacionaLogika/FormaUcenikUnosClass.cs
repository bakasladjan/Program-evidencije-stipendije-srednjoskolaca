using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;
using PoslovnaLogika;

namespace PrezentacionaLogika
{
    public class FormaUcenikUnosClass
    {
        // atributi
          private string _stringKonekcije;
          private string _JMBGUcenika;
          private string _imeIPrezimeUcenika;
          private string _razred;
          private string _skola;
          private DateTime _datumRodjenja;
          private string _adresaUcenika;
          private string _kontaktTelefon;
          private string _nazivStipendije;


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

          public string NazivStipendije
          {
            get { return _nazivStipendije; }
            set { _nazivStipendije = value; }
          }



        // konstruktor
        public FormaUcenikUnosClass(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

          // private metode

          // public metode
          // metoda vraca sve škole, koje ce se prikazati u drop down listi 
          public DataSet DajPodatkeZaCombo()
        {
            DataSet dsPodaci = new DataSet();
            StipendijaDBClass stipendijaDBObject = new StipendijaDBClass(_stringKonekcije);

            dsPodaci = stipendijaDBObject.DajSveStipendije() ; 
            
            return dsPodaci;
        }

          //metoda proverava da li su popunjena sva polja za unos
          public bool DaLiJeSvePopunjeno()
        {
            bool SvePopunjeno = false;



            if ((_JMBGUcenika.Length > 0)
                && (_imeIPrezimeUcenika.Length > 0)
                && (_razred.Length > 0)
                && (_skola.Length > 0)
                && (_datumRodjenja != DateTime.MinValue)
                && (_adresaUcenika.Length > 0)
                && (_kontaktTelefon.Length > 0)
                && (_nazivStipendije.Length > 0)
                && (!_nazivStipendije.Equals("Izaberite...")))

            {
                SvePopunjeno = true;
            }
            else
            {
                SvePopunjeno = false;
            }

            return SvePopunjeno;
        }

          //metoda proverava da li je učenikov JMBG jedinstven u bazi
          public bool DaLiJeJedinstvenZapis()
        {
            bool JedinstvenZapis = false;
            DataSet dsPodaci = new DataSet();
            UcenikDBClass ucenikDBObject = new UcenikDBClass(_stringKonekcije);
            dsPodaci = ucenikDBObject.DajUcenikaPoJMBG(_JMBGUcenika);
            
            if (dsPodaci.Tables[0].Rows.Count == 0)
            {
                JedinstvenZapis = true;
            }
            else
            {
                JedinstvenZapis = false;
            }

            return JedinstvenZapis;

        }

          // metoda koja snima podatke u bazu
          public bool SnimiPodatke()
          {
            bool uspehSnimanja=false;

            UcenikDBClass ucenikDBObject = new UcenikDBClass(_stringKonekcije);

            UcenikClass noviUcenikObject = new UcenikClass();
               noviUcenikObject.JMBGUcenika = _JMBGUcenika;
               noviUcenikObject.ImeIPrezimeUcenika = _imeIPrezimeUcenika;
               noviUcenikObject.Razred = _razred;
               noviUcenikObject.Skola = _skola;
               noviUcenikObject.DatumRodjenja = _datumRodjenja;
               noviUcenikObject.AdresaUcenika = _adresaUcenika;
               noviUcenikObject.KontaktTelefon = _kontaktTelefon;

               StipendijaClass stipendijaObject = new StipendijaClass();

               StipendijaDBClass stipendijaDBObject = new StipendijaDBClass(_stringKonekcije);
               stipendijaObject.Sifra = stipendijaDBObject.DajSifruStipendijePoNazivu(_nazivStipendije);
               stipendijaObject.Naziv = _nazivStipendije;



            noviUcenikObject.Stipendija  = stipendijaObject; 
            
               uspehSnimanja = ucenikDBObject.SnimiNovogUcenika(noviUcenikObject); 


            return uspehSnimanja;
          }


          // metoda koja proverava da su podaci u skladu sa poslovnim pravilom, odnosno da li moze da se upise novi učenik u bazu 
          public bool DaLiSuPodaciUskladjeniSaPoslovnimPravilima()
          {
            // POSLOVNO PRAVILO:
            // Roditelj ne moze da unese vise učenika sa istom školom
            // nego sto je dozvoljeno maksimalnim brojem prema Sistematizaciji
            // broja učenika.
            bool UskladjeniPodaci = false;

               try
               {
                    PoslovnaPravilaClass objPoslovnaPravila = new PoslovnaPravilaClass(_stringKonekcije);

                    //izracunavanje ID škole
                    StipendijaDBClass stipendijaDBObject = new StipendijaDBClass(_stringKonekcije);
                    string sifra = stipendijaDBObject.DajSifruStipendijePoNazivu(_nazivStipendije);
                    UskladjeniPodaci = objPoslovnaPravila.DaLiImaMestaZaUpis(sifra);
                    return UskladjeniPodaci;
               }
               catch (Exception ex)
               {
                    Console.WriteLine("Greška prilikom provere poslovnih pravila: " + ex.Message);
                    return false;
               }
          }

    }
}
