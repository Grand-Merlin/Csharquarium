using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Variables locales
            int rnd;
            Aquarium aquarium = new Aquarium();

            //Instructions
            //Initialisation de base de l'aquarium avec un nombre alléatoir de poisson (carnivore et herbivore) et d'algue
            //carnivore
            rnd = Utilities.RandInt(1, 3);
            for (int i = 0; i < rnd; i++)
            {
                aquarium.AjouterCarnivore(Utilities.RandInt(0, 21), aquarium.DeterminerRace(Utilities.RandInt(0, 2)));//On peut ajouter des poisson qui on n'importe quelle age
            }
            //herbivore
            rnd = Utilities.RandInt(1, 3);
            for (int i = 0; i < rnd; i++)
            {
                aquarium.AjouterHerbivore(Utilities.RandInt(0, 21), aquarium.DeterminerRace(Utilities.RandInt(0, 2)));
            }


            //Algue
            rnd = Utilities.RandInt(1, 5);
            for (int i = 0; i < rnd; i++)
            {
                aquarium.AjouterAlgue(Utilities.RandInt(0, 21), 10);//On peut ajouter des algue qui on n'importe quelle age
            }

            do
            {
                aquarium.ProgresserTemps();
            }
            while (Utilities.getSpecificInput("Voulez vous faire progresser le temp (Y/N) ?", "yn") == "Y");

        }
    }
}