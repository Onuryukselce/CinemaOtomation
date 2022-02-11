using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaOtomasyon
{
    public partial class Anamenu : Form
    {
        public Anamenu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Salonlarigoruntule sg = new Salonlarigoruntule();
            sg.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FilmMenu fm = new FilmMenu();
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FilmEkle fe = new FilmEkle();
            fe.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Seanslar s = new Seanslar();
            s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SeansEkle se = new SeansEkle();
            se.Show();
                
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
