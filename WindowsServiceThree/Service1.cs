using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Timers;
using GSBMission4;

namespace WindowsServiceThree
{
    public partial class Service1 : ServiceBase
    {
        private ConnexionSQL maConnexion;
        private Timer timer1 = new Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
        private void InitializeTimer()
        {
            timer1.Interval = 10000;

            timer1.Elapsed += timer1_Tick;
            timer1.Enabled = true;
            timer1.Start();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                timer1.Start();
                GestionDate date = new GestionDate();
                String ajd = date.dateJour();
                int a = int.Parse(ajd.Substring(0, 2));
                if (a >= 1 && a <= 24)
                {
                    maConnexion = ConnexionSQL.getInstance("localhost", "gsb-v1", "root", "");
                    maConnexion.openConnection();

                    MySqlCommand oCom1 = maConnexion.reqExec("Update testfichefrais set idEtat = 'CL' where idEtat ='CR' and mois =" + date.moisPrecedent());
                    oCom1.ExecuteNonQuery();


                    maConnexion.closeConnection();
                }
            }
            catch (Exception emp)
            {
                throw (emp);

            }
        }
    }
}
