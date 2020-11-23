using System;
using System.Collections.Generic;

namespace Filmoteka
{
    public class Clan : Gost
    {
        #region Atributi

        List<Watchlist> watchliste;
        DateTime rokPretplate;

        #endregion

        #region Properties

        public List<Watchlist> Watchliste
        {
            get => watchliste;
        }
        public DateTime RokPretplate
        {
            get => rokPretplate;
        }

        #endregion

        #region Konstruktor

        public Clan(string user, string pass, string name, string surname, DateTime endDate)
            : base(user, pass, name, surname)
        {
            watchliste = new List<Watchlist>();
            rokPretplate = endDate;
        }

        public Clan(DateTime endDate)
            : base()
        {
            watchliste = new List<Watchlist>();
            rokPretplate = endDate;
        }

        #endregion

        #region Metode

        /// <summary>
        /// Metoda u kojoj se vrši produženje članarine.
        /// Da bi se članarina mogla produžiti, treba se sačekati najmanje mjesec dana od njenog isticanja, a najviše 6 mjeseci.
        /// Ukoliko članarina još uvijek nije istekla ili je prošlo manje od mjesec dana od isticanja
        /// ili je prošlo više od 6 mjeseci od isticanja, potrebno je baciti izuzetak.
        /// </summary>
        /// <param name="noviRok"></param>
        public void ProdužiRok(DateTime noviRok)
        {
            int brojMjeseci = ((this.rokPretplate.Year - noviRok.Year) * 12) + this.rokPretplate.Month - noviRok.Month;
            DateTime now = DateTime.Now;
            if (noviRok.Date <= now.Date) throw new Exception();
            else if(brojMjeseci<1 || brojMjeseci>6) throw new Exception();

            else
                this.rokPretplate = noviRok;
        }

        public void ResetujListe()
        {
            watchliste.Clear();
        }

        #endregion
    }
}
