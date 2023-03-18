using PracticaLINQ.Data.Context;
using PracticaLINQ.Data.Queries.QueriesInterfaces;
using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using PracticaLINQ.Services.CustomExceptions;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace PracticaLINQ.Data.Queries
{
    public class ProductQueries : IProductQueries
    {
        private readonly NorthwindContext _northwindContext;
        public ProductQueries()
        {
            this._northwindContext = new NorthwindContext();
        }

        public Products GetProduct()
        {
            var prodList = _northwindContext.Products;
            return prodList
                .FirstOrDefault() ?? throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
        }

        public List<ProductCategoriesDTO> GetProductCategoriesGroupBy()
        {
            var categories = _northwindContext.Categories
                                .Where(c => c.Products.Any())
                                .Select(c => new ProductCategoriesDTO { categoryName = c.CategoryName })
                                .Distinct()
                                .ToList();
            return categories ?? throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
        }

        public Products GetProductsFirstOrNullByID(int productID)
        {
            var productList = _northwindContext.Products.ToList();
            var produc = productList
                .FirstOrDefault(x => x.ProductID == productID);
            return produc ?? null;
        }

        public List<Products> GetProductsNoStock()
        {
            return _northwindContext.Products
                .Where(x => x.UnitsInStock == 0 || x.UnitsInStock == null)
                .ToList() ?? throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
        }

        public List<Products> GetProductsOrderByName(bool isAcending)
        {
            var products = (from p in _northwindContext.Products
                            orderby p.ProductName ascending
                            select p);
            if (!isAcending)
            {
                products = products
                    .OrderByDescending(x => x.ProductName);
            }
            return products
                .ToList() ?? throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
        }

        public List<Products> GetProductsOrderByUnitsInStock(bool isAcending)
        {
            var products = (from p in _northwindContext.Products
                            orderby p.UnitsInStock descending
                            select p);
            if (!isAcending)
            {
                products = products.OrderBy(x => x.UnitsInStock);
            }
            return products
                .ToList() ?? throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
        }

        public List<Products> GetProductsStockAndThree()
        {
            return _northwindContext.Products
                .Where(x => (x.UnitsInStock != 0 || x.UnitsInStock == null) && x.UnitPrice > 3)
                .ToList() ?? throw new IsNullOrEmptyException(ConfigurationManager.AppSettings["invalidOperationProdText"]);
        }
    }
}
