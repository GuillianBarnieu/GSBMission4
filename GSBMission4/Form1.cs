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
            InitializeTimer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maConnexion = ConnexionSQL.getInstance("localhost", "gsb-v1", "root", "");
            maConnexion.openConnection();
            GestionDate date = new GestionDate();
            DataTable dt = new DataTable();

            MySqlCommand oCom = maConnexion.reqExec("Select * from fichefrais where mois =" + date.moisPrecedent());
            dt.Load(oCom.ExecuteReader());
            dataGridView1.DataSource = dt;
            maConnexion.closeConnection();
            //reader.Close();

        }

        private void InitializeTimer()
        {
            timer1.Interval = 10000;
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Start();
        }

        private void Timer1_Tick(object Sender, EventArgs e)
        {
            //timer1.Stop();
            try
            {
                timer1.Start();
                GestionDate date = new GestionDate();
                String ajd = date.dateJour();   
                int a = int.Parse(ajd.Substring(0, 2));

                maConnexion.openConnection();



                 if (a >= 1 && a <= 22)
                {
                    MySqlCommand oCom1 = maConnexion.reqExec("Update fichefrais set idEtat = 'CL' where idEtat ='CR' and mois =" + date.moisPrecedent());
                    oCom1.ExecuteNonQuery();
                    MySqlCommand oCom = maConnexion.reqExec("Select * from fichefrais where mois =" + date.moisPrecedent());
                    DataTable dt2 = new DataTable();
                    dt2.Load(oCom.ExecuteReader());
                    dataGridView1.DataSource = dt2;
                    maConnexion.closeConnection();
                }
            }
            catch (Exception emp)
            {
                MessageBox.Show(emp.Message);
            }
        }
        /*DateTime ajd = DateTime.Now;
        String moisPreced = date.moisPrecedent();
        maConnexion.openConnection();
        lesFichesPrecedentes = maConnexion.reqExec("Select * from Fichefrais where mois = " + moisPreced + "and idEtat = CL");

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
        */
    }
}
