using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Framework.Infrastructure
{
    public class BaseRepository<TKey, T> : IRepository<TKey, T> where T : BaseEntity<TKey>
    {
        #region Constructor

        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        #endregion

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public bool IsExist(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Any(condition);
        }

        public T GetBy(TKey id)
        {
            return _context.Find<T>(id);
        }

        public List<T> GetList(Expression<Func<T, bool>> condition = null)
        {
            var query = _context.Set<T>().AsQueryable<T>();

            if(condition is not null)
                query = query.Where(condition);

            return query.ToList();
        }
    }
}