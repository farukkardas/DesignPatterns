using System;

namespace Builder
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            productDirector.GenerateProduct(builder);
            builder.GModel();
            Console.WriteLine(builder.GModel().Id);
            Console.WriteLine(builder.GModel().ProductName);

            Console.WriteLine(builder.GModel().CategoryName);
            
            Console.WriteLine(builder.GModel().DiscountedPrice);


        }
    }
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }

    }


    public abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GModel();

    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        private ProductViewModel model = new ProductViewModel();

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Phone";
            model.ProductName = "Apple";
            model.UnitPrice = 3500;
            
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal) 0.90;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GModel()
        {
            return model;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        private ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Phone";
            model.ProductName = "Apple";
            model.UnitPrice = 3500;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GModel()
        {
            return model;
        }
    }

    public class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
