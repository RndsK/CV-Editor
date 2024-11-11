using CV.Core.Models;
using CV.Core.Services;
using CV.Data;

namespace CV.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(CvDbContext context) : base(context)
        {

        }
        public T? GetById(int id)
        {
            return GetById<T>(id);
        }
        public ServiceResult Create(T entity)
        {
            return Create<T>(entity);
        }
        public ServiceResult Delete(T entity)
        {
            return Delete<T>(entity);
        }
        public ServiceResult Update(T entity)
        {
            return Update<T>(entity);
        }
        public IEnumerable<T> List()
        {
            return List<T>();
        }
    }
}
