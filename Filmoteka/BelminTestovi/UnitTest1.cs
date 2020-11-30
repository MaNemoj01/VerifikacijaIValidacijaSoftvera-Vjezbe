using Microsoft.VisualStudio.TestTools.UnitTesting;
using Filmoteka;
using System;
using System.Collections.Generic;

namespace BelminTestovi
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestiranjeMetodeProduziRokZa40dana()
        {
            Clan c = new Clan(DateTime.Today.AddDays(-60));
            c.ProdužiRok(DateTime.Today.AddDays(90));
            
            Assert.AreEqual(DateTime.Today.AddDays(90), c.RokPretplate);        
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException))]
        public void TestiranjeMetodeProduziRokZaVracanjaUProslost()
        {
            Clan c = new Clan(DateTime.Today);
            c.ProdužiRok(DateTime.Today.AddDays(-10));        
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestiranjeMetodeProduziRokKadaProduzujemo7danaPrijeIsteka()
        {
            Clan c = new Clan("baustelac", "JEDANDVATRICETRI", "Huso", "Husic", DateTime.Today);
            c.ProdužiRok(DateTime.Today.AddDays(7));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestiranjeMetodeProduziRokKada()
        {
            Clan c = new Clan("baustelac", "JEDANDVATRICETRI", "Huso", "Husic", DateTime.Today.AddDays(10));
            c.ProdužiRok(DateTime.Today.AddDays(12));
        }

        [TestMethod]
        public void TestiranjeMetodeGetWatchListeZaClana()
        {
            Clan c = new Clan("baustelac", "JEDANDVATRICETRI", "Huso", "Husic", DateTime.Today);
            c.Watchliste.Add(new Watchlist("Horori"));
            Assert.IsTrue(c.Watchliste.Count == 1);
        }

        [TestMethod]
        public void TestiranjeMetodeResetanjeWatchListeZaClana()
        {
            Clan c = new Clan("baustelac", "JEDANDVATRICETRI", "Huso", "Husic", DateTime.Today);
            c.Watchliste.Add(new Watchlist("Horori"));
            c.Watchliste.Add(new Watchlist("Komedije"));
            c.ResetujListe();
            Assert.IsTrue(c.Watchliste.Count == 0);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException))]
        public void TestiranjeSeteraNazivaZaFilmaException()
        {
            Film f = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });
            f.Naziv = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestiranjeSeteraOcjenaZaFilmaException()
        {
            Film f = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });
            f.Ocjena = 5.1;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestiranjeMetodeRadSaKorisnicimaFilmotekeOpcija0Izuzetak()
        {
            Filmoteka.Filmoteka filmovita = new Filmoteka.Filmoteka();
            Clan c = new Clan(DateTime.Today.AddDays(20));
            filmovita.Clanovi.Add(c);
            filmovita.RadSaKorisnicima(c, 0);
        }

        [TestMethod]
        public void TestiranjeGeteraIDZaFilm()
        {
            Film f = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });
            Assert.IsNotNull(f.Id);
        }

        [TestMethod]
        public void TestiranjeGeteraNazivZaFilm()
        {
            Film f = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });
            Assert.AreEqual("Need For Speed", f.Naziv);
        }

        [TestMethod]
        public void TestiranjeGeteraZanrZaFilm()
        {
            Film f = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });
            Assert.AreEqual(Zanr.Akcija, f.Žanr);
        }

        [TestMethod]
        public void TestiranjeKontstruktoraZaFilmKadNisuGlumciPoslani()
        {
            Film f = new Film("Need For Speed", 3.5, Zanr.Akcija, null);
            Assert.IsTrue(f.Glumci.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestiranjeSeteraGlumacaSaNepostojecimImenomZaFilm()
        {
            Film f = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "", "" });
        }

        [TestMethod]
        /*Prosljeđuju se dobri parametri*/
        public void TestAutomatakiKorisnickiPodaciIspavo()
        {
            Tuple<string, string> podaci = Gost.AutomatskiKorisničkiPodaci("Nadja", "Alijagic");
            Assert.AreEqual(podaci.Item1, "naalijagicdja");
            Assert.AreEqual(podaci.Item2, "NAALIJAGICDJA");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        /*prosljeđuje se ime i prezime znakovima u sebi, očekuje se izuzetak*/
        public void TestAutomatakiKorisnickiPodaciIzuzetak()
        {
            Tuple<string, string> podaci = Gost.AutomatskiKorisničkiPodaci("Nadj%", "Ali5agic");
        }

        [TestMethod]
        /*prosljeđuje se dugo prezime, te će se username morati zaustaviti poslije 19 karaktera*/
        public void TestAutomatakiKorisnickiPodaciDugUser()
        {
            Gost g = new Gost();
            Tuple<string, string> podaci = Gost.AutomatskiKorisničkiPodaci("Mujo", "Gavrankapetanovic");
            Assert.AreEqual(podaci.Item1.Length, 19);
            Assert.AreEqual(podaci.Item1, "mugavrankapetanovic");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        /*prosljeđuje se prazan string umjesto imena, očekuje se izuzetak*/
        public void TestAutomatakiKorisnickiPodaciPrazno()
        {
            Tuple<string, string> podaci = Gost.AutomatskiKorisničkiPodaci("", "Mujic");
        }

        [TestMethod]


        public void TestiranjeMetodeDajSveFilmoveSGlumcima()
        {
            Film film = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });
            Film noviFilm = new Film("Need For Sleep", 4.5, Zanr.Akcija, new List<string>() { "Meho Horozic", "Huso Husic" });

            Filmoteka.Filmoteka filmotekaKodOmera = new Filmoteka.Filmoteka();
            filmotekaKodOmera.Filmovi.Add(film);
            filmotekaKodOmera.Filmovi.Add(noviFilm);

            List<string> glumci = new List<string> { "Meho Horozic", "Huso Husic" };

            List<Film> movies = filmotekaKodOmera.DajSveFilmoveSGlumcima(glumci);
            Assert.AreEqual(1, movies.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestiranjeMetodeDajSveFilmoveSGlumcima2()
        {
            Film film = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });
            Film noviFilm = new Film("Need For Sleep", 4.9, Zanr.Akcija, new List<string>() { "Meho Horozic", "Huso Husic" });

            Filmoteka.Filmoteka filmotekaKodOmera = new Filmoteka.Filmoteka();
            filmotekaKodOmera.Filmovi.Add(film);
            filmotekaKodOmera.Filmovi.Add(noviFilm);

            List<string> glumci = new List<string> { };

            List<Film> movies = filmotekaKodOmera.DajSveFilmoveSGlumcima(glumci);
        }

        [TestMethod]

        public void TestiranjeDajSrednjuOcjenuSvihFilmova()
        {
            Film noviFilm = new Film("Need For Sleep", 5.0, Zanr.Akcija, new List<string>() { "Meho Horozic", "Huso Husic" });
            Film drugiNoviFilm = new Film("Need For Summer", 1.0, Zanr.Akcija, new List<string>() { "Meho Horozic", "Huso Husic" });
            List<Film> filmovi = new List<Film>();
            filmovi.Add(noviFilm);
            filmovi.Add(drugiNoviFilm);
            Filmoteka.Watchlist lista = new Watchlist("Moja lista", filmovi);

            Assert.AreEqual(3.0, lista.DajSrednjuOcjenuSvihFilmova());

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestiranjeDajSrednjuOcjenuSvihFilmovaPraazno()
        {

            List<Film> filmovi = new List<Film>();

            Filmoteka.Watchlist lista = new Watchlist("Moja lista", filmovi);

            Assert.AreEqual(3.0, lista.DajSrednjuOcjenuSvihFilmova());

        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestiranjeRezisera()
        {
            Filmoteka.Reziser ireziser = new Reziser();
            Film drugiNoviFilm = new Film("Need For Summer", 1.0, Zanr.Akcija, new List<string>() { "Meho Horozic", "Huso Husic" });
            ireziser.DaLiJeReziraoFilm(drugiNoviFilm);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        /*prosljeđuje se User koji je kraci od 5 slova*/
        public void TestGostSetUsernameIzuzetak()
        {
            Gost g = new Gost("user", "passwordsifra", "Ime", "Imenic");
        }

        [TestMethod]
        /*mijenja se username*/
        public void TestGostSetIGetUser()
        {
            Gost g = new Gost("username", "PASSWORDSIFRA", "Ime", "Imenic");
            g.Username = "imimenice";
            Assert.AreEqual("imimenice", g.Username);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        /*Password je malim slovima i kraci od 10 slova*/
        public void TestGostSetPasswordPogresno()
        {
            Gost g = new Gost("username", "password", "Ime", "Imenic");

        }
        [TestMethod]
        /*mijenja se password*/
        public void TestGostSetIGetPassword()
        {
            Gost g = new Gost("username", "PASSWORDSIFRA", "Ime", "Imenic");
            g.Password = "NOVIPASSWORD";
            Assert.AreEqual("NOVIPASSWORD".GetHashCode().ToString(), g.Password);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        /*Ime je prazan string*/
        public void TestGostSetImePogresno()
        {
            Gost g = new Gost("username", "PASSWORDSIFRA", "", "Imenic");

        }
        [TestMethod]
        /*mijenja se ime*/
        public void TestGostSetIGetIme()
        {
            Gost g = new Gost("username", "PASSWORDSIFRA", "Ime", "Imenic");
            g.Ime = "Nadja";
            Assert.AreEqual("Nadja", g.Ime);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        /*rosljedjuje se prazan string za prezime*/
        public void TestGostSetPrezimePogresno()
        {
            Gost g = new Gost("username", "PASSWORDSIFRA", "Ime", "");

        }
        [TestMethod]
        /*mijenja se prezime*/
        public void TestGostSetIGetPrezime()
        {
            Gost g = new Gost("username", "PASSWORDSIFRA", "Ime", "Imenic");
            g.Prezime = "Novoprezime";
            Assert.AreEqual("Novoprezime", g.Prezime);
        }
        [TestMethod]
        /*uzima se id gosta*/
        public void TestGostID()
        {
            Gost g = new Gost("username", "PASSWORDSIFRA", "Ime", "Imenic");
            string id = g.Id;

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]

        public void TestiranjePogresnogImenaWhatchlist()
        {
            List<Film> filmovi = new List<Film>();

            Filmoteka.Watchlist lista = new Watchlist("", filmovi);


        }

        [TestMethod]
        public void TestiranjeWhatchlistGetter()
        {
            List<Film> filmovi = new List<Film>();

            Filmoteka.Watchlist lista = new Watchlist("Moja lista filmova", filmovi);

            Assert.AreEqual("Moja lista filmova", lista.Naziv);


        }

        [TestMethod]
        public void TestiranjeWhatchlistGetterZaBaziv()
        {
            List<Film> filmovi = new List<Film>();


            Filmoteka.Watchlist lista = new Watchlist("Moja lista", filmovi);
            int br = lista.Filmovi.Count;

            Assert.AreEqual(0, br);
        }

        [TestMethod]
        /*dodaje se nova watchlista*/
        public void TestDodajWatchListu()
        {
            Filmoteka.Filmoteka f = new Filmoteka.Filmoteka();
            Clan c = new Clan("username", "PASSWORDSIFRA", "Ime", "Imenic", DateTime.Now);
            List<Film> filmovi = new List<Film>();
            Film film = new Film("Pirats of Carribian", 4.0, Zanr.Akcija, new List<string> { "Johnny Depp" });
            Film film1 = new Film("Avengers", 4.0, Zanr.Akcija, new List<string> { "Chris Evens", "Robert Downey Junior" });
            filmovi.Add(film);
            filmovi.Add(film1);
            f.DodajWatchlistu(c, filmovi, "Superheroji");
            Assert.AreEqual(1, c.Watchliste.Count);
        }
    }
}
