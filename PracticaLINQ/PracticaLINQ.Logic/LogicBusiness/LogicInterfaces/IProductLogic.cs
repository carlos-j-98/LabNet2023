using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using System.Collections.Generic;

namespace PracticaLINQ.Logic.LogicBusiness.LogicInterfaces
{
    public interface IProductLogic
    {
        List<Products> GetNoStockProducts();
        List<Products> GetStockProductsStockThreePerUnits();
        Products GetProduct(int productId);
        List<Products> GetProductsOrderedByName(bool isAcending);
        List<Products> GetProductsOrderedByUnitsInStock(bool isAcending);
        List<ProductCategoriesDTO> GetProductCategoriesGrupBy();
        Products GetOneProduct();
    }
}
