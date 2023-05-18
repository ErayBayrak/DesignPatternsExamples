using System;
//SINGLETON DESIGN PATTERN
//Creational design patterns grubuna ait singleton design pattern bir nesnenin application pool kapanana kadar bir kez üretilmesini ve tek bir instance’ının olmasını kontrol altında tutar.
//Aynı zamanda bu nesne sınıf dışından da erişilebilir olur. Bir sınıfın bir anda sadece bir örneğinin olması istenildiği zamanlarda kullanılır.
//Örneğin veritabanı uygulamalarında bir anda bir bağlantı nesnesinin olması sistem kaynaklarının verimli bir şekilde kullanılmasını sağlar.
//Singleton deseni uygulanacak sınıfın constructor(yapıcı) metodu private olarak tanımlanır ve sınıfın içinde kendi türünden static bir sınıf tanımlanır.
//Tanımlanan bu sınıfa erişimi sağlayacak bir metot veya property de sınıfa eklenir. Bu desenin birden fazla kullanım şekli olsa da genel anlamda bu şekilde kullanılır.
namespace SingletonDP
{
    class Singleton
    {

        private static Singleton _instance;
        private static Guid _id; //nesnenin tek olduğunun ispati

        public Guid Id { get { return _id; } }

        //singleton sınıfına ait sınıfın çalışma zamanında constructordan yararlanarak oluşturulmamamasını sağlar
        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            if (_instance == null)
                _instance = new Singleton();

            return _instance;
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            Singleton singleton1 = Singleton.GetInstance();
            Console.WriteLine(singleton1.Id.ToString());

            Singleton singleton2 = Singleton.GetInstance();
            Console.WriteLine(singleton2.Id.ToString());

            //ikisi için de aynı id gelir. çünkü tektir.
            Console.ReadKey();
        }

    }
}
