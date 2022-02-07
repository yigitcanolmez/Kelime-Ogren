using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kelime_Öğren
{
    public partial class oyun : Form
    {
        public oyun()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        OleDbConnection bgl = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\YC\\Desktop\\dbSozluk.accdb");
        Random rnd = new Random();
        int sure = 90;
        int kelime = 0;

        void getir()
        {
            int sayi;
            sayi = rnd.Next(1, 2490);

            bgl.Open();
            OleDbCommand komut = new OleDbCommand("Select * from sozluk where id=@p1", bgl);
            komut.Parameters.AddWithValue("@p1", sayi);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txteng.Text = dr[1].ToString();
                lblcevap.Text = dr[2].ToString();
            }
            bgl.Close();
        }
         private void oyun_Load(object sender, EventArgs e)
        {
            getir();
            timer1.Start();
        }

      

        private void timer1_Tick(object sender, EventArgs e)
        {
            sure--;
            label3.Text = sure.ToString();
            progressBar1.Value = Convert.ToInt32( label3.Text);
            if (sure == 1)
            {
                txttr.Enabled = false;
                MessageBox.Show("Skorunuz = " + lblkelime.Text);
                timer1.Stop();
            }

        }

  

        private void txttr_TextChanged(object sender, EventArgs e)
        {
            if (txttr.Text == lblcevap.Text)
            {
                kelime++;
                lblkelime.Text = kelime.ToString();
                txttr.Text = "";
                getir();
                txttr.Focus();
            }
        }
    }
}
