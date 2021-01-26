using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            
            
        }
    }

    class Logging : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }

    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("Checked");
        }
    }

    class Validation : IValidation
    {


        public void Validate()
        {
            Console.WriteLine("Validated");
        }
    }




    public interface ILogger
    {
        void Log();
    }

    public interface ICaching
    {
        public void Cache();
    }

    internal interface IAuthorize
    {
        public void CheckUser();
    }

    public interface IValidation
    {
        void Validate();
    }




    class CustomerManager
    {
        private CrossCuttingConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            _concerns.Logger.Log();
            _concerns.Validation.Validate();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogger Logger;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidation Validation;

        public CrossCuttingConcernsFacade()
        {
            Logger = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validation = new Validation();
        }
    }
}
