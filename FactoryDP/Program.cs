using System;

//Factory Design Pattern, nesne yaratma işlemi için bir arayüz tasarlanmasını gerektirir ve alt sınıfların nesne üretmesine olanak sağlar.
//Ayrıca, hangi sınıf nesnesinin oluşacağını da alt sınıflar kendileri belirler. Böylece nesne yaratma işlemini soyutlaştırır. 
namespace FactoryDP
{
        public abstract class Screen
        { //Abstract parent class

            public abstract void Draw();
        }
        //Concrete Product
        class WinScreen : Screen
        {
            public override void Draw()
            {
                Console.WriteLine("Windows Ekranı");
            }
        }
        //Concrete Product
        class WebScreen : Screen
        {
            public override void Draw()
            {
                Console.WriteLine("Web Ekranı");
            }

        }
        //Concrete Product
        class MobileScreen : Screen
        {
            public override void Draw()
            {
                Console.WriteLine("Mobile Ekranı");
            }
        }
        enum ScreenModel
        {
            Windows,
            Web,
            Mobile
        }

        //Creator Class
        class Creator
        {

            public Screen ScreenFactory(ScreenModel screenModel)
            {
                Screen screen = null;

                switch (screenModel)
                {
                    case ScreenModel.Windows:
                        screen = new WinScreen();
                        break;

                    case ScreenModel.Web:
                        screen = new WebScreen();
                        break;

                    case ScreenModel.Mobile:
                        screen = new MobileScreen();
                        break;

                }

                return screen;
            }

        }
        class Program
        {

            static void Main(string[] args)
            {
                Creator creator = new Creator();

                Screen screenWindows = creator.ScreenFactory(ScreenModel.Windows);
                Screen screenWeb = creator.ScreenFactory(ScreenModel.Web);
                Screen screenMobile = creator.ScreenFactory(ScreenModel.Mobile);

                screenWindows.Draw();
                screenWeb.Draw();
                screenMobile.Draw();

                Console.ReadKey();
            }

        }
       
    
}
