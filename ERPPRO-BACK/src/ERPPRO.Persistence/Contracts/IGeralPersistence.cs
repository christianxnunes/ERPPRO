using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPPRO.Persistence.Contracts
{
    public interface IGeralPersistence
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T[] entity) where T: class;
        Task<bool> SaveChangeAsync();
    }
}