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
        private ConnexionSQL maConnexion;
        private DataTable dt;
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
            dt = new DataTable();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                dt.Columns.Add(reader.GetName(i));
            }
            while (reader.Read())
            {


                DataRow dr = dt.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {

                    dr[i] = reader.GetValue(i);
                }

                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;

            reader.Close();

        }
    }
}
