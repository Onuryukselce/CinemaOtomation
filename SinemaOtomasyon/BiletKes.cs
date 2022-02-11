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
    
    public partial class BiletKes : Form
    {
        // Koltukları bool olarak tanımlıyorum
        private bool koltuk1;
        private bool koltuk2;
        private bool koltuk3;
        private bool koltuk4;
        private bool koltuk5;
        private bool koltuk6;
        private bool koltuk7;
        private bool koltuk8;
        private bool koltuk9;
        private bool koltuk10;
        private bool koltuk11;
        private bool koltuk12;
        private bool koltuk13;
        private bool koltuk14;
        private bool koltuk15;
        private bool koltuk16;
        private bool koltuk17;
        private bool koltuk18;
        private bool koltuk19;
        private bool koltuk20;
        private bool koltuk21;
        private bool koltuk22;
        private bool koltuk23;
        private bool koltuk24;
        private bool koltuk25;
        private bool koltuk26;
        private bool koltuk27;
        private bool koltuk28;
        private bool koltuk29;
        private bool koltuk30;


        public BiletKes()
        {
            InitializeComponent();
        }

        private List<int> DoluKoltuklar() // DoluKoltukları almak için bir fonksiyon oluşturdum
        {
            Bilet bilet = new Bilet(); // Bilet nesnesini tanımlıyorum
            List<int> koltuklar = new List<int>(); // koltuklar isimli int tipi bir lsite tnaımlıyorum
                DataTable biletler = bilet.BiletGoster(); // Biletleri alıyorum
            DataRow[] alinmiskoltuklar = biletler.Select("SeansNo = " + SeansNo.Seansno); // İçerisinden seansno eşleşenleri seçiyorum

            foreach(DataRow koltuk in alinmiskoltuklar) // row[] içinde geziyorum
            {
                int k = koltuk.Field<int>("KoltukNo"); // KoltukNo alanından veriyi alıyorum
                koltuklar.Add(k); // koltuklar isimli listeme ekliyorum
            }

            return koltuklar; // listemi donduruyorum
        }

        private void DoluKoltuklariBelirtveIsaretle()
        {
            List<int> koltuklar = DoluKoltuklar(); // koltuklar listemi buradaa çağırıyorum
            foreach(int i in koltuklar) // koltuklar listemin içinde gemeye başlıyorum
            {
                switch(i) // Her koltuğu kontrol edip dolu olanları kırmızı işaretleyip enabled = false yapıyorum.
                {
                    case 1:
                        koltuk1 = false;
                        checkBox1.BackColor = Color.Red;
                        checkBox1.Enabled = false;
                        break;
                    case 2:
                        koltuk2 = false;
                        checkBox2.BackColor = Color.Red;
                        checkBox2.Enabled = false;
                        break;
                    case 3:
                        koltuk3 = false;
                        checkBox3.BackColor = Color.Red;
                        checkBox3.Enabled = false;
                        break;
                    case 4:
                        koltuk4 = false;
                        checkBox4.BackColor = Color.Red;
                        checkBox4.Enabled = false;
                        break;
                    case 5:
                        koltuk5 = false;
                        checkBox5.BackColor = Color.Red;
                        checkBox5.Enabled = false;
                        break;
                    case 6:
                        koltuk6 = false;
                        checkBox6.BackColor = Color.Red;
                        checkBox6.Enabled = false;
                        break;
                    case 7:
                        koltuk7 = false;
                        checkBox7.BackColor = Color.Red;
                        checkBox7.Enabled = false;
                        break;
                    case 8:
                        koltuk8 = false;
                        checkBox8.BackColor = Color.Red;
                        checkBox8.Enabled = false;
                        break;
                    case 9:
                        koltuk9 = false;
                        checkBox9.BackColor = Color.Red;
                        checkBox9.Enabled = false;
                        break;
                    case 10:
                        koltuk10 = false;
                        checkBox10.BackColor = Color.Red;
                        checkBox10.Enabled = false;
                        break;
                    case 11:
                        koltuk11 = false;
                        checkBox11.BackColor = Color.Red;
                        checkBox11.Enabled = false;
                        break;
                    case 12:
                        koltuk12 = false;
                        checkBox12.BackColor = Color.Red;
                        checkBox12.Enabled = false;
                        break;
                    case 13:
                        koltuk13 = false;
                        checkBox13.BackColor = Color.Red;
                        checkBox13.Enabled = false;
                        break;
                    case 14:
                        koltuk14 = false;
                        checkBox14.BackColor = Color.Red;
                        checkBox14.Enabled = false;
                        break;
                    case 15:
                        koltuk15 = false;
                        checkBox15.BackColor = Color.Red;
                        checkBox15.Enabled = false;
                        break;
                    case 16:
                        koltuk16 = false;
                        checkBox16.BackColor = Color.Red;
                        checkBox16.Enabled = false;
                        break;
                    case 17:
                        koltuk17 = false;
                        checkBox17.BackColor = Color.Red;
                        checkBox17.Enabled = false;
                        break;
                    case 18:
                        koltuk18 = false;
                        checkBox19.BackColor = Color.Red;
                        checkBox19.Enabled = false;
                        break;
                    case 19:
                        koltuk19 = false;
                        checkBox19.BackColor = Color.Red;
                        checkBox19.Enabled = false;
                        break;
                    case 20:
                        koltuk20 = false;
                        checkBox20.BackColor = Color.Red;
                        checkBox20.Enabled = false;
                        break;
                    case 21:
                        koltuk21 = false;
                        checkBox21.BackColor = Color.Red;
                        checkBox21.Enabled = false;
                        break;
                    case 22:
                        koltuk22 = false;
                        checkBox22.BackColor = Color.Red;
                        checkBox22.Enabled = false;
                        break;
                    case 23:
                        koltuk23 = false;
                        checkBox23.BackColor = Color.Red;
                        checkBox23.Enabled = false;
                        break;
                    case 24:
                        koltuk24 = false;
                        checkBox24.BackColor = Color.Red;
                        checkBox24.Enabled = false;
                        break;
                    case 25:
                        koltuk25 = false;
                        checkBox25.BackColor = Color.Red;
                        checkBox25.Enabled = false;
                        break;
                    case 26:
                        koltuk26 = false;
                        checkBox26.BackColor = Color.Red;
                        checkBox26.Enabled = false;
                        break;
                    case 27:
                        koltuk27 = false;
                        checkBox27.BackColor = Color.Red;
                        checkBox27.Enabled = false;
                        break;
                    case 28:
                        koltuk28 = false;
                        checkBox28.BackColor = Color.Red;
                        checkBox28.Enabled = false;
                        break;
                    case 29:
                        koltuk29 = false;
                        checkBox29.BackColor = Color.Red;
                        checkBox29.Enabled = false;
                        break;
                    case 30:
                        koltuk30 = false;
                        checkBox30.BackColor = Color.Red;
                        checkBox30.Enabled = false;
                        break;





                }
            }
        }
        private void BiletEkle(int _seansNo, int _koltukNo, decimal _fiyat) // Bilet ekle fonksiyonumu tanımlıyorum
        {
            Bilet bilet = new Bilet(_seansNo, _koltukNo, _fiyat); // Bilet oluşturuyorum
            bilet.BiletEkle(); // Bileti ekliyorum
        }

        private List<int> secilikoltuklar = new List<int>(); // secili kotluklar için listemi tanımlıyorum
        
        private void generalCheckBoxEvent(object sender, EventArgs e) // Genel checkBox eventi tıklanan checkbox'ın arkasını yeşil yapıyor
        {
            CheckBox chx = (CheckBox)sender;
            if (chx.Checked == true)
            {
                chx.BackColor = Color.Chartreuse;
                secilikoltuklar.Add(Convert.ToInt32(chx.AccessibleName));
                
            }

            else
            {
                chx.BackColor = Color.LightGray;
                secilikoltuklar.Remove(Convert.ToInt32(chx.AccessibleName));
               /* for(int i = 0; i < secilikoltuklar.Count; i++)
                {
                    if(i == Convert.ToInt32(chx.AccessibleName))
                    {
                        secilikoltuklar.Remove()
                    }
                } */

            }

            label36.Text = "";
            foreach(int i in secilikoltuklar)
            {
                label36.Text += i.ToString() + ",";

            }


        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(int i in secilikoltuklar)
            {
                BiletEkle(SeansNo.Seansno, i, 10); //10 tl fiyatla bilet oluşturuyorum
            }

            MessageBox.Show("Bilet alım işlemi başarılı");
            DoluKoltuklariBelirtveIsaretle();
            label36.Text = "";
        }

        private void BiletKes_Load(object sender, EventArgs e)
        {
            DoluKoltuklariBelirtveIsaretle();
        }
    }
    public static class SeansNo
    {
        private static int _seansno;
        public static int Seansno
        {
            set { _seansno = value; }
            get { return _seansno; }
        }
    }
}
