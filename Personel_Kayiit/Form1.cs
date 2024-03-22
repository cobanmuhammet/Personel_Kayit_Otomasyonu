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
using System.Data.Sql;

namespace Personel_Kayiit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection bag = new SqlConnection(@"Data Source=./;Initial Catalog=PersonelVeriTabanı;Integrated Security=True");

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        void listele()
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Personel", bag);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        void temizle()
        {
            txtPerİd.Clear();
            txtPerAd.Clear();
            txtPerMeslek.Clear();
            txtPerSoyad.Clear();
            cmbSehir.Text = "";
            mskMaas.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            label8.Text = "";
            txtPerAd.Focus();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMeslek,PerMaas,PerDurum) values(@p1,@p2,@p3,@p4,@p5,@p6)",bag);
            komut.Parameters.AddWithValue("@p1", txtPerAd.Text);
            komut.Parameters.AddWithValue("@p2", txtPerSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", txtPerMeslek.Text);
            komut.Parameters.AddWithValue("@p5", mskMaas.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            bag.Close();
            listele();
            temizle();
            MessageBox.Show("Kayıt Eklendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
            }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtPerİd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtPerAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtPerSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtPerMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komutsil = new SqlCommand("delete from Tbl_Personel where Perİd=@s1", bag);
            komutsil.Parameters.AddWithValue("@s1", txtPerİd.Text);
            komutsil.ExecuteNonQuery();
            bag.Close();
            listele();
            temizle();
            MessageBox.Show("Kayıt Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);          
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komutg = new SqlCommand("update Tbl_Personel set PerAd=@g1,PerSoyad=@g2,PerSehir=@g3,PerMaas=@g4,PerDurum=@g5,PerMeslek=@g6 where Perİd=@g7", bag);
            komutg.Parameters.AddWithValue("@g1", txtPerAd.Text);
            komutg.Parameters.AddWithValue("@g2", txtPerSoyad.Text);
            komutg.Parameters.AddWithValue("@g3", cmbSehir.Text);
            komutg.Parameters.AddWithValue("@g4", mskMaas.Text);
            komutg.Parameters.AddWithValue("@g5", label8.Text);
            komutg.Parameters.AddWithValue("@g6", txtPerMeslek.Text);
            komutg.Parameters.AddWithValue("@g7", txtPerİd.Text);
            komutg.ExecuteNonQuery();
            bag.Close();
            listele();
            temizle();
            MessageBox.Show("Kayıt Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
