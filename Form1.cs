using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ORGANİZER
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmDepartmanlar frm = new Formlar.FrmDepartmanlar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnPersonelListesi2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Formlar.FrmPersonel frm =new Formlar.FrmPersonel();
            frm.MdiParent = this;
            frm.Show();
        }

        private void BtnPersonelİstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Formlar.FrmPersonelİstatistik frm3 = new Formlar.FrmPersonelİstatistik();
            frm3.MdiParent = this;
            frm3.Show();
        }

        private void BtnFirmaCari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Formlar.FrmFirmaCari frm4 = new Formlar.FrmFirmaCari();
            frm4.MdiParent = this;
            frm4.Show();
        }
    }
}
