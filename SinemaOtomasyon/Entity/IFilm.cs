using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SinemaOtomasyon.Entity
{
    interface IFilm //Film sınıfı için bir arayüz oluşturuyorum buradaki metotlar sınıfı yazarken bana yol gösterecek
    {
        int FilmEkle(); // Filmi ekleyeceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım
        int FilmSil(); // Filmi sileceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım
        int FilmDegistir(); // Filmi değiştireceğim fonksiyon bu. Akabinde int ile Data layerdan gelen etkilenen sorgu sayısını basacağım
        DataTable FilmGoster();// Filmi göstereceğim fonksiyon bu. 
    }
}
