using WebApplication.Models.Products;

namespace WebApplication.Models.Services
{
    public interface IProductDataService
    {
        List<ProductViewModel> GetAllProducts();
        List<ProductViewModel> SearchProducts(string searchTerm);

        ProductViewModel GetProductById(int id);

        int Insert(ProductViewModel product);
        int Update(ProductViewModel product);
        int Delete(ProductViewModel product);

    }
}
