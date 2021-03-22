using System;
using System.Collections.Generic;
using System.Text;

namespace GSBMission4
{
    public  class GestionDate
    {
       
        public String dateJour()
        {
            DateTime ajd = DateTime.Now;
            String asString = ajd.ToString("dd/MM/yyyy");
            return asString;
        }

        public String moisPrecedent()
        {
            DateTime ajd = DateTime.Now;
            ajd = ajd.AddMonths(-1);
            String asString = ajd.ToString("dd/MM/yyyy");
            String lAnnee = asString.Substring(6, 4);
            String leMois = asString.Substring(3, 2);
            asString = lAnnee + leMois;
            return asString;
        }

        public String moisSuivant()
        {
            DateTime ajd = DateTime.Now;
            ajd = ajd.AddMonths(+1);
            String asString = ajd.ToString("dd/MM/yyyy");

            return asString;
        }

        public String getMois(String laDate)
        {
            String moisJour = laDate.Substring(3, 4);
            return moisJour;
        }



    }
}
