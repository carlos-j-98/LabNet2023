using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using System.Collections.Generic;

namespace PracticaLINQ.Data.Queries.QueriesInterfaces
{
    public interface IProductQueries
    {
        List<Products> GetProductsNoStock();
        List<Products> GetProductsStockAndThree();
        Products GetProductsFirstOrNullByID(int productID);
        List<Products> GetProductsOrderByName(bool isAcending);
        List<Products> GetProductsOrderByUnitsInStock(bool isAcending);
        List<ProductCategoriesDTO> GetProductCategoriesGroupBy();
        Products GetProduct();
    }
}
