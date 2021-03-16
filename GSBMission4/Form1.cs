using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GSBMission4
{
    public partial class Form1 : Form
    {
        private MySqlCommand selectionEmpl;
        private MySqlCommand lesFichesPrecedentes;
        private ConnexionSQL maConnexion;
        private DataTable dtAffichage;
        private DataTable dtFiches;
        private GestionDate date;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maConnexion = ConnexionSQL.getInstance("localhost", "gsb-v1", "root", "");
            maConnexion.openConnection();

            selectionEmpl = maConnexion.reqExec("Select* from fichefrais");


            MySqlDataReader reader = selectionEmpl.ExecuteReader();
            dtAffichage = new DataTable();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                dtAffichage.Columns.Add(reader.GetName(i));
            }
            while (reader.Read())
            {


                DataRow drAffichage = dtAffichage.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {

                    drAffichage[i] = reader.GetValue(i);
                }

                dtAffichage.Rows.Add(drAffichage);
            }
            dataGridView1.DataSource = dtAffichage;
            maConnexion.closeConnection();
            reader.Close();

        }

        private void InitializeTimer()
        {
            timer1.Interval = 30000;
            timer1.Tick += new EventHandler(Timer1_Tick);
        }

        private void Timer1_Tick(object Sender, EventArgs e)
        {
            DateTime ajd = DateTime.Now;
            String moisPreced = date.moisPrecedent();
            maConnexion.openConnection();
            lesFichesPrecedentes = maConnexion.reqExec("Select * from Fichefrais where mois = " + moisPreced + "and idEtat =");

            MySqlDataReader readerFiches = lesFichesPrecedentes.ExecuteReader();
            dtFiches = new DataTable();

            for (int i = 0; i < readerFiches.FieldCount; i++)
            {
                dtFiches.Columns.Add(readerFiches.GetName(i));
            }
            while (readerFiches.Read())
            {


                DataRow drFiches = dtFiches.NewRow();
                for (int i = 0; i < readerFiches.FieldCount; i++)
                {

                    drFiches[i] = readerFiches.GetValue(i);
                }

                dtFiches.Rows.Add(drFiches);

            }
        }
    }
}
