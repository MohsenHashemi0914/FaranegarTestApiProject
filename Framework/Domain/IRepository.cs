using System.Linq.Expressions;

namespace Framework.Domain
{
    public interface IRepository<in TKey, T> where T : BaseEntity<TKey>
    {
        void SaveChanges();
        void Add(T entity);
        bool IsExist(Expression<Func<T, bool>> condition);
        T GetBy(TKey id);
        List<T> GetList(Expression<Func<T, bool>> condition = null);
    }
}