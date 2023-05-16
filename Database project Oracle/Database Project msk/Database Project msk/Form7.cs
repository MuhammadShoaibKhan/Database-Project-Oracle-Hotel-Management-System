using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Database_Project_msk
{
    public partial class Form7 : Form
    {
                                 
        public Form7()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string myConnection = ("Data Source=xe;User ID=system;Password=3097elite");
                OracleConnection myconn = new OracleConnection(myConnection);
                OracleCommand cmd = new OracleCommand("SELECT * FROM SCOTT.ROOM_DETAILS;", myconn);
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
        private void saveData()
        {
            try
            {
                string myConnection = ("Data Source=xe;User ID=system;Password=3097elite");
                OracleConnection myconn = new OracleConnection(myConnection);
                myconn.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO SCOTT.ROOM_DETAILS(ROOM_NO,ROOM_COST,FLOOR_NO,ROOM_TYPE,AC_NONAC_ROOM) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", myconn);
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

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void DeleteData()
        {
            string myConnection = ("Data Source=xe;User ID=system;Password=3097elite");
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(myConnection);
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand();

            try
            {
                conn.Open();
                cmd = new Oracle.DataAccess.Client.OracleCommand("DELETE FROM ROOM_DETAILS WHERE ROOM_NO = ('" + textBox1.Text + "')", conn);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = ("Data Source=xe;User ID=system;Password=3097elite");
                OracleConnection myconn = new OracleConnection(myConnection);
                myconn.Open();
                OracleCommand cmd = new OracleCommand("UPDATE SCOTT.ROOM_DETAILS SET ROOM_NO =('" + textBox1.Text + "'), ROOM_COST =('" + textBox2.Text + "'),FLOOR_NO=('" + textBox3.Text + "'),ROOM_TYPE=('" + textBox4.Text + "'),AC_NONAC_ROOM=('" + textBox5.Text + "') WHERE ROOM_NO=('" + textBox1.Text + "')", myconn);
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
         

        public void button5_Click(object sender, EventArgs e)
        {
            RetrieveData();
        }
        private void RetrieveData()
        {
            try
            {
                string ConString = "Data Source=xe;User ID=system;Password=3097elite";
                using (OracleConnection con = new OracleConnection(ConString))
                {
                    OracleCommand cmd = new OracleCommand(TextBox6.Text, con);
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

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 ff = new Form1();
            ff.Show();
        }

        
        }
    }



   

