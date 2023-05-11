using System;
//ABSTRACT FACTORY PATTERN
//Abstract Factory deseni, aynı anda birden çok nesne ile birlikte işlem yapmak istediğimiz durumlarda kullanabileceğimiz bir tasarım desenidir.
//Abstract Factory birbiri ile ilişki classları (sınıf), methodların içeriğini belirlemeden oluşturmayı sağlıyor.
//Kısacası Abstract Factory D.P. ilişkisel olan birden fazla nesnenin üretimini tek bir ara yüz tarafından değil her ürün ailesi için farklı bir arayüz tanımlayarak sağlamaktadır.
namespace DesignPatterns
{
    public interface IPlayer
    {
        string GetTopScorer();
    }
    public interface ITeam
    {
        string GetTeamColor();
    }
    public interface IFootballFactory
    {
        ITeam CreateTeam();
        IPlayer CreatePlayer();
    }
    public class BundesLigaFactory : IFootballFactory
    {
        public ITeam CreateTeam()
        {
            return new BorussiaDotmund();
        }
        public IPlayer CreatePlayer()
        {
            return new BundesligaPlayer();
        }
    }
    public class BorussiaDotmund : ITeam
    {
        public string GetTeamColor()
        {
            return "Black and Yellow";
        }
    }
    public class BundesligaPlayer : IPlayer
    {
        public string GetTopScorer()
        {
            return "Robert Lewandowski";
        }
    }
    public class FootballWorld
    {
        private readonly ITeam _team;
        public FootballWorld(IFootballFactory factory)
        {
            _team = factory.CreateTeam();
        }
        public string GetFootballTeamColor()
        {
            return _team.GetTeamColor();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BundesLigaFactory germany = new BundesLigaFactory();
            FootballWorld footballWorld = new FootballWorld(germany);
            Console.WriteLine(footballWorld.GetFootballTeamColor());
            Console.ReadLine();
        }
    }
}
