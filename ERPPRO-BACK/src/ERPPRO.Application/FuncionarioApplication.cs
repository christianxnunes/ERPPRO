using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.Application.Contracts;
using ERPPRO.Domain;
using ERPPRO.Persistence;
using ERPPRO.Persistence.Contracts;

namespace ERPPRO.Application
{
    public class FuncionarioApplication : IFuncionarioApplication
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IFuncionarioPersistence _funcionarioPersistence;

        public FuncionarioApplication(IGeralPersistence geralPersistence, IFuncionarioPersistence funcionarioPersistence)
        {
            _geralPersistence = geralPersistence;
            _funcionarioPersistence = funcionarioPersistence;
        }


        public async Task<Funcionario> AddFuncionarios(Funcionario model)
        {
            try
            {
                _geralPersistence.Add<Funcionario>(model);
                if(await _geralPersistence.SaveChangeAsync())
                {
                    return model;
                }
                return null;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Funcionario> UpdateFuncionarios(int funcionarioId, Funcionario model)
        {
            try
            {
                var funcionario = await _funcionarioPersistence.GetIdFuncionarioAsync(funcionarioId);
                if (funcionario == null) return null;

                model.Id = funcionario.Id;

                _geralPersistence.Update(model);
                if(await _geralPersistence.SaveChangeAsync())
                {
                    return model;
                }
                return null;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteFuncionarios(int funcionarioId)
        {
            try
            {
                var funcionario = await _funcionarioPersistence.GetIdFuncionarioAsync(funcionarioId);
                if (funcionario == null) throw new Exception("Registro não encontrado!");


                _geralPersistence.Delete<Funcionario>(funcionario);
                return await _geralPersistence.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Funcionario[]> GetAllFuncionariosAsync()
        {
            try
            {
                var funcionarios = await _funcionarioPersistence.GetAllFuncionariosAsync();
                if (funcionarios == null) return null;

                return funcionarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Funcionario> GetIdFuncionarioAsync(int funcionarioId)
        {
            try
            {
                var funcionario = await _funcionarioPersistence.GetIdFuncionarioAsync(funcionarioId);
                if (funcionario == null) return null;

                return funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}