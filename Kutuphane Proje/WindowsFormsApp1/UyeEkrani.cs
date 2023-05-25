using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class FormUye : Form
    {
        Sql_baglantı sql = new Sql_baglantı();
        public FormUye()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql.Baglantı();

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
                    sql.komut.CommandText = "insert into Table_giris (username,password) values (@ad,@sifre)";
                    sql.komut.Parameters.AddWithValue("ad", textBox1.Text);
                    sql.komut.Parameters.AddWithValue("sifre", textBox2.Text);
                    sql.komut.ExecuteNonQuery();
                    sql.adim = textBox1.Text;
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
            FormGiris gec =new FormGiris();
            gec.Show();
        }

        private void FormUye_Load(object sender, EventArgs e)
        {

        }
    }
}
