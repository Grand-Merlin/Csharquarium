using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class PoissonCarnivore : Poisson
    {
        #region Champs
        private string _race;
        #endregion

        #region Constructeurs
        public PoissonCarnivore(string nom, string genre, int age, int pointDeVie, bool aFaim, bool estMort, bool estHermaphroditeOppo, bool estHermaphroditeAge, string race)
            : base(nom, genre, age, pointDeVie, aFaim, estMort, estHermaphroditeOppo, estHermaphroditeAge)
        {
            Race = race;
        }
        #endregion

        #region Propriétés
        public string Race
        {
            get { return _race; }
            set { _race = value; }
        }

        #endregion

        #region Methodes
        public void Manger(Poisson proie)
        {
            //Mange uniquement si le poisson a faim (5PV ou moins)
            if (this.PointDeVie <= 5)
            {
                this.PointDeVie += 5;
                proie.SubitPredation(this);
            }
        }
        #endregion
    }
}
