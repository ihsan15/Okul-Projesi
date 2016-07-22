using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEntityOkul
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        OkulEntities ent = new OkulEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllSiniflar();
            }

        }

        private void GetAllSiniflar()
        {
            var siniflar = (from s in ent.Sınıflar
                            select new { s.Adı, s.Id }).ToList();

            ddlSiniflar.DataTextField = "Adı";
            ddlSiniflar.DataValueField = "Id";
            ddlSiniflar.DataSource = siniflar;
            ddlSiniflar.DataBind();

            GetAllOgrencilerBySinifID(Convert.ToInt32(ddlSiniflar.SelectedValue));
        }

        protected void itemselected(object sender, EventArgs e)
        {
            Temizle();
            GetAllOgrencilerBySinifID(Convert.ToInt32(ddlSiniflar.SelectedValue));
        }

        private void GetAllOgrencilerBySinifID(int sinifID)
        {
            var Ogrenciler = (from o in ent.Ogrencilers
                              where o.SınıfId == sinifID
                              select new { o.Ad, o.Soyad, o.Telefon, o.Adres, o.TC, o.TaksitSayısı, o.TaksitTutar, o.Id }).ToList();
            gvOgrenciler.DataSource = Ogrenciler;
            gvOgrenciler.DataBind();
        }

        protected void ddlSiniflar_DataBound(object sender, EventArgs e)
        {
        }

        protected void gvOgrenciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Temizle();
            txtAdi.Text = HttpUtility.HtmlDecode(gvOgrenciler.SelectedRow.Cells[1].Text);
            txtSoyadi.Text = gvOgrenciler.SelectedRow.Cells[2].Text;
            txtTelefon.Text = gvOgrenciler.SelectedRow.Cells[3].Text;
            txtAdres.Text = gvOgrenciler.SelectedRow.Cells[4].Text;
            txtTC.Text = gvOgrenciler.SelectedRow.Cells[5].Text;
            txtTSayisi.Text = gvOgrenciler.SelectedRow.Cells[6].Text;
            txtTTutari.Text = gvOgrenciler.SelectedRow.Cells[7].Text;
            txtId.Text = gvOgrenciler.SelectedValue.ToString();

            OgrencilerPaneli.Visible = true;
            btnDegistir.Enabled = true;
            btnKaydet.Enabled = false;
            btnSil.Enabled =true;
        }

        protected void lbtnEkle_Click(object sender, EventArgs e)
        {
            OgrencilerPaneli.Visible = true;
            btnDegistir.Enabled = false;
            btnKaydet.Enabled = true;
            btnSil.Enabled = false;

            Temizle();
        }

        private void Temizle()
        {
            txtAdi.Text = "";
            txtSoyadi.Text = "";
            txtTelefon.Text = "";
            txtAdres.Text = "";
            txtTC.Text = "";
            txtTSayisi.Text = "";
            txtTTutari.Text = "";
            lblMesaj.Text = "";
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if(OgrenciKontrol())
            {
                lblMesaj.Text = "Öğrenci Zaten Kayıtlı!!!";
                txtAdi.Focus();
            }
            else
            {
                Ogrenciler ogr = new Ogrenciler();
                ogr.Ad = txtAdi.Text;
                ogr.Soyad = txtSoyadi.Text;
                ogr.Telefon = txtTelefon.Text;
                ogr.Adres = txtAdres.Text;
                ogr.TC = txtTC.Text;
                ogr.TaksitSayısı = Convert.ToByte(txtTSayisi.Text);
                ogr.TaksitTutar = Convert.ToDecimal(txtTTutari.Text);
                ogr.SınıfId = Convert.ToInt32(ddlSiniflar.SelectedValue);
                ent.Ogrencilers.Add(ogr);
                try
                {
                    ent.SaveChanges();
                    GetAllOgrencilerBySinifID(Convert.ToInt32(ddlSiniflar.SelectedValue));
                    btnKaydet.Enabled = false;
                    Temizle();
                    lblMesaj.Text = "Öğrenci Kaydedildi";
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                }
            }
        }

        private bool OgrenciKontrol()
        {
            int sayisi = (from o in ent.Ogrencilers
                          where o.Ad == txtAdi.Text && o.Soyad == txtSoyadi.Text
                          select o).ToList().Count();
            return Convert.ToBoolean(sayisi);
        }

        protected void btnDegistir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            //var degistir = ent.Ogrencilers.Where(o => o.Id == Convert.ToInt32(txtId.Text)).Select(o => o).First();
            var degistir = (from o in ent.Ogrencilers
                            where o.Id == id
                            select o).ToList().FirstOrDefault();
            degistir.Ad = txtAdi.Text;
            degistir.Soyad = txtSoyadi.Text;
            degistir.Telefon = txtTelefon.Text;
            degistir.Adres = txtAdres.Text;
            degistir.TC = txtTC.Text;
            degistir.TaksitSayısı = Convert.ToByte(txtTSayisi.Text);
            degistir.TaksitTutar = Convert.ToDecimal(txtTTutari.Text);
            degistir.SınıfId = Convert.ToInt32(ddlSiniflar.SelectedValue);
            try
            {
                ent.SaveChanges();
                lblMesaj.Text = "Öğrenci Bilgileri Değiştirildi.";
                GetAllOgrencilerBySinifID(Convert.ToInt32(ddlSiniflar.SelectedValue));
                Temizle();
                btnDegistir.Enabled = false;
                btnSil.Enabled = false;
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {

        }

        protected void gvOgrenciler_DataBound(object sender, EventArgs e)
        {
        }
    }
}