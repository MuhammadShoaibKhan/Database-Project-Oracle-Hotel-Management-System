using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Odbc;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;


namespace Database_Project_msk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {

                string myConnection = ("Data Source=xe;User ID=system;Password=3097elite");
                OracleConnection myConn = new OracleConnection(myConnection);
                OracleCommand SelectCommand = new OracleCommand("Select * from SCOTT.DATABASE_LOGIN where USERNAME='"+this.textBox1.Text+"' and PASSWORD='"+this.textBox2.Text + "'",myConn);
                OracleDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while(myReader.Read())
                {
                    count = count + 1;
                }
                if(count==1)
                {
                    MessageBox.Show("Username and password is correct");
                    this.Hide();
                    MainMenu main = new MainMenu();
                    main.Show();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate username and password...Access denied");
                    Form1 form = new Form1();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("User name and password is incorrect please try again.");
                    Form1 form = new Form1();
                    form.Show();
                }
                    myConn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}