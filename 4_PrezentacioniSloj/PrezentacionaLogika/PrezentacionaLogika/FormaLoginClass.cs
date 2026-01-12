using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using KlasePodataka;
using System.Data;

namespace PrezentacionaLogika
{
    public class FormaLoginClass
    {

        private string _stringKonekcije;
        
        private string _korisnickoIme;

        private string _sifra;

          private string _status;

          //property
          public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { _korisnickoIme = value; }
        }

        public string Sifra
        {
            get { return _sifra; }
            set { _sifra = value; }
        }

          public string Status
          {
               get { return _status; }
               set { _status = value; }
          }

        // konstruktor
        public FormaLoginClass(string noviStringKonekcije)
        {
               _stringKonekcije = noviStringKonekcije;
        }


          // javne metode
          // metoda proverava da li korisnik sa unetim korisnickim imenom i sifrom postoji u bazi

          public bool VazeciKorisnik()
        {
            bool vazeci = false;

            KorisnikDBClass objKorisnikDB = new KorisnikDBClass(_stringKonekcije);
            DataSet dsPodaci = objKorisnikDB.DajKorisnikaPoKorisnickomImenuISifri(_korisnickoIme, _sifra);

            if (dsPodaci.Tables[0].Rows.Count > 0)
                // pronasao ga je u bazi
            {
                vazeci = true;
            }
            else
            {
                vazeci = false;
            }

            return vazeci;

        }

          // metoda vraca ime i prezime korisnika
          public string DajImePrezimeKorisnika()
        {
            string ImePrezime = "";

               KorisnikDBClass objKorisnikDB = new KorisnikDBClass(_stringKonekcije);
            DataSet dsPodaci = objKorisnikDB.DajKorisnikaPoKorisnickomImenuISifri(_korisnickoIme, _sifra);

            if (dsPodaci.Tables[0].Rows.Count > 0)
            // pronasao ga je u bazi
            {
                ImePrezime = dsPodaci.Tables[0].Rows[0].ItemArray[2].ToString() + " " + dsPodaci.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            return ImePrezime;

        }

          // metoda vraca status korisnika
          public string DajStatusKorisnika()
          {
               string Status = "";
               KorisnikDBClass objKorisnikDB = new KorisnikDBClass(_stringKonekcije);
               DataSet dsPodaci = objKorisnikDB.DajKorisnikaPoKorisnickomImenuISifri(_korisnickoIme, _sifra);

               if (dsPodaci.Tables[0].Rows.Count > 0)
               // pronasao ga je u bazi
               {
                    Status = dsPodaci.Tables[0].Rows[0].ItemArray[5].ToString();
               }
               return Status;

          }





     }
}
