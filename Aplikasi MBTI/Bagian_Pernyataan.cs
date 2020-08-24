using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Aplikasi_MBTI
{
    public partial class Bagian_Pernyataan : Form
    {
        int No_Pernyataan = 1;
        string jenis_a, jenis_b;
        string kode_hasil, tipe_individu, saran_pengembangan, saran_profesi, pasangan;
        int angka_1, angka_2, angka_3, angka_4, angka_5, angka_6, angka_7, angka_8;
        Bagian_Hasil coba = new Bagian_Hasil();
        private void Tombol_Informasi_Selengkapnya_Click(object sender, EventArgs e)
        {
            kode_hasil = Kotak_1.Text + Kotak_2.Text + Kotak_3.Text + Kotak_4.Text;
            Hasil();
            coba.ShowDialog();

            // MessageBox.Show(Kotak_1.Text + Kotak_2.Text + Kotak_3.Text + Kotak_4.Text);
        }

        int total = 15;
        public Bagian_Pernyataan()
        {
            InitializeComponent();
            Konek();
        }
        public void Konek()
        {

            SQLiteConnection Koneksi_DB;
            Koneksi_DB = new SQLiteConnection("Data Source=mbti.sqlite;Version=3;");
            Koneksi_DB.Open();
            if (No_Pernyataan > 60)
            {
                
                Label_Pernyataan.Visible = false;
                Tombol_Pernyataan_A.Enabled = false;
                Tombol_Pernyataan_A.Visible = false;
                Tombol_Pernyataan_B.Enabled = false;
                Tombol_Pernyataan_B.Visible = false;
                Pernyataan_A.Visible = false;
                Pernyataan_B.Visible = false;

                Label_Hasil.Visible = true;
                Kotak_1.Visible = true;
                Kotak_2.Visible = true;
                Kotak_3.Visible = true;
                Kotak_4.Visible = true;
                Tombol_Informasi_Selengkapnya.Visible = true;
                MessageBox.Show("Anda telah menyelesaikan tes kepribadian." +System.Environment.NewLine+"Untuk melihat informasi selengkapnya klik tombol 'Informasi Selengkapnya'.");
                if (Convert.ToDecimal(Kotak_Introvert.Text) > Convert.ToDecimal(Kotak_Ekstrovert.Text)){
                    Kotak_1.Text = "I";

                } else
                {
                    Kotak_1.Text = "E";
                }


                if (Convert.ToDecimal(Kotak_Sensing.Text) > Convert.ToDecimal(Kotak_Intuition.Text))
                {
                    Kotak_2.Text = "S";

                }
                else
                {
                    Kotak_2.Text = "N";
                }


                if (Convert.ToDecimal(Kotak_Thinking.Text) > Convert.ToDecimal(Kotak_Feeling.Text))
                {
                    Kotak_3.Text = "T";

                }
                else
                {
                    Kotak_3.Text = "F";
                }


                if (Convert.ToDecimal(Kotak_Judging.Text) > Convert.ToDecimal(Kotak_Perceiving.Text))
                {
                    Kotak_4.Text = "J";

                }
                else
                {
                    Kotak_4.Text = "P";
                }

            }
            else {
                try
                {
                    string sql = "SELECT * FROM data_pernyataan WHERE id=" + No_Pernyataan;
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, Koneksi_DB))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                string pernyataan_a = reader["pernyataan_a"].ToString();
                                Pernyataan_A.Text = pernyataan_a;
                                jenis_a = reader["jenis_a"].ToString();
                                string pernyataan_b = reader["pernyataan_b"].ToString();
                                Pernyataan_B.Text = pernyataan_b;
                                jenis_b = reader["jenis_b"].ToString();

                            }
                        }
                    }


                }
                catch (SQLiteException e)
                {
                    MessageBox.Show("Ada kesalahan : " + e.ToString());
                }
            }
        }


        private void Tombol_Pernyataan_A_Click(object sender, EventArgs e)
        {
            if (jenis_a == "1")
            {
                angka_1++;
                decimal sementara = 0;
                sementara = ((decimal)angka_1 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Introvert.Text = sementara.ToString("#.##");
            }
            else if (jenis_a == "2")
            {
                angka_2++;
                decimal sementara = 0;
                sementara = ((decimal)angka_2 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Sensing.Text = sementara.ToString("#.##");
            }
            else if (jenis_a == "3")
            {
                angka_3++;
                decimal sementara = 0;
                sementara = ((decimal)angka_3 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Thinking.Text = sementara.ToString("#.##");
            }
            else if (jenis_a == "4")
            {
                angka_4++;
                decimal sementara = 0;
                sementara = ((decimal)angka_4 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Judging.Text = sementara.ToString("#.##");
            }
            else if (jenis_a == "5")
            {
                angka_5++;
                decimal sementara = 0;
                sementara = ((decimal)angka_5 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Ekstrovert.Text = sementara.ToString("#.##");
            }
            else if (jenis_a == "6")
            {
                angka_6++;
                decimal sementara = 0;
                sementara = ((decimal)angka_6 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Intuition.Text = sementara.ToString("#.##");
            }
            else if(jenis_a == "7")
            {
                angka_7++;
                decimal sementara = 0;
                sementara = ((decimal)angka_7 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Feeling.Text = sementara.ToString("#.##");
            }
            else
            {
                angka_8++;
                decimal sementara = 0;
                sementara = ((decimal)angka_8 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Perceiving.Text = sementara.ToString("#.##");
            }
            No_Pernyataan++;
            Konek();
        }


        public void Hasil()
        {

            SQLiteConnection Koneksi_DB;
            Koneksi_DB = new SQLiteConnection("Data Source=mbti.sqlite;Version=3;");
            Koneksi_DB.Open();
            try
            {
                string sql = "SELECT * FROM data_hasil WHERE kode='" + kode_hasil + "'";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, Koneksi_DB))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            tipe_individu = reader["tipe_individu"].ToString();
                            
                            coba.Teks_Tipe_Individu.Text = tipe_individu.Replace("<n>", System.Environment.NewLine);
                            saran_pengembangan = reader["saran_pengembangan"].ToString();
                            coba.Teks_Saran_Pengembangan.Text = saran_pengembangan.Replace("<n>", System.Environment.NewLine);
                            saran_profesi = reader["saran_profesi"].ToString();
                            coba.Teks_Saran_Profesi.Text = saran_profesi;
                            pasangan = reader["pasangan"].ToString();
                            coba.Teks_Pasangan.Text = pasangan;
                            coba.Kode.Text = kode_hasil;
                        }
                        

                    }
                }

            }
            catch (SQLiteException e)
            {
                MessageBox.Show("Ada kesalahan : " + e.ToString());
            }
        }

            private void Tombol_Pernyataan_B_Click(object sender, EventArgs e)
        {
            if (jenis_b == "1")
            {
                angka_1++;
                decimal sementara = 0;
                sementara = ((decimal)angka_1 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Introvert.Text = sementara.ToString("#.##");
            }
            else if (jenis_b == "2")
            {
                angka_2++;
                decimal sementara = 0;
                sementara = ((decimal)angka_2 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Sensing.Text = sementara.ToString("#.##");
            }
            else if (jenis_b == "3")
            {
                angka_3++;
                decimal sementara = 0;
                sementara = ((decimal)angka_3 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Thinking.Text = sementara.ToString("#.##");
            }
            else if (jenis_b == "4")
            {
                angka_4++;
                decimal sementara = 0;
                sementara = ((decimal)angka_4 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Judging.Text = sementara.ToString("#.##");
            }
            else if (jenis_b == "5")
            {
                angka_5++;
                decimal sementara = 0;
                sementara = ((decimal)angka_5 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Ekstrovert.Text = sementara.ToString("#.##");
            }
            else if (jenis_b == "6")
            {
                angka_6++;
                decimal sementara = 0;
                sementara = ((decimal)angka_6 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Intuition.Text = sementara.ToString("#.##");
            }
            else if (jenis_b == "7")
            {
                angka_7++;
                decimal sementara = 0;
                sementara = ((decimal)angka_7 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Feeling.Text = sementara.ToString("#.##");
            }
            else
            {
                angka_8++;
                decimal sementara = 0;
                sementara = ((decimal)angka_8 / total) * 100;
                Math.Round(sementara, 2);
                Kotak_Perceiving.Text = sementara.ToString("#.##");
            }
            No_Pernyataan++;
            Konek();
        }

        private void Bagian_Pernyataan_Load(object sender, EventArgs e)
        {

        }
    }
}
