using System;

namespace hwFacade
{

    class Client
    {
        public static void ClientCode(Facade facade)
        {
            Console.Write(facade.Operation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            Subsystem3 subsystem3 = new Subsystem3();
            Facade facade = new Facade(subsystem1, subsystem2, subsystem3);
            Client.ClientCode(facade);
            Console.Read();
        }
    }

    public class Subsystem1
    {
        public string operation1()
        {
            return "Клиент: *заказывает доставку на дом*\n";
        }

        public string operationN()
        {
            return "Клиент: *оплатил заказ*\n";
        }
    }

    public class Subsystem2
    {
        public string operation1()
        {
            return "Курьер: *упаковывает товар*\n";
        }

        public string operationZ()
        {
            return "Курьер: *доставил заказ*\n";
        }
    }

    public class Facade
    {
        protected Subsystem1 _subsystem1;

        protected Subsystem2 _subsystem2;

        protected Subsystem3 _subsystem3;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2, Subsystem3 subsystem3)
        {
            this._subsystem1 = subsystem1;
            this._subsystem2 = subsystem2;
            this._subsystem3 = subsystem3;
        }

        // Методы Фасада удобны для быстрого доступа к сложной
        // функциональности подсистем. Однако клиенты получают только часть
        // возможностей подсистемы.
        public string Operation()
        {
            string result = "";
            result += this._subsystem1.operation1();
            result += this._subsystem2.operation1();
            result += this._subsystem3.operation1();
            result += "";
            result += this._subsystem1.operationN();
            result += this._subsystem2.operationZ();
            result += this._subsystem3.operation2();

            return result;
        }
    }
    public class Subsystem3
    {
        public string operation1()
        {
            return "Сервис: *Требует оплатить заказ*\n";
        }
        public string operation2()
        {
            return "Клиент: *Оплатил доставку*\n";
        }

    }
}
