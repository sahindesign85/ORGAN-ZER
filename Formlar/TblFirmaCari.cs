using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ORGANİZER.Entity;


namespace ORGANİZER.Formlar
{
    public partial class FrmFirmaCari : Form
    {

        istakipEntities2 db = new istakipEntities2();
        public FrmFirmaCari()
        {
            InitializeComponent();
        }

        void Listele()
        {

            var degerler = (from x in db.TblFirmaCari
                            select new
                            {
                                x.ID,
                                x.Unvan,
                                x.Adres,
                                x.Telefon,
                                x.YetkiliKisi,
                                x.VergiDairesi,
                                x.VergiKimlikNo,

                            }).ToList();
            gridControl1.DataSource = degerler;
        }

        private void TblFirmaCari_Load(object sender, EventArgs e)
        {
            Listele();
            txtID.Enabled = false;

            txtUnvan.Text = "";
            txtAdres.Text = "";
            txtYetkiliKisi.Text = "";
            txtTelefon.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiKimlikNo.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtUnvan.Text = gridView1.GetFocusedRowCellValue("Unvan").ToString();
            txtAdres.Text = gridView1.GetFocusedRowCellValue("Adres").ToString();
            txtYetkiliKisi.Text = gridView1.GetFocusedRowCellValue("YetkiliKisi").ToString();
            txtTelefon.Text = gridView1.GetFocusedRowCellValue("Telefon").ToString();
            txtVergiDairesi.Text = gridView1.GetFocusedRowCellValue("VergiDairesi").ToString();
            txtVergiKimlikNo.Text = gridView1.GetFocusedRowCellValue("VergiKimlikNo").ToString();

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblFirmaCari t = new TblFirmaCari();
            t.Unvan = txtUnvan.Text;
            t.Adres = txtAdres.Text;
            t.YetkiliKisi = txtYetkiliKisi.Text;
            t.Telefon = txtTelefon.Text;
            t.VergiDairesi = txtVergiDairesi.Text;
            t.VergiKimlikNo = txtVergiKimlikNo.Text;

            db.TblFirmaCari.Add(t);
            XtraMessageBox.Show("Yeni Firma cari kaydı başarılı bir şekilde gerçekleşti",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            db.SaveChanges();

            //bütün textboxları sıfırla. kursta yok başlangıç
            txtUnvan.Text = "";
            txtAdres.Text = "";
            txtYetkiliKisi.Text = "";
            txtTelefon.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiKimlikNo.Text = "";

            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var x = int.Parse(txtID.Text); //ID tekstteki değeri x değerine aktar
            var deger = db.TblFirmaCari.Find(x); // tbl Personel tablosunda x değişkeni yani id'nin konumunu ve doğal olarak satırını bulup deger değişkenine atamak için
            db.TblFirmaCari .Remove(deger);
            
            db.SaveChanges(); //değişilikleri datagride yansıtmak için
            XtraMessageBox.Show(txtID, "Firma bilgileri başarılı bir şekilde silindi. Silinmiş personel listesinden ayrılan personellere ulaşabilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();  


        }
    }
}
