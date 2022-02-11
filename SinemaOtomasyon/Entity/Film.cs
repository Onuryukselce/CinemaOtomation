using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SinemaOtomasyon.Business;

namespace SinemaOtomasyon.Entity
{
    class Film :IFilm,IDisposable // Veritabanındaki film nesnesi için burada bir film sınıfı oluşturuyorum
    {
        private int _filmno; // Tablodaki FilmNo alanı için private int değişken tanımlıyorum.
        private string _filmadi; // Tablodaki FilmAdi alanı için private string değişken tanımlıyorum.
        private string _filmturu; // Tablodaki FilmTuru alanı için private string değişken tanımlıyorum.
        private string _yonetmen; // Tablodaki Yonetmen alanı için private string değişken tanımlıyorum.
        private string _afisYolu; // Tablodaki Afişyolu alanı için private string değişken tanımlıyorum
        public int FilmNo // _filmno alanını örtülü olarak public ediyorum ve kapsülleme işlemini gerçekleştiriyorum.
        {
            get { return _filmno; }
            set { _filmno = value; }
        }

        public string FilmAdi // _filmadi alanını örtülü olarak public ediyorum ve kapsülleme işlemini gerçekleştiriyorum.
        {
            get { return _filmadi; }
            set { _filmadi = value; }
        }

        public string FilmTuru //  _filmturu alanını örtülü olarak public ediyorum ve kapsülleme işlemini gerçekleştiriyorum.
        {
            get { return _filmturu; }
            set { _filmturu = value; }
        }

        public string Yonetmen // _yonetmen alanını örtülü olarak public ediyorum ve kapsülleme işlemini gerçekleştiriyorum.
        {
            get { return _yonetmen; }
            set { _yonetmen = value; }
        }

        public string AfisYolu // _afisYolu alanını örtülü olarak public ediyorum ve kapsülleme yapıyorum
        {
            get { return _afisYolu; }
            set { _afisYolu = value; }
        }

        public Film() // Boş constructor tanımlıyorum
        {

        }

        public Film(int _filmno, string _filmadi, string _filmturu, string _yonetmen, string _afisYolu) // Bütün özelliklerini içeren bir constructor tanımlıyorum
        {
            FilmNo = _filmno; // FilmNo alanını constructor parametresi ile dolduruyorum
            FilmAdi = _filmadi; // FilmAdı alanını constructor parametresi ile dolduruyorum
            FilmTuru = _filmturu; // FilmTürü alanını constructor parametresi ile dolduruyorum
            Yonetmen = _yonetmen; // Yonetmen alanını constructor parametresi ile dolduruyorum
            AfisYolu = _afisYolu; // Afisyolu alanını constructır parametresi iel dolduruyorum
        }

       public Film(string _filmadi, string _filmturu, string _yonetmen, string _afisYolu) // Eğer filmno ihtiyacım yoksa diye filmno olmayan bir constructor daha tanımlıyorum.
        {
            FilmAdi = _filmadi; // FilmAdı alanını constructor parametresi ile dolduruyorum
            FilmTuru = _filmturu; // FilmTürü alanını constructor parametresi ile dolduruyorum
            Yonetmen = _yonetmen; // Yonetmen alanını constructor parametresi ile dolduruyorum
            AfisYolu = _afisYolu; // Afisyolu alanını constructır parametresi iel dolduruyorum

        }


        public int FilmEkle()
        {
            FilmBL FilmBusiness = new FilmBL(); // Film Business katmanımı tanımlıyorum.

            int etkilenenSonuc = FilmBusiness.FilmEkle(this);
            return etkilenenSonuc;
        }

        public int FilmSil()
        {
            FilmBL FilmBusiness = new FilmBL(); // Film Business katmanımı tanımlıyorum.

            int etkilenenSonuc = FilmBusiness.FilmSil(this);
            return etkilenenSonuc;
        }

        public int FilmDegistir()
        {
            FilmBL FilmBusiness = new FilmBL(); // Film Business katmanımı tanımlıyorum.

            int etkilenenSonuc = FilmBusiness.FilmGuncelle(this);
            return etkilenenSonuc;
        }

        public DataTable FilmGoster()
        {
            FilmBL FilmBusiness = new FilmBL(); // Film Business katmanımı tanımlıyorum.

            DataTable Filmler = FilmBusiness.TumFilmleriGetir();
            return Filmler;
        }

        ~Film() { GC.SuppressFinalize(this); } //Deconstructor oluşturuyorum ve class silindiğinde Garbage Collector tarafından işlenmesi için kodunu yazıyorum.

       public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
