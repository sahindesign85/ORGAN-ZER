using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.XtraEditors;
using ORGANİZER.Entity; // entity framework'ün çaışabilmesi için

namespace ORGANİZER.Formlar
{
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
            
        }

        istakipEntities2 db = new istakipEntities2(); //iş takip veritabanı sınıfının çalışabilmesi için instance (örnek alma sınıftan)

        void Personeller() //personel listelemek için method üretme
        {

            var degerler = from x in db.TblPersonel // tbl personel tablosundaki değerleri gridcontol dataviewinde listelemek için
                           select new
                           {
                               x.ID,
                               x.Ad,
                               x.Soyad,
                               x.Mail,
                               x.Telefon,
                               x.Görsel,
                               
                               Departman = x.TblDepartmanlar.Ad, //bunun farklı olmasının sebebi Personelde ID numara olarak görülen
                                                                 //departman kodunun veritabanında tbl departman tablosundan alınıp ismiyle
                                                                 //görünmesi için

                               x.Durum // Eğer model oluşturulduktan sonra veritabanında bir değişiklik olursa model klasöründeki model1.edmx
                               //dosyası açılıpsağ tıklayıp updatee database denilir. Durum sütuunda bu yaşandı.

                            };

            gridControl1.DataSource = degerler.Where(x=>x.Durum==true).ToList(); //gridcontrol1 (devexpress datagöstericisi) için göstereceği tabloyu işaret etmek için. 
            // yukarıdaki degerler listesinden alıyor veriyi. Ekstra olarak işten çıkanlar tabloda görülmesin diye false değeri döndürenler where komutuyla listeden çıkarıldı.
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Personeller(); // listele butonuna basıldığında  yukarda yaratılan personeller methodu çalıştırılıyor. 

        }

        private void FrmPersonel_Load(object sender, EventArgs e)

        {
            
            Personeller();


            var departmanlar = (from x in db.TblDepartmanlar
            select new
            {
                x.ID,
                x.Ad,
                
            }).ToList();
            
            // devexpress aracı olan lookupedit'in içindeki ID değeri TBLdepartmanlardaki Adlarla değiştirmek için başlangıç
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.DataSource = departmanlar;
            // devexpress aracı olan lookupedit'in içindeki ID değeri TBLdepartmanlardaki Adlarla değiştirmek için bitiş

            lookUpEdit1.Text = "Atanmadı";
            db.SaveChanges();


        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblPersonel t = new TblPersonel();
            t.Ad = txtAD.Text;
            t.Soyad= txtSoyadP.Text;
            t.Mail = txtMail.Text;
            t.Görsel = txtGorsel.Text;
            t.Telefon = txtTelefon.Text;

            if (lookUpEdit1.Text == "Atanmadı")
            {
                MessageBox.Show("Departman eklemediniz");
                return;
            }

            else
            {
                t.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            }
           
            bool durum = true;
            t.Durum = durum;

            db.TblPersonel.Add(t);
            XtraMessageBox.Show("Yeni personel kaydı başarılı bir şekilde gerçekleşti", 
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            db.SaveChanges();
            
            //bütün textboxları sıfırla. kursta yok başlangıç
            txtAD.Text = "";
            txtSoyadP.Text = "";
            txtMail.Text = "";
            txtGorsel.Text = "";
            txtTelefon.Text = "";
            

            lookUpEdit1.Text = "Atanmadı";
            //bütün textboxları sıfırla. kursta yok bitiş

            Personeller();



        }



        private void BtnSil_Click(object sender, EventArgs e)
        {
            var x = int.Parse (txtID.Text); //ID tekstteki değeri x değerine aktar
            var deger = db.TblPersonel.Find(x); // tbl Personel tablosunda x değişkeni yani id'nin konumunu ve doğal olarak satırını bulup deger değişkenine atamak için
            deger.Durum = false; // degerin bulunduğu satırdaki deger durum değişkenini false yapıyor. Veritabanından silmek
            // yerine false yapıldığında ileriye yönelik hatalar giderilmiş oluyor. ilerde silinen personelin listelendiği ayrı bir sayfa yapılacaak.
            db.SaveChanges(); //değişilikleri datagride yansıtmak için
            XtraMessageBox.Show("Personel başarılı bir şekilde silindi. Silinmiş personel listesinden ayrılan personellere ulaşabilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Personeller();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAD.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            txtSoyadP.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            txtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            txtTelefon.Text = gridView1.GetFocusedRowCellValue("Telefon").ToString();
            txtGorsel.Text = gridView1.GetFocusedRowCellValue("Görsel").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Departman").ToString();
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text);
            var deger =db.TblPersonel.Find(x);
            deger.Ad = txtAD.Text;
            deger.Soyad = txtSoyadP.Text;
            deger.Mail = txtMail.Text;
            deger.Telefon = txtTelefon.Text;
            deger.Görsel = txtGorsel.Text;
            deger.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            XtraMessageBox.Show("Personel başarılı bir şekilde güncellendi. ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Personeller();
        }
    }
}
