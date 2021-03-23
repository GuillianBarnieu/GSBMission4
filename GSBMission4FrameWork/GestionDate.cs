using System;
using System.Collections.Generic;
using System.Text;

namespace GSBMission4FrameWork


{
    public class GestionDate
    {

        public string dateJour()
        {
            DateTime ajd = DateTime.Now;
            string asString = ajd.ToString("dd/MM/yyyy");
            return asString;
        }

        public string moisPrecedent()
        {
            DateTime ajd = DateTime.Now;
            ajd = ajd.AddMonths(-1);
            string asString = ajd.ToString("dd/MM/yyyy");
            string lAnnee = asString.Substring(6, 4);
            string leMois = asString.Substring(3, 2);
            asString = lAnnee + leMois;
            return asString;
        }

        public string moisSuivant()
        {
            DateTime ajd = DateTime.Now;
            ajd = ajd.AddMonths(+1);
            string asString = ajd.ToString("dd/MM/yyyy");

            return asString;
        }

        public string getMois(string laDate)
        {
            string moisJour = laDate.Substring(3, 4);
            return moisJour;
        }



    }
}
