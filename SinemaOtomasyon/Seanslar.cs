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
    public partial class Seanslar : Form
    {
        public Seanslar()
        {
            InitializeComponent();
        }

        private void Seanslar_Load(object sender, EventArgs e)
        {
            SeanslariGoster();
        }

        private void AfisYukle(string _filePath)
        {
            try
            {
                pictureBox1.Image = new Bitmap(_filePath);

            }
            catch (OutOfMemoryException ex) { MessageBox.Show("Filme ait afişin boyutu beklenenden büyük olduğu için gösterilemiyor"); }


        }

        private bool SecimVarMi() // seçili kolon olup olmadığını kontrol ediyorum
        {
            if (dataGridView1.SelectedRows.Count == 1) // Eğer bir seçili kolon varsaa true dön değilse false
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
            if (dataGridView1.SelectedRows.Count > 1) // Eğer çoklu seçim yapılmışsa true dön çoklu seçim yapılmamışsa false dön.
            { return true; }
            else
            {
                return false;
            }
        }

        private void TekliSecim() // Tekliseçim yapılırsa olacak olaylar
        {
            label3.Text = TekliSeciminSalonAdi(); // Salon Adını texte yaz
            label8.Text = TekliSeciminTarihSaat();
            label4.Text = "Salon : ";
            AfisYukle(TekliSeciminAfisYolu());
            panel1.Enabled = true; // Panel 1 yani güncellemeyi aç
            panel1.Visible = true; // Panel 1 'i görünür yap
            textBox1.Text = TekliSeciminSalonNo(); // Salon noyu textboxa yaz
            textBox3.Text = TekliSeciminFilmNo(); // Film noyu textboxa yaz
            textBox4.Text = TekliSeciminTarihSaat(); // TarihSaati yextboxa yaz

            label6.Text = dataGridView1.SelectedRows.Count.ToString(); // Seçim sayısını yaz
        }

        private void Coklusecim() // Çoklu seçim ypaılırsa olacak olaylar
        {
            label4.Text = "Çoklu Seçim"; // Text'e çoklu seçim yaz
            label3.Text = "";
            label8.Text = "";
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

        private string TekliSeciminFilmAdi() // Tekli seçimde film adını yakalayan fonksiyon
        {
            DataGridViewRow secim = TekliSecimiYakala(); // Teklisecim rowunu yakalıyorum
            string a = Convert.ToString(secim.Cells["FilmAdi"].Value); // İçerisindeki kolonu okuyorum

            return a; // Veriyi dönüyorum
        }

       
       
        private string TekliSeciminAfisYolu()
        {
            DataGridViewRow secim = TekliSecimiYakala(); // Teklisecim rowunu yakalıyorum
            string a = Convert.ToString(secim.Cells["AfisYolu"].Value); // İçerisindeki kolonu okuyorum

            return a; // Veriyi dönüyorum
        }

        private string TekliSeciminFilmNo() // Tekli seçimde film no yakalayan fonksiyon
        {
            DataGridViewRow secim = TekliSecimiYakala(); // Tekli seçimi yakalıyorum
            string a = Convert.ToString(secim.Cells["FilmNo"].Value); // İçerisindeki kolonu okuuyorum

            return a; // Veriyi dönüyorum
        }

        private string TekliSeciminTarihSaat() //Tekli seçimde  ttarih saat yakalayan fonksiyon
        {
            DataGridViewRow secim = TekliSecimiYakala(); // Tekli seçimi yakalıyorum
            string a = Convert.ToString(secim.Cells["SeansTarihSaat"].Value); // İçerisindeki kolonu okuuyorum

            return a; // Veriyi dönüyorum
        }

        private string TekliSeciminSeansno() //Tekli seçimde  seansno yakalayan fonksiyon
        {
            DataGridViewRow secim = TekliSecimiYakala(); // Tekli seçimi yakalıyorum
            string a = Convert.ToString(secim.Cells["SeansNo"].Value); // İçerisindeki kolonu okuuyorum

            return a; // Veriyi dönüyorum
        }
        public void SeanslariGoster() // Salonları datagridview'e atacak fonksiyonum bu
        {
            Salon Salon = new Salon(); // Salon tanımlıyorum
            Film film = new Film(); // Film Tanımlıyorum
            Seans seans = new Seans(); // Seans tanımlıyorum

            DataTable a = Salon.SalonGoster(); // SalonGoster fonksiyonumu çağırıyorum
            DataTable b = film.FilmGoster(); // FilmGoster fonksiyonumu çağırıyorum
            DataTable c = seans.SeansGoster(); // Seans göster fonksiyonumu tanımlıyorum

            DataTable Hepsi = new DataTable(); // İki datayı joinleyeceğim tabloyu oluştruyuorum

            // Bu üç datayı birleştirmek istiyorum o yüzden Hepsi adlı bir tablo açıp kolonlarını belirliyorum
            Hepsi.Columns.Add("SeansNo", typeof(int));
            Hepsi.Columns.Add("SalonNo", typeof(int));
            Hepsi.Columns.Add("SalonAdi", typeof(string));
            Hepsi.Columns.Add("FilmNo", typeof(int));
            Hepsi.Columns.Add("FilmAdi", typeof(string));
            Hepsi.Columns.Add("SeansTarihSaat", typeof(DateTime));
            Hepsi.Columns.Add("AfisYolu", typeof(string));

            //Aşağıda bir linq sorgusu çalıştırıp 3 tabloyu birleştirip uygun verileri alacağım
            var sorgu = from dr1 in c.AsEnumerable()
                            join dr2 in b.AsEnumerable() on dr1.Field<int>("FilmNo") equals
      dr2.Field<int>("FilmNo")
                            join dr3 in a.AsEnumerable() on dr1.Field<int>("SalonNo") equals 
                            dr3.Field<int>("SalonNo")
                            select new
                            {
                                SeansNo = dr1.Field<int>("SeansNo"),
                                SalonNo = dr3.Field<int>("SalonNo"),
                                SalonAdi = dr3.Field<string>("SalonAdi"),
                                FilmNo = dr2.Field<int>("FilmNo"),
                                FilmAdi = dr2.Field<string>("FilmAdi"),
                                Afisyolu = dr2.Field<string>("AfisYolu"),
                                SeansTarihSaat = dr1.Field<DateTime>("SeansTarihSaat")
                            };

            foreach (var x in sorgu) // Verileri tabloya yüklüyorum
            {
                DataRow addedRow = Hepsi.Rows.Add();
                addedRow.SetField("SeansNo", x.SeansNo);
                addedRow.SetField("SalonNo", x.SalonNo);
                addedRow.SetField("SalonAdi", x.SalonAdi);
                addedRow.SetField("FilmNo", x.FilmNo);
                addedRow.SetField("FilmAdi", x.FilmAdi);
                addedRow.SetField("AfisYolu", x.Afisyolu);
                addedRow.SetField("SeansTarihSaat", x.SeansTarihSaat);
            }

            dataGridView1.AutoGenerateColumns = true; // Kolonları otomatik oluşturmasını istiyorum
            dataGridView1.DataSource = Hepsi; // Data kaynağı alarak Hepsi seçiyorum
            dataGridView1.Columns["AfisYolu"].Visible = false; // AfisYolu kolonunun gözükmesini istemiyorum
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

        private int SeciliSeanslariSil() // secili seansları sildiğmi fonksiyonum
        {
            int toplamSilinen = 0; // Toplamsilinen'i kaydetmek istiyorum
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows) // Seçim yapılmış rowların içinde dönüyorum
            {
                string seanstring = Convert.ToString(item.Cells["SeansNo"].Value); // SeansNo stringini alıyorum
                int seansNo = Convert.ToInt32(seanstring); // stringi inte çeviriyorum
                Seans s = new Seans(); // seans nesnesi yaratıyorum
                s.SeansNo = seansNo; // seansno'nu kolondan aldığım veriye eşitliyorum
                toplamSilinen += s.SeansSil(); // filmi siliyorum


                dataGridView1.Rows.RemoveAt(item.Index); // Fimleri tablodan da siliyorum
            }




            return toplamSilinen; // Toplam silineni dönüyorum
        }

        private int SeansGuncelle(int _seansNo, int _salonNo, int _filmNo, string tarihsaat) // Seans guncelleme fonksiyonum
        {
            Seans s = new Seans(_seansNo, _salonNo, _filmNo, tarihsaat); // Seans tanımlıyorum
            int sonuc = s.SeansDegistir(); // Seans değiştiriyorum

            return sonuc; // sonucu dönüyorum
        }

        public int SeansSec()
        {
            int seansNo = Convert.ToInt32(TekliSeciminSeansno());

            return seansNo;
        }
        
    private void button1_Click(object sender, EventArgs e)
        {
            DialogResult sil = MessageBox.Show(label6.Text + " Adet filmi silmek istediğinize emin misiniz ?", "Silme işlemi", MessageBoxButtons.YesNo); // Silmek için onay istiyorum
            if (sil == DialogResult.Yes) // Eğer evete basılırsa salonları siliyorum.
            {
                SeciliSeanslariSil();
                SeanslariGoster(); // Tabloyu refreshliyorum
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty)
            {
                SeansGuncelle(Convert.ToInt32(TekliSeciminSeansno()), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox3.Text), textBox4.Text);
                SeanslariGoster();
            } else
            {
                MessageBox.Show("Tum alanlar doldurulmak zorundadır!");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BiletKes bk = new BiletKes();
            SeansNo.Seansno = SeansSec();
            bk.Show();
            
        }
    }
}
