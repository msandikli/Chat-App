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
namespace MY_Chat_App
{
    public partial class Mesaj : Form
    {
        public Mesaj()
        {
            InitializeComponent();
        }
        static string conString = "Data Source=den1.mssql7.gear.host;Initial Catalog=chatt;Uid=chatt;Password=Mehmet0699.;";
        public string id = "";
        public string messid = "";
        public string name = "";
        public string id2 = "";
        public void Yükle()
        {
            textBox1.Clear();
            listBox1.Items.Clear();
            SqlConnection bag = new SqlConnection(conString);
            bag.Open();
            SqlCommand kmt = new SqlCommand("Select * from [chatt].[dbo].[" + id + ".Messages] where messid='" + messid + "'", bag);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                id2 = Convert.ToString(dr["id"]);
                string messages = Convert.ToString(dr["messages"]);
                string type = Convert.ToString(dr["type"]);
                if(type=="rcv")
                {
                    listBox1.Items.Add(name + ": " + messages);
                }
                if(type=="send")
                {
                    listBox1.Items.Add("Sen: " + messages);
                }
            }
            bag.Close();
        }
        private void Mesaj_Load(object sender, EventArgs e)
        {
            name = name.ToUpper();
            label1.Text += name;
            timer1.Start();
            Yükle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mesaj = textBox1.Text;
            string type = "send";
            string type2 = "rcv";
            string id3 = "";
            if(mesaj!="")
            {
                int a = Convert.ToInt32(id2);
                a++;
                SqlConnection bag = new SqlConnection(conString);
                bag.Open();
                SqlCommand kmt2 = new SqlCommand("insert into [chatt].[dbo].[" + id + ".Messages] (id,messid,messages,type) values(" + a + ",'" + messid + "','" + mesaj + "','" + type + "')", bag);
                kmt2.ExecuteNonQuery();
                bag.Close();
                bag.Open();
                SqlCommand kmts = new SqlCommand("Select * from [chatt].[dbo].[" + messid + ".Messages] ", bag);
                SqlDataReader dr2 = kmts.ExecuteReader();
                while (dr2.Read())
                {
                    id3 = Convert.ToString(dr2["id"]);
                }
                int b = 0;
                if(id3!="")
                {
                    b = Convert.ToInt32(id3);
                    b++;
                }
                else
                {
                    b = 1;
                }
                bag.Close();
                bag.Open();
                SqlCommand kmt3 = new SqlCommand("insert into [chatt].[dbo].[" + messid + ".Messages] (id,messid,messages,type) values(" + b + ",'" + id + "','" + mesaj + "','" + type2 + "')", bag);
                kmt3.ExecuteNonQuery();
                bag.Close();
                Yükle();
            }
        }
        public int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if(sayac%5==0)
            {
                Yükle();
            }
        }
    }
}
