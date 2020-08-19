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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }
        static string conString = "Data Source=den1.mssql7.gear.host;Initial Catalog=chatt;Uid=chatt;Password=Mehmet0699.;";
        private void button3_Click(object sender, EventArgs e)
        {
            int say = 0;
            string usname = textBox1.Text;
            usname=usname.Trim();
            string pass = textBox2.Text;
            string userid = "";
            SqlConnection bag = new SqlConnection(conString);
            bag.Open();
            SqlCommand kmt = new SqlCommand("Select * from [chatt].[dbo].[user]", bag);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                
                string usname2 = Convert.ToString(dr["username"]);
                string pass2 = Convert.ToString(dr["password"]);
                userid = Convert.ToString(dr["userid"]);
                if(usname==usname2&&pass==pass2)
                {
                    
                    say = 1;
                    break;
                }
            }
            if(say==1)
            {
                if(checkBox1.Checked)
                {
                    Main mn = new Main();
                    mn.user = userid;
                    mn.Show();
                    bag.Close();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı/Parola Hatalı!");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int say = 0;
            string usname = textBox4.Text;
            string pass = textBox5.Text;
            string name = textBox3.Text;
            string userid2 = "";
            string id = "";
            SqlConnection bag = new SqlConnection(conString);
            bag.Open();
            SqlCommand kmt = new SqlCommand("Select * from [chatt].[dbo].[user]", bag);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                id= Convert.ToString(dr["id"]);
                string usname2 = Convert.ToString(dr["username"]);
                string pass2 = Convert.ToString(dr["password"]);
                userid2 = Convert.ToString(dr["userid"]);
                if (usname == usname2)
                {
                    say = 1;
                }

            }
            bag.Close();
            if(say==0)
            {
                if(id=="")
                {
                    bag.Open();
                    userid2 = "100001";
                    SqlCommand kmt5 = new SqlCommand("insert into [chatt].[dbo].[user] (id,username,password,userid,name) values(1,'" + usname + "','" + pass + "','" + userid2 + "','" + name + "')", bag);
                    kmt5.ExecuteNonQuery();
                    
                }
                else
                {
                    int a = Convert.ToInt32(id);
                    a++;
                    int b = Convert.ToInt32(userid2);
                    b++;
                    userid2 = b.ToString();
                    bag.Open();
                    SqlCommand kmt2 = new SqlCommand("insert into [chatt].[dbo].[user] (id,username,password,userid,name) values(" + a + ",'" + usname + "','" + pass + "','" + userid2 + "','" + name + "')", bag);
                    kmt2.ExecuteNonQuery();
                }
                
                bag.Close();
                if(checkBox2.Checked)
                {
                    bag.Open();
                    SqlCommand kmt3 = new SqlCommand("CREATE TABLE [dbo].[" + userid2 + "]([id][int] NOT NULL,[reqok][nvarchar](50) NULL,[friendname][nvarchar](50) NULL,[friendid][nvarchar](50) NULL, CONSTRAINT[PK_" + userid2 + "] PRIMARY KEY CLUSTERED([id] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY]", bag);
                    kmt3.ExecuteNonQuery();
                    bag.Close();
                    bag.Open();
                    SqlCommand kmt4 = new SqlCommand("CREATE TABLE [dbo].[" + userid2 + ".Messages]([id][int] NOT NULL,[messid][nvarchar](50) NULL,[messages][nvarchar](50) NULL,[type][nvarchar](50) NULL, CONSTRAINT[PK_" + userid2 + ".Messages] PRIMARY KEY CLUSTERED([id] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY]", bag);
                    kmt4.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı! Giriş Yapın");
                    button5.PerformClick();
                    button1.PerformClick();
                }
            }
            else if(say==1)
            {
                MessageBox.Show("Kullanıcı adı kullanılmaktadır!");
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox3.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kullanıcının yapacağı tüm görüşmelerdeki yasal olmayan davranışlar kendi sorumluluğundadır.");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kullanıcının yapacağı tüm görüşmelerdeki yasal olmayan davranışlar kendi sorumluluğundadır.");
        }
    }
}
