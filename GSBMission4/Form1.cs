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
            //Initialisation des composants du Form
            InitializeComponent();
            //Initialisation du Timer
            InitializeTimer();
        }

        /// <summary>
        /// Actions à réaliser au chargement du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //Création d'un objet maConnexion de type ConnexionSQL
            maConnexion = ConnexionSQL.getInstance("localhost", "gsb-v1", "root", "");

            //Ouverture de la connexion maConnexion
            maConnexion.openConnection();

            //Création de la DataTable dt2 qui va contenir les résultats de la requête précedente
            GestionDate date = new GestionDate();

            //Remplissage de la DataTable dt avec les résultats donnés par l'ExecuteReader sur la requête précedente.
            DataTable dt = new DataTable();

            MySqlCommand oCom = maConnexion.reqExec("Select * from fichefrais where mois =" + date.moisPrecedent());
            dt.Load(oCom.ExecuteReader());

            //Remplissage de la DataGridView avec le contenu de dt
            dataGridView1.DataSource = dt;

            //Fermeture de la Connexion maConnexion
            maConnexion.closeConnection();
            //reader.Close();

        }

        /// <summary>
        /// Fonction initialisant le Timer
        /// </summary>
        private void InitializeTimer()
        {
            //Définition de l'Interval à 10000ms, soit 10 secondes
            timer1.Interval = 10000;

            //Création de l'évenement s'effectuant au tick du Timer.
            timer1.Tick += new EventHandler(Timer1_Tick);

            //Démarage du Timer
            timer1.Start();
        }

        /// <summary>
        /// Fonction décrivant l'évenement se déckenchant à chaque tick du serveur
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object Sender, EventArgs e)
        {
            //timer1.Stop();
            try
            {
                timer1.Start();

                //Création d'un objet date
                GestionDate date = new GestionDate();

                //Création du String de la date du jour complète (dd/mm/yyyy)
                String ajd = date.dateJour();

                //Récupération de la partie jour (dd) de la date complète
                int a = int.Parse(ajd.Substring(0, 2));

                //Ouverture de la connexion avec l'objet maConnexion
                maConnexion.openConnection();



                 if (a >= 1 && a <= 22)
                {
                    //Création de la commande contenant la requête de mise à jour de l'état des fiches frais
                    MySqlCommand oCom1 = maConnexion.reqExec("Update fichefrais set idEtat = 'CL' where idEtat ='CR' and mois =" + date.moisPrecedent());
                    //Execution de la requête précedement créée
                    oCom1.ExecuteNonQuery();

                    //Création de la commande contenant la requête de mise à jour de l'affichage des fiches
                    MySqlCommand oCom = maConnexion.reqExec("Select * from fichefrais where mois =" + date.moisPrecedent());

                    //Création de la DataTable dt2 qui va contenir les résultats de la requête précedente
                    DataTable dt2 = new DataTable();

                    //Remplissage de la DataTable dt2 avec les résultats donnés par l'ExecuteReader sur la requête précedente.
                    dt2.Load(oCom.ExecuteReader());

                    //Remplissage de la dataGridView avec les résultats stockés dans dt2
                    dataGridView1.DataSource = dt2;

                    //Fermeture de la connexion maConnexion
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
