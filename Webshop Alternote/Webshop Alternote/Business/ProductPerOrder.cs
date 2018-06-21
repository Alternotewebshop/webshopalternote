using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop_Alternote.Business
{
    public class ProductPerOrder
    {
        private int _orderID;
        private int _artikelID;
        private int _aantal;
        private double _prijs;
        
        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        public int ArtikelID
        {
            get { return _artikelID; }
            set { _artikelID = value; }
        }

        public int Aantal
        {
            get { return _aantal; }
            set { _aantal = value; }
        }

        public double Prijs
        {
            get { return _prijs; }
            set {_prijs = value;}
        }


    }
}