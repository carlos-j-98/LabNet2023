using Practica4.EF.Data;
using Practica4.EF.Entities.DTO;
using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.EF.Logic.QueriesLogic
{
    public class TerritoriesLogic : GenericLogic <Territories>
    {
        public override List<Territories> GetAll()
        {
            using (_northwindContext)
            {
                return _northwindContext.Territories.ToList();
            }
        }
    }
}
