using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Interfaces.Repositories;
using Domain.Core.Interfaces.Services;
using Domain.Entities;
using Domain.Services.Extensions;
using Domain.Services.Services.Base;

namespace Domain.Services.Services
{
    public class ServiceMotorista : ServiceBase<Motorista>, IServiceMotorista
    {
        private readonly IRepositoryMotorista _repository;

        public ServiceMotorista(IRepositoryMotorista repository)
                : base(repository)
        {
            _repository = repository;
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