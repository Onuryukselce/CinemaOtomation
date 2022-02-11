using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace SinemaOtomasyon.Data
{
    static class Baglanti // Veritabani ile baglanti kurmak icin bu sinifi kullanacağım
    {
        public static string yol = @"D:\veritabani.mdb"; // veritabani yolum
        public static OleDbConnection dbBaglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + "'" + yol + "'"); //Baglanti stringim
        public static OleDbCommand dbKomut = new OleDbCommand(); //Sorgu komut nesnem
    }
}
