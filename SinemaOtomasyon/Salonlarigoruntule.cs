using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SinemaOtomasyon.Entity;
namespace SinemaOtomasyon
{
    public partial class Salonlarigoruntule : Form
    {
        public Salonlarigoruntule()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private bool SecimVarMi() // seçili kolon olup olmadığın ıkontrol ediyorum
        {
            if(dataGridView1.SelectedRows.Count == 1) // Eğer bir seçili kolon varsaa true dön değilse false
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private bool CokluSecimYapilmisMi() // Coklu seçimi kontrol ediyorum
        {
            if(dataGridView1.SelectedRows.Count > 1) // Eğer çoklu seçim yapılmışsa true dön çoklu seçim yapılmamışsa false dön.
            { return true; }
            else
            {
                return false;
            }
        }

        private void TekliSecim() // Tekliseçim yapılırsa olacak olaylar
        {
            label4.Text = TekliSeciminSalonAdi(); // Salon Adını texte yaz
            panel1.Enabled = true; // Panel 1 yani güncellemeyi aç
            panel1.Visible = true; // Panel 1 'i görünür yap
            textBox1.Text = TekliSeciminSalonAdi(); // Salon ADını textboxa yaz
            label6.Text = dataGridView1.SelectedRows.Count.ToString(); // Seçim sayısını yaz
        }

        private void Coklusecim() // Çoklu seçim ypaılırsa olacak olaylar
        {
            label4.Text = "Çoklu Seçim"; // Text'e çoklu seçim yaz
            panel1.Enabled = false; // Panel yani güncellemeyi kapa
            label6.Text = dataGridView1.SelectedRows.Count.ToString(); // Seçili satır sayısını yaz
        }

        private DataGridViewRow TekliSecimiYakala() // Tekli seçimi yakalayan fonksiyonum
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex; // seçili hücrelerin rowindexini alıyorum
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex]; //  bu index ile  row seçiyorum

            return selectedRow; // rowu döndürüyorum
        }

        private string TekliSeciminSalonAdi() // Tekli seçimde salon adını yakalayan fonksiyon
        {
            DataGridViewRow secim = TekliSecimiYakala(); // Teklisecim rowunu yakalıyorum
            string a = Convert.ToString(secim.Cells["SalonAdi"].Value); // İçerisindeki kolonu okuyorum

            return a; // Veriyi dönüyorum
        }

        private string TekliSeciminSalonNo() // Tekli seçimde salon no yakalayan fonksiyon
        {
            DataGridViewRow secim = TekliSecimiYakala(); // Tekli seçimi yakalıyorum
            string a = Convert.ToString(secim.Cells["SalonNo"].Value); // İçerisindeki kolonu okuuyorum

            return a; // Veriyi dönüyorum
        }
        private void SalonlariGoster() // Salonları datagridview'e atacak fonksiyonum bu
        {
            Salon MainSalon = new Salon(); // Salon tanımlıyorum

            DataTable a = MainSalon.SalonGoster(); // SalonGoster fonksiyonumu çağırıyorum
            dataGridView1.AutoGenerateColumns = true; // Kolonları otomatik oluşturmasını istiyorum
            dataGridView1.DataSource = a; // Data kaynağı alarak SalonGoster fonksiyonumdan dönen a tablosunu gösteriyorum
        }
        private void Salonlarigoruntule_Load(object sender, EventArgs e)
        {
            SalonlariGoster(); // Form çalıştığında veriler gelsin istiyorum
         }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (CokluSecimYapilmisMi() == true) // Çoklu seçim yapılmışsa CokluSecim eventi çalışıyor
            {
                Coklusecim();
            }

            if (SecimVarMi() == true) // Tekli seçim var mı diye kontrol ediyorum varsa TekliSecim eventi çalışıyor
                TekliSecim();
        }

        private int SeciliSalonlariSil() // Toplu silme fonksiyonum burada
        {
            int toplamSilinen = 0; // Toplamsilinen'i kaydetmek istiyorum
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows) // Seçim yapılmış rowların içinde dönüyorum
            {
                string salonstring = Convert.ToString(item.Cells["SalonNo"].Value); // salonno stringini alıyorum
                int salonNo = Convert.ToInt32(salonstring); // stringi inte çeviriyorum
                Salon s = new Salon(); // salon nesnesi yaratıyorum
                s.SalonNo = salonNo; // salonNo'nu kolondan aldığım veriye eşitliyorum
                toplamSilinen += s.SalonSil(); // salonu siliyorum

               
                dataGridView1.Rows.RemoveAt(item.Index); // Salonları tablodan da siliyorum
            }




            return toplamSilinen; // Toplam silineni dönüyorum
        }

        private int seciliSalonIDAl() // Seçili salonun id'sini almak için bu fonksiyonu kullanıyorum
        {
            int salonNo = 0; // döneceğim salonNo yu 0 yapıyorum
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows) // Seçili salonların içinde dönüyorum
            {
                string salonstring = Convert.ToString(item.Cells["SalonNo"].Value); // SalonNo hücresinden value çekiyorum
               salonNo = Convert.ToInt32(salonstring); // çektiğim veriyi int'e cast ediyorum
                

                
            }

            return salonNo; // veriyi dönüyorum
        }


        private int SalonEkle(string _salonAdi) // Salon ekleme fonksiyonum
        {
            Salon salon = new Salon(_salonAdi); // salon tanımlıyorum
            int sonuc = salon.SalonEkle(); // salonu ekliyorum
            return sonuc; // sonucu donuyorum
        }

        private int SalonDuzenle(int _salonNo, string _salonAdi) // Salon düzenleme fonksiyonum
        {
            Salon salon = new Salon(_salonNo,_salonAdi); // yeni bir salon nesnesi yaratıoyur
            int sonuc = salon.SalonDegistir(); // Update ediyorum
            return sonuc; // Sonucu donuyorum
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            DialogResult sil = MessageBox.Show(label6.Text + " Adet salonu silmek istediğinize emin misiniz ?", "Silme işlemi", MessageBoxButtons.YesNo); // Silmek için onay istiyorum
            if(sil == DialogResult.Yes) // Eğer evete basılırsa salonları siliyorum.
            {
                SeciliSalonlariSil();
                SalonlariGoster(); // Tabloyu refreshliyorum
            }
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != string.Empty) // Eğer textBox boş değilse textBoxtaki isimle bir salon ekliyorum
            {
                SalonEkle(textBox2.Text); // Salon ekliyorum
                SalonlariGoster(); // Tabloyu yeniliyorum
            } else
            {
                MessageBox.Show("Salon ismi boş olamaz!"); // Salon ismi boş bırakılmışsa uyarı veriyorum
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int seciliSalonNo = seciliSalonIDAl(); // Seçili salonun idsini alıyorum
            if(textBox1.Text != string.Empty) // Eğer textbox boş değilse
            {
                SalonDuzenle(seciliSalonNo, textBox1.Text); // Salon adını değiştiriyorum
                SalonlariGoster(); // Tabloyu yeniliyorum
            }
            

        }
    }
}
