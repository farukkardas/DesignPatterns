using System;

namespace AbstractFactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();
        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public class NLogger:Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with NLogger");
        }
    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache:Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with RedisCache");
        }
    }

    public abstract class CrossCuttingConcernFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1:CrossCuttingConcernFactory
    {
        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }


        public override Caching CreateCaching()
        {
            return new RedisCache();
        }
    }
    public class Factory2 : CrossCuttingConcernFactory
    {
        public override Logging CreateLogger()
        {
            return new NLogger();
        }


        public override Caching CreateCaching()
        {
            return new MemCache();
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernFactory _crossCuttingConcern;

        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernFactory crossCuttingConcern)
        {
            _crossCuttingConcern = crossCuttingConcern;
            _logging = _crossCuttingConcern.CreateLogger();
            _caching = _crossCuttingConcern.CreateCaching();
        }

        public void GetAll()
        {
           _logging.Log("Logged");
           _caching.Cache("Cached");
            Console.WriteLine("Listed.");
        }


    }
}
