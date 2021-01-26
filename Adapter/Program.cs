using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
        }
    }

    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("FK Logu loglandı.");
            Console.WriteLine("Saved");
        }
    }

    interface ILogger
    {
        void Log(string message);

    }

    class FkLogger:ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("FK Logger {0}", message);
        }
    }

    //Nuget
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with Log4Net, {0}",message);
        }
    }

    class Log4NetAdapter:ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}
