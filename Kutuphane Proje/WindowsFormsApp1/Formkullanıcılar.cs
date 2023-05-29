using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Formkullanıcılar : Form
    {
        public Formkullanıcılar()
        {
            InitializeComponent();
        }

        private void label_geri_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu gec = new FormMenu();
            gec.ShowDialog();
        }
        Sql_baglantı sql = new Sql_baglantı();
        string sifrem;
        private void Formkullanıcılar_Load(object sender, EventArgs e)
        {
            sql.Baglantı();
            sql.komut.CommandText = "select password from Table_giris where username = @adim";
            sql.komut.Parameters.AddWithValue("adim", sql.adim);
            sifrem = sql.komut.ExecuteScalar().ToString();
            textBox1.Text = sql.adim;
            textBox2.Text = sifrem;
            sql.baglan.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql.Baglantı();
            sql.komut.Parameters.Clear();
            string sorgu = "update Table_giris set";
            List<string> degerler = new List<string>();
            bool a = false , b = false,onay = true;
            if (textBox1.Text != sql.adim)
            {
                a = true;

                sql.komut.CommandText = "select username from Table_giris where username = @ad";
                sql.komut.Parameters.AddWithValue("ad", textBox1.Text);
                SqlDataReader oku = sql.komut.ExecuteReader();
                if (oku.Read())
                {
                    label3.Text = "bu kullanıcı adı zaten var";
                    onay = false;
                }
                else
                {
                    sql.baglan.Close();
                    sql.Baglantı();
                    sql.komut.Parameters.Clear();
                    sql.komut.CommandText = "update Table_kitaplar set durum = @duruumyeter where durum = @Trololololololhehehehhe";
                    sql.komut.Parameters.AddWithValue("duruumyeter", textBox1.Text);
                    sql.komut.Parameters.AddWithValue("Trololololololhehehehhe", sql.adim);
                    sql.komut.ExecuteNonQuery();
                    sql.baglan.Close();
                    sql.Baglantı();
                    degerler.Add(" username = @adim");
                    sql.komut.Parameters.AddWithValue("adim", textBox1.Text);
                }
                
            }
            if (textBox2.Text != sifrem)
            {
                b = true;
                degerler.Add(" password = @sifrem");
                sql.komut.Parameters.AddWithValue("sifrem", textBox2.Text);
            }
            if (a == false && b == false)
            {
                label3.Text = "Hiçbir değeri değiştirmediniz";
            }
            else if (onay == true)
            {
                sorgu += string.Join(",", degerler);
                sorgu += " where username = @user";
                sql.komut.Parameters.AddWithValue("user", sql.adim);
                sql.komut.CommandText= sorgu;
                sql.komut.ExecuteNonQuery();
                if (a == true && b == true)
                {
                    label3.Text = "Kullanıcı adınız ve şifreniz değiştirildi";
                }
                else if (b == true)
                {
                    label3.Text = "şifreniz değiştirildi";
                }
                else if (a == true)
                {
                    label3.Text = "Kullanıcı adınız değiştirildi";
                }
                sql.adim = textBox1.Text;
                sifrem = textBox2.Text;
                
            }
            sql.baglan.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql.Baglantı();
            sql.komut.CommandText = "update Table_kitaplar set durum = null where durum = @ad";
            sql.komut.Parameters.AddWithValue("ad", sql.adim);
            sql.komut.ExecuteNonQuery();
            sql.baglan.Close();
            sql.Baglantı();
            sql.komut.CommandText = "delete from Table_giris where username = @adim";
            sql.komut.Parameters.AddWithValue ("adim", sql.adim);
            sql.komut.ExecuteNonQuery();
            Application.Exit();
            sql.baglan.Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "...";
        }
    }
}
