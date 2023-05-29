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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formkullanıcılar gec = new Formkullanıcılar();
            gec.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKitaplar formKitaplar = new FormKitaplar();
            formKitaplar.ShowDialog(); 
            
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            Sql_baglantı sql = new Sql_baglantı();
            if (sql.adim == "admin")
            {
                button2.Enabled = false;
                button2.Visible = false;
            }
        }
    }
}
 