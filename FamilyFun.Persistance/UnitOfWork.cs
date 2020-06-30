using System;
using System.Collections.Generic;

namespace FamilyFun.Persistance
{
    public class UnitOfWork
    {
        public IDictionary<Type, object> repositories = new Dictionary<Type, object>();


        //public IAsyncRepository<T> Repository<T>() 
        //{
        //    if (repositories.Keys.Contains(typeof(T)) == true)
        //    {
        //        return repositories[typeof(T)] as IAsyncRepository<T>;
        //    }

        //    IAsyncRepository<T> repo = new JsonRepository<T>();
        //    repositories.Add(typeof(T), repo);
        //    return repo;
        //}

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
