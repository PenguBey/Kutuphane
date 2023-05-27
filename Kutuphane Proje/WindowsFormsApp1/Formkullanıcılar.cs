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
        private void Formkullanıcılar_Load(object sender, EventArgs e)
        {
            sql.Baglantı();
            sql.komut.CommandText = "select password from Table_giris";

            sql.baglan.Close();
        }
    }
}
