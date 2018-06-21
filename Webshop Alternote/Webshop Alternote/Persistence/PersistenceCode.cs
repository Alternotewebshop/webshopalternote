using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Webshop_Alternote.Business;
using System.Net.Mail;


namespace Webshop_Alternote.Persistence
{
    public class PersistenceCode
    {
        //De connection string
        private string conn = "server=localhost;user id=root;password=Test123 ;database=dbalternote";


        //--------------------------------------------------------
        //Methods die nodig zijn bij catalogus en toevoeg pagina's
        //--------------------------------------------------------

        //Lijst van alle producten ophalen.
        public List<Artikel> HaalAlleArtikelsOp()
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select * from tblartikels";
            MySqlCommand cmd = new MySqlCommand(querry, sqlcon);
            MySqlDataReader dtr = cmd.ExecuteReader();
            List<Artikel> lijst = new List<Artikel>();
            while (dtr.Read())
            {
                Artikel _artikel = new Artikel();
                _artikel.artikelID = Convert.ToInt32(dtr["artikelID"]);
                _artikel.Naam = Convert.ToString(dtr["naam"]);
                _artikel.Omschrijving = Convert.ToString(dtr["omschrijving"]);
                _artikel.Prijs = Convert.ToDouble(dtr["prijs"]);
                _artikel.Voorraad = Convert.ToInt32(dtr["voorraad"]);
                _artikel.Foto = Convert.ToString(dtr["foto"]);
                lijst.Add(_artikel);
            }
            sqlcon.Close();
            return lijst;
        }

