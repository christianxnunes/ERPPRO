using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.Domain;

namespace ERPPRO.Persistence.Contracts
{
    public interface IFuncionarioPersistence
    {
        Task<Funcionario[]> GetAllFuncionariosAsync();
    }
}