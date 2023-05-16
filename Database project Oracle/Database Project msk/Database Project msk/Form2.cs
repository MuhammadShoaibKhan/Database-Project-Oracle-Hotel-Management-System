using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;



namespace Database_Project_msk
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
         
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string myConnection = ("Data Source=xe;User ID=scott;Password=tiger");
                OracleConnection myconn = new OracleConnection(myConnection);
                OracleCommand cmd = new OracleCommand("SELECT * FROM SCOTT.DURATION;", myconn);
                myconn.Open();

                cmd.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }





            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void loadDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = ("Data Source=xe;User ID=scott;Password=tiger");
                OracleConnection myconn = new OracleConnection(myConnection);
                OracleCommand cmd = new OracleCommand("SELECT * FROM SCOTT.DURATION;", myconn);
                myconn.Open();

                cmd.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void loadDatabaseToolStripMenuItem_Click2(object sender, EventArgs e)
        {
            try
            {
                string myConnection = ("Data Source=xe;User ID=scott;Password=tiger");
                OracleConnection myconn = new OracleConnection(myConnection);
                OracleCommand cmd = new OracleCommand("SELECT * FROM SCOTT.DURATION;", myconn);
                myconn.Open();

                cmd.CommandType = CommandType.Text;
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            saveData();
        }
        //          private void loadDatabaseToolStripMenuItem_Click3(object sender, EventArgs e)
        //          {
        private void saveData()
        {
            try
            {
                string myConnection = ("Data Source=xe;User ID=scott;Password=tiger");
                OracleConnection myconn = new OracleConnection(myConnection);
                myconn.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO SCOTT.DURATION(DURATION_ID, STATUS, DAYS_SPENT) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", myconn);
                cmd.Connection = myconn;
                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated == 0)
                    MessageBox.Show("Record not inserted");
                else
                    MessageBox.Show("Success!");
                myconn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void DeleteData()
        {
            string myConnection = ("Data Source=xe;User ID=scott;Password=tiger");
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(myConnection);
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand();

            try
            {
                conn.Open();
                cmd = new Oracle.DataAccess.Client.OracleCommand("DELETE FROM DURATION WHERE DURATION_ID = ('"+textBox1.Text+"')", conn);
                cmd.ExecuteNonQuery();

                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated == 0)
                    MessageBox.Show("Success! ");
                else
                    MessageBox.Show("Record not deleted");
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = ("Data Source=xe;User ID=scott;Password=tiger");
                Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(myConnection);
                Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand();
          
            
            }catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = ("Data Source=xe;User ID=scott;Password=tiger");
                OracleConnection myconn = new OracleConnection(myConnection);
                myconn.Open();
                OracleCommand cmd = new OracleCommand("UPDATE SCOTT.DURATION SET DURATION_ID =('"+ textBox1.Text+"'), STATUS =('"+textBox2.Text+"'),DAYS_SPENT=('"+textBox3.Text+"') WHERE DURATION_ID=('"+textBox1.Text+"')",myconn);
                cmd.Connection = myconn;
                cmd.ExecuteNonQuery();
                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated == 0)
                    MessageBox.Show("Record not inserted");
                else
                    MessageBox.Show("Success!");
                myconn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 ff = new Form1();
            ff.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RetrieveData();
        }
        private void RetrieveData()
        {
            try
            {
                string ConString = "Data Source=xe;User ID=scott;Password=tiger";
                using (OracleConnection con = new OracleConnection(ConString))
                {
                    OracleCommand cmd = new OracleCommand(textBox4.Text, con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0].DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}