using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace SinemaOtomasyon.Entity
{
    interface ISalon // Salon sınıfı için bir arayüz oluşturuyorum buradaki metotlar bana sınıfı yazarken yol gösterecek
    {
        int SalonEkle(); // Salon ekleyeceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım
        int SalonSil(); // Salon sileceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım
        int SalonDegistir(); // Salon değiştireceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım

        DataTable SalonGoster(); // Salon göstereceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım.
    }
}
