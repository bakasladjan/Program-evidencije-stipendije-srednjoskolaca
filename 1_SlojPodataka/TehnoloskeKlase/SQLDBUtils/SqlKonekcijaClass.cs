using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data.SqlClient; 

namespace SqlDBUtils
{
    public class SqlKonekcijaClass
    {
        /* ODGOVORNOST: Konekcija na celinu baze podataka, SQL server tipa  */

        #region Atributi
        private SqlConnection _konekcija;
        //
        private string _putanjaSQLBaze;
        private string _nazivBaze;
        private string _nazivSQLDBMSinstance;
        #endregion

        #region Konstruktor
        public SqlKonekcijaClass(string nazivSQLDBMSInstance, string putanjaSqlBaze, string nazivBaze)
        {
            _putanjaSQLBaze = putanjaSqlBaze;
            _nazivBaze = nazivBaze;
            _nazivSQLDBMSinstance = nazivSQLDBMSInstance; 
        }
        #endregion

        #region Privatne metode
        private string DajStringKonekcije()
        {
            string mStringKonekcije;
            if (_putanjaSQLBaze.Length.Equals(0) || _putanjaSQLBaze==null)
            {
                mStringKonekcije = "Data Source=" + _nazivSQLDBMSinstance + " ;Initial Catalog=" + _nazivBaze + ";Integrated Security=True";
            }
            else
            {  
                mStringKonekcije = "Data Source=.\\" + _nazivSQLDBMSinstance + ";AttachDbFilename=" + _putanjaSQLBaze + "\\" + _nazivBaze +  ";Integrated Security=True;Connect Timeout=30;User Instance=True";
            }
            return mStringKonekcije;
        }
        #endregion

        #region Javne metode
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

        public SqlConnection DajKonekciju()
        {
            return _konekcija;
        }

        public void ZatvoriKonekciju()
        {
            _putanjaSQLBaze = "";
            _konekcija.Close();
            _konekcija.Dispose();
        }

        #endregion

    }
}
