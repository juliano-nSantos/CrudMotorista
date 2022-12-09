using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.DTO;
using Domain.Entities;

namespace Infra.CrossCutting.Adapter.Interfaces
{
    public interface IMapperMotorista
    {
        Motorista MapperToEntity(MotoristaDTO motoristaDTO);
        List<MotoristaDTO> MapperListMotorista(List<Motorista> lstMotoristas);
        MotoristaDTO MapperToDTO(Motorista motorista);
    }
}