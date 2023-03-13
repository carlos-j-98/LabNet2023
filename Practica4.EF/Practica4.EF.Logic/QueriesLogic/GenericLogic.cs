using Practica4.EF.Data;
using System.Collections.Generic;

namespace Practica4.EF.Logic.QueriesLogic
{
    public abstract class GenericLogic<T>
    {
        protected readonly NorthwindContext _northwindContext;
        public GenericLogic()
        {
            _northwindContext = new NorthwindContext();
        }
        public virtual List<T> GetAll()
        {
            return new List<T>();
        }
    }
}
