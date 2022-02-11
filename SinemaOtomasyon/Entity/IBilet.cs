using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SinemaOtomasyon.Entity
{
    interface IBilet // Bilet sınıfım için yol gösterecek arayüz
    {
        int BiletEkle(); // Bilet ekleyeceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım
        int BiletDegistir();  // Bilet değiştireceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım
        int BiletSil(); // Bilet sileceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım
        DataTable BiletGoster(); // Bilet göstereceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım
    }
}
