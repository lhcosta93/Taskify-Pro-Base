using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taskify_Pro.Domain.Interfaces.Repositories
{
    public interface IGeneralRepo
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteMany<T>(T[] entity) where T : class;

        Task<bool> SaveChangesAsync();
    }
}