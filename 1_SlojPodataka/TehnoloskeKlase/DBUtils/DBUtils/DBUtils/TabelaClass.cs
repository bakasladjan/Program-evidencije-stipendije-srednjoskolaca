using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data.SqlClient; 


namespace DBUtils
{
    public class TabelaClass
    {

          #region Atributi
          // privatni atributi
          private string _nazivTabele;
        private KonekcijaClass _konekcija;
        private SqlDataAdapter _adapter;
        private System.Data.DataSet _dataSet;
        
        #endregion

        #region Konstruktor

        public TabelaClass(KonekcijaClass konekcija, string nazivTabele)
        {
            _konekcija = konekcija;
            _nazivTabele = nazivTabele;
        }
        
        #endregion

        #region Privatne metode

        private void KreirajAdapter(string selectUpit, string insertUpit, string deleteUpit, string updateUpit)
        {
            SqlCommand mSelectKomanda, mInsertKomanda, mDeleteKomanda, mUpdateKomanda;

            mSelectKomanda = new SqlCommand();
            mSelectKomanda.CommandText = selectUpit;
            mSelectKomanda.Connection = _konekcija.DajKonekciju();

            mInsertKomanda = new SqlCommand();
            mInsertKomanda.CommandText = insertUpit;
            mInsertKomanda.Connection = _konekcija.DajKonekciju();

            mDeleteKomanda = new SqlCommand();
            mDeleteKomanda.CommandText = deleteUpit;
            mDeleteKomanda.Connection = _konekcija.DajKonekciju();

            mUpdateKomanda = new SqlCommand();
            mUpdateKomanda.CommandText = updateUpit;
            mUpdateKomanda.Connection = _konekcija.DajKonekciju();

               _adapter = new SqlDataAdapter();
               _adapter.SelectCommand = mSelectKomanda;
               _adapter.InsertCommand = mInsertKomanda;
               _adapter.UpdateCommand = mUpdateKomanda;
               _adapter.DeleteCommand = mDeleteKomanda;
        }

        private void KreirajDataset()
        {
            _dataSet = new System.Data.DataSet();
            _adapter.Fill(_dataSet, _nazivTabele);
            
        }

        private void ZatvoriAdapterDataset()
        {
            _adapter.Dispose();
            _dataSet.Dispose();
        }
        
        #endregion

        #region Javne metode

        public System.Data.DataSet DajPodatke(string selectUpit)
            // izdvaja podatke u odnosu na dat selectupit
        {
            KreirajAdapter(selectUpit, "", "", "");
            KreirajDataset();
            return _dataSet;
        }

        public int DajBrojSlogova()
        {
            int brojSlogova = _dataSet.Tables[0].Rows.Count; 
            return brojSlogova;
        }

        public bool IzvrsiAzuriranje(string upit)
            // izvrzava azuriranje unos/brisanje/izmena u odnosu na dati i upit
        {

            //
            bool uspeh = false;
           SqlConnection mKonekcija;
           SqlCommand Komanda;
           SqlTransaction mTransakcija = null; 
            try
            {
                mKonekcija = _konekcija.DajKonekciju();
                // aktivan kod  

                // povezivanje
                Komanda = new SqlCommand();
                Komanda.Connection = mKonekcija;
                Komanda = mKonekcija.CreateCommand();
                // pokretanje
                // NE TREBA OPEN JER DOBIJAMO OTVORENU KONEKCIJU KROZ KONSTRUKTOR
                // mKonekcija.Open();
                mTransakcija = mKonekcija.BeginTransaction();
                Komanda.Transaction = mTransakcija;
                Komanda.CommandText = upit;
                Komanda.ExecuteNonQuery();
                mTransakcija.Commit();
                uspeh = true;
            }
            catch
            {
                mTransakcija.Rollback();
                uspeh = false;
            }
            return uspeh;
        }


        #endregion

    }
}
