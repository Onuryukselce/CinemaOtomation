using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinemaOtomasyon.Entity;


namespace SinemaOtomasyon.Business
{
    static class FilmlerOnbellek // Filmleri önbellekte tutmak için bir static sınıf tanımlıyorum
    {
        public static DataTable Onbellek = new DataTable(); // Her film göstermek istediğimde veritabanına sorgu göndermek istemiyorum bu nedenle sınıfımın içinde bir Önbellek oluşturmaya karar verdim
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

        public static void OnBellektenSil(Film film) // Onbellekten veriyi silmek için OnBellektenSil fonksiyonumu oluşturuyorum
        {
            for (int i = Onbellek.Rows.Count - 1; i >= 0; i--) //Onbelleğin rowları arasında geziyorum
            {
                DataRow dr = Onbellek.Rows[i]; //Obelleğin her rowunu dr isimli bir değişkene atıyorum
                if (Convert.ToInt32(dr["FilmNo"]) == film.FilmNo) // Eğer dr "FilmNo" sütunu, verilen filmNo ya eşit ise
                    dr.Delete(); // Satırı siliyorum
            }
            Onbellek.AcceptChanges(); // Değişiklikleri kabul ettiriyorum
        }

        public static void OnBellegiDuzenle(Film film) // Önbelleği düzenle fonksiyonumu tanımlıyorum
        {
            for(int i = Onbellek.Rows.Count -1; i >= 0; i--) // Tıpkı OnBellektenSil fonksiyonundaki gibi  önbelleğin rowları arasında geziyorum
            {
                DataRow dr = Onbellek.Rows[i]; // Önbelleğin her rowunu dr isimli bir değişkene atıyorum
                    if(Convert.ToInt32(dr["FilmNo"]) == film.FilmNo) // Eğer dr FilNo sütunu, verilen filmNoya eşit ise
                {
                    dr["FilmAdi"] = film.FilmAdi; // FilmAdi alanını film sınıfının ilgili alanına eşitliyorum
                    dr["FilmTuru"] = film.FilmTuru; // FilmTuru alanını film sınıfının ilgili alanına eşitliyorum
                    dr["Yonetmen"] = film.Yonetmen; // Yonetmen alanını film sınıfının ilgili alanına eşitliyorum
                    dr["AfisYolu"] = film.AfisYolu; // AfisYolu alanını film sınıfının ilgili alanına eşitliyorum

                }
            }
            Onbellek.AcceptChanges();
        }
        public static void OnBellegeEkle(Film film) //Verileri önbelleğe eklemek için fonksiyonumu oluşturuyorum
        {

            DataRow dataRow = Onbellek.NewRow(); // Veri DataTable nesnemin içinde bir DataRow nesnesi oluşturuyorum
            dataRow["FilmNo"] = OnBellektekiSonIDGetir(); // Bu rowun FilmNo kolonunu, OnBellektekiSonFilminIDGetir fonksiyonundan dönen veri ile dolduruyorum.
            dataRow["FilmAdi"] = film.FilmAdi; // rowun FilmAdi kolonunu film sinifinin FilmAdi propertysi ile dolduruyorum
            dataRow["FilmTuru"] = film.FilmTuru; // rowun FilmTuru kolonunu film sınıfının FilmTuru propertysi ile dolduruyorum
            dataRow["Yonetmen"] = film.Yonetmen; // rowun Yonetmen kolonunu film sınıfının Yonetmen propertysi ile dolduruyorum
            dataRow["AfisYolu"] = film.AfisYolu; // AfisYolu alanını film sınıfının ilgili alanına eşitliyorum

            Onbellek.Rows.Add(dataRow); // Oluşturudğum rowu Onbelleğe ekliyorum
        }

        private static int OnBellektekiSonIDGetir() // Eğer bir ekleme yapılıyorsa id db tarafında otomatik olarak atanıyor fakat bunu önbellekte elle yapmak zorundayız bu nedenle bu fonksiyonu kullanıyorum
        {
            if (Onbellek.Rows.Count > 0) // ÖnBelleğin boş olup olmadığına bakıyorum
            {
                //Önbellek boş değilse
                DataRow OnBellektekiSonRow = Onbellek.Rows[Onbellek.Rows.Count - 1]; // ÖnbellektekiSonRow isimli DataRow nesneme OnBellek tablosunun son Row'unu (Satır) aktarıyorum
                var SonIDVar = OnBellektekiSonRow["FilmNo"].ToString(); // SonID'yi FilmNo isiml columndan alıyorum
                int SonID = Convert.ToInt32(SonIDVar); // integer'a çeviriyorum

                return SonID+1; // Bulduğum id eklenen son id olduğu için 1 ekliyorum ve döndürüyorum
            }
            else
            {
                return KontrolID; // Eğer tablo boşsa, ya tablo boştur ya da önbellek yoktur iki durumda da son ID = Son eklenen id + 1 olacak
            }

        }
    }
}
