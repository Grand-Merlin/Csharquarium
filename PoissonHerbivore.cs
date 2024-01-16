using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class PoissonHerbivore : Poisson
    {
        #region Champs
        private String _race;
        #endregion

        #region Constructeurs
        public PoissonHerbivore(string nom, string genre, int age, int pointDeVie, bool aFaim, bool estMort, bool estHermaphroditeOppo, bool estHermaphroditeAge, string race)
            : base(nom, genre, age, pointDeVie, aFaim, estMort, estHermaphroditeOppo, estHermaphroditeAge)
        {
            Race = race;
        }
        #endregion

        #region Propriétés
        public String Race
        {
            get { return _race; }
            set { _race = value; }
        }
        #endregion

        #region Methodes
        public void Manger(Algue algue)
        {
            this.PointDeVie += 3;
            algue.SubitPredation(this);
        }
        #endregion


    }
}
