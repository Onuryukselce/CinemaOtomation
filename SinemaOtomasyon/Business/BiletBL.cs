using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinemaOtomasyon.Data;
using SinemaOtomasyon.Entity;
using System.Data;

namespace SinemaOtomasyon.Business
{
    class BiletBL
    {
        private BiletDL BiletDataKatman = new BiletDL(); // Data katmanımdaki BiletDL sınıfını private erişim belirteci kullanarak implement ediyorum
                                                      // Ayrıca sınıf dışından kesinlikle erişim olmaması gerektiği için erişim belirtecini private olarak ayarlıyorum


        public DataTable TumBiletleriGetir() // Tüm biletlerin tüm verilerini gönderecek fonksiyonumu tanımlıyorum
        {
            DataTable Biletler = new DataTable(); //Biletler verisini tutacak DataTable nesnemi tanımlıyorum
            DataSet BiletlerDS = new DataSet();
            if (BiletlerOnbellek.VeriOnbellegeEsit == true)
            {
                Biletler = BiletlerOnbellek.OnBellektenYukle(); // Biletler DataSetimi önbellekten yüklüyorum böylece gereksiz sorgulardan kaçınmış oluyorum.
            }
            else
            {
                BiletlerDS = BiletDataKatman.select(); // Data katmanındaki select metodunu kullanarak Biletler isimli DataSetime veriyi alıyorum
                Biletler = BiletlerDS.Tables[0];
                BiletlerOnbellek.Onbellek = BiletlerOnbellek.OnBellegeYukle(Biletler); // Biletler ön blleğine veri tabanımdan çektiğim sorguyu ekliyorum böyle önbelleğim de güncel kalmış oluyor.
                BiletlerOnbellek.VeriOnbellegeEsit = true; // VeriOnbellegeEsit degilse son sorgumu veritabanından yaptığım için artık veri önbelleğe eşit bu yüzden bool = true yapıyorum
            }

            return Biletler; // Biletler verimi döndürüyorum

        }

        public int BiletEkle(Bilet bilet) // BiletEkle fonksiyonum filk eklemek için tanımlıyorum
        {
            int etkilenenSonuc = 0; // etkilenen sonuç değişkenimi tanımlıyorum çünkü Data katmanından bana böyle bir veri gelecek
            etkilenenSonuc = BiletDataKatman.insert(bilet); // Bilet sınıfımı Data katmanına gönderiyorum böylece data katmanı veriyi işleyerek veritabanına yazıyor
            if (etkilenenSonuc > 0) // Eğer bilet veritabanına eklenebilimişse ...
                BiletlerOnbellek.OnBellegeEkle(bilet); // Ekleme yaptığımda önbellekteki bütünlüğün bozulmaması için veriyi önbelleğe de aynı şekilde ekleyen fonksiyonumu çağrıyorum.


            return etkilenenSonuc; // Etkilenen sonuç değişkenimi döndürüyorum.            

        }

        public int BiletGuncelle(Bilet bilet) // Bileti güncellemek için BiletiGuncelle fonksiyonumu oluşturuyorum
        {
            int etkilenenSonuc = 0; // etkilenen sonuç değişkenimi tanımlıyorum çünkü Data katmanından bana böyle bir veri gelecek
            etkilenenSonuc = BiletDataKatman.update(bilet); // Bilet sınıfımı Data katmanına gönderiyorum böylece data katmanı veriyi işleyerek veritabanına yazıyor
            BiletlerOnbellek.OnBellegiDuzenle(bilet); // Önbelleği düzenleme fonksiyonumu çağırıyorum
            return etkilenenSonuc; // Sonucu döndürüyorum

        }

        public int BiletSil(Bilet bilet) // Bileti silmek için BiletSil fonksiyonumu kuruyorum
        {
            int etkilenenSonuc = 0; // etkilenen sonuç değişkenimi tanımlıyorum çünkü Data katmanından bana böyle bir veri gelecek
            etkilenenSonuc = BiletDataKatman.delete(bilet); // Bilet sınıfımı Data katmanına gönderiyorum böylece data katmanı veriyi işleyerek veritabanına yazıyor
            BiletlerOnbellek.OnBellektenSil(bilet);
            return etkilenenSonuc; // Sonucu döndürüyorum
        }
    }
}
