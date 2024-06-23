using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclide(x => x.ProductType);
            AddInclide(x => x.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclide(x => x.ProductType);
            AddInclide(x => x.ProductBrand);
        }
    }
}