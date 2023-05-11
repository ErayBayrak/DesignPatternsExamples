using System;
//BUILDER DESIGN PATTERN
//Builder design patterni farklı şekildeki nesnelerin oluşturulmasında, clientin sadece nesne tipini belirterek creation işlemini gerçekleştirebilmesini sağlamak için kullanılır.
//Builder design patterninde clientin kullanmak istediği bir ürünün birden fazla şekli olabileceği düşünülür. Farklı şekillerin olduğu nesnenin üretiminden builder pattern sorumludur.
//Dolayısıyla client bu işten soyutlanır.
//Bir nesne oluşturduğumuzda sınıfımızın içerisindeki değişkenlerden ürettiğimiz constructor metod bize gereksiz gelen parametrelerden oluşabilir.
//Nesne yaratılırken bu constructor metod içerisindeki kadar parametre alması gerekmekte.
//Bu yapı zaman zaman bize uymayabilir o yüzden farklı parametreler alan ya da istediğimiz kadar parametre alabilen metod oluşturumunda Builder Pattern imdadımıza yetişmektedir. 
namespace BuilderPattern
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double KM { get; set; }
        public bool Gear { get; set; }
        public override string ToString()
        {
            return $"{Brand} marka car {Model} modelinde {KM} kilometrede {Gear} vites olarak üretilmiştir.";
        }
    }
    abstract class ICarBuilder
    {
        protected Car car;
        public Car Car
        {
            get { return car; }
        }

        public abstract void SetBrand();
        public abstract void SetModel();
        public abstract void SetKM();
        public abstract void SetGear();
    }
    class OpelConcreteBuilder : ICarBuilder
    {
        public OpelConcreteBuilder()
        {
            car = new Car();
        }
        public override void SetKM() => car.KM = 100;
        public override void SetBrand() => car.Brand = "Opel";
        public override void SetModel() => car.Model = "Astra";
        public override void SetGear() => car.Gear = true;
    }
    class ToyotaConcreteBuilder : ICarBuilder
    {
        public ToyotaConcreteBuilder()
        {
            car = new Car();
        }
        public override void SetKM() => car.KM = 150;
        public override void SetBrand() => car.Brand = "Toyota";
        public override void SetModel() => car.Model = "Corolla";
        public override void SetGear() => car.Gear = true;
    }
    class BMWConcreteBuilder : ICarBuilder
    {
        public BMWConcreteBuilder()
        {
            car = new Car();
        }
        public override void SetKM() => car.KM = 25;
        public override void SetBrand() => car.Brand = "BMW";
        public override void SetModel() => car.Model = "X Bilmem Kaç";
        public override void SetGear() => car.Gear = true;
    }
    class CarProduce
    {
        public void Produce(ICarBuilder Car)
        {
            Car.SetKM();
            Car.SetBrand();
            Car.SetModel();
            Car.SetGear();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            ICarBuilder car = new OpelConcreteBuilder();
            CarProduce produce = new CarProduce();
            produce.Produce(car);

            Console.WriteLine(car.Car.ToString());

            car = new ToyotaConcreteBuilder();
            produce.Produce(car);
            Console.WriteLine(car.Car.ToString());

            Console.Read();
        }
    }
}
