using PracticaLINQ.Data.Context;
using PracticaLINQ.Data.Queries.QueriesInterfaces;
using PracticaLINQ.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLINQ.Data.Queries
{
    public class ProductQueries : IProductQueries
    {
        private readonly NorthwindContext _northwindContext;
        public ProductQueries()
        {
            this._northwindContext = new NorthwindContext();
        }

        public Products GetProductsFirstOrNullByID()
        {
            var productList = _northwindContext.Products.ToList();
            return productList.FirstOrDefault(x => x.ProductID == 789);
        }

        public List<Products> GetProductsNoStock()
        {
            return _northwindContext.Products
                .Where(x => x.UnitsInStock == 0 || x.UnitsInStock == null)
                .ToList();
        }

        public List<Products> GetProductsStockAndThree()
        {
            return _northwindContext.Products
                .Where(x => ( x.UnitsInStock != 0 || x.UnitsInStock == null) && x.UnitPrice > 3)
                .ToList();
        }
    }
}
