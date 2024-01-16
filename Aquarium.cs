using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Csharquarium
{
    public class Aquarium
    {
        #region Champs
        private List<Poisson> _listePoisson;
        private List<Algue> _listeAlgue;
        private List<string> _listeNomMale;
        private List<string> _listeNomFemelle;
        private List<string> _listeRaceHerbivore;
        private List<string> _listeRaceCarnivore;
        private List<int> _listeNomMaleDejaChoisi;
        private List<int> _listeNomFemelleDejaChoisi;
        private List<string> _listeHermaphroditeAge;
        private List<string> _listehermaphroditeOpportuniste;
        #endregion

        #region Constructeurs
        public Aquarium()
        {
            ListePoisson = new List<Poisson>();
            ListeAlgue = new List<Algue>();
            ListeNomMaleDejaChoisi = new List<int>();
            ListeNomFemelleDejaChoisi = new List<int>();
            ListeHermaphroditeAge = new List<string>()
            {
                "Bar", "Mérou"
            };
            ListeHermaphroditeOpportunise = new List<string>()
            {
                "Sole", "Poisson-clown"
            };
            ListeNomMale = new List<string>()
            {
                "Nemo", "Marlin", "Triton", "Neptune", "Finley", "Bubbles",
                "Ocean", "Poseidon", "Squirt", "Captain", "Gil", "Blu", "Tide",
                "Aquaman", "Sushi", "Flipper", "Coral", "Atlas", "Moby", "Wave"
            };
            ListeNomFemelle = new List<string>()
            {
                "Pearl", "Marina", "Ariel", "Coral", "Luna", "Dory", "Sapphire",
                "Misty", "Nixie", "Crystal", "Bubbles",  "Aqua", "Azura", "Oceana",
                "Mermaid", "Iris", "Star", "Sunny", "Serenity", "River"
            };
            ListeRaceHerbivore = new List<string>()
            {
                "Sole", "Bar", "Carpe"
            };
            ListeRaceCarnivore = new List<string>()
            {
                "Mérou", "Thon", "Poisson-clown"
            };
        }
        #endregion

        #region Propriétés

        public List<string> ListeHermaphroditeOpportunise
        {
            get { return _listehermaphroditeOpportuniste; }
            set { _listehermaphroditeOpportuniste = value; }
        }

        public List<string> ListeHermaphroditeAge
        {
            get { return _listeHermaphroditeAge; }
            set { _listeHermaphroditeAge = value; }
        }

        public List<int> ListeNomFemelleDejaChoisi
        {
            get { return _listeNomFemelleDejaChoisi; }
            set { _listeNomFemelleDejaChoisi = value; }
        }


        public List<int> ListeNomMaleDejaChoisi
        {
            get { return _listeNomMaleDejaChoisi; }
            set { _listeNomMaleDejaChoisi = value; }
        }


        public List<string> ListeRaceCarnivore
        {
            get { return _listeRaceCarnivore; }
            set { _listeRaceCarnivore = value; }
        }

        public List<string> ListeRaceHerbivore
        {
            get { return _listeRaceHerbivore; }
            set { _listeRaceHerbivore = value; }
        }

        public List<string> ListeNomFemelle
        {
            get { return _listeNomFemelle; }
            set { _listeNomFemelle = value; }
        }

        public List<string> ListeNomMale
        {
            get { return _listeNomMale; }
            set { _listeNomMale = value; }
        }

        public List<Algue> ListeAlgue
        {
            get { return _listeAlgue; }
            set { _listeAlgue = value; }
        }

        public List<Poisson> ListePoisson
        {
            get { return _listePoisson; }
            set { _listePoisson = value; }
        }

        #endregion

        #region Methodes
        public PoissonCarnivore AjouterCarnivore(int age, string race)
        {
            //Variables locales
            string nom;
            string genre;
            int pointDeVie;
            bool estMort;
            bool estHermaphroditeOppo;
            bool estHermaphroditeAge;
            bool dejaManger;
            //Instructions
            pointDeVie = 10;
            estMort = false;
            dejaManger = false;
            genre = Utilities.RandInt(0, 2) == 0 ? "Male" : "Femelle";
            nom = DonnerNom(genre);
            estHermaphroditeOppo = DetermineOrientation(race);
            estHermaphroditeAge = DetermineOrientation(race);
            PoissonCarnivore poissonCarnivore = new PoissonCarnivore(nom, genre, age, pointDeVie, dejaManger, estMort, estHermaphroditeOppo, estHermaphroditeAge, race);
            ListePoisson.Add(poissonCarnivore);
            Console.WriteLine($"{poissonCarnivore.Nom} viens de naitre");
            //3 secondes de pause avant de poursuivre
            Thread.Sleep(3000);
            return poissonCarnivore;
        }
        public PoissonHerbivore AjouterHerbivore(int age, string race)
        {
            //Variables locales
            string nom;
            string genre;
            int pointDeVie;
            bool estMort;
            bool dejaManger;
            bool estHermaphroditeOppo;
            bool estHermaphroditeAge;

            //Instructions
            pointDeVie = 10;
            estMort = false;
            dejaManger = false;
            genre = Utilities.RandInt(0, 2) == 0 ? "Male" : "Femelle";
            nom = DonnerNom(genre);
            estHermaphroditeOppo = DetermineOrientation(race);
            estHermaphroditeAge = DetermineOrientation(race);
            PoissonHerbivore poissonHerbivore = new PoissonHerbivore(nom, genre, age, pointDeVie, dejaManger, estMort, estHermaphroditeOppo, estHermaphroditeAge, race);
            ListePoisson.Add(poissonHerbivore);
            Console.WriteLine($"{poissonHerbivore.Nom} viens de naitre");
            //3 secondes de pause avant de poursuivre
            Thread.Sleep(3000);
            return poissonHerbivore;
        }
        public Algue AjouterAlgue(int age, int pointDeVie)
        {
            //Variables locales
            //Instructions
            Algue algue = new Algue(age, pointDeVie);
            ListeAlgue.Add(algue);
            return algue;
        }
        public void ReproductionPoisson(Poisson poissonA, Poisson poissonB)
        {
            //Variables locales
            //Instructions
            if (poissonA.PointDeVie > 5 && poissonB.PointDeVie > 5)
            {
                if (poissonA is PoissonCarnivore carnivoreA && poissonB is PoissonCarnivore carnivoreB)
                {
                    //On regarde si notre poisson est un hermaphrodite opportuniste dans la liste
                    if (Utilities.isAlreadyInList(carnivoreA.Race, ListeHermaphroditeOpportunise))
                    {
                        //On on regarde le genre de poissonB
                        if (carnivoreA.Genre == carnivoreB.Genre)
                        {
                            //Le poisson prend le genre opposé
                            carnivoreA.ChangementGenre();
                            Console.WriteLine($"{carnivoreA.Nom} est devenu{(carnivoreA.Genre == "Male" ? "" : "e")} un{(carnivoreA.Genre == "Male" ? "" : "e")} {carnivoreA.Genre} pour s'accoupler");
                            //3 secondes de pause avant de poursuivre
                            Thread.Sleep(3000);
                            Console.WriteLine($"{carnivoreA.Nom} et {carnivoreB.Nom} s'accouplent");
                            //3 secondes de pause avant de poursuivre
                            Thread.Sleep(3000);
                            this.AjouterCarnivore(0, carnivoreA.Race);
                        }
                    }
                    //On regarde si notre poisson est un hermaphrodite avec l'age dans la liste
                    else if (Utilities.isAlreadyInList(carnivoreA.Race, ListeHermaphroditeAge))
                    {
                        if (carnivoreA.Genre != carnivoreB.Genre)
                        {
                            if (carnivoreA.Age > 10 && carnivoreA.AChangerDeGenre == false)
                            {
                                Console.Write($"{carnivoreA.Nom} a plus de 10 ans {(carnivoreA.Genre == "Male" ? "il" : "elle")} devient un{(carnivoreA.Genre == "Male" ? "e" : "")} ");
                                carnivoreA.ChangementGenre();
                                Console.WriteLine(carnivoreA.Genre);
                                //3 secondes de pause avant de poursuivre
                                Thread.Sleep(3000);
                            }
                        }
                    }
                    else
                    {
                        //Si se sont des monosexué
                        if (carnivoreA.Genre != carnivoreB.Genre)
                        {
                            Console.WriteLine($"{carnivoreA.Nom} et {carnivoreB.Nom} s'accouplent");
                            //3 secondes de pause avant de poursuivre
                            Thread.Sleep(3000);
                            this.AjouterCarnivore(0, carnivoreA.Race);
                        }
                    }
                }
                else if (poissonA is PoissonHerbivore herbivoreA && poissonB is PoissonHerbivore herbivoreB)
                {
                    //On regarde si notre poisson est un hermaphrodite opportuniste dans la liste
                    if (Utilities.isAlreadyInList(herbivoreA.Race, ListeHermaphroditeOpportunise))
                    {
                        //On on regarde le genre de poissonB
                        if (herbivoreA.Genre == herbivoreB.Genre)
                        {
                            //Le poisson prend le genre opposé
                            herbivoreA.ChangementGenre();
                            Console.WriteLine($"{herbivoreA.Nom} est devenu{(herbivoreA.Genre == "Male" ? "" : "e")} un{(herbivoreA.Genre == "Male" ? "" : "e")} {herbivoreA.Genre} pour s'accoupler");
                            //3 secondes de pause avant de poursuivre
                            Thread.Sleep(3000);
                            Console.WriteLine($"{herbivoreA.Nom} et {herbivoreB.Nom} s'accouplent");
                            //3 secondes de pause avant de poursuivre
                            Thread.Sleep(3000);
                            this.AjouterCarnivore(0, herbivoreA.Race);
                        }
                    }
                    //On regarde si notre poisson est un hermaphrodite avec l'age dans la liste
                    else if (Utilities.isAlreadyInList(herbivoreA.Race, ListeHermaphroditeAge))
                    {
                        if (herbivoreA.Genre != herbivoreB.Genre)
                        {
                            if (herbivoreA.Age > 10 && herbivoreA.AChangerDeGenre == false)
                            {
                                Console.Write($"{herbivoreA.Nom} a plus de 10 ans {(herbivoreA.Genre == "Male" ? "il" : "elle")} devient un{(herbivoreA.Genre == "Male" ? "e" : "")} ");
                                herbivoreA.ChangementGenre();
                                Console.WriteLine(herbivoreA.Genre);
                                //3 secondes de pause avant de poursuivre
                                Thread.Sleep(3000);
                            }
                        }
                    }
                    else
                    {
                        //Si se sont des monosexué
                        if (herbivoreA.Genre != herbivoreB.Genre)
                        {
                            Console.WriteLine($"{herbivoreA.Nom} et {herbivoreB.Nom} s'accouplent");
                            //3 secondes de pause avant de poursuivre
                            Thread.Sleep(3000);
                            this.AjouterCarnivore(0, herbivoreA.Race);
                        }
                    }
                }
            }
        }
        public void ReproductionAlgue(Algue algue)
        {
            if (algue.PointDeVie > 10)
            {
                algue.PointDeVie = algue.PointDeVie / 2;
                Console.WriteLine("Une algue est née");
                //3 secondes de pause avant de poursuivre
                Thread.Sleep(3000);
                this.AjouterAlgue(0, algue.PointDeVie);
            }
        }
        public string DonnerNom(string genre)
        {
            //Variables locales
            int rnd;
            //Instructions
            if (genre == "Male")
            {
                //Evite de choisir plusieur fois le meme nom
                do
                {
                    rnd = Utilities.RandInt(0, ListeNomMale.Count);
                }
                while (Utilities.isAlreadyInList(rnd, ListeNomMaleDejaChoisi));
                ListeNomMaleDejaChoisi.Add(rnd);
                return ListeNomMale[rnd];
            }
            else
            {
                do
                {
                    rnd = Utilities.RandInt(0, ListeNomFemelle.Count);
                }
                while (Utilities.isAlreadyInList(rnd, ListeNomFemelleDejaChoisi));
                ListeNomFemelleDejaChoisi.Add(rnd);
                return ListeNomFemelle[rnd];
            }
        }
        public string DeterminerRace(int listeDesRaces)
        {
            //Variables locales
            int rnd;

            //Instructions
            if (listeDesRaces == 0)
            {
                rnd = Utilities.RandInt(0, ListeRaceCarnivore.Count);
                return ListeRaceCarnivore[rnd];
            }
            else
            {
                rnd = Utilities.RandInt(0, ListeRaceHerbivore.Count);
                return ListeRaceHerbivore[rnd];
            }

        }
        public bool DetermineOrientation(string race)
        {
            for (int i = 0; i < ListeHermaphroditeOpportunise.Count; i++)
            {
                if (race == ListeHermaphroditeOpportunise[i])
                {
                    return true;
                }
            }
            for (int i = 0; i < ListeHermaphroditeAge.Count; i++)
            {
                if (race == ListeHermaphroditeAge[i])
                {
                    return true;
                }
            }
            return false;
        }
        public void PurgerLesMorts()
        {
            //On purge les poisson mort
            for (int i = 0; i < ListePoisson.Count; i++)
            {
                if (ListePoisson[i].EstMort)
                {
                    ListePoisson.Remove(ListePoisson[i]);
                }
            }
            //On purge les algues morte
            for (int i = 0; i < ListeAlgue.Count; i++)
            {
                if (ListeAlgue[i].EstMorte)
                {
                    ListeAlgue.Remove(ListeAlgue[i]);
                }
            }
        }
        public void ProgresserTemps()
        {
            //Variables locales
            //Instructions

            //On supprime tous ce qui est mort
            PurgerLesMorts();
            //Effacer le contenu de la console
            Console.Clear();
            // Optionnel : Repositionner le curseur en haut à gauche de la console
            Console.SetCursorPosition(0, 0);

            //Compte le nombre d'algue dans l'aquarium
            Console.WriteLine($"il y a {ListeAlgue.Count} algue{(ListeAlgue.Count > 1 ? "s" : "")} dans l'aquarium \n");

            ////Affiche la liste des poisson présent dans l'aquarium
            //foreach (Poisson poisson in ListePoisson)
            //{
            //    //Console.WriteLine($"{poisson.Nom} est un{(poisson.Genre is "Male" ? "" : "e")} {poisson.Genre}");
            //    //Console.WriteLine($"{poisson.Nom} est un{(poisson.Genre is "Male" ? "" : "e")} {poisson.GetType()}");
            //    Console.WriteLine($"{poisson.Nom} : {poisson.PointDeVie} PV {poisson.Age} ans");
            //}
            //Console.WriteLine();
            
            //Application du malus de faim + incrementation de l'age de tous les poisson
            for (int i = 0; i < ListePoisson.Count; i++)
            {
                ListePoisson[i].MalusFaim();
                ListePoisson[i].PoissonGrandit();
            }
            //Incrementation de l'age des algues
            for (int i = 0; i < ListeAlgue.Count; i++)
            {
                ListeAlgue[i].AlgueGrandit();
            }
            //On enleve les morts
            PurgerLesMorts();

            //Les Algues se reproduisent
            for (int i = 0; i < ListeAlgue.Count; i++)
            {
                ReproductionAlgue(ListeAlgue[i]);
            }

            //Les poissons se reproduisent
            for (int i = 0; i < ListePoisson.Count; i++)
            {
                //Variables locales
                int rnd;

                //Instructions
                //tirage au sort du partenaire
                //Recommence si le poisson se tire lui meme
                do
                {
                    rnd = Utilities.RandInt(0, ListePoisson.Count);
                }
                while (rnd == i);

                //Ils se reproduisent ou pas
                ReproductionPoisson(ListePoisson[i], ListePoisson[rnd]);

            }
            //Les poissons mangent si il on faim
            for (int i = 0; i < ListePoisson.Count; i++)
            {
                //Variables locales
                int rnd;
                //Instructions
                //tirage au sort de la proie, si il y a encore des proie dans l'aquarium
                if (ListePoisson.Count > 1)
                {
                    do
                    {
                        rnd = Utilities.RandInt(0, ListePoisson.Count);
                    }
                    while (rnd == i);

                    if (ListePoisson[i] is PoissonCarnivore carnivore)
                    {
                        carnivore.Manger(ListePoisson[rnd]);
                        //si la proie est morte, on l'enleve de la liste
                        PurgerLesMorts();
                    }
                    else if (ListePoisson[i] is PoissonHerbivore herbivore)
                    {
                        //On verifie si il y a encore des algue dans l'aquarium
                        if (ListeAlgue.Count > 0)
                        {
                            //si l'algue est morte, on l'enleve de la liste
                            PurgerLesMorts();
                        }
                        else
                        {
                            Console.WriteLine($"{herbivore.Nom} ne peut pas manger car il n'y a plus d'algue");
                            //appuier pour continuer
                            Console.ReadLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{ListePoisson[i].Nom} ne peut plus manger personne");
                    //3 secondes de pause avant de poursuivre
                    Thread.Sleep(3000);
                }
            }
        }
        
        #endregion
    }
}


