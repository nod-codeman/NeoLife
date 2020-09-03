using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{   
    // Using a single repository for all
    public interface IProductRepository
    {
        // using IReadOnlyList ensures that the data can only be read
        Task<IReadOnlyList<Product>> GetProductAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        Task<Product> GetProductByIdAsync(int id);
    }
}