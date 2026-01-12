using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data.SqlClient; 

namespace DBUtils
{
    public class KonekcijaClass
    {

         /* ODGOVORNOST: Konekcija na celinu baze podataka, SQL server tipa  */

        #region Atributi
        private SqlConnection _konekcija;
        //
        private string _putanjaBaze;
        private string _nazivBaze;
        private string _nazivDBMSinstance;
        private string _stringKonekcije;
        #endregion

        #region Konstruktor
        public KonekcijaClass(string nazivDBMSInstance, string putanjaBaze, string nazivBaze)
        {
            _putanjaBaze = putanjaBaze;
            _nazivBaze = nazivBaze;
            _nazivDBMSinstance = nazivDBMSInstance;
            _stringKonekcije = "";
        }

        public KonekcijaClass(string noviStringKonekcije)
        {
            _putanjaBaze = "";
            _nazivBaze = "";
            _nazivDBMSinstance = "";
            _stringKonekcije = noviStringKonekcije;
        }
          #endregion

          #region Privatne metode
          // metoda vraca string konekcije na bazu podataka
          private string DajStringKonekcije()
        {
            string mStringKonekcije;
            if (_stringKonekcije.Length.Equals(0) || _stringKonekcije == null)
            {
                // AKO NEMAMO GOTOV STRING KONEKCIJE KOJI JE DAT PUTEM KONSTRUKTORA
                if (_putanjaBaze.Length.Equals(0) || _putanjaBaze == null)
                {
                    mStringKonekcije = "Data Source=" + _nazivDBMSinstance + " ;Initial Catalog=" + _nazivBaze + ";Integrated Security=True";
                }
                else
                {
                    mStringKonekcije = "Data Source=.\\" + _nazivDBMSinstance + ";AttachDbFilename=" + _putanjaBaze + "\\" + _nazivBaze + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
                }
            }
            else
            {
                // AKO IMAMO VEC DAT GOTOV STRING KONEKCIJE
                mStringKonekcije = _stringKonekcije;
            }
            return mStringKonekcije;
        }
          #endregion

          #region Javne metode
          // metoda za otvaranje konekcije ka bazi podataka
          public bool OtvoriKonekciju()
        {
            bool uspeh;
            _konekcija = new SqlConnection();
            _konekcija.ConnectionString = DajStringKonekcije();

            try
            {
                _konekcija.Open();
                uspeh = true;
            }
            catch
            {
                uspeh = false;
            }
            return uspeh;
        }

          // metoda vraca konekciju
          public SqlConnection DajKonekciju()
        {
            return _konekcija;
        }

          // metoda zatvara konekciju
          public void ZatvoriKonekciju()
        {
            _putanjaBaze = "";
            _konekcija.Close();
            _konekcija.Dispose();
        }

        #endregion

    }
}
