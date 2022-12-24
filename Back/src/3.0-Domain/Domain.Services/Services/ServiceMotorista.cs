using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Extensions;
using Domain.Core.Interfaces.Repositories;
using Domain.Core.Interfaces.Services;
using Domain.Core.Interfaces.Validations;
using Domain.Entities;
using Domain.Models;
using Domain.Services.Services.Base;

namespace Domain.Services.Services
{
    public class ServiceMotorista : ServiceBase<Motorista>, IServiceMotorista
    {
        private readonly IRepositoryMotorista _repository;
        private readonly IValidationModel<FiltroBuscaMotorista> _validateFiltroMotorista;

        public ServiceMotorista(IRepositoryMotorista repository, 
                            IValidationModel<FiltroBuscaMotorista> validateFiltroMotorista)
                : base(repository)
        {
            _repository = repository;
            _validateFiltroMotorista = validateFiltroMotorista;
        }

        public override void Add(Motorista obj)
        {
            try
            {
                obj.CPF = obj.CPF.RemoveDotsDashBars();
                obj.Enderecos.Cep = obj.Enderecos.Cep.RemoveDotsDashBars();
                 
                if(obj.CPF.IsValidCpf())
                {
                    _repository.Add(obj);
                }
                else
                {
                    throw new ArgumentException("CPF Inválido!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Motorista> GetByFilter(FiltroBuscaMotorista filtro)
        {
            try
            {
                if(_validateFiltroMotorista.ValidateModel(filtro))
                {
                    filtro.CPF = filtro.CPF.RemoveDotsDashBars();

                    return _repository.GetByFilter(filtro);
                }
                else
                {
                    throw new ArgumentException("Preencha ao menos um dos filtros de busca");
                }
                
            }
            catch (ArgumentException ax)
            {
                throw ax;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Remove(Motorista obj)
        {
            try
            {
                var motorista = _repository.GetById(obj.IdMotorista);

                if(motorista != null)
                {
                    _repository.Remove(obj);
                }
                else
                {
                    throw new Exception("Erro ao excluir o Motorista");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Update(Motorista obj)
        {
            try
            {
                var motorista = _repository.GetById(obj.IdMotorista);

                if(motorista != null)
                {
                    obj.Enderecos.Cep = obj.Enderecos.Cep.RemoveDotsDashBars();
                    _repository.Update(obj);
                }
                else
                {
                    throw new Exception("Erro ao atualizar o Motorista");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}