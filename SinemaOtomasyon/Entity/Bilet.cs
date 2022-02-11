using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SinemaOtomasyon.Business;
namespace SinemaOtomasyon.Entity
{
    class Bilet // Veritabanımdaki Bilet tablosuna karşılık gelen Bilet sınıfını oluşturuyorum
    {
        private int _biletno; // BiletNo alanına karşılık _biletno değişkenini private int olarak tanımlıyorum
        private int _seansno; // SeansNo alanına karşılık _seansno değişkeni private int olarak tanımlıyorum
        private int _koltukno; // KoltukNo alanına karşılık _koltukno değişkenini private int olarak tanımlıyorum
        private decimal _fiyat; // Fiyat alanına karşılık gelen _fiyat değişkenini private decimal olarak tanımlıyorum, burada bir para tutarı olduğu için bu değişken decimal
        private BiletBL BiletBusiness = new BiletBL();
        public int BiletNo // _biletno değişkenini örtülü olarak public edip kapsüllüyorum
        {
            get { return _biletno; } 
            set { _biletno = value; }
        }

        public int SeansNo // _seansno değişkenini örtülü olarak public edip kapsüllüyorum
        {
            get { return _seansno; }
            set { _seansno = value; }
        }

        public int KoltukNo // _koltukno değişkenini örtülü olarak public edip kapsüllüyorum
        {
            get { return _koltukno; }
            set { _koltukno = value; }
        }

        public decimal Fiyat // _Fiyat değişkenini örtülü olarak public edip kapsüllüyorum
        {
            get { return _fiyat; }
            set { _fiyat = value; }
        }

        public Bilet() // Parametresiz constructor tanımlıyorum
        {

        }

        public Bilet(int _biletno, int _seansno, int _koltukno, decimal _fiyat ) // Parametreli constructor oluşturuyorum
        {
            BiletNo = _biletno; // BiletNo alanı _biletno parametresine eşitlendi
            SeansNo = _seansno; // SeansNo alanı _seansno parametresine eşitlendi
            KoltukNo = _koltukno; // KoltukNo alanı _koltukno parametresine eşitlendi
            Fiyat = _fiyat; // Fiyat alanı _fiyat parametresine eşitlendi
        }

        public Bilet(int _seansno, int _koltukno, decimal _fiyat) // Biletno olmayan parametreli constructor oluşturuyorum 
        {
            SeansNo = _seansno; // SeansNo alanı _seansno parametresine eşitlendi
            KoltukNo = _koltukno; // KoltukNo alanı _koltukno parametresine eşitlendi
            Fiyat = _fiyat; // Fiyat alanı _fiyat parametresine eşitlendi
        }

        public int BiletEkle() // Business katmana erişecek biletekle fonksiyonumu tanımlıyorum
        {
            int etkilenenSonuc = BiletBusiness.BiletEkle(this); // BiletEkle fonksiyonunu çağırıp değerini nit'e atıyorum
            return etkilenenSonuc; // Değeri döndürüyorum
        }

        public int BiletDuzenle() // Business katmnına erişecek birduzenle fonksiyonumu tanımlıyorum
        {
            int etkilenenSonuc = BiletBusiness.BiletGuncelle(this); // BiletGuncelle fonksiyonumu çağırıyorum ve değerini int'e atıyorum
            return etkilenenSonuc; // Değeri döndürüyorum
        }

        public int BiletSil() // Busines katmanına erişecek sil fonksiyonumu tanımlıyorum
        {
            int etkilenenSonuc = BiletBusiness.BiletSil(this); // Sil fonksiyonumu çağırıyorum ve değerini int'e atıyorum
            return etkilenenSonuc; // Değeri dönüyrum
        }

        public DataTable BiletGoster() // Business katmanına erişecek göster fonksyinoumu tanımlıyorum
        {
            DataTable Biletler = BiletBusiness.TumBiletleriGetir(); // TumBiletleriGetri fonksiyonumu çağırıyorum ve değerini Biletler'e atıyorum
            return Biletler; // Değerimi döndürüyorum
        }


         ~Bilet() // Destructor tanımlıyorum
        {
            GC.SuppressFinalize(this); // Garbage Collector ile sınıfımın bellekte yer tutmasının önüne geçiyorum.
        }
    }
}
