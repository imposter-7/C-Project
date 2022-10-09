using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace project
{
    public partial class Form1 : Form
    {

        SQLiteConnection hala_dbconnection;
        
        public Form1()
        {
            InitializeComponent();
            hala_dbconnection = new SQLiteConnection("Data Source=Applicants.sqlite; Version=3;");
            hala_dbconnection.Open();

        }

        private void theatreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // string sql = "INSERT INTO Applicants(FirstName, LastName, Address,NationalNo, Email, PhoneNumber, UniName, Major) VALUES ('Hala','Farraj','Amman','20180664','hala@03003','079988656','PSUT', 'SE' ) ;";

            if (!textBox7.Text.StartsWith("07") || textBox7.Text.Length!=10)
            {
                MessageBox.Show("Enter a number that starts with 07", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
            }

            else
            {
                if (!textBox8.Text.Contains("@"))
                {
                    MessageBox.Show("Enter a valid email please !","Error",MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                }

                else
                {
                    string sql = "INSERT INTO Applicants(FirstName, LastName, Address,NationalNo, Email, PhoneNumber, UniName, Major) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox5 + "','" + textBox8.Text + "','" + textBox7.Text + "','" + textBox3.Text + "','" + textBox4.Text + "');";

                    SQLiteCommand command = new SQLiteCommand(sql, hala_dbconnection);
                    command.ExecuteNonQuery();
                   
                    load_data();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               // string sql = "DELETE FROM Applicants WHERE ApplicantID='8' ;";
                string sql = "DELETE FROM Applicants WHERE ApplicantID='" + numericUpDown1.Value.ToString() + "';";
                SQLiteCommand command = new SQLiteCommand(sql, hala_dbconnection);
                command.ExecuteNonQuery();

                load_data();
            }

            catch(System.Exception exp)
            {
                MessageBox.Show(exp.GetType().ToString() + " is found");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Applicants";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, hala_dbconnection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            //SQLiteCommand command = new SQLiteCommand(sql, hala_dbconnection);
            //SQLiteDataReader reader = command.ExecuteReader();
            //string output = "";
            //    while(reader.Read())
            //    {
            //    output += "First Name:" + reader["FirstName"] + "\tLast Name:" + reader["LastName"] + "\tAddress:" + reader["Address"] + "\tNationalNo:" + reader["NationalNo"] + "\tEmail:" + reader["Email"] + "\tPhone:" + reader["PhoneNumber"] + "\tUniName:" + reader["UniName"] + "\tMajor:" + reader["Major"] + "\n";
            //    }

            //MessageBox.Show(output);
        }

        void load_data()
        {
            string sql = "SELECT * FROM Applicants";
            SQLiteDataAdapter adaper = new SQLiteDataAdapter(sql, hala_dbconnection);
            DataSet dataset = new DataSet();
            adaper.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
             //   string sql = "Select * From Applicants Where UniName= 'PSUT' ; ";
                string sql = "Select * From Applicants Where UniName= '"+textBox9.Text+"';";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, hala_dbconnection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];

            }
            catch(System.Exception exp)
            {
                MessageBox.Show(exp.GetType().ToString());
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string sql = "UPDATE Applicants SET Address='Dubai' WHERE ApplicantID='2' ;";
            string sql = "UPDATE Applicants SET Address='" + textBox6.Text + "' WHERE ApplicantID= '" + numericUpDown2.Value.ToString() + "';";
            SQLiteCommand command = new SQLiteCommand(sql, hala_dbconnection);
            command.ExecuteNonQuery();
            load_data();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
