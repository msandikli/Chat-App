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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public string user = "";
        private void Main_Load(object sender, EventArgs e)
        {
            label1.Text += user;

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        static string conString = "Data Source=den1.mssql7.gear.host;Initial Catalog=chatt;Uid=chatt;Password=Mehmet0699.;";
        private void button1_Click(object sender, EventArgs e)
        {
            if(grp2%2==0)
            {
                groupBox2.Visible = true;
                //Mesajlar butonu
                int say = 0;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                string messid = "";
                SqlConnection bag = new SqlConnection(conString);
                bag.Open();
                SqlCommand kmt = new SqlCommand("Select * from [chatt].[dbo].[" + user + ".Messages]", bag);
                SqlDataReader dr = kmt.ExecuteReader();
                while (dr.Read())
                {
                    messid = Convert.ToString(dr["messid"]);
                    int i = 0;
                    int hata = 0;
                    int count = listBox3.Items.Count;

                    if (messid == "")
                    {
                        say = 1;
                        break;
                    }
                    while (i < count)
                    {
                        listBox3.SelectedIndex = i;
                        if (messid == listBox3.SelectedItem.ToString())
                        {
                            hata = 1;
                        }
                        i++;
                    }
                    if (hata == 0)
                    {
                        listBox3.Items.Add(messid);
                    }


                }
                bag.Close();
                bag.Open();
                if (say == 0)
                {
                    int count = listBox3.Items.Count;
                    int i = 0;
                    string name = "";
                    while (i < count)
                    {
                        listBox3.SelectedIndex = i;
                        string messid2 = listBox3.SelectedItem.ToString();
                        SqlCommand kmt2 = new SqlCommand("Select * from [chatt].[dbo].[User] where userid=" + messid2 + "", bag);
                        SqlDataReader dr2 = kmt2.ExecuteReader();
                        while (dr2.Read())
                        {
                            name = Convert.ToString(dr2["name"]);
                            listBox1.Items.Add(name);
                            listBox2.Items.Add(messid2);
                        }
                        i++;
                    }
                }
                bag.Close();
            }
            else
            {
                groupBox2.Visible = false;
            }
            grp2++;
            
        }

        private void button3_Click(object sender, EventArgs e)//Mesajı görüntüle

        {
            if(listBox1.SelectedItem!=null)
            {
                Mesaj msj = new Mesaj();
                msj.id = user;
                msj.messid = listBox2.SelectedItem.ToString();
                msj.name = listBox1.SelectedItem.ToString();
                msj.Show();

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox4.SelectedIndex = listBox5.SelectedIndex;
        }
        public int grp3 = 0;
        public int grp5 = 0;
        public int grp2 = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if(grp3%2==0)
            {
                groupBox3.Visible = true;
                int say = 0;
                listBox4.Items.Clear();
                listBox5.Items.Clear();
                string frid = "";
                string frname = "";
                string reqok = "";
                SqlConnection bag = new SqlConnection(conString);
                bag.Open();
                SqlCommand kmt = new SqlCommand("Select * from [chatt].[dbo].[" + user + "]", bag);
                SqlDataReader dr = kmt.ExecuteReader();
                while (dr.Read())
                {
                    frid = Convert.ToString(dr["friendid"]);
                    frname= Convert.ToString(dr["friendname"]);
                    reqok= Convert.ToString(dr["reqok"]);
                    int i = 0;
                    int hata = 0;
                    int count = listBox4.Items.Count;

                    if (frid == "")
                    {
                        say = 1;
                        break;
                    }
                    while (i < count)
                    {
                        listBox4.SelectedIndex = i;
                        if (frid == listBox4.SelectedItem.ToString())
                        {
                            hata = 1;
                        }
                        i++;
                    }
                    if (hata == 0&&reqok=="yes")
                    {
                        listBox4.Items.Add(frid);
                        listBox5.Items.Add(frname);
                    }


                }
                bag.Close();
            }
            else
            {
                groupBox3.Visible = false;
            }
            grp3++;
        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox6.SelectedIndex = listBox7.SelectedIndex;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (grp5 % 2 == 0)
            {
                groupBox5.Visible = true;
                listBox8.Items.Clear();
                listBox9.Items.Clear();
                string frid = "";
                string frname = "";
                string reqok = "";
                SqlConnection bag = new SqlConnection(conString);
                bag.Open();
                SqlCommand kmt = new SqlCommand("Select * from [chatt].[dbo].[" + user + "]", bag);
                SqlDataReader dr = kmt.ExecuteReader();
                while (dr.Read())
                {
                    frid = Convert.ToString(dr["friendid"]);
                    frname = Convert.ToString(dr["friendname"]);
                    reqok = Convert.ToString(dr["reqok"]);
                    int i = 0;
                    int hata = 0;
                    int count = listBox9.Items.Count;

                    if (frid == "")
                    {
                        break;
                    }
                    while (i < count)
                    {
                        listBox9.SelectedIndex = i;
                        if (frid == listBox9.SelectedItem.ToString())
                        {
                            hata = 1;
                        }
                        i++;
                    }
                    if (hata == 0 && reqok == "no")
                    {
                        listBox9.Items.Add(frid);
                        listBox8.Items.Add(frname);
                    }


                }
                bag.Close();
            }
            else
            {
                groupBox5.Visible = false;
            }
            grp5++;
        }
        int sayac = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            if(sayac%2==0)
            {
                label3.Visible = true;
                textBox1.Visible = true;
                button6.Visible = true;
            }
            else
            {
                label3.Visible = false;
                textBox1.Visible = false;
                button6.Visible = false;
            }
            sayac++;

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = "";
            string a = "";
            int say = 0;
            int hata = 0;
            SqlConnection bag = new SqlConnection(conString);
            bag.Open();
            SqlCommand kmt = new SqlCommand("Select * from [chatt].[dbo].["+user+"]", bag);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                a = Convert.ToString(dr["id"]);
                string id2 = Convert.ToString(dr["friendid"]);
                if(id==id2||id==user)
                {
                    hata = 1;
                }
            }
            int b = 1;
            if (a!="")
            {
                b = Convert.ToInt32(a);
                b++;
            }
            bag.Close();
            if (hata==0)
            {
                bag.Open();
                SqlCommand kmt2 = new SqlCommand("Select * from [chatt].[dbo].[User]", bag);
                SqlDataReader dr2 = kmt2.ExecuteReader();
                while (dr2.Read())
                {
                    string id2 = Convert.ToString(dr2["userid"]);
                    if (id == id2)
                    {
                        say = 1;
                        name = Convert.ToString(dr2["name"]);
                    }
                }
                bag.Close();
                if (say==1)
                {
                    bag.Open();
                    SqlCommand kmt3 = new SqlCommand("insert into [chatt].[dbo].[" + user + "] (id,friendname,friendid,reqok) values(" + b + ",'" + name + "','" + id + "','wait')", bag);
                    kmt3.ExecuteNonQuery();
                    bag.Close();
                    bag.Open();
                    SqlCommand kmt4 = new SqlCommand("Select * from [chatt].[dbo].[User]", bag);
                    SqlDataReader dr3 = kmt2.ExecuteReader();
                    string s = "";
                    while (dr3.Read())
                    {
                        string id2 = Convert.ToString(dr3["userid"]);
                        if (user == id2)
                        {
                            s= Convert.ToString(dr3["id"]);
                            name = Convert.ToString(dr3["name"]);
                        }
                    }
                    int c = 1;
                    if(s!="")
                    {
                        c =Convert.ToInt32(s);
                        c++;
                    }
                    bag.Close();
                    bag.Open();
                    SqlCommand kmt5 = new SqlCommand("insert into [chatt].[dbo].[" + id + "] (id,friendname,friendid,reqok) values(" + c + ",'" + name + "','" + user + "','no')", bag);
                    kmt5.ExecuteNonQuery();
                    bag.Close();
                }
                MessageBox.Show("Arkadaşlık isteği gönderildi.");
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(listBox9.SelectedItem!=null)
            {
                string id = listBox9.SelectedItem.ToString();
                SqlConnection bag = new SqlConnection(conString);
                bag.Open();
                SqlCommand kmt = new SqlCommand("Update [chatt].[dbo].[" + user + "] set reqok='yes' where friendid='"+id+"'", bag);
                kmt.ExecuteNonQuery();
                bag.Close();
                bag.Open();
                SqlCommand kmt2 = new SqlCommand("Update [chatt].[dbo].[" + id + "] set reqok='yes' where friendid='" + user + "'", bag);
                kmt2.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Arkadaş eklendi.");
                button2.PerformClick();
                button2.PerformClick();
                button4.PerformClick();
                button4.PerformClick();
            }
        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox9.SelectedIndex = listBox8.SelectedIndex;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox9.SelectedItem != null)
            {
                string id = listBox9.SelectedItem.ToString();
                SqlConnection bag = new SqlConnection(conString);
                bag.Open();
                SqlCommand kmt = new SqlCommand("delete from [chatt].[dbo].[" + user + "]  where friendid='" + id + "'", bag);
                kmt.ExecuteNonQuery();
                bag.Close();
                bag.Open();
                SqlCommand kmt2 = new SqlCommand("delete from [chatt].[dbo].[" + id + "]  where friendid='" + user + "'", bag);
                kmt2.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Arkadaşlık isteği reddedildi.");
                button4.PerformClick();
                button4.PerformClick();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedItem != null)
            {
                string id = listBox4.SelectedItem.ToString();
                SqlConnection bag = new SqlConnection(conString);
                bag.Open();
                SqlCommand kmt = new SqlCommand("delete from [chatt].[dbo].[" + user + "]  where friendid='" + id + "'", bag);
                kmt.ExecuteNonQuery();
                bag.Close();
                bag.Open();
                SqlCommand kmt2 = new SqlCommand("delete from [chatt].[dbo].[" + id + "]  where friendid='" + user + "'", bag);
                kmt2.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Arkadaş silindi.");
                button2.PerformClick();
                button2.PerformClick();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Mesaj msj = new Mesaj();
            msj.id = user;
            msj.messid = listBox4.SelectedItem.ToString();
            msj.name = listBox5.SelectedItem.ToString();
            msj.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(listBox3.SelectedItem!=null)
            {
                string id = listBox3.SelectedItem.ToString();
                SqlConnection bag = new SqlConnection(conString);
                bag.Open();
                SqlCommand kmt = new SqlCommand("delete from [chatt].[dbo].[" + user + ".Messages]  where messid='" + id + "'", bag);
                kmt.ExecuteNonQuery();
                MessageBox.Show("Mesaj Silindi");
                button1.PerformClick();
                button1.PerformClick();
            }
        }
    }
}
