using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SinemaOtomasyon.Data;
using SinemaOtomasyon.Entity;

namespace SinemaOtomasyon.Business
{
    class SeansBL
    {
        private SeansDL SeansDataKatman = new SeansDL(); // Data katmanımdaki SeansDL sınıfını private erişim belirteci kullanarak implement ediyorum
                                                      // Ayrıca sınıf dışından kesinlikle erişim olmaması gerektiği için erişim belirtecini private olarak ayarlıyorum


        public DataTable TumSeanslariGetir() // Tüm seanslerin tüm verilerini gönderecek fonksiyonumu tanımlıyorum
        {
            DataTable Seansler = new DataTable(); //Seansler verisini tutacak DataTable nesnemi tanımlıyorum
            DataSet SeanslerDS = new DataSet();
            if (SeanslarOnbellek.VeriOnbellegeEsit == true)
            {
                Seansler = SeanslarOnbellek.OnBellektenYukle(); // Seansler DataSetimi önbellekten yüklüyorum böylece gereksiz sorgulardan kaçınmış oluyorum.
            }
            else
            {
                SeanslerDS = SeansDataKatman.select(); // Data katmanındaki select metodunu kullanarak Seansler isimli DataSetime veriyi alıyorum
                Seansler = SeanslerDS.Tables[0];
                SeanslarOnbellek.Onbellek = SeanslarOnbellek.OnBellegeYukle(Seansler); // Seansler ön blleğine veri tabanımdan çektiğim sorguyu ekliyorum böyle önbelleğim de güncel kalmış oluyor.
                SeanslarOnbellek.VeriOnbellegeEsit = true; // VeriOnbellegeEsit degilse son sorgumu veritabanından yaptığım için artık veri önbelleğe eşit bu yüzden bool = true yapıyorum
            }

            return Seansler; // Seansler verimi döndürüyorum

        }

        public int SeansEkle(Seans seans) // SeansEkle fonksiyonum filk eklemek için tanımlıyorum
        {
            int etkilenenSonuc = 0; // etkilenen sonuç değişkenimi tanımlıyorum çünkü Data katmanından bana böyle bir veri gelecek
            etkilenenSonuc = SeansDataKatman.insert(seans); // Seans sınıfımı Data katmanına gönderiyorum böylece data katmanı veriyi işleyerek veritabanına yazıyor
            if (etkilenenSonuc > 0) // Eğer seans veritabanına eklenebilimişse ...
                SeanslarOnbellek.OnBellegeEkle(seans); // Ekleme yaptığımda önbellekteki bütünlüğün bozulmaması için veriyi önbelleğe de aynı şekilde ekleyen fonksiyonumu çağrıyorum.


            return etkilenenSonuc; // Etkilenen sonuç değişkenimi döndürüyorum.            

        }

        public int SeansGuncelle(Seans seans) // Seansi güncellemek için SeansiGuncelle fonksiyonumu oluşturuyorum
        {
            int etkilenenSonuc = 0; // etkilenen sonuç değişkenimi tanımlıyorum çünkü Data katmanından bana böyle bir veri gelecek
            etkilenenSonuc = SeansDataKatman.update(seans); // Seans sınıfımı Data katmanına gönderiyorum böylece data katmanı veriyi işleyerek veritabanına yazıyor
            SeanslarOnbellek.OnBellegiDuzenle(seans); // Önbelleği düzenleme fonksiyonumu çağırıyorum
            return etkilenenSonuc; // Sonucu döndürüyorum

        }

        public int SeansSil(Seans seans) // Seansi silmek için SeansSil fonksiyonumu kuruyorum
        {
            int etkilenenSonuc = 0; // etkilenen sonuç değişkenimi tanımlıyorum çünkü Data katmanından bana böyle bir veri gelecek
            etkilenenSonuc = SeansDataKatman.delete(seans); // Seans sınıfımı Data katmanına gönderiyorum böylece data katmanı veriyi işleyerek veritabanına yazıyor
            SeanslarOnbellek.OnBellektenSil(seans);
            return etkilenenSonuc; // Sonucu döndürüyorum
        }

    }
}
