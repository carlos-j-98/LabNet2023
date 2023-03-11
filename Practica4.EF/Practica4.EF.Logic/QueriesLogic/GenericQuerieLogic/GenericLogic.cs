using Practica4.EF.Data;
using Practica4.EF.Entities.DTO;
using System.Collections.Generic;

namespace Practica4.EF.Logic.QueriesLogic.GenericQuerieLogic
{
    public abstract class GenericLogic
    {
        protected readonly NorthwindContext _northwindContext;
        public GenericLogic()
        {
            _northwindContext = new NorthwindContext();
        }
        public abstract List<GenericDTO> GetAll();
    }
}
