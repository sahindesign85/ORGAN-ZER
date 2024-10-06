using DevExpress.LookAndFeel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ORGANİZER.Entity;
using DevExpress.Data.Linq.Helpers;


namespace ORGANİZER.Formlar
{
    public partial class FrmPersonelİstatistik : Form
    {
        public FrmPersonelİstatistik()
        {
            InitializeComponent();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        
        istakipEntities2 db = new istakipEntities2();
        private void FrmPersonelİstatistik_Load(object sender, EventArgs e)
        {
            LblToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();
            LblToplamPersonel.Text = db.TblPersonel.Count().ToString();
            LblToplamFirma.Text = db.TblFirmalar.Count().ToString();
            lblAktifİs.Text = db.TblGorevler.Count(x=> x.Durum=="1").ToString();
            lblPasifİs.Text = db.TblGorevler.Count(x => x.Durum == "0").ToString();
            lblSonGorev.Text = db.TblGorevler.OrderByDescending(x => x.ID).Select(x => x.Aciklama).FirstOrDefault();
            lblSehirSayisi.Text = db.TblFirmalar.Select(x => x.il).Distinct().Count().ToString();
            lblSektorSayisi.Text = db.TblFirmalar.Select(x => x.Sektör).Distinct().Count().ToString();
        }
    }
}
