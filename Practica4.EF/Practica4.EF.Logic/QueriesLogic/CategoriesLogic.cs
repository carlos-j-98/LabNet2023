using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.EF.Logic.QueriesLogic
{
    public class CategoriesLogic : GenericLogic<Categories>
    {
        public override List<Categories> GetAll()
        {
            using (_northwindContext)
            {
                return _northwindContext.Categories.ToList();
            }
        }
    }
}
