using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Products
{
    public class ProductViewModel
    {
        [DisplayName("Id number")]
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Cost to customer")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Description of the product")]
        public string Description { get; set; }

    }
}
