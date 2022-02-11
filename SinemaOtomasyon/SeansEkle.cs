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
    public partial class SeansEkle : Form
    {
        public SeansEkle()
        {
            InitializeComponent();
        }
        private int SeansOlustur(int _salonNo, int _filmNo, string tarihsaat) // Seans ekleme fonksiyonum
        {
            Seans s = new Seans( _salonNo, _filmNo, tarihsaat); // Seans tanımlıyorum
            int sonuc = s.SeansEkle(); // Seans ekliyorum

            return sonuc; // sonucu dönüyorum
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty)
            {
               int sonuc = SeansOlustur(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox3.Text), textBox4.Text);
                if(sonuc > 0)
                {
                    MessageBox.Show("Seans Başarıyla Oluşturuldu");
                } else
                {
                    MessageBox.Show("Birşeyler ters gitti");

                }

            }
            else
            {
                MessageBox.Show("Tum alanlar doldurulmak zorundadır!");
            }
        }
    }
}
