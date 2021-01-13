using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_des_clients
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cnx = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Gestion;Integrated Security=True");
        DataSet DS = new DataSet();
        SqlDataAdapter DA;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter("Select * from client", cnx);
            DA.Fill(DS,"clt");
            dataGridView1.DataSource = DS.Tables["clt"];



            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow Ligne = DS.Tables["clt"].NewRow();
            Ligne[0] = int.Parse(textBox4.Text);
            Ligne[1] = textBox1.Text;
            Ligne[2] = textBox2.Text;
            Ligne[3] = textBox3.Text;
            DS.Tables["clt"].Rows.Add(Ligne);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int p = -1;
            for (int i = 0; i < DS.Tables["clt"].Rows.Count; i++)
            {
                if (textBox4.Text == DS.Tables["clt"].Rows[i][0].ToString())
                {
                    p = i;
                }
            }
            if(p == -1){ MessageBox.Show("cilent introvable"); }
            else { DS.Tables["clt"].Rows[p].Delete(); 
                    MessageBox.Show("Le client a été supprimè avec succès");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            int p = -1;
            for (int i = 0; i < DS.Tables["clt"].Rows.Count; i++)
            {
                if (textBox4.Text == DS.Tables["clt"].Rows[i][0].ToString())
                {
                    p = i;
                }
            }
            if (p == -1) { MessageBox.Show("cilent introvable"); }
            else
            {
                DS.Tables["clt"].Rows[p][0] = int.Parse(textBox4.Text);
                DS.Tables["clt"].Rows[p][1] = textBox1.Text;
                DS.Tables["clt"].Rows[p][2] = textBox2.Text;
                DS.Tables["clt"].Rows[p][3] = textBox3.Text;
                MessageBox.Show("Le client a été modifié avec succès");
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlCommandBuilder cb = new SqlCommandBuilder(DA);
            DA.Update(DS,"clt");
            MessageBox.Show("Les données ont été bien Enregistrées");
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("voulez vous vider les champs  ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VIDER(this);
            }
           
        }

        public void VIDER(Control f)
        {
            foreach (Control ct in f.Controls)
            {
                if (ct.GetType() == typeof(TextBox))
                {
                    ct.Text = "";
                }

                if (ct.Controls.Count != 0) ;
                {
                    VIDER(ct);
                }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

            int p = -1;
            for (int i = 0; i < DS.Tables["clt"].Rows.Count; i++)
            {
                if (textBox5.Text == DS.Tables["clt"].Rows[i][3].ToString())
                {
                    p = i;
                }
            }
            if (p == -1)
            {
                MessageBox.Show("client not found");
            }
            else
            {

                if (DS.Tables["clt"] != null)
                {
                    DS.Tables["clt"].Clear();
                }
                DA = new SqlDataAdapter("Select  * from client where Ville = '" + textBox5.Text + "'", cnx);
                DA.Fill(DS, "clt");
                dataGridView1.DataSource = DS.Tables["clt"];
            }

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {


        
    }

        private void button6_Click(object sender, EventArgs e)
        {
            if (DS.Tables["clt"] != null)
            {
                DS.Tables["clt"].Clear();
            }
            DA = new SqlDataAdapter("Select  * from client ", cnx);
            DA.Fill(DS, "clt");
            dataGridView1.DataSource = DS.Tables["clt"];

        }
    }
}