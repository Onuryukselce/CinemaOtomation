using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SinemaOtomasyon.Entity
{
    interface ISeans // Seans isimli bir arayüz oluşturuyorum Seans sınıfını yazarken bana yol gösterecek
    {
        int SeansEkle(); // Seans ekleyeceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım
        int SeansSil(); // Seans sileceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım
        int SeansDegistir(); // Seans değiştireceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım
        DataTable SeansGoster(); // Seans göstereceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım
       
        // DataTable FilmSalonGoster(); // Filme göre salon göstereceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım.

    }
}
