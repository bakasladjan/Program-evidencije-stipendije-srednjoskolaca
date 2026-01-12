using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class StipendijaListaClass
    {
        // atributi
        private List<StipendijaClass> _listaStipendija; 

        // property
        public List<StipendijaClass> ListaStipendija
        {
            get
            {
                return _listaStipendija;
            }
            set
            {
                if (this._listaStipendija != value)
                    this._listaStipendija = value;
            }
        }

        // konstruktor
        public StipendijaListaClass()
        {
            _listaStipendija = new List<StipendijaClass>(); 

        }

        // privatne metode

        // javne metode
        public void DodajElementListe(StipendijaClass novaStipendijaObject)
        {
            _listaStipendija.Add(novaStipendijaObject);
        }

        public void ObrisiElementListe(StipendijaClass stipendijaZaBrisanjeObject)
        {
            _listaStipendija.Remove(stipendijaZaBrisanjeObject);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            _listaStipendija.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(StipendijaClass staraStipendijaObject, StipendijaClass novaStipendijaObject)
        {
            int indexStareStipendije = 0;
            indexStareStipendije = _listaStipendija.IndexOf(staraStipendijaObject);
            _listaStipendija.RemoveAt(indexStareStipendije);
            _listaStipendija.Insert(indexStareStipendije, novaStipendijaObject);   
        }

           

     




    }
}
