using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.Domain;

namespace ERPPRO.Application.Contracts
{
    public interface IFuncionarioApplication
    {
        Task<Funcionario> AddFuncionarios(Funcionario model);
        Task<Funcionario> UpdateFuncionarios(int funcionarioId, Funcionario model);
        Task<bool> DeleteFuncionarios(int funcionarioId);
        Task<Funcionario[]> GetAllFuncionariosAsync();
        Task<Funcionario> GetIdFuncionarioAsync(int funcionarioId);
    }
}