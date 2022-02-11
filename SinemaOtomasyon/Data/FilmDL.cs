using System;
using SinemaOtomasyon.Entity;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace SinemaOtomasyon.Data
{
    class FilmDL : ISorgu<Film> // Sorgu arayüzümü extend edip generic parametresine Film sınıfını giriyorum
    {

        int NonQuery(OleDbCommand komut)
        {
            int etkilenenKolonlar = 0; // Etkilenen kolonları bastıracağım değişkenimi tanımlıyorum ve değerini sıfır yapıyorum.
                Baglanti.dbKomut = komut;
                try
                {
                    Baglanti.dbKomut.Connection = Baglanti.dbBaglanti; // Komutumun OleDBConnection dbBaglanti nesnesine baglı olmasını sağlıyorum
                    Baglanti.dbBaglanti.Open(); // Bağlantıyı açıyorum

                }
                catch (OleDbException ex) // Eğer bağlantı sırasında hata olursa bunu OleDBException ile yakalıyorum
                {
                    MessageBox.Show("Hata : " + ex.Message + " Hata Kodu : " + ex.ErrorCode); // Ekrana hata mesajı basıyorum
                }

                try // Burada sorguyu yukarıda açtığımız bağlantı üzerinde veritabanına göndereceğiz ancak yine işletim hatalarını yakalamak için try catch ile hata yakalama yapıyorum
                {
                    etkilenenKolonlar = Baglanti.dbKomut.ExecuteNonQuery(); // Sorgumu çalıştırıyorum ve etkilenenKolonlar değişkenine etkilenen kolon sayısını istiyorum

                }
                catch (InvalidOperationException ex) // Eğer komut işlenmesi sırasında hata çıkarsa bunu InvalidOperationException ile yakalıyorum
                {
                    MessageBox.Show("Hata : " + ex.Message); // Hata mesajını ekrana basıyorum
                }

                Baglanti.dbBaglanti.Close();
                return etkilenenKolonlar; // Etkilenen kolonlar değerini döndürüyorum
        }

            public int insert(Film film) // arayüzde tanımlı insert metodumu yazmaya başlıyorum
        {
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text; // Static baglanti sınıfımın static OleDbCommand dbKomut nesnesinin, Komut tipini text olarak ayarlıyorum.

            cmd.CommandText = "insert into Film([FilmAdi], [FilmTuru],[Yonetmen],[AfisYolu]) values (?,?,?,?)"; //CommandText kısmında komutumun yapacağı sorguyu yapıyorum ancak henüz veri girişi yapmıyorum

                cmd.Parameters.AddWithValue("@FilmAdi", film.FilmAdi); // FilmAdi alanına parametre olaram film sınıfımı FilmAdi propertysinni atyorum
                cmd.Parameters.AddWithValue("@FilmTuru", film.FilmTuru); // FilmTuru alanına paremetre olarak film sınıfımın FilmTuru propertysini atıyorum
                cmd.Parameters.AddWithValue("@Yonetmen", film.Yonetmen); // Yonetmen alanına parametre olarak film sınıfımın Yonetmen propertysini atıyorum
                cmd.Parameters.AddWithValue("@AfisYolu", film.AfisYolu); // AfisYolu alanına parametre olarak film sınıfımın Yonetmen propertysini atıyorum

            int etkilenenKolonlar = NonQuery(cmd); // NonQuery fonksiyonuma sınıfımı ve komutumu göndererek işlemesini ve bana etkilenenKolonlar verisini sunmasını sağlaıyorum

                return etkilenenKolonlar; // etkilenenKolonlar verimi döndürüyorum
            }

       public int update(Film film) // arayüzde tanımlı update metodumu çağırıyorum
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text; // Static baglanti sınıfımın static OleDbCommand dbKomut nesnesinin, Komut tipini text olarak ayarlıyorum.
            cmd.CommandText = "UPDATE Film SET FilmAdi = ?, FilmTuru = ?, Yonetmen = ?, AfisYolu = ? WHERE FilmNo = ?"; //CommandText kısmında komutumun yapacağı sorguyu yapıyorum ancak henüz veri girişi yapmıyorum

            cmd.Parameters.AddWithValue("@FilmAdi", film.FilmAdi); // FilmAdi alanına parametre olaram film sınıfımı FilmAdi propertysinni atyorum
            cmd.Parameters.AddWithValue("@FilmTuru", film.FilmTuru); // FilmTuru alanına paremetre olarak film sınıfımın FilmTuru propertysini atıyorum
            cmd.Parameters.AddWithValue("@Yonetmen", film.Yonetmen); // Yonetmen alanına parametre olarak film sınıfımın Yonetmen propertysini atıyorum
            cmd.Parameters.AddWithValue("@AfisYolu", film.AfisYolu); // AfisYolu alanına parametre olarak film sınıfımın Yonetmen propertysini atıyorum
            cmd.Parameters.AddWithValue("@FilmNo", film.FilmNo); // FilmNo alanına parametre olarak film sınıfımın filmNo propertysini atıyorum

            int etkilenenKolonlar = NonQuery(cmd); // NonQuery fonksiyonuma sınıfımı ve komutumu göndererek işlemesini ve bana etkilenenKolonlar verisini sunmasını sağlaıyorum
           
            return etkilenenKolonlar; // etkilenenKolonlar verimi döndürüyorum

        }

    public int delete(Film film) // arayüzde tanımlı delete fonksiyonumu tanımlıyorum
        {
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text; // Static baglanti sınıfımın static OleDbCommand dbKomut nesnesinin, Komut tipini text olarak ayarlıyorum.
                cmd.CommandText = "DELETE From Film where FilmNo = ?"; //CommandText kısmında komutumun yapacağı sorguyu yapıyorum ancak henüz veri girişi yapmıyorum

                cmd.Parameters.AddWithValue("@FilmNo", film.FilmNo); // FilmNo alanına parametre olarak film sınıfımın filmNo propertysini atıyorum

            int etkilenenKolonlar = NonQuery(cmd); // NonQuery fonksiyonuma sınıfımı ve komutumu göndererek işlemesini ve bana etkilenenKolonlar verisini sunmasını sağlaıyorum

            return etkilenenKolonlar; // etkilenenKolonlar verimi döndürüyorum

        }

        public DataSet select() // Verimi DataSet cinsinden döndüreceğim bu yüzden select ifademi DataSet cinsinden yazıyorum
        {
            Baglanti.dbKomut.CommandType = CommandType.Text; //komut tipimi text olarak ayarlıyorum
            Baglanti.dbKomut.CommandText = "SELECT * From Film"; // komutumu select sorgusu için hazırlıyorum

                Baglanti.dbKomut.Connection = Baglanti.dbBaglanti; // Komutumun OleDBConnection dbBaglanti nesnesine baglı olmasını sağlıyorum

                try
                {
                
                Baglanti.dbBaglanti.Open(); // Bağlantıyı açıyorum

            }
            catch (OleDbException ex) // Eğer bağlantı sırasında hata olursa bunu OleDBException ile yakalıyorum
            {
                MessageBox.Show("Hata : " + ex.Message + " Hata Kodu : " + ex.ErrorCode); // Ekrana hata mesajı basıyorum
            }

            DataSet sorguSonucu = new DataSet(); // Sonucu döndüreceğim DataSet nesnesini oluşturuyorum
            OleDbDataAdapter sorguAdaptor = new OleDbDataAdapter(Baglanti.dbKomut); // DataSet Fill komutunu kullanabilmek için OleDbDataAdapter nesnesi oluşturuyorum
            sorguAdaptor.Fill(sorguSonucu,"Film"); // Sorgu sonucunu tablo adıyla birlikte DataSet'e yüklüyorum

            Baglanti.dbBaglanti.Close(); // Bağlantıyı kapatıyorum
            return sorguSonucu; // Sorgu sonucumu döndürüyorum
            
           

        }


    }
  }

