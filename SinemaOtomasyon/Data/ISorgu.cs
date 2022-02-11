using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SinemaOtomasyon.Entity;

namespace SinemaOtomasyon.Data
{
    interface ISorgu<T> // Bütün entitylerle çalışması için generic bir arayüz oluşturuyorum
    {
        int insert(T sinif); //insert sorgusunu bu fonksiyonla çalıştıracağım ve int ile etkilenen sorgu sayısını döneceğim
        int update(T sinif); // update sorgusunu bu fonksiyonla kullancağım ve int ile etkilenen sorgu sayısını döneceğim
        DataSet select(); //Sorgu sonuçlarını reader ile okuyup Business katmanına reader'ı döneceğim.

        int delete(T sinif); // delete sorgusunu bu fonksiyonla çalıştıracağım ve int ile etkilenen sorgu sayısını döneceğim.
    }
}
