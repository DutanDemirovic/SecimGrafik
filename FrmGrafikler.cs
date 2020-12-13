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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HBD9E76;Initial Catalog=dbSecim;Integrated Security=True");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            // İlçe Adlarını Comboboxa Çekme

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select IlceAd from TblIlce", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            baglanti.Close();

            // Grafiğe Toplam Sonuçları Gösterme

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(Aparti),sum(Bparti),sum(Cparti),sum(Dparti),sum(Eparti) from TblIlce", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("Aparti", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("Bparti", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("Cparti", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("Dparti", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("Eparti", dr2[4]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select * from TblIlce where IlceAd=@P1", baglanti);
            komut3.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr = komut3.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                label7.Text = dr[2].ToString();
                label8.Text = dr[3].ToString();
                label9.Text = dr[4].ToString();
                label10.Text = dr[5].ToString();
                label11.Text = dr[6].ToString();
            }
            baglanti.Close();
        }
    }
}