        //Ophalen van 1 artikel
        public Artikel HaalEénArtikelOp(int artikelID)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select * from tblartikels where  artikelid=" + artikelID;
            MySqlCommand cmd = new MySqlCommand(querry, sqlcon);
            MySqlDataReader dtr = cmd.ExecuteReader();
            Artikel _artikel = new Artikel();
            while (dtr.Read())
            {
                _artikel.artikelID = Convert.ToInt32(dtr["artikelID"]);
                _artikel.Naam = Convert.ToString(dtr["naam"]);
                _artikel.Omschrijving = Convert.ToString(dtr["omschrijving"]);
                _artikel.Prijs = Convert.ToDouble(dtr["prijs"]);
                _artikel.Voorraad = Convert.ToInt32(dtr["voorraad"]);
                _artikel.Foto = Convert.ToString(dtr["foto"]);
            }
            sqlcon.Close();
            return _artikel;
        }

        //Kijken of het artikel al in het winkelmandje zit
        public bool InHetMandjeOfNiet(int klantid, int artikelid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select klantid, artikelid from tblwinkelmand where klantid="+klantid + " and artikelid="+ artikelid;
            MySqlCommand cmd = new MySqlCommand(querry, sqlcon);
            MySqlDataReader dtr = cmd.ExecuteReader();
            if (dtr.HasRows)
            {
                sqlcon.Close();
                return true;
            }
            else
            {
                sqlcon.Close();
                return false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------




        //-------------------------------------------
        //Methods die nodig zijn bij het winkelmandje
        //-------------------------------------------

        //Info van de aangemelde klant binnenhalen
        public Klant HaalKlantOP(int klantid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select * from tblklant where klantid="+ klantid;
            MySqlCommand cmd = new MySqlCommand(querry, sqlcon);
            MySqlDataReader dtr = cmd.ExecuteReader();
            Klant _klant = new Klant();
            while (dtr.Read())
            {
                _klant.KlantID = Convert.ToInt32(dtr["klantid"]);
                _klant.Naam = Convert.ToString(dtr["naam"]);
                _klant.Voornaam = Convert.ToString(dtr["voornaam"]);
                _klant.Adres = Convert.ToString(dtr["adres"]);
                _klant.Mail = Convert.ToString(dtr["mail"]);
                _klant.Postcode = Convert.ToString(dtr["postcode"]);
                _klant.Gemeente = Convert.ToString(dtr["gemeente"]);
            }
            sqlcon.Close();
            return _klant;
        }

        //Controleren van de klant na het aanmelden
        public bool CheckBestaanKlant(string gebruikersnaam, string wachtwoord)
        {
            MySqlConnection sqlconn = new MySqlConnection(conn);
            sqlconn.Open();
            string qry = "select gebruikersnaam, wachtwoord from tblklant where gebruikersnaam='" + gebruikersnaam + "' and wachtwoord='" + wachtwoord + "'";
            MySqlCommand cmd = new MySqlCommand(qry, sqlconn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            if(dtr.HasRows)
            {
                sqlconn.Close();
                return true;
            }
            else
            {
                sqlconn.Close();
                return false;
            }
        }

        //Ophalen van de klanten(id)
        public int OphalenIDMetGebruikersnaam(string gebruikernsnaam)
        {
            MySqlConnection sqlconn = new MySqlConnection(conn);
            sqlconn.Open();
            string qry = "select klantid from tblklant where gebruikersnaam='"+gebruikernsnaam+"'";
            MySqlCommand cmd = new MySqlCommand(qry, sqlconn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            int id = 0;
            while(dtr.Read())
            {
                id = Convert.ToInt32(dtr["klantid"]);
            }
            sqlconn.Close();
            return id;
            
        }

        //Vullen van het winkelmandje (van uit de toevoegpagina)
        public void VulWinkelmandje(int klantID, int productID, int aantal)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "insert into tblwinkelmand (klantID,artikelID,aantal) values (" + klantID + "," + productID + "," + aantal + ")";
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }

        //afttrekken van voorraad na toevoegen aan winkelmand
        public void VoorraadAftrekkenNaToevoegen(int artikelid, int aantal)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string qry = "update tblartikels set voorraad = (voorraad-" + aantal + ")  where artikelID =" + artikelid;
            MySqlCommand cmd = new MySqlCommand(qry, sqlcon);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }

        //Optellen van voorraad na verwijderen uit winkelmand
        public void VoorraadTerugToevoegen(int artikelid, int aantal)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string qry = "update tblartikels set voorraad = (voorraad+" + aantal + ")  where artikelID =" + artikelid;
            MySqlCommand cmd = new MySqlCommand(qry, sqlcon);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }


        //Kijken of de winkelmand niet leeg is
        public bool LeegOfNiet(int klantid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select * from tblklant where klantid="+ klantid;
            MySqlCommand cmd = new MySqlCommand(querry, sqlcon);
            MySqlDataReader dtr = cmd.ExecuteReader();
            Winkelmand _winkelmand = new Winkelmand();
            if(dtr.HasRows)
            {
                sqlcon.Close();
                return true;
            }
            else
            {
                sqlcon.Close();
                return false;
            }
        }

        //Ophalen van alle gegevens die in het winkelmandje zitten
        public List<Winkelmand> OphalenWinkelmand(int klantID)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "SELECT foto, tblartikels.artikelID, naam,omschrijving,aantal,prijs from tblartikels inner join tblwinkelmand on tblartikels.artikelID = tblwinkelmand.artikelID where klantid=" + klantID;
            MySqlCommand cmd = new MySqlCommand(querry, sqlcon);
            MySqlDataReader dtr = cmd.ExecuteReader();
            List<Winkelmand> lijst = new List<Winkelmand>();
            while(dtr.Read())
            {
                Winkelmand _winkelmand = new Winkelmand();
                _winkelmand.Foto = Convert.ToString(dtr["foto"]);
                _winkelmand.ArtikelID = Convert.ToInt32(dtr["artikelid"]);
                _winkelmand.Omschrijving = Convert.ToString(dtr["omschrijving"]);
                _winkelmand.Naam = Convert.ToString(dtr["naam"]);
                _winkelmand.Aantal = Convert.ToInt32(dtr["aantal"]);
                _winkelmand.Prijs = Convert.ToDouble(dtr["prijs"]);
                _winkelmand.Totaal = (Convert.ToDouble(dtr["prijs"]) * Convert.ToInt32(dtr["aantal"]));

                lijst.Add(_winkelmand);
            }
            sqlcon.Close();
            return lijst;
        }

        //berekenen van de totale prijs van alle artikelen in het winkelmandje
        public double TotalePrijsWinkelmand(int klantID)
        {
            MySqlConnection sqlconn = new MySqlConnection(conn);
            sqlconn.Open();
            string qry = "select sum(tblwinkelmand.aantal*prijs)as totaal  from tblartikels inner join tblwinkelmand on tblwinkelmand.artikelid = tblartikels.artikelid where klantid=" + klantID + " order by totaal";
            MySqlCommand cmd = new MySqlCommand(qry, sqlconn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            double TotaalPrijs = 0;
            while (dtr.Read())
            {
                TotaalPrijs = Convert.ToDouble(dtr["totaal"]);
            }
            sqlconn.Close();
            return TotaalPrijs;
        }

       
        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------


        //---------------------------------------------------
        //Methods die nodig zijn voor het maken van het order
        //---------------------------------------------------

        //Aanmaken van het order
        public void tblOrdersInvullen(int klantid)
        {
            MySqlConnection sqlconn = new MySqlConnection(conn);
            sqlconn.Open();
            string juistedatum = DateTime.Today.ToString("yyyy-MM-dd"); //DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day.;
            string qry = "insert into tblorders (datum,klantid) values ('" + juistedatum + "', " + klantid + ")";
            MySqlCommand cmd = new MySqlCommand(qry,sqlconn);
            cmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        //Totaleprijs bereken van het order
        //Vinden we al terug in de method TotalePrijsWinkelmand

        //Ophalen van de prijs van een artikel
        public double OphalenActuelePrijs(int artikelid)
        {
            MySqlConnection sqlconn = new MySqlConnection(conn);
            sqlconn.Open();
            string qry = "select prijs from tblartikels where artikelid=" + artikelid;
            MySqlCommand cmd = new MySqlCommand(qry,sqlconn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            double prijs=0;
            while(dtr.Read())
            {
                 prijs = Convert.ToDouble(dtr["prijs"]);
            }
            sqlconn.Close();
            return prijs;
        }

        //Ophalen van het laatste order van een klant
        public int OphalenLaatsteOrder(int klantid)
        {
            MySqlConnection sqlconn = new MySqlConnection(conn);
            sqlconn.Open();
            string qry = "select orderid from tblorders where klantid= " + klantid + " limit 1";
            MySqlCommand cmd = new MySqlCommand(qry, sqlconn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            int laatsteorder = 0;
            while(dtr.Read())
            {
                laatsteorder = Convert.ToInt32(dtr["orderid"]);
            }
            sqlconn.Close();
            return laatsteorder;
        }

        //Ophalen van alle informatie voor het vullen van tblorderinformatie
        public ProductPerOrder HaalOrderInfoOp(int klantid)
        {
            MySqlConnection sqlconn = new MySqlConnection(conn);
            sqlconn.Open();
            string qry = "select artikelid, aantal from tblwinkelmand where klantid=" + klantid + " limit 1";
            MySqlCommand cmd = new MySqlCommand(qry, sqlconn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            ProductPerOrder _ProductPerOrder = new ProductPerOrder();
            while (dtr.Read())
            {
                _ProductPerOrder.OrderID = OphalenLaatsteOrder(klantid);
                _ProductPerOrder.ArtikelID = Convert.ToInt32(dtr["artikelid"]);
                _ProductPerOrder.Aantal = Convert.ToInt32(dtr["aantal"]);
                _ProductPerOrder.Prijs = OphalenActuelePrijs(klantid);
            }
            return _ProductPerOrder;
        }
        

        //vullen van de tabel orderinformatie
        public void tblOrderInformatieInvullen(int klantid)
        {
            ProductPerOrder _ProductPerOrder = HaalOrderInfoOp(klantid);
            MySqlConnection sqlconn = new MySqlConnection(conn);
            sqlconn.Open();
            string juisteprijs = _ProductPerOrder.Prijs.ToString().Replace(",", ".");
            string qry = "insert into tblorderinformatie(orderid, artikelid, aantal, prijs) values(" + _ProductPerOrder.OrderID + "," + _ProductPerOrder.ArtikelID + "," + _ProductPerOrder.Aantal + "," + juisteprijs + ")";
            MySqlCommand cmd = new MySqlCommand(qry, sqlconn);
            cmd.ExecuteNonQuery();
            sqlconn.Close();
        }

        //Ophalen van hoeveelartikelen  die in het winkelmandje zitten
        public int LengteWinkelmand(int klantid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select count(artikelid) as totaal from tblwinkelmand where klantid=" + klantid + " order by klantid";
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            MySqlDataReader reader = sqlcom.ExecuteReader();
            int totaal = 0;
            while (reader.Read())
            {
                totaal = Convert.ToInt32(reader["totaal"]);
            }
            sqlcon.Close();
            return totaal;
        }

        //verwijderen van de artikelen ui het winkelmandje
        public void VerwijderWinkelmand(int klantid, int artikelid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "delete from tblwinkelmand where klantid= " + klantid + " and artikelid=" + artikelid;
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }

        public int OphalenLaatsteOrder()
        {
            MySqlConnection sqlconn = new MySqlConnection(conn);
            sqlconn.Open();
            string qry = "SELECT orderid from tblorders  order by datum desc limit 1 ";
            MySqlCommand cmd = new MySqlCommand(qry, sqlconn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            int id = 0;
            while (dtr.Read())
            {
                id = Convert.ToInt32(dtr["orderid"]);
            }
            sqlconn.Close();
            return id;
        }


        public bool ControleerNogInHetMandje(int klantid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select * from tblwinkelmand where klantid=" + klantid;
            MySqlCommand cmd = new MySqlCommand(querry, sqlcon);
            MySqlDataReader dtr = cmd.ExecuteReader();
            Winkelmand _winkelmand = new Winkelmand();
            if (dtr.HasRows)
            {
                sqlcon.Close();
                return true;
            }
            else
            {
                sqlcon.Close();
                return false;
            }
        }

        public void VerwijderRowInWinkelmand(int klantid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "delete from tblwinkelmand where klantid=" + klantid + " limit 1";
            MySqlCommand cmd = new MySqlCommand(querry, sqlcon);
            cmd.ExecuteNonQuery();
           
        }








        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------


        public void SendEmail(int klantid,string bericht)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select mail from tblklant where klantid=" + klantid;
            MySqlCommand cmd = new MySqlCommand(querry, sqlcon);
            MySqlDataReader dtr = cmd.ExecuteReader();
            Klant _klant = new Klant();
            while(dtr.Read())
            {
                _klant.Mail = Convert.ToString(dtr["mail"]);
            }
            sqlcon.Close();
            //MailMessage mail = new MailMessage("alternoteKCST@gmail.com", _klant.Mail);
            //SmtpClient client = new SmtpClient();
            //client.EnableSsl = true; -
            // client.Credentials = new System.Net.NetworkCredential("alternoteKCST@gmail.com", "Test0987654321");
            //client.Port = 587;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Host = "smtp.gmail.com";
            //mail.Subject = "Bestelbon";
            //mail.Body = bericht;
            //client.Send(mail);

            SmtpClient mijnSMTP = new SmtpClient();
            mijnSMTP.Host = "smtp.gmail.com";
            mijnSMTP.Port = 587;
            mijnSMTP.EnableSsl = true;
            mijnSMTP.Credentials = new System.Net.NetworkCredential("alternoteKCST@gmail.com", "Test0987654321");

            MailMessage mijnMail = new MailMessage("alternoteKCST@gmail.com", _klant.Mail);
            mijnMail.Subject = "Bestelbon";
            mijnMail.Body = bericht;

            mijnSMTP.Send(mijnMail);



        }



    }
}