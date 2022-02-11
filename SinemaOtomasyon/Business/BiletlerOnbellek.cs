using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SinemaOtomasyon.Entity;

namespace SinemaOtomasyon.Business
{
    static class BiletlerOnbellek
    {
            public static DataTable Onbellek = new DataTable(); // Her bilet göstermek istediğimde veritabanına sorgu göndermek istemiyorum bu nedenle sınıfımın içinde bir Önbellek oluşturmaya karar verdim
            public static bool VeriOnbellegeEsit = false; // Eğer bu static sınıf bir şekilde hafızadan yok olursa değişkenin değeri otomatik olarak false olacağı için veri önbelleğin boş olduğu anlaşılacaktır.
        public static int KontrolID; // Kontrol id değişkenim

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

            public static void OnBellektenSil(Bilet bilet) // Onbellekten veriyi silmek için OnBellektenSil fonksiyonumu oluşturuyorum
            {
                for (int i = Onbellek.Rows.Count - 1; i >= 0; i--) //Onbelleğin rowları arasında geziyorum
                {
                    DataRow dr = Onbellek.Rows[i]; //Obelleğin her rowunu dr isimli bir değişkene atıyorum
                    if (Convert.ToInt32(dr["BiletNo"]) == bilet.BiletNo) // Eğer dr "BiletNo" sütunu, verilen biletNo ya eşit ise
                        dr.Delete(); // Satırı siliyorum
                }
                Onbellek.AcceptChanges(); // Değişiklikleri kabul ettiriyorum
            }

            public static void OnBellegiDuzenle(Bilet bilet) // Önbelleği düzenle fonksiyonumu tanımlıyorum
            {
                for (int i = Onbellek.Rows.Count - 1; i >= 0; i--) // Tıpkı OnBellektenSil fonksiyonundaki gibi  önbelleğin rowları arasında geziyorum
                {
                    DataRow dr = Onbellek.Rows[i]; // Önbelleğin her rowunu dr isimli bir değişkene atıyorum
                    if (Convert.ToInt32(dr["BiletNo"]) == bilet.BiletNo) // Eğer dr FilNo sütunu, verilen biletNoya eşit ise
                    {
                        dr["SeansNo"] = bilet.SeansNo; // SeansNo alanını bilet sınıfının ilgili alanına eşitliyorum
                        dr["KoltukNo"] = bilet.KoltukNo; // KoltukNo alanını bilet sınıfının ilgili alanına eşitliyorum
                        dr["Fiyat"] = bilet.Fiyat; // Fiyat alanını bilet sınıfının ilgili alanına eşitliyorum
                    }
                }
                Onbellek.AcceptChanges();
            }
            public static void OnBellegeEkle(Bilet bilet) //Verileri önbelleğe eklemek için fonksiyonumu oluşturuyorum
            {

                DataRow dataRow = Onbellek.NewRow(); // Veri DataTable nesnemin içinde bir DataRow nesnesi oluşturuyorum
                dataRow["BiletNo"] = OnBellektekiSonIDGetir(); // Bu rowun BiletNo kolonunu, OnBellektekiSonBiletinIDGetir fonksiyonundan dönen veri ile dolduruyorum.
                dataRow["SeansNo"] = bilet.SeansNo; // rowun SeansNo kolonunu bilet sinifinin BiletAdi propertysi ile dolduruyorum
                dataRow["KoltukNo"] = bilet.KoltukNo; // rowun KoltukNo kolonunu bilet sınıfının BiletTuru propertysi ile dolduruyorum
                dataRow["Fiyat"] = bilet.Fiyat; // rowun Fiyat kolonunu bilet sınıfının Yonetmen propertysi ile dolduruyorum
                Onbellek.Rows.Add(dataRow); // Oluşturudğum rowu Onbelleğe ekliyorum
            }

            private static int OnBellektekiSonIDGetir() // Eğer bir ekleme yapılıyorsa id db tarafında otomatik olarak atanıyor fakat bunu önbellekte elle yapmak zorundayız bu nedenle bu fonksiyonu kullanıyorum
            {
                if (Onbellek.Rows.Count > 0) // ÖnBelleğin boş olup olmadığına bakıyorum
                {
                    //Önbellek boş değilse
                    DataRow OnBellektekiSonRow = Onbellek.Rows[Onbellek.Rows.Count - 1]; // ÖnbellektekiSonRow isimli DataRow nesneme OnBellek tablosunun son Row'unu (Satır) aktarıyorum
                    var SonIDVar = OnBellektekiSonRow["BiletNo"].ToString(); // SonID'yi BiletNo isiml columndan alıyorum
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
