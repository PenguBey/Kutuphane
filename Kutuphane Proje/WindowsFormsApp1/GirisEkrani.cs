using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }

        private void GirisEkrani_Load(object sender, EventArgs e)
        {
            label4.Text = "Yoksa Üye Olmadığınız Halde,\nBeni Kandırarak Giriş Yapabileceğinize İnanarak.\n Giriş Yapmayamı Çalıştınız?";
        }
        Sql_baglantı sql = new Sql_baglantı();
        private void button1_Click(object sender, EventArgs e)
        {
            sql.Baglantı();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                sql.komut.Parameters.Clear();
                sql.komut.CommandText = "select * from Table_giris where username = @ad and password = @sifre";
                sql.komut.Parameters.AddWithValue("ad", textBox1.Text);
                sql.komut.Parameters.AddWithValue("sifre", textBox2.Text);
                var deger = sql.komut.ExecuteScalar();
                if (deger != null)
                {
                    sql.adim = textBox1.Text;
                    this.Close();
                    FormMenu gec = new FormMenu();
                    gec.Show();
                }
                else
                {
                    label3.Text = "Kullanıcı Adı veya Şifre Yanlış";
                    textBox1.Focus();
                }
                /*SqlDataReader oku = sql.komut.ExecuteReader();
                if (oku.HasRows)
                {
                    this.Close();
                    FormMenu gec = new FormMenu();
                    gec.Show();
                }*/
            }
            else
            {
                label3.Text = "Lütfen kullanıcı adınızı ve şifrenizi tam doldurunuz!";
                textBox1.Focus();
            }
            sql.baglan.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
            FormUye gec = new FormUye();
            gec.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "";
        }
    }
}
