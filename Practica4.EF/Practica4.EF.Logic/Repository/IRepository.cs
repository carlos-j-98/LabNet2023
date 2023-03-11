namespace Practica4.EF.Logic.Repository
{
    public interface IRepository <T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int _id);
    }
}
