using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SinemaOtomasyon.Business;
namespace SinemaOtomasyon.Entity
{
    class Salon : ISalon // Veritabanındaki Salon tabloma karşılık gelen Salon sınıfımı oluşturuyorum
    {
        private int _salonNo; // SalonNo alanına karşılık gelen salonNo değişkenimi private olarak tanımlıyorum
        private string _salonadi; // SalonAdi alanına karşılık gelen salonadi dğeişkenimi vprivate olarak tanımlıyorum

        public int SalonNo // salonNo değişkenimi örtülü olarak public ediyorum ve kapsülleme işlemini gerçekleştiriyorum.
        {
            get { return _salonNo; }
            set { _salonNo = value; }
        }

        public string SalonAdi // salonadi değişkenimi örtülü olarak public ediyorum ve kapsülleme işlemini gerçekleştiriyorum.
        {
            get { return _salonadi; }
            set { _salonadi = value; }
        }

        public Salon() // Boş constructor tanımlıyorum
        {

        }

        public Salon(int _salonno, string _salonadi) //Parametreli constructor tanımlıyorum
        {
            SalonNo = _salonno;
            SalonAdi = _salonadi;
        }

        public Salon(string _salonadi) // Salonno olmayan bir constructor tanımlıyorum
        {
            SalonAdi = _salonadi;
        }


        public int SalonEkle()
        {
                 SalonBL SalonBusiness = new SalonBL();

        int etkilenenSonuc = SalonBusiness.SalonEkle(this);
            return etkilenenSonuc;
        }

        public int SalonDegistir()
        {
            SalonBL SalonBusiness = new SalonBL();
            int etkilenenSonuc = SalonBusiness.SalonGuncelle(this);
            return etkilenenSonuc;
        }

        public int SalonSil()
        {
            SalonBL SalonBusiness = new SalonBL();
            int etkilenenSonuc = SalonBusiness.SalonSil(this);
            return etkilenenSonuc;
        }

        public DataTable SalonGoster()
        {
            SalonBL SalonBusiness = new SalonBL();
            DataTable Salonlar = SalonBusiness.TumSalonlariGetir();
            return Salonlar;
        }



        ~Salon() // Classımın destructorunu oluşturuyorum ve içine Garbage Collector ekliyorum.
        {
            GC.SuppressFinalize(this);
        }
    }
}
