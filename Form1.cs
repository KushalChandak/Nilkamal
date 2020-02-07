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
using System.IO;

namespace ND
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string str;
        DataSet ds;
        int i;
        SqlDataAdapter adp;
        public Form1()
        {
            InitializeComponent();
        }

    
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server= BLT199\\SQLEXPRESS ;Database= nd;Integrated Security=true");
            con.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server= BLT199\\SQLEXPRESS ;Database= nd;Integrated Security=true");
            con.Open();

            DateTime dt = Convert.ToDateTime(dateTimePicker1.Value);

            str = "insert into workers_details(id,name,dt,hr) values('" + textBox5.Text + "', '" + textBox1.Text + "', '" + dt + "','" + textBox2.Text + "')";

            cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();

            try
            {
                
                MessageBox.Show("inserted");
                MessageBox.Show("Saved...");
            }
            catch (Exception)
            {
                MessageBox.Show("Not Saved");
            }
            finally
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server= BLT199\\SQLEXPRESS ;Database= nd;Integrated Security= true");
            con.Open();
            DateTime dt1 = Convert.ToDateTime(dateTimePicker1.Value);
            cmd = new SqlCommand("update workers_details set Name = '"+textBox1.Text+"' , dt = '" + dt1+"', hr = '"+textBox2.Text+"' where id = '" + textBox5.Text+"'", con  );
            cmd.ExecuteNonQuery();
            try
            {

            
                MessageBox.Show("Record Updates Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Not Updated");
            }
            finally {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server= BLT199\\SQLEXPRESS ;Database= nd;Integrated Security=true");
            con.Open();
            cmd = new SqlCommand("delete from workers_details where id = "+ textBox5.Text+" ", con);

            try
            {

                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted ..");
                textBox1.Clear();
                textBox2.Clear();
                textBox5.Clear();
                dateTimePicker1.Value.ToLocalTime();

            }
            catch (Exception )
            {

                MessageBox.Show("Not Show");
            }
            finally {
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
               SqlConnection con = new SqlConnection("Server= BLT199\\SQLEXPRESS ;Database= nd;Integrated Security=true");
            con.Open();
            cmd = new SqlCommand("select * from workers_details where id = "+ textBox5.Text+"", con);
            try {

                dr = cmd.ExecuteReader();
                if (dr.Read()) {

                    //textBox5.Text = dr[1].ToString();
                    textBox1.Text = dr[1].ToString();
                    textBox2.Text = dr[3].ToString();
                  
                    dateTimePicker1.Text = Convert.ToDateTime(dr[2]).ToString();
               

                }
                else 

                    MessageBox.Show("Record Not Found");
                }
                finally {

                    }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ds.Tables[0].Rows.Count > 0) {

                i--;
                textBox5.Text = ds.Tables[0].Rows[i]["Id"].ToString();
                textBox1.Text = ds.Tables[0].Rows[i]["Name"].ToString();
                textBox2.Text = ds.Tables[0].Rows[i]["hr"].ToString();
                dateTimePicker1.Text = Convert.ToDateTime(dr[2]).ToString();


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (i < ds.Tables[0].Rows.Count - 1) {

                i++;

                

                textBox5.Text = ds.Tables[0].Rows[i]["Id"].ToString();
                textBox1.Text = ds.Tables[0].Rows[i]["Name"].ToString();
                textBox2.Text = ds.Tables[0].Rows[i]["hr"].ToString();
                dateTimePicker1.Text = Convert.ToDateTime(dr[2]).ToString();


            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
