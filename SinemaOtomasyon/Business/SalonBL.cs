using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinemaOtomasyon.Entity;
using SinemaOtomasyon.Data;
using System.Data;

namespace SinemaOtomasyon.Business
{
    class SalonBL
    {
        private SalonDL SalonDataKatman = new SalonDL(); // Data katmanımdaki SalonDataKatman sınıfını private erişim belirteci kullanarak implement ediyorum
                                                      // Ayrıca sınıf dışından kesinlikle erişim olmaması gerektiği için erişim belirtecini private olarak ayarlıyorum


        public DataTable TumSalonlariGetir() // Tüm salonların tüm verilerini gönderecek fonksiyonumu tanımlıyorum
        {
            DataTable Salonlar = new DataTable(); //Salonlar verisini tutacak DataTable nesnemi tanımlıyorum
            DataSet SalonlarDS = new DataSet(); // Salonlar dataSet olarak döneceği için onu da tanımlıyorum
            if (SalonlarOnbellek.VeriOnbellegeEsit == true)
            {
                Salonlar = SalonlarOnbellek.OnBellektenYukle(); // SAlonlar  DataSetimi önbellekten yüklüyorum böylece gereksiz sorgulardan kaçınmış oluyorum.
            }
            else
            {
                SalonlarDS = SalonDataKatman.select(); // Data katmanındaki select metodunu kullanarak Salonlar isimli DataSetime veriyi alıyorum
                Salonlar = SalonlarDS.Tables[0];
                    SalonlarOnbellek.Onbellek = SalonlarOnbellek.OnBellegeYukle(Salonlar); // Salonlar ön blleğine veri tabanımdan çektiğim sorguyu ekliyorum böyle önbelleğim de güncel kalmış oluyor.
                    SalonlarOnbellek.VeriOnbellegeEsit = true; // VeriOnbellegeEsit degilse son sorgumu veritabanından yaptığım için artık veri önbelleğe eşit bu yüzden bool = true yapıyorum
               
            }

            return Salonlar; // Salonlar verimi döndürüyorum

        }

        public int SalonEkle(Salon Salon) // SalonEkle fonksiyonum salon eklemek için tanımlıyorum
        {
            int etkilenenSonuc = 0; // etkilenen sonuç değişkenimi tanımlıyorum çünkü Data katmanından bana böyle bir veri gelecek
            etkilenenSonuc = SalonDataKatman.insert(Salon); // Salon sınıfımı Data katmanına gönderiyorum böylece data katmanı veriyi işleyerek veritabanına yazıyor
            if (etkilenenSonuc > 0) // Eğer Salon veritabanına eklenebilimişse ...
                SalonlarOnbellek.OnBellegeEkle(Salon); // Ekleme yaptığımda önbellekteki bütünlüğün bozulmaması için veriyi önbelleğe de aynı şekilde ekleyen fonksiyonumu çağrıyorum.

            return etkilenenSonuc; // Etkilenen sonuç değişkenimi döndürüyorum.            

        }

        public int SalonGuncelle(Salon Salon) // Saloni güncellemek için SaloniGuncelle fonksiyonumu oluşturuyorum
        {
            int etkilenenSonuc = 0; // etkilenen sonuç değişkenimi tanımlıyorum çünkü Data katmanından bana böyle bir veri gelecek
            etkilenenSonuc = SalonDataKatman.update(Salon); // Salon sınıfımı Data katmanına gönderiyorum böylece data katmanı veriyi işleyerek veritabanına yazıyor
            SalonlarOnbellek.OnBellegiDuzenle(Salon); // Önbelleği düzenleme fonksiyonumu çağırıyorum
            return etkilenenSonuc; // Sonucu döndürüyorum

        }

        public int SalonSil(Salon Salon) // Saloni silmek için SalonSil fonksiyonumu kuruyorum
        {
            int etkilenenSonuc = 0; // etkilenen sonuç değişkenimi tanımlıyorum çünkü Data katmanından bana böyle bir veri gelecek
            etkilenenSonuc = SalonDataKatman.delete(Salon); // Salon sınıfımı Data katmanına gönderiyorum böylece data katmanı veriyi işleyerek veritabanına yazıyor
            SalonlarOnbellek.OnBellektenSil(Salon); // Önbellekten silme fonksiyonumu çağırıyorumü
            return etkilenenSonuc; // Sonucu döndürüyorum
        }
    }
}
