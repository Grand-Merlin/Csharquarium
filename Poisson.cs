using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Poisson
    {
        #region Champs
        private string _nom;
        private string _genre;
        private int _pointDeVie;
        private int _age;
        private bool _estMort;
        private bool _aFaim;
        private bool _estHermaphroditeOppo;
        private bool _estHermaphroditeAge;
        private bool _aChangerDeGenre;
        #endregion

        #region Constructeurs
        public Poisson(string nom, string genre, int age, int pointDeVie, bool aFaim, bool estMort, bool estHermaphroditeOppo, bool estHermaphroditeAge)
        {
            Nom = nom;
            Genre = genre;
            Age = age;
            PointDeVie = pointDeVie;
            AFaim = aFaim;
            EstMort = estMort;
            EstHermaphroditeOppo = estHermaphroditeOppo;
            EstHermaphroditeAge = estHermaphroditeAge;
        }
        #endregion

        #region Propriétés

        public bool AChangerDeGenre
        {
            get { return _aChangerDeGenre; }
            set { _aChangerDeGenre = value; }
        }

        public bool EstHermaphroditeAge
        {
            get { return _estHermaphroditeAge; }
            set { _estHermaphroditeAge = value; }
        }

        public bool EstHermaphroditeOppo
        {
            get { return _estHermaphroditeOppo; }
            set { _estHermaphroditeOppo = value; }
        }

        public bool AFaim
        {
            get { return _aFaim; }
            set { _aFaim = value; }
        }

        public bool EstMort
        {
            get { return _estMort; }
            set { _estMort = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int PointDeVie
        {
            get { return _pointDeVie; }
            set { _pointDeVie = value; }
        }


        public String Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }


        public String Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        #endregion

        #region Methodes
        public void MalusFaim()
        {
            this.PointDeVie -= 1;
            if (this.PointDeVie <= 0)
            {
                Console.WriteLine($"{this.Nom} est mort{(this.Genre == "Male" ? "" : "e")} par manque de point de vie");
                //3 secondes de pause avant de poursuivre
                Thread.Sleep(1000);
                this.EstMort = true;
            }
        }
        public void PoissonGrandit()
        {
            this.Age += 1;
            if (this.Age > 20)
            {
                Console.WriteLine($"{this.Nom} est mort{(this.Genre == "Male" ? "" : "e")} de vieillesse");
                //3 secondes de pause avant de poursuivre
                Thread.Sleep(3000);
                this.EstMort = true;
            }
            else
            {
                Console.WriteLine($"{this.Nom} : {this.PointDeVie} PV {this.Age} ans");
            }
        }
        public void AppliquerEffetFaim()
        {
            if (this.PointDeVie <= 5)
            {
                this.AFaim = true;
            }

        }
        public void SubitPredation(Poisson poisson)
        {
            this.PointDeVie -= 4;
            if (this.PointDeVie <= 0)
            {
                //3 secondes de pause avant de poursuivre
                Thread.Sleep(3000);
                Console.WriteLine($"{poisson.Nom} a completement manger {this.Nom}");
                this.EstMort = true;
            }
            else if (this.PointDeVie > 0)
            {
                //3 secondes de pause avant de poursuivre
                Thread.Sleep(3000);
                Console.WriteLine($"{poisson.Nom} a croqué {this.Nom}");
            }
        }
        public void ChangementGenre()
        {
            if (this.Genre == "Male")
            {
                this.Genre = "Femelle";
                this.AChangerDeGenre = true;
            }
            else
            {
                this.Genre = "Male";
                this.AChangerDeGenre = true;
            }
        }
        #endregion

    }
}
