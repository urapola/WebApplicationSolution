using Bogus;
using WebApplication.Models.Products;

namespace WebApplication.Models.Services
{
    public class HardCodedSampleDataRepository : IProductDataService
    {

        static List<ProductViewModel> productsList = new List<ProductViewModel>();

        public int Delete(ProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> GetAllProducts()
        {
            if (productsList.Count == 0) 
            {
                productsList.Add(new ProductViewModel { Id = 1, Name = "Mouse Pad", Price = 5.99m, Description = "Pices of mouse pad to help work better" });
                productsList.Add(new ProductViewModel { Id = 2, Name = "Web Cam", Price = 45.50m, Description = "Zoom meetting is better" });
                productsList.Add(new ProductViewModel { Id = 3, Name = "4 TB USB", Price = 130.99m, Description = "Backup your data" });
                productsList.Add(new ProductViewModel { Id = 4, Name = "Wireless Mouse", Price = 15.99m, Description = "Notebook works good" });

                for (int i = 0; i < 100; i++)
                {
                    productsList.Add(new Faker<ProductViewModel>()
                        .RuleFor(p => p.Id, i + 5)
                        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                        .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                        .RuleFor(p => p.Description, f => f.Rant.Review()));
                }
            }


            return productsList;
        }

        public ProductViewModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductViewModel product)
        {
            throw new NotImplementedException();
        }
    }
}
