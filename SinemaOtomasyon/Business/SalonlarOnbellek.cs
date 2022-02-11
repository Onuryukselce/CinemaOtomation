using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SinemaOtomasyon.Entity;
namespace SinemaOtomasyon.Business
{
    class SalonlarOnbellek
    {
      
            public static DataTable Onbellek = new DataTable(); // Her salon göstermek istediğimde veritabanına sorgu göndermek istemiyorum bu nedenle  Önbellek oluşturmaya karar verdim
            public static bool VeriOnbellegeEsit = false; // Eğer bu static sınıf bir şekilde hafızadan yok olursa değişkenin değeri otomatik olarak false olacağı için veri önbelleğin boş olduğu anlaşılacaktır.

        public static DataTable OnBellegeYukle(DataTable dt) // Onbellege yuklemek için OnBellegeYukle fonksiyonu oluşturuyorum
            {
                Onbellek = dt.Clone(); // OnBellege alınacak tablonun yapısını kopyalıyorum
                foreach (DataRow dr in dt.Rows) // Önbelleğe alınacak tablo içerisindedeki rowlar içinde dönüyorum
                {
                    Onbellek.Rows.Add(dr.ItemArray); // Rowları Onbelleğe ekliyorum.
                }

                return Onbellek; // Onbelleği dönüyorum.
            }

            public static DataTable OnBellektenYukle() //Onbellekten veriyi yüklemek için OnBellektenYukle fonksiyonumu oluşturuyorum
            {


                DataTable OnBellektenGelecek = Onbellek.Copy(); //Onbelleği DataTable nesneme kopyalıyorum

                return OnBellektenGelecek; // OnBellektenGeleni return ediyorum
            }

            public static void OnBellektenSil(Salon salon) // Onbellekten veriyi silmek için OnBellektenSil fonksiyonumu oluşturuyorum
            {
                for (int i = Onbellek.Rows.Count - 1; i >= 0; i--) //Onbelleğin rowları arasında geziyorum
                {
                    DataRow dr = Onbellek.Rows[i]; //Obelleğin her rowunu dr isimli bir değişkene atıyorum
                    if (Convert.ToInt32(dr["SalonNo"]) == salon.SalonNo) // Eğer dr "SalonNo" sütunu, verilen SalonNo ya eşit ise
                        dr.Delete(); // Satırı siliyorum
                }
                Onbellek.AcceptChanges(); // Değişiklikleri kabul ettiriyorum
            }

            public static void OnBellegiDuzenle(Salon salon) // Önbelleği düzenle fonksiyonumu tanımlıyorum
            {
                for (int i = Onbellek.Rows.Count - 1; i >= 0; i--) // Tıpkı OnBellektenSil fonksiyonundaki gibi  önbelleğin rowları arasında geziyorum
                {
                    DataRow dr = Onbellek.Rows[i]; // Önbelleğin her rowunu dr isimli bir değişkene atıyorum
                    if (Convert.ToInt32(dr["SalonNo"]) == salon.SalonNo) // Eğer dr SAlono sütunu, verilen SalonNoya eşit ise
                    {
                        dr["SalonAdi"] = salon.SalonAdi; // SalonAdi alanını salon sınıfının ilgili alanına eşitliyorum
                       
                    }
                }
                Onbellek.AcceptChanges();
            }
            public static void OnBellegeEkle(Salon salon) //Verileri önbelleğe eklemek için fonksiyonumu oluşturuyorum
            {

                DataRow dataRow = Onbellek.NewRow(); // Veri DataTable nesnemin içinde bir DataRow nesnesi oluşturuyorum
                dataRow["SalonNo"] = OnBellektekiSonIDGetir(); // Bu rowun SalonNo kolonunu, OnBellektekiSonIDGetir fonksiyonundan dönen veri ile dolduruyorum.
                dataRow["SalonAdi"] = salon.SalonAdi; // rowun SalonAdi kolonunu salon sinifinin SalonAdı propertysi ile dolduruyorum
                Onbellek.Rows.Add(dataRow); // Oluşturduğum rowu Onbelleğe ekliyorum
            }

            private static int OnBellektekiSonIDGetir() // Eğer bir ekleme yapılıyorsa id db tarafında otomatik olarak atanıyor fakat bunu önbellekte elle yapmak zorundayız bu nedenle bu fonksiyonu kullanıyorum
            {
                if (Onbellek.Rows.Count > 0) // ÖnBelleğin boş olup olmadığına bakıyorum
                {
                    //Önbellek boş değilse
                    DataRow OnBellektekiSonRow = Onbellek.Rows[Onbellek.Rows.Count - 1]; // ÖnbellektekiSonRow isimli DataRow nesneme OnBellek tablosunun son Row'unu (Satır) aktarıyorum
                    var SonIDVar = OnBellektekiSonRow["SalonNo"].ToString(); // SonID'yi SalonNo isiml columndan alıyorum
                    int SonID = Convert.ToInt32(SonIDVar); // integer'a çeviriyorum

                    return SonID + 1; // Bulduğum id eklenen son id olduğu için 1 ekliyorum ve döndürüyorum
                }
                else
                {
                    return 0; // Eğer tablo boşsa, ya tablo boştur ya da önbellek yoktur iki durumda da son ID = 0 olacağı için 0 döndürüyorum
                }

            }
        }
}
