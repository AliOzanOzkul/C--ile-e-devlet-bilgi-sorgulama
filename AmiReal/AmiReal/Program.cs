using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiReal
{
    class Program
    {
        static void Main(string[] args)
        {
            BasaDon:
            Kisi kisi = new Kisi();
            Console.WriteLine("Lütfen Adınızı Giriniz : ");
            kisi.Ad = Console.ReadLine();
            Console.WriteLine("Lütfen Soyadınızı Giriniz : ");
            kisi.Soyad = Console.ReadLine();
            Console.WriteLine("Lütfen Dogum Yılınızı Giriniz : ");
            kisi.DogumYili = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen Tc Kimlik Numaranızı Giriniz : ");
            kisi.TcNo = long.Parse(Console.ReadLine());

            bool durum;

            try
            {
                using (KimlikDogrula.KPSPublicSoapClient service = new KimlikDogrula.KPSPublicSoapClient { })
                {

                    durum = service.TCKimlikNoDogrula(kisi.TcNo, kisi.Ad, kisi.Soyad, kisi.DogumYili);
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (durum == true)
            {
                Console.WriteLine("Girmiş Olduğunuz Bilgiler DOĞRUDUR.");
            }
            else
            {
                Console.WriteLine("Girmiş Olduğunuz Bilgiler HATALIDIR!!!");
            }
            goto BasaDon;


        }


        class Kisi
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public int DogumYili { get; set; }
            public long TcNo { get; set; }






        }
    }
}
