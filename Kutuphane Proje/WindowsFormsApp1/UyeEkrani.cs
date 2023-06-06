using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class FormUye : Form
    {

        string dosyayolu = "datas.txt";
        Sql_baglantı sql = new Sql_baglantı();
        public FormUye()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            
            sql.Baglantı();
            StreamWriter writer = new StreamWriter(dosyayolu);
            sql.komut.CommandText = "select username from Table_giris";
            SqlDataReader oku = sql.komut.ExecuteReader();
            List<string> username = new List<string>();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                while (oku.Read())
                {
                    username.Add(oku.GetString(0));
                }
                sql.baglan.Close();
                sql.baglan.Open();
                if (username.Contains(textBox1.Text))
                {
                    label3.Text = "Bu Kullanıcı Adı Zaten Kayıtlı!";
                    textBox1.Focus();
                }
                else
                {
                    sql.komut.Parameters.Clear();
                    sql.komut.CommandText = "insert into Table_giris (username,password,ip) values (@ad,@sifrei,@ipm)";
                    sql.komut.Parameters.AddWithValue("ad", textBox1.Text);
                    sql.komut.Parameters.AddWithValue("sifrei", textBox2.Text);
                    string hostName = Dns.GetHostName();
                    string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                    sql.komut.Parameters.AddWithValue("ipm", myIP);
                    sql.komut.ExecuteNonQuery();
                    sql.adim = textBox1.Text;

                    writer.WriteLine(textBox1.Text);
                    writer.WriteLine(textBox2.Text);
                    sql.kayitlikullanici = textBox1.Text;
                    sql.kayitlisifre = textBox2.Text;
                    this.Hide();
                    FormMenu gec = new FormMenu();
                    gec.Show();
                }
            }
            else
            {
                label3.Text = "Lütfen kullanıcı adınızı ve şifrenizi tam doldurunuz!";
                textBox1.Focus();
            }


            sql.baglan.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGiris gec = new FormGiris();
            gec.Show();
        }
        string kaykullanad, kaysifre;
        private void FormUye_Load(object sender, EventArgs e)
        {
            using (var reader = new StreamReader(dosyayolu))
            {
                kaykullanad = reader.ReadLine();
                kaysifre = reader.ReadLine();
                if (true)
                {
                    //txt dosyasını kontrol etmek için kullan
                }
            }
            //Üye Olma Formunu Düzenler 
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            panel1.MaximumSize = panel1.Size;
            panel1.MinimumSize = panel1.Size;
            textBox1.MaximumSize = textBox1.Size;
            textBox1.MinimumSize = textBox1.Size;
            textBox2.MaximumSize = textBox2.Size;
            textBox2.MinimumSize = textBox2.Size;
            label1.MaximumSize = label1.Size;
            label1.MinimumSize = label1.Size;
            label2.MaximumSize = label2.Size;
            label2.MinimumSize = label2.Size;
            label3.MaximumSize = label3.Size;
            label3.MinimumSize = label3.Size;
            label4.MaximumSize = label4.Size;
            label4.MinimumSize = label4.Size;
            label5.MaximumSize = label5.Size;
            label5.MinimumSize = label5.Size;
            label6.MaximumSize = label6.Size;
            label6.MinimumSize = label6.Size;
            button1.MaximumSize = button1.Size;
            button1.MinimumSize = button1.Size;
            timer1.Start();

        }
        int sayac;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac = sayac + 1;
            if (sayac != 110)
            {
                panel2.Width = panel2.Width + 3;
                panel2.Height = panel2.Height + 2;
            }
            else
            {
                panel2.Enabled = true;
                timer1.Stop();
            }
        }
        bool timerstarter = true;
        private void FormUye_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E || e.KeyCode == Keys.Space)
            {
                if (timerstarter == true)
                {
                    timer1.Enabled = false;
                    panel2.Size = panel2.MaximumSize;
                    panel2.Enabled = true;
                    timerstarter = false;
                }
                else
                {
                    timerstarter = true;
                }
            }
        }
    }
}
