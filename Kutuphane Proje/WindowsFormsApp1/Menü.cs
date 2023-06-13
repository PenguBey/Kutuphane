using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }
        FormKitaplar formKitaplar = new FormKitaplar();
        Formkullanıcılar gec = new Formkullanıcılar();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            gec.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            this.Hide();
            formKitaplar.Show();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            saat = int.Parse(naber.ToString("hh"));
            dak = int.Parse(naber.ToString("mm"));
            san = int.Parse(naber.ToString("ss"));
            label1.Text = saat.ToString();
            label2.Text = dak.ToString();
            label3.Text = san.ToString();
            timer1.Start();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            Sql_baglantı sql = new Sql_baglantı();
            if (sql.adim == "admin")
            {
                button2.Enabled = false;
                button2.Visible = false;
            }
        }
        DateTime naber = DateTime.Now;
        int saat, dak, san;
        private void timer1_Tick(object sender, EventArgs e)
        {
            saat = int.Parse(naber.ToString("hh"));
            dak = int.Parse(naber.ToString("mm"));
            san = int.Parse(naber.ToString("ss"));
            label1.Text = saat.ToString();
            label2.Text = dak.ToString();
            label3.Text = san.ToString();
        }
    }
}
 