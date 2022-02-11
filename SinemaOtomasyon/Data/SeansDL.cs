using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using SinemaOtomasyon.Entity;
using System.Windows.Forms;
namespace SinemaOtomasyon.Data
{
    class SeansDL : ISorgu<Seans>
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

        public int insert(Seans seans) // arayüzde tanımlı insert metodumu yazmaya başlıyorum
        {
            OleDbCommand cmd = new OleDbCommand();
            Baglanti.dbKomut.CommandType = CommandType.Text; // Static baglanti sınıfımın static OleDbCommand dbKomut nesnesinin, Komut tipini text olarak ayarlıyorum.

            cmd.CommandText = "insert into Seans([SalonNo], [FilmNo],[SeansTarihSaat]) values (?,?,?)"; //CommandText kısmında komutumun yapacağı sorguyu yapıyorum ancak henüz veri girişi yapmıyorum

            cmd.Parameters.AddWithValue("@SalonNo", seans.SalonNo); // SalonNo alanına parametre olaram seans sınıfımı SalonNo propertysinni atyorum
            cmd.Parameters.AddWithValue("@FilmNo", seans.FilmNo); // FilmNo alanına paremetre olarak seans sınıfımın FilmNo propertysini atıyorum
            cmd.Parameters.AddWithValue("@SeansTarihSaat", seans.SeansTarihSaat); // SeansTarihSaat alanına parametre olarak seans sınıfımın SeansTarihSaat propertysini atıyorum

            int etkilenenKolonlar = NonQuery(cmd); // NonQuery fonksiyonuma sınıfımı ve komutumu göndererek işlemesini ve bana etkilenenKolonlar verisini sunmasını sağlaıyorum

            return etkilenenKolonlar; // etkilenenKolonlar verimi döndürüyorum
        }

        public int update(Seans seans) // arayüzde tanımlı update metodumu çağırıyorum
        {
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text; // Static baglanti sınıfımın static OleDbCommand dbKomut nesnesinin, Komut tipini text olarak ayarlıyorum.
            cmd.CommandText = "UPDATE Seans SET SalonNo = ?, FilmNo = ?, SeansTarihSaat = ? where SeansNo = ?"; //CommandText kısmında komutumun yapacağı sorguyu yapıyorum ancak henüz veri girişi yapmıyorum

            cmd.Parameters.AddWithValue("@SalonNo", seans.SalonNo); // SalonNo alanına parametre olaram seans sınıfımın SalonNo propertysinni atyorum
            cmd.Parameters.AddWithValue("@FilmNo", seans.FilmNo); // FilmNo alanına paremetre olarak seans sınıfımın FilmNo propertysini atıyorum
            cmd.Parameters.AddWithValue("@SeansTarihSaat", seans.SeansTarihSaat); // SeansTarihSaat alanına parametre olarak seans sınıfımın SeansTarihSaat propertysini atıyorum
            cmd.Parameters.AddWithValue("@SeansNo", seans.SeansNo); // SeansNo alanına parametre olarak seans sınıfımın SeansNo propertysini atıyorum

            int etkilenenKolonlar = NonQuery(cmd); // NonQuery fonksiyonuma sınıfımı ve komutumu göndererek işlemesini ve bana etkilenenKolonlar verisini sunmasını sağlaıyorum

            return etkilenenKolonlar; // etkilenenKolonlar verimi döndürüyorum

        }

        public int delete(Seans seans) // arayüzde tanımlı delete fonksiyonumu tanımlıyorum
        {
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text; // Static baglanti sınıfımın static OleDbCommand dbKomut nesnesinin, Komut tipini text olarak ayarlıyorum.
            cmd.CommandText = "DELETE From Seans where SeansNo = ?"; //CommandText kısmında komutumun yapacağı sorguyu yapıyorum ancak henüz veri girişi yapmıyorum

            
            cmd.Parameters.AddWithValue("@SeansNo", seans.SeansNo); // SeansNo alanına parametre olarak seans sınıfımın SeansNo propertysini atıyorum
            
            int etkilenenKolonlar = NonQuery(cmd); // NonQuery fonksiyonuma sınıfımı ve komutumu göndererek işlemesini ve bana etkilenenKolonlar verisini sunmasını sağlaıyorum

            return etkilenenKolonlar; // etkilenenKolonlar verimi döndürüyorum

        }

        public DataSet select() // Verimi DataSet cinsinden döndüreceğim bu yüzden select ifademi DataSet cinsinden yazıyorum
        {
            Baglanti.dbKomut.CommandType = CommandType.Text; //komut tipimi text olarak ayarlıyorum
            Baglanti.dbKomut.CommandText = "SELECT * From Seans"; // komutumu select sorgusu için hazırlıyorum

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
            sorguAdaptor.Fill(sorguSonucu, "Seans"); // Sorgu sonucunu tablo adıyla birlikte DataSet'e yüklüyorum

            Baglanti.dbBaglanti.Close(); // Bağlantıyı kapatıyorum
            return sorguSonucu; // Sorgu sonucumu döndürüyorum



        }
    }
}
