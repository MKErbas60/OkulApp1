using OkullApp.MODEL;
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
using OkulApp.BLL;

namespace OkulApp1
{
    public partial class frmOgrKayit : Form
    {
        public frmOgrKayit()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //public bool OgrenciEkle(Ogrenci ogr)
        //{
        //    SqlConnection cn = null;
        //    SqlCommand cmd = null;
        //    try
        //    {
        //        using (cn = new SqlConnection("Data Source=.;Initial Catalog=OkulDB;Integrated Security=true"))
        //        {
        //            using (cmd = new SqlCommand($"Insert into tblOgrenciler values (@Ad,@Soyad,@Numara)", cn))
        //            {

        //                SqlParameter[] p = {
        //            new SqlParameter("@Ad",ogr.Ad),
        //            new SqlParameter("@Soyad",ogr.Soyad),
        //            new SqlParameter("@Numara",ogr.Numara)


        //        };
        //                cmd.Parameters.AddRange(p);
        //            }
        //        }
        //        //cn = new SqlConnection("Data Source=.;Initial Catalog=OkulDB;Integrated Security=true");
        //        //cmd = new SqlCommand($"Insert into tblOgrenciler values (@Ad,@Soyad,@Numara)", cn);




        //        cn.Open();
        //        int sonuc = cmd.ExecuteNonQuery();
        //        return (sonuc > 0);
        //    }
        //    catch (SqlException)
        //    {

        //        throw;

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    //finally
        //    //{
        //    //    if (cn != null && cn.State != ConnectionState.Closed)
        //    //    {
        //    //        cn.Close();
        //    //        cn.Dispose();
        //    //        cmd.Dispose();
        //    //    }
        //    //}
        //}
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                bool sonuc = obl.OgrenciEkle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim(), });
                MessageBox.Show(sonuc ? "Ekleme Başarılı!" : "Ekleme başarısız!!");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numaralı öğrenci zaten var.");
                        break;
                    default:
                        MessageBox.Show("Veritabanı hatası");
                        break;
                }
            }
            catch (Exception)
            {
                throw;
                MessageBox.Show("Allahallah ne oldu acep");
            }
        }
    }
}
