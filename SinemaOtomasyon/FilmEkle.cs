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
    public partial class FilmEkle : Form
    {
        public FilmEkle()
        {
            InitializeComponent();
        }

        private void FilmEkle_Load(object sender, EventArgs e)
        {

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

        private void AfisYukle(string _filePath)
        {
            try
            {
                pictureBox1.Image = new Bitmap(_filePath);

            }
            catch (OutOfMemoryException ex) 
            { MessageBox.Show("Filme ait afişin boyutu beklenenden büyük olduğu için gösterilemiyor Hata : " + ex.Message); }


        }
        private int FilmOlustur(string _filmAdi,string _filmTuru, string _Yonetmen, string _afisYolu) // film ekleme fonksiyonum
        {
            Film film = new Film(_filmAdi, _filmTuru, _Yonetmen, _afisYolu); // film tanımlıyorum
            int sonuc = film.FilmEkle(); // film ekliyorum
            return sonuc; // sonucu donuyorum
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty)
            {
                FilmOlustur(textBox1.Text, textBox3.Text, textBox4.Text, textBox2.Text);
                AfisYukle(textBox2.Text);
                MessageBox.Show("Film başarıyla eklendi");
            }
            else
            {
                MessageBox.Show("Alanlar boş olamaz!");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = AfisDegistir();
        }
    }
}
