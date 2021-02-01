using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;

namespace FamilyFun.Persistance
{
    public interface IPersistor<TEntity>
    {
        Task<ICollection<TEntity>> RetrievePersistedDataAsync();
        Task PersistAsync(ICollection<TEntity> entities);
    }

    public class JsonPersistor<TEntity> : IPersistor<TEntity>
    {
        private readonly string _filePath;

        public JsonPersistor(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public async Task<ICollection<TEntity>> RetrievePersistedDataAsync()
        {
            if (!File.Exists(_filePath))
            {
                using Stream newFileStream = File.OpenWrite(_filePath);
                List<TEntity> enities = new List<TEntity>();
                await JsonSerializer.SerializeAsync(newFileStream, enities);
                return enities;
            }

            using Stream stream = File.OpenRead(_filePath);
            return await JsonSerializer.DeserializeAsync<List<TEntity>>(stream);
        }

        public async Task PersistAsync(ICollection<TEntity> entities)
        {

            using Stream stream = File.OpenWrite(_filePath);
            await JsonSerializer.SerializeAsync(stream, entities);
        }
    }

    public class BinaryPersistor<TEntity> : IPersistor<TEntity>
    {
        private readonly string _filePath;

        public BinaryPersistor(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public async Task<ICollection<TEntity>> RetrievePersistedDataAsync()
        {
            if (!File.Exists(_filePath))
            {
                ICollection<TEntity> enities = new List<TEntity>();
                await PersistAsync(enities);                
                return enities;
            }

            IFormatter formatter = new BinaryFormatter();
            using Stream stream = File.OpenRead(_filePath); 
            return (ICollection<TEntity>)formatter.Deserialize(stream);
        }

        public Task PersistAsync(ICollection<TEntity> entities)
        {
            using Stream stream = File.OpenWrite(_filePath);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, entities);
            return Task.CompletedTask;
        }
    }
}