using System;
using System.Windows.Forms;

namespace TCKontrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sorgulaButtonClick(object sender, EventArgs e)
        {
            long kimlikNo = long.Parse(txtTC.Text);
            int yil = int.Parse(txtYil.Text);
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            bool durum;
            try
            {
                using (TcDogrula.KPSPublicSoapClient service = 
                    new TcDogrula.KPSPublicSoapClient { })
                {
                    durum = service.TCKimlikNoDogrula(kimlikNo, ad,
                        soyad, yil);
                }
            }
            catch (Exception)
            {

                throw;
            }
            if(durum == true)
            {
                MessageBox.Show($"{ad} {soyad} isminde birisi bulunmaktadir.");
            }
            else
            {
                MessageBox.Show("Boyle birisi yoktur");
            }
          
        }
    }
}
