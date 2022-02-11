using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SinemaOtomasyon.Entity;
namespace SinemaOtomasyon
{
    public partial class FilmMenu : Form
    {
        public FilmMenu()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool SecimVarMi() // seçili kolon olup olmadığın ıkontrol ediyorum
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

        private void AfisYukle(string _filePath)
        {
            try
            {
                pictureBox1.Image = new Bitmap(_filePath);

            } catch(OutOfMemoryException ex){ MessageBox.Show("Filme ait afişin boyutu beklenenden büyük olduğu için gösterilemiyor"); }


        }

        private void TekliSecim() // Tekliseçim yapılırsa olacak olaylar
        {
            label4.Text = TekliSeciminFilmAdi(); // Film Adını texte yaz
            string filmYolu = TekliSeciminAfisYolu();
            AfisYukle(filmYolu);
            panel1.Enabled = true; // Panel 1 yani güncellemeyi aç
            panel1.Visible = true; // Panel 1 'i görünür yap
            textBox1.Text = TekliSeciminFilmAdi(); // Film ADını textboxa yaz
            textBox3.Text = TekliSeciminFilmTuru(); // Film Turunu TextBoxa yaz
            textBox4.Text = TekliSeciminYonetmeni(); // Filmin yönetmenini yaz
            textBox2.Text = TekliSeciminAfisYolu();
            label7.Text = dataGridView1.SelectedRows.Count.ToString(); // Seçim sayısını yaz
        }

        private void Coklusecim() // Çoklu seçim ypaılırsa olacak olaylar
        {
            label4.Text = "Çoklu Seçim"; // Text'e çoklu seçim yaz
            panel1.Enabled = false; // Panel yani güncellemeyi kapa
            label7.Text = dataGridView1.SelectedRows.Count.ToString(); // Seçili satır sayısını yaz
        }

        private DataGridViewRow TekliSecimiYakala() // Tekli seçimi yakalayan fonksiyonum
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex; // seçili hücrelerin rowindexini alıyorum
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex]; //  bu index ile  row seçiyorum

            return selectedRow; // rowu döndürüyorum
        }

        private string TekliSeciminFilmAdi() // Tekli seçimde film adını yakalayan fonksiyon
        {
            DataGridViewRow secim = TekliSecimiYakala(); // Teklisecim rowunu yakalıyorum
            string a = Convert.ToString(secim.Cells["FilmAdi"].Value); // İçerisindeki kolonu okuyorum

            return a; // Veriyi dönüyorum
        }

        private string TekliSeciminFilmTuru()
        {
            DataGridViewRow secim = TekliSecimiYakala(); // Teklisecim rowunu yakalıyorum
            string a = Convert.ToString(secim.Cells["FilmTuru"].Value); // İçerisindeki kolonu okuyorum

            return a; // Veriyi dönüyorum
        }

        private string TekliSeciminYonetmeni()
        {
            DataGridViewRow secim = TekliSecimiYakala(); // Teklisecim rowunu yakalıyorum
            string a = Convert.ToString(secim.Cells["Yonetmen"].Value); // İçerisindeki kolonu okuyorum

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

        private void FilmGoster()
        {
            Film filmler = new Film();

            DataTable a = filmler.FilmGoster();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = a;
        }

        private int FilmDuzenle(int _filmNo, string _filmAdi, string _filmTuru, string _Yonetmen, string _afisYolu) // Salon düzenleme fonksiyonum
        {
            Film film = new Film(_filmNo,_filmAdi, _filmTuru, _Yonetmen, _afisYolu); // yeni bir salon nesnesi yaratıoyur
            int sonuc = film.FilmDegistir(); // Update ediyorum
            return sonuc; // Sonucu donuyorum
        }

        private int FilmEkle(string _filmAdi, string _filmTuru, string _Yonetmen, string _afisYolu) // Film ekleme fonksiyonu
        {
            Film film = new Film(_filmAdi,_filmTuru, _Yonetmen, _afisYolu); // flm oluşturuyorum
            int sonuc = film.FilmEkle(); // Ekliyorum
            return sonuc; // Sonucu donuyorum
        }

        private int FilmSil(int _filmNo) // Filmsil fonksiyonu
        {
            Film film = new Film(); // Film oluşturuyorum
           film.FilmNo = _filmNo; //filmnoyu yazıyorum
            int sonuc = film.FilmSil();//siliyorum
            return sonuc; // sonucu donuyorum
        }
        private void FilmMenu_Load(object sender, EventArgs e)
        {
            FilmGoster();
        }

        private int SeciliFilmleriSil() // Toplu silme fonksiyonum burada
        {
            int toplamSilinen = 0; // Toplamsilinen'i kaydetmek istiyorum
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows) // Seçim yapılmış rowların içinde dönüyorum
            {
                string filmstring = Convert.ToString(item.Cells["FilmNo"].Value); // filmno stringini alıyorum
                int filmNo = Convert.ToInt32(filmstring); // stringi inte çeviriyorum
                Film f = new Film(); // film nesnesi yaratıyorum
                f.FilmNo = filmNo; // filmno'nu kolondan aldığım veriye eşitliyorum
                toplamSilinen += f.FilmSil(); // filmi siliyorum


                dataGridView1.Rows.RemoveAt(item.Index); // Fimleri tablodan da siliyorum
            }




            return toplamSilinen; // Toplam silineni dönüyorum
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult sil = MessageBox.Show(label7.Text + " Adet filmi silmek istediğinize emin misiniz ?", "Silme işlemi", MessageBoxButtons.YesNo); // Silmek için onay istiyorum
            if (sil == DialogResult.Yes) // Eğer evete basılırsa salonları siliyorum.
            {
                SeciliFilmleriSil();
                FilmGoster(); // Tabloyu refreshliyorum
            }
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

        private string AfisDegistir()
        {
            string fullPath = "";
            OpenFileDialog fg = new OpenFileDialog();
            fg.Filter = "Imaj Dosyalari (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (fg.ShowDialog() == DialogResult.OK)
            {
                string DosyaYolu = fg.FileName;


                fullPath = DosyaYolu;
            }

            return fullPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty)
            {
                FilmDuzenle(Convert.ToInt32(TekliSeciminFilmNo()),textBox1.Text,  textBox3.Text, textBox4.Text , textBox2.Text);
                FilmGoster();
            } else
            {
                MessageBox.Show("Alanlar boş olamaz!");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           textBox2.Text = AfisDegistir();
        }
    }
}
