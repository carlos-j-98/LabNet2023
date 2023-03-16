using PracticaLINQ.Data.Queries;
using PracticaLINQ.Data.Queries.QueriesInterfaces;
using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using PracticaLINQ.Services.Service.ServicesInterfaces;
using System.Collections.Generic;

namespace PracticaLINQ.Services.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductQueries _productQueries;
        public ProductService()
        {
            _productQueries = new ProductQueries();
        }

        public List<Products> GetNoStockProducts()
        {
            return _productQueries.GetProductsNoStock();
        }

        public Products GetProduct(int productId)
        {
            return _productQueries.GetProductsFirstOrNullByID(productId);
        }

        public Products GetProduct()
        {
            return _productQueries.GetProduct();
        }

        public List<ProductCategoriesDTO> GetProductCategoriesGrupBy()
        {
            return _productQueries.GetProductCategoriesGroupBy();
        }

        public List<Products> GetProductsOrderedByName(bool isAcending)
        {
            return _productQueries.GetProductsOrderByName(isAcending);
        }

        public List<Products> GetProductsOrderedByUnitsInStock(bool isAcending)
        {
            return _productQueries.GetProductsOrderByUnitsInStock(isAcending);
        }

        public List<Products> GetStockProductsStockThreePerUnits()
        {
            return _productQueries.GetProductsStockAndThree();
        }
    }
}
