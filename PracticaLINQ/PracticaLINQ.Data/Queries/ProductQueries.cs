using PracticaLINQ.Data.Context;
using PracticaLINQ.Data.Queries.QueriesInterfaces;
using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using System.Collections.Generic;
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
            return prodList.FirstOrDefault();
        }

        public List<ProductCategoriesDTO> GetProductCategoriesGroupBy()
        {
            var prodCate = (from c in _northwindContext.Categories
                            join p in _northwindContext.Products on c.CategoryID equals p.CategoryID
                            group p by c.CategoryName into g
                            select new
                            {
                                CategoryName = g.Key,
                                Products = g.Select(p => p.ProductName).ToList()
                            }).ToList();
            var result = prodCate.ToList().Select(x => new ProductCategoriesDTO
            {
                categoryName = x.CategoryName,
                productName = string.Join(",", x.Products)
            }).ToList();
            return result;
        }

        public Products GetProductsFirstOrNullByID(int productID)
        {
            var productList = _northwindContext.Products.ToList();
            return productList.FirstOrDefault(x => x.ProductID == productID);
        }

        public List<Products> GetProductsNoStock()
        {
            return _northwindContext.Products
                .Where(x => x.UnitsInStock == 0 || x.UnitsInStock == null)
                .ToList();
        }

        public List<Products> GetProductsOrderByName(bool isAcending)
        {
            var products = (from p in _northwindContext.Products
                            orderby p.ProductName ascending
                            select p);
            if (!isAcending)
            {
                products = products.OrderByDescending(x => x.ProductName);
            }
            return products.ToList();
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
            return products.ToList();
        }

        public List<Products> GetProductsStockAndThree()
        {
            return _northwindContext.Products
                .Where(x => (x.UnitsInStock != 0 || x.UnitsInStock == null) && x.UnitPrice > 3)
                .ToList();
        }
    }
}
