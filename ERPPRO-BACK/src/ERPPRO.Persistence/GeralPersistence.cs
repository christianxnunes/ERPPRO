using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.Domain;
using ERPPRO.Persistence.Contracts;
using ERPPRO.Persistence.Contexto;
using Microsoft.EntityFrameworkCore;

namespace ERPPRO.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly ERPPROContext _context;
        public GeralPersistence(ERPPROContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        
        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}