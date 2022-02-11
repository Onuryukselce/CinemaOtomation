using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SinemaOtomasyon.Business;

namespace SinemaOtomasyon.Entity
{
    class Seans // Veritabanımdaki Seans tablosuna karşılık gelen sınıfımı oluşturuyorum.
    {
        private int _seansno; // SeansNo alanına karşılık gelen _seansno değişkenimi private olarak oluşturuyorum
        private int _salonno; // SalonNo alanına karşılık gelen _salonno değişkenimi private olarak oluşturuyorum
        private int _filmno; // FilmNo alanına karılık gelen _filmno değişkenimi private olarak tanımlıyorum
        private string _seanstarihssat; // SeansTarihSaat alanına karşılık gelen _seanstarihsaat değişkenimi private olarak tanımlıyorum
        SeansBL SeansBusiness = new SeansBL();
        public int SeansNo // _seansno değişkenimi örtülü olarak public edip kapsüllüyorum
        {
            get { return _seansno; }
            set { _seansno = value; }
        }

        public int SalonNo // _salonno değişkenimi örtülü olarak public edip kapsüllüyorum
        {
            get { return _salonno; }
            set { _salonno = value; }
        }

        public int FilmNo // _filmno değişkenimi örtülü olarak public edip kapsüllüyorum
        {
            get { return _filmno; }
            set { _filmno = value; }
        }

        public string SeansTarihSaat // _seanstarihsaat değişkenimi örtülü olarak public edip kapsüllüyorum
        {
            get { return _seanstarihssat; }
            set { _seanstarihssat = value; }
        }

        public Seans() // Boş constructor oluşturuyorum
        {

        }

        public Seans(int _seansno, int _salonno, int _filmno, string _seanstarihsaat) // Parametreli constructor oluşturuyorum.
        {
            SeansNo = _seansno; // SeansNo alanımı _seansno parametresine eşitliyorum
            SalonNo = _salonno; // SalonNo alanını _salonno parametresine eşitliyorum
            FilmNo = _filmno; // FilmNo alanını _filmno parametresine eşitliyorum
            SeansTarihSaat = _seanstarihsaat; // SeansTarihSaat alanını _seanstarihsaat parametresine eşitliyorum

        }

        public Seans(int _salonno, int _filmno, string _seanstarihsaat) // Parametreli constructor oluşturuyorum.
        {
            SalonNo = _salonno; // SalonNo alanını _salonno parametresine eşitliyorum
            FilmNo = _filmno; // FilmNo alanını _filmno parametresine eşitliyorum
            SeansTarihSaat = _seanstarihsaat; // SeansTarihSaat alanını _seanstarihsaat parametresine eşitliyorum

        }

        public int SeansEkle()
        {
            int etkilenenSonuc = SeansBusiness.SeansEkle(this);
            return etkilenenSonuc;
        }

        public int SeansDegistir()
        {
            int etkilenenSonuc = SeansBusiness.SeansGuncelle(this);
            return etkilenenSonuc;
        }

        public int SeansSil()
        {
            int etkilenenSonuc = SeansBusiness.SeansSil(this);
            return etkilenenSonuc;
        }

        public DataTable SeansGoster()
        {
            DataTable Seanslar = SeansBusiness.TumSeanslariGetir();
            return Seanslar;
        }
        ~Seans() // Destructor oluşturuyorum
        {
            GC.SuppressFinalize(this);  // GC entegre ederek bellekte gereksiz yer tutmasının önüne geçiyorum.
        }

    }
}
