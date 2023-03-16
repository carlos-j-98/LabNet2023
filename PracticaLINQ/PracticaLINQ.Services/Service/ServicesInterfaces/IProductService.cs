using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using System.Collections.Generic;

namespace PracticaLINQ.Services.Service.ServicesInterfaces
{
    public interface IProductService
    {
        List<Products> GetNoStockProducts();
        List<Products> GetStockProductsStockThreePerUnits();
        Products GetProduct(int productId);
        List<Products> GetProductsOrderedByName(bool isAcending);
        List<Products> GetProductsOrderedByUnitsInStock(bool isAcending);
        List<ProductCategoriesDTO> GetProductCategoriesGrupBy();
        Products GetProduct();
    }
}
