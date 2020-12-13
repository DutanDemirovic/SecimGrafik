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

namespace SecimTablosu
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HBD9E76;Initial Catalog=dbSecim;Integrated Security=True");
        private void btnOyKayit_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TblIlce (IlceAd,Aparti,Bparti,Cparti,Dparti,Eparti) values (@IlceAd,@Aparti,@Bparti,@Cparti,@Dparti,@Eparti)", baglanti);
            komut.Parameters.AddWithValue("@IlceAd", txtIlceAdi.Text);
            komut.Parameters.AddWithValue("@Aparti", txtApartisi.Text);
            komut.Parameters.AddWithValue("@Bparti", txtBpartisi.Text);
            komut.Parameters.AddWithValue("@Cparti", txtCpartisi.Text);
            komut.Parameters.AddWithValue("@Dparti", txtDpartisi.Text);
            komut.Parameters.AddWithValue("@Eparti", txtEpartisi.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy Girişi Başarı İle Gerçekleştirildi");
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frm = new FrmGrafikler();
            frm.Show();
        }
    }
}
