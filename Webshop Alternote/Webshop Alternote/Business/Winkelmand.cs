using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop_Alternote.Business
{
    public class Winkelmand
    {
        private string _foto;
        private int _artikelid;
        private string _naam;
        private string _omschrijving;
        private int _aantal;
        private double _prijs;
        private double _totaal;


        public string Foto
        {
            set { _foto = value; }
            get { return _foto; }
        }

        public int ArtikelID
        {
            set { _artikelid = value; }
            get { return _artikelid; }
        }

        public string Naam
        {
            set { _naam = value; }
            get { return _naam; }
        }

        public string Omschrijving
        {
            set { _omschrijving = value; }
            get { return _omschrijving; }
        }

        public int Aantal
        {
            set { _aantal = value; }
            get { return _aantal; }
        }

        public double Prijs
        {
            set { _prijs = value; }
            get { return _prijs; }
        }

        public double Totaal
        {
            set { _totaal = value; }
            get { return _totaal; }
        }
    }
}