using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.DTO;
using Application.Interfaces;
using Domain.Core.Interfaces.Services;
using Infra.CrossCutting.Adapter.Interfaces;

namespace Application.Service
{
    public class ApplicationServiceMotorista : IApplicationServiceMotorista
    {
        private readonly IServiceMotorista _serviceMotorista;
        private readonly IMapperMotorista _mapperMotorista;

        public ApplicationServiceMotorista(IServiceMotorista serviceMotorista, IMapperMotorista mapperMotorista)
        {
            _serviceMotorista = serviceMotorista;
            _mapperMotorista = mapperMotorista;
        }

        public void Add(MotoristaDTO obj)
        {
            try
            {
                var motorista = _mapperMotorista.MapperToEntity(obj);

                _serviceMotorista.Add(motorista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            _serviceMotorista.Dispose();
        }

        public List<MotoristaDTO> GetAll()
        {
            try
            {
                var lstMotorista = _serviceMotorista.GetAll();

                return _mapperMotorista.MapperListMotorista(lstMotorista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MotoristaDTO GetById(int id)
        {
            try
            {
                var motorista = _serviceMotorista.GetById(id);

                if(motorista == null)
                    return null;
                    
                return _mapperMotorista.MapperToDTO(motorista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(MotoristaDTO obj)
        {
            try
            {
                var motorista = _mapperMotorista.MapperToEntity(obj);

                _serviceMotorista.Remove(motorista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(MotoristaDTO obj)
        {
            try
            {
                var motorista = _mapperMotorista.MapperToEntity(obj);

                _serviceMotorista.Update(motorista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}