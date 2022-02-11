using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using SinemaOtomasyon.Entity;
namespace SinemaOtomasyon.Data
{
    class BiletDL : ISorgu<Bilet>
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

        public int insert(Bilet bilet) // arayüzde tanımlı insert metodumu yazmaya başlıyorum
        {
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text; // Static baglanti sınıfımın static OleDbCommand dbKomut nesnesinin, Komut tipini text olarak ayarlıyorum.

            cmd.CommandText = "insert into Bilet([SeansNo], [KoltukNo], [Fiyat]) values (?,?,?)"; //CommandText kısmında komutumun yapacağı sorguyu yapıyorum ancak henüz veri girişi yapmıyorum

            cmd.Parameters.AddWithValue("@SeansNo", bilet.SeansNo); // SeansNo alanına parametre olaram bilet sınıfımı SeansNo propertysinni atyorum
            cmd.Parameters.AddWithValue("@KoltukNo", bilet.KoltukNo); // KoltukNo alanına paremetre olarak bilet sınıfımın KoltukNo propertysini atıyorum
            cmd.Parameters.AddWithValue("@Fiyat", bilet.Fiyat); // Fiyat alanına parametre olarak bilet sınıfımın Fiyat propertysini atıyorum

            int etkilenenKolonlar = NonQuery(cmd); // NonQuery fonksiyonuma sınıfımı ve komutumu göndererek işlemesini ve bana etkilenenKolonlar verisini sunmasını sağlaıyorum

            return etkilenenKolonlar; // etkilenenKolonlar verimi döndürüyorum
        }

        public int update(Bilet bilet) // arayüzde tanımlı update metodumu çağırıyorum
        {
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text; // Static baglanti sınıfımın static OleDbCommand dbKomut nesnesinin, Komut tipini text olarak ayarlıyorum.
            cmd.CommandText = "UPDATE Bilet SET SeansNo = ?, KoltukNo = ?, Fiyat = ? where BiletNo = ?"; //CommandText kısmında komutumun yapacağı sorguyu yapıyorum ancak henüz veri girişi yapmıyorum

            cmd.Parameters.AddWithValue("@SeansNo", bilet.SeansNo); // SeansNo alanına parametre olaram bilet sınıfımı SeansNo propertysinni atyorum
            cmd.Parameters.AddWithValue("@KoltukNo", bilet.KoltukNo); // KoltukNo alanına paremetre olarak bilet sınıfımın KoltukNo propertysini atıyorum
            cmd.Parameters.AddWithValue("@Fiyat", bilet.Fiyat); // Fiyat alanına parametre olarak bilet sınıfımın Fiyat propertysini atıyorum


            int etkilenenKolonlar = NonQuery(cmd); // NonQuery fonksiyonuma sınıfımı ve komutumu göndererek işlemesini ve bana etkilenenKolonlar verisini sunmasını sağlaıyorum

            return etkilenenKolonlar; // etkilenenKolonlar verimi döndürüyorum

        }

        public int delete(Bilet bilet) // arayüzde tanımlı delete fonksiyonumu tanımlıyorum
        {
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text; // Static baglanti sınıfımın static OleDbCommand dbKomut nesnesinin, Komut tipini text olarak ayarlıyorum.
            cmd.CommandText = "DELETE From Bilet where BiletNo = ?"; //CommandText kısmında komutumun yapacağı sorguyu yapıyorum ancak henüz veri girişi yapmıyorum

            cmd.Parameters.AddWithValue("@BiletNo", bilet.BiletNo); // BiletNo alanına parametre olarak bilet sınıfımın  BiletNo propertysini atıyorum

            int etkilenenKolonlar = NonQuery(cmd); // NonQuery fonksiyonuma sınıfımı ve komutumu göndererek işlemesini ve bana etkilenenKolonlar verisini sunmasını sağlaıyorum

            return etkilenenKolonlar; // etkilenenKolonlar verimi döndürüyorum

        }

        public DataSet select() // Verimi DataSet cinsinden döndüreceğim bu yüzden select ifademi DataSet cinsinden yazıyorum
        {
            Baglanti.dbKomut.CommandType = CommandType.Text; //komut tipimi text olarak ayarlıyorum
            Baglanti.dbKomut.CommandText = "SELECT * From Bilet"; // komutumu select sorgusu için hazırlıyorum

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
            sorguAdaptor.Fill(sorguSonucu, "Bilet"); // Sorgu sonucunu tablo adıyla birlikte DataSet'e yüklüyorum

            Baglanti.dbBaglanti.Close(); // Bağlantıyı kapatıyorum
            return sorguSonucu; // Sorgu sonucumu döndürüyorum



        }


    }
}
