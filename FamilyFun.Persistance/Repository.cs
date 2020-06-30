using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FamilyFun.Persistance
{
    public interface IAsyncRepository<TEntity>
    {
        Task InsertAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllWhereAsync(Func<TEntity, bool> predicate);
        Task<TEntity> GetOneAsync(string id);
        Task<bool> UpdateAsync(TEntity entity);
    }

    public class Repository<TEntity> : IAsyncRepository<TEntity>
    {
        private readonly Lazy<Task<ICollection<TEntity>>> _entities;
        private readonly IPersistor<TEntity> _persistor;

        public Repository(IPersistor<TEntity> persistor)
        {
            _persistor = persistor ?? throw new ArgumentNullException(nameof(persistor));

            _entities = new Lazy<Task<ICollection<TEntity>>>(async () =>
            {
                return await _persistor.RetrievePersistedDataAsync();
            });
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.Value;
        }

        public async Task<IEnumerable<TEntity>> GetAllWhereAsync(Func<TEntity, bool> predicate)
        {
            return (await GetAllAsync()).Where(predicate);
        }

        public async Task<TEntity> GetOneAsync(string id)
        {
            return (await GetAllWhereAsync(e => GetEntityId(e) == id)).Single();
        }

        protected virtual string GetEntityId(TEntity entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            PropertyInfo? idProperty = entity.GetType().GetProperty("Id");

            if (idProperty is null)
            {
                throw new InvalidOperationException("Id not found for entity");
            }

            return (string)idProperty.GetValue(entity);
        }

        public async Task InsertAsync(TEntity entity)
        {
            (await _entities.Value).Add(entity);
            await _persistor.PersistAsync(await _entities.Value);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            string id = GetEntityId(entity);

            TEntity existingEntity;

            try
            {
                existingEntity = await GetOneAsync(id);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
                
            if(!(await _entities.Value).Remove(existingEntity))
            {
                return false;
            }

            (await _entities.Value).Add(entity);

            await _persistor.PersistAsync(await _entities.Value);

            return true;
        }
    }
}
