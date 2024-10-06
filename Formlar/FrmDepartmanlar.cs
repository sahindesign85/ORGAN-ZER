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
using System.Data.Entity;
using ORGANİZER.Entity;


namespace ORGANİZER.Formlar
{
    public partial class FrmDepartmanlar : Form
    {
        public FrmDepartmanlar()
        {
            InitializeComponent();
        }

        istakipEntities2 db = new istakipEntities2();
        void Listele()
        {

            var degerler = (from x in db.TblDepartmanlar
                            select new
                            {
                                x.ID,
                                x.Ad

                            }).ToList();
            gridControl1.DataSource = degerler;
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblDepartmanlar t = new TblDepartmanlar();
            t.Ad = txtAD.Text;
            db.TblDepartmanlar.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Departman başarılı bir şekilde sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(txtID.Text); // önce x adında bir integer yaratıyor. sonra İdnin texboxındaki rakamı x değerine girdiriyor.
                var deger = db.TblDepartmanlar.Find(x); //bütün tabloda texboxtan gelen x değerini bulup o satırı seciyor. ve değer değişkenine atıyor.
                db.TblDepartmanlar.Remove(deger); // departmanlar tableindaki değere atanmış ıdnin bulunduğu satırı siliyor
                db.SaveChanges(); // Değişikliklerin datagridviewde görüntülenmesini sağlıyor.
                XtraMessageBox.Show("Departman silme işlemi başarılı bir şeki" +
                    "lde gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Listele();
            }
            catch (Exception)
            {

                MessageBox.Show("Beklenmeyen bir hata oluştu. Lütfendaha sonra tekrar deneyiniz.");
            }
            

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAD.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text); // önce x adında bir integer yaratıyor. sonra İdnin texboxındaki rakamı x değerine girdiriyor.
            var deger = db.TblDepartmanlar.Find(x); //bütün tabloda texboxtan gelen x değerini bulup o satırı seciyor. ve değer değişkenine atıyor.
            deger.Ad = txtAD.Text;
           
            db.SaveChanges(); // Değişikliklerin datagridviewde görüntülenmesini sağlıyor.
            XtraMessageBox.Show("Departman güncelleme işlemi başarılı bir şeki" +
                "lde gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Listele();
        }

        private void FrmDepartmanlar_Load(object sender, EventArgs e)
        {
            Listele();
        }


    }
}
