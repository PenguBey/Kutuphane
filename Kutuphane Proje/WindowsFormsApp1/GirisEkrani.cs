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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            button1.FlatStyle = FlatStyle.Flat;
            timer1.Start();
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
        private void FormGiris_KeyDown(object sender, KeyEventArgs e)
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
