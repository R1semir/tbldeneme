using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace denemelerim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BJO2DGU\\SQLEXPRESS;Initial Catalog=DersVeriTabani;Integrated Security=True");


        bool durum;
        void mukerrer()
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from Tbl_Bilgi where Numara=@p3",baglanti);
            komut2.Parameters.AddWithValue("@p3",mskNumara.Text);
            SqlDataReader dr = komut2.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mukerrer();
            if (durum == true) 
            { 
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Bilgi (Numara,AdSoyad) values (@p1,@p2)",baglanti);
            komut.Parameters.AddWithValue("@p1",mskNumara.Text);
            komut.Parameters.AddWithValue("@p2",txtAdSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Eklendi");
            }
            else
            {
                MessageBox.Show("Kullanıcı Numarası Zaten Mevcut", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
