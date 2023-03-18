using PracticaLINQ.Data.Queries;
using PracticaLINQ.Data.Queries.QueriesInterfaces;
using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using PracticaLINQ.Logic.LogicBusiness.LogicInterfaces;
using System.Collections.Generic;

namespace PracticaLINQ.Logic.LogicBusiness
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductQueries _productQueries;
        public ProductLogic()
        {
            _productQueries = new ProductQueries();
        }
        public ProductLogic(IProductQueries productQueries)
        {
            _productQueries = productQueries;
        }

        public List<Products> GetNoStockProducts()
        {
            return _productQueries.GetProductsNoStock();
        }

        public Products GetProduct(int productId)
        {
            return _productQueries.GetProductsFirstOrNullByID(productId) ?? null;
        }

        public Products GetOneProduct()
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
