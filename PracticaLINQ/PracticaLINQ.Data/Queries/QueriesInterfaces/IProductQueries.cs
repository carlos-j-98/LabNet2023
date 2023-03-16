using PracticaLINQ.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLINQ.Data.Queries.QueriesInterfaces
{
    public interface IProductQueries
    {
        List<Products> GetProductsNoStock();
        List<Products> GetProductsStockAndThree();
        Products GetProductsFirstOrNullByID();
    }
}
