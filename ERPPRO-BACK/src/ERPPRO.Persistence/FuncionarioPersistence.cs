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
    public class FuncionarioPersistence : IFuncionarioPersistence
    {
        private readonly ERPPROContext _context;
        public FuncionarioPersistence(ERPPROContext context)
        {
            _context = context;
        }
        public async Task<Funcionario[]> GetAllFuncionariosAsync()
        {
            IQueryable<Funcionario> query = _context.Funcionarios;
            query = query.OrderBy(f => f.Id);
            return await query.ToArrayAsync();
        }
        public async Task<Funcionario> GetIdFuncionarioAsync(int funcionarioId)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;
            query = query.OrderBy(f => f.Id).Where(f => f.Id == funcionarioId);
            return await query.FirstOrDefaultAsync();
        }
    }
}