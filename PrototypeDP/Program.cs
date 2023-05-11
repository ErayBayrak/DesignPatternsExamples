using System;
//Yaptığımız projemizde nesnemizi birden fazla oluşturmamız gerektiğinde normalde “new” olarak oluşturmak yerine bir tane oluşturduğumuz nesnemizin klonunu oluşturmamızı sağlayan bir design patterndir.
//Prototype Pattern kullanılmasının amacı üretilen nesnenin çok kaynak tüketmesi durumunun engellenmesini sağlamaktır.
namespace PrototypeDP
{
    //bu classı implemente eden classlar içerideki metodu uygulamak zorunda olduklarından metot da AventurePrototype'ı döndürmek zorunda olduğundan
    //ki kendi de abstract olduğundan türeyen tip kendi çalışma zamanını geriye döndürmekle yükümlüdür
    abstract class AdventurePrototype
    {
        public abstract AdventurePrototype Clone();
    }

    //Concrete Prototype
    class Product : AdventurePrototype
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal ListPrice { get; set; }

        public Product(int productId, string name, decimal listPrice)
        {
            ProductId = productId;
            Name = name;
            ListPrice = listPrice;
        }

        public override AdventurePrototype Clone()
        {
            return MemberwiseClone() as AdventurePrototype;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product lcdTv = new Product(1000, "ABC Lcd TV 106", 1000);
            //bunu ürettikten sonra yarın öbürgün bunun seri üretimine geçmek istediğimizi düşünelim.

            Product lcdTv2 = lcdTv.Clone() as Product;
            Console.WriteLine("lcdTv Orijinal:"+lcdTv.ProductId+" "+lcdTv.Name+" "+lcdTv.ListPrice+"\n lcdTv2 Kopyası: "+lcdTv2.ProductId+" "+lcdTv2.Name+" "+lcdTv2.ListPrice);
            Console.ReadKey();
        }

    }
}
