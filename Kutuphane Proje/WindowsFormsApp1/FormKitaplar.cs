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
    public partial class FormKitaplar : Form
    {
        public FormKitaplar()
        {
            InitializeComponent();
        }
        Sql_baglantı sql = new Sql_baglantı();
        private void FormKitaplar_Load(object sender, EventArgs e)
        {
            label1.Text = "Kullanıcı: " + sql.adim;
            if (sql.adim == "admin")
            {
                button_geriver.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
                buttonsil.Enabled = true;
                button_geriver.Visible = false;
                button3.Visible = false;
                button4.Visible = true;
                buttonsil.Visible = true;
            }
            comboBox2.SelectedIndex = 0;
            sql.Baglantı();
            sql.komut.CommandText = "select * from Table_kitaplar";
            sorgulamak();

            sql.baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql.Baglantı();
            listView1.Items.Clear();
            sql.komut.Parameters.Clear();
            string sorgu = "select * from Table_kitaplar where ";
            List<string> filtreler = new List<string>();

            if (textBox1.Text == "" && textBox2.Text =="" && comboBox2.SelectedIndex == 0 && radioButton4.Checked == true)
            {
                sorgu = "select * from Table_kitaplar";
            }

            if (textBox1.Text != "")
            {
                filtreler.Add(" ad like @adim ");
                sql.komut.Parameters.AddWithValue("adim", "%" + textBox1.Text + "%");
            }
            if (textBox2.Text != "")
            {
                filtreler.Add(" yazar like @yazarım ");
                sql.komut.Parameters.AddWithValue("yazarım", "%" + textBox2.Text + "%");
            }
            if (comboBox2.SelectedIndex != 0 && comboBox2.SelectedItem.ToString() != "")
            {
                filtreler.Add(" tür = @türüm ");
                sql.komut.Parameters.AddWithValue("türüm", comboBox2.SelectedItem.ToString());
            }


            if (radioButton1.Checked == true)
            {
                filtreler.Add(" durum = @durumum ");
                sql.komut.Parameters.AddWithValue("durumum", sql.adim);
            }
            if (radioButton2.Checked == true)
            {
                filtreler.Add(" durum  is null ");

            }
            if (radioButton3.Checked == true)
            {
                filtreler.Add(" durum is not null and durum != @durumum ");
                sql.komut.Parameters.AddWithValue("durumum", sql.adim);
            }
            sorgu += string.Join("and", filtreler);
            sql.komut.CommandText = sorgu;
            sorgulamak();
            sql.baglan.Close();
            
        }
        private void sorgulamak()
        {
            SqlDataReader oku = sql.komut.ExecuteReader();
            while (oku.Read())
            {
                if (oku["durum"].ToString() == "")
                {
                    string[] yukle = { oku.GetString(0), oku.GetString(1), oku["tür"].ToString(), "Ödünç Alınabilir" };
                    ListViewItem eke = new ListViewItem(yukle);
                    listView1.Items.Add(eke);
                }
                else if (oku["durum"].ToString() == sql.adim)
                {
                    
                    string[] yukle = { oku.GetString(0), oku.GetString(1), oku["tür"].ToString(), "Senin Elinde" };

                    ListViewItem eke = new ListViewItem(yukle);
                    listView1.Items.Add(eke);
                }
                else
                {
                    string[] yukle;
                    if (sql.adim == "admin")
                    {
                         yukle = new string[] { oku.GetString(0), oku.GetString(1), oku["tür"].ToString(), oku["durum"].ToString() };
                    }
                    else
                    {
                        yukle = new string[] { oku.GetString(0), oku.GetString(1), oku["tür"].ToString(), "alınamaz" };

                    }
                    
                    ListViewItem eke = new ListViewItem(yukle);
                    listView1.Items.Add(eke);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                sql.Baglantı();
                sql.komut.Parameters.Clear();
                sql.komut.CommandText = "select durum from Table_kitaplar where ad = @adim and durum is null";
                sql.komut.Parameters.AddWithValue("adim", textBox1.Text);
                SqlDataReader oku = sql.komut.ExecuteReader();
                if (oku.Read())
                { 
                  
                       sql.baglan.Close();
                       sql.Baglantı();
                       sql.komut.CommandText = "update Table_kitaplar set durum = @durumum where ad = @adim";
                       sql.komut.Parameters.AddWithValue("durumum", sql.adim);
                       sql.komut.Parameters.AddWithValue("adim", textBox1.Text);
                       sql.komut.ExecuteNonQuery();
                       label6.Text = "kitabınız başarıyla ödünç alındı";
                  
                    
                }
                else
                {
                    label6.Text = "Kitabın adını yanlış yazmış olabilirsiniz\nKitap başkasında olabilir\nKitap sizde olabilir";
                }


                sql.baglan.Close();
            }
            else
            {
                label6.Text = "Ödünç alacağınız kitabın adını, Ad kısmına eksiksin yazınız ";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                sql.Baglantı();
                sql.komut.Parameters.Clear();
                sql.komut.CommandText = "select * from Table_kitaplar where ad = @adim and durum = @durumum ";
                sql.komut.Parameters.AddWithValue("adim", textBox1.Text);
                sql.komut.Parameters.AddWithValue("durumum", sql.adim);
                SqlDataReader oku = sql.komut.ExecuteReader();
                if (oku.Read())
                {              
                 sql.baglan.Close();
                 sql.Baglantı();
                 sql.komut.CommandText = "update Table_kitaplar set durum = null where durum = @durumum";
                 sql.komut.Parameters.AddWithValue("durumum", sql.adim);
                 sql.komut.ExecuteNonQuery();
                 label6.Text = "kitabınız başarıyla iade edildi";
                }
                else
                {
                    label6.Text = "Kitabın adını yanlış yazmış olabilirsiniz \nKitap sende olmayabilir";
                }

                sql.baglan.Close();
            }
            else
            {
                label6.Text = "Ödünç vereceğiniz kitabın adını, Ad kısmına eksiksin yazınız ";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void buttonsil_Click(object sender, EventArgs e)
        {

        }
    }
}
