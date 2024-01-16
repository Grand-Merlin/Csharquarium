using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Algue
    {
        #region Champs
        private int _age;
        private int _pointDeVie;
        private bool _estMorte;
        #endregion

        #region Constructeurs
        public Algue(int age, int pointDeVie)
        {
            Age = age;
            PointDeVie = pointDeVie;
        }
        #endregion

        #region Propriétés

        public bool EstMorte
        {
            get { return _estMorte; }
            set { _estMorte = value; }
        }

        public int PointDeVie
        {
            get { return _pointDeVie; }
            set { _pointDeVie = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        #endregion

        #region Methodes
        public void AlgueGrandit()
        {
            this.Age += 1;
        }
        public void SubitPredation(Poisson poisson)
        {
            this.PointDeVie -= 2;
            if (this.PointDeVie <=0)
            {
                //3 secondes de pause avant de poursuivre
                Thread.Sleep(3000);
                Console.WriteLine($"{poisson.Nom} a completement manger une algue");
                Console.WriteLine($"{poisson.Nom} a completement manger une algue");
                this.EstMorte = true;
            }
            else if (this.PointDeVie > 0)
            {
                //3 secondes de pause avant de poursuivre
                Thread.Sleep(3000);
                Console.WriteLine($"{poisson.Nom} a croqué une algue");
            }
        }
        #endregion

    }
}
