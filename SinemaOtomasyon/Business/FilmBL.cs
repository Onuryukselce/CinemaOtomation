using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using SinemaOtomasyon.Entity;
using SinemaOtomasyon.Data;

namespace SinemaOtomasyon.Business
{
    class FilmBL
    {
        private FilmDL FilmDataKatman = new FilmDL(); // Data katmanımdaki FilmDL sınıfını private erişim belirteci kullanarak implement ediyorum
       // Ayrıca sınıf dışından kesinlikle erişim olmaması gerektiği için erişim belirtecini private olarak ayarlıyorum


        public DataTable TumFilmleriGetir() // Tüm filmlerin tüm verilerini gönderecek fonksiyonumu tanımlıyorum
        {
            DataTable Filmler = new DataTable(); //Filmler verisini tutacak DataTable nesnemi tanımlıyorum
            DataSet FilmlerDS = new DataSet();
            if (FilmlerOnbellek.VeriOnbellegeEsit == true)
            {
                /* Filmler = FilmlerOnbellek.OnBellektenYukle(); // Filmler DataSetimi önbellekten yüklüyorum böylece gereksiz sorgulardan kaçınmış oluyorum.*/
                FilmlerDS = FilmDataKatman.select(); // Data katmanındaki select metodunu kullanarak Filmler isimli DataSetime veriyi alıyorum
                Filmler = FilmlerDS.Tables[0];
            }
            else
            {
                FilmlerDS = FilmDataKatman.select(); // Data katmanındaki select metodunu kullanarak Filmler isimli DataSetime veriyi alıyorum
                Filmler = FilmlerDS.Tables[0];
                FilmlerOnbellek.Onbellek = FilmlerOnbellek.OnBellegeYukle(Filmler); // Filmler ön blleğine veri tabanımdan çektiğim sorguyu ekliyorum böyle önbelleğim de güncel kalmış oluyor.
                FilmlerOnbellek.VeriOnbellegeEsit = true; // VeriOnbellegeEsit degilse son sorgumu veritabanından yaptığım için artık veri önbelleğe eşit bu yüzden bool = true yapıyorum
            }

            return Filmler; // Filmler verimi döndürüyorum

        }

        public int FilmEkle(Film film) // FilmEkle fonksiyonum filk eklemek için tanımlıyorum
        {
            int etkilenenSonuc = 0; // etkilenen sonuç değişkenimi tanımlıyorum çünkü Data katmanından bana böyle bir veri gelecek
            etkilenenSonuc = FilmDataKatman.insert(film); // Film sınıfımı Data katmanına gönderiyorum böylece data katmanı veriyi işleyerek veritabanına yazıyor
           
            /* if(etkilenenSonuc > 0) // Eğer film veritabanına eklenebilimişse ...
                FilmlerOnbellek.OnBellegeEkle(film); // Ekleme yaptığımda önbellekteki bütünlüğün bozulmaması için veriyi önbelleğe de aynı şekilde ekleyen fonksiyonumu çağrıyorum.
*/

            return etkilenenSonuc; // Etkilenen sonuç değişkenimi döndürüyorum.            
        
        }

        public int FilmGuncelle(Film film) // Filmi güncellemek için FilmiGuncelle fonksiyonumu oluşturuyorum
        {
            int etkilenenSonuc = 0; // etkilenen sonuç değişkenimi tanımlıyorum çünkü Data katmanından bana böyle bir veri gelecek
            etkilenenSonuc = FilmDataKatman.update(film); // Film sınıfımı Data katmanına gönderiyorum böylece data katmanı veriyi işleyerek veritabanına yazıyor
            FilmlerOnbellek.OnBellegiDuzenle(film); // Önbelleği düzenleme fonksiyonumu çağırıyorum
            return etkilenenSonuc; // Sonucu döndürüyorum

        }

        public int FilmSil(Film film) // Filmi silmek için FilmSil fonksiyonumu kuruyorum
        {
            int etkilenenSonuc = 0; // etkilenen sonuç değişkenimi tanımlıyorum çünkü Data katmanından bana böyle bir veri gelecek
            etkilenenSonuc = FilmDataKatman.delete(film); // Film sınıfımı Data katmanına gönderiyorum böylece data katmanı veriyi işleyerek veritabanına yazıyor
            FilmlerOnbellek.OnBellektenSil(film);
            return etkilenenSonuc; // Sonucu döndürüyorum
        }

       
    }
}
