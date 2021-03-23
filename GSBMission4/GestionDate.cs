using System;
using System.Collections.Generic;
using System.Text;

namespace GSBMission4FrameWork
{
    public  class GestionDate
    {
       
        /// <summary>
        /// Function that uses DateTime to return the actual day
        /// </summary>
        /// <returns>Current Month</returns>
        public String dateJour()
        {
            DateTime ajd = DateTime.Now;
            String asString = ajd.ToString("dd/MM/yyyy");
            return asString;
        }

        /// <summary>
        /// Function that uses DateTime to return the last month
        /// </summary>
        /// <returns>Last Month</returns>
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

        /// <summary>
        /// Function that uses DateTime to return the next month
        /// </summary>
        /// <returns>Next Month</returns>
        public String moisSuivant()
        {
            DateTime ajd = DateTime.Now;
            ajd = ajd.AddMonths(+1);
            String asString = ajd.ToString("dd/MM/yyyy");

            return asString;
        }

        /// <summary>
        /// Function that uses DateTime to return the current month
        /// </summary>
        /// <returns>The current month</returns>
        public String getMois(String laDate)
        {
            String moisJour = laDate.Substring(3, 4);
            return moisJour;
        }



    }
}
