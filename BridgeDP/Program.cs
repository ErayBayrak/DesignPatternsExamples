using System;
//BRIDGE DESIGN PATTERN
//Aşağıda Bridge tasarım deseninin teorik implementasyonu verilmiştir. Abstraction classı , main class tarafından ulaşılabilinen classtır
//yani temsili olarak bizim clientımızın ulaştığı ve fonksiyonel classları clienttan soyutlayan classtır. Bridge ise abstraction ile iletişimde olan classtır.
//Bridge classı köprü vazifesi gördüğünden tüm fonksiyonel classların atası olmak zorundadır.

namespace BridgeDP
{
    interface Bridge
    {
        string OperationImp();
    }

    class ImplementationA : Bridge
    {
        public string OperationImp()
        {
            return "Implementation A";
        }
    }

    class ImplementationB : Bridge
    {
        public string OperationImp()
        {
            return "Implementation B";
        }
    }

    class Abstraction
    {
        Bridge bridge;

        public Abstraction(Bridge Implementation)
        { bridge = Implementation; }

        public string Operation()
        {
            return "Abstraction <> " + bridge.OperationImp();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bridge Pattern \n");
            Console.WriteLine(new Abstraction(new ImplementationA()).Operation());
            Console.WriteLine(new Abstraction(new ImplementationB()).Operation());

            Console.ReadKey();
        }
    }
}
