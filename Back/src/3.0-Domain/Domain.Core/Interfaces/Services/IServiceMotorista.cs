using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Interfaces.Services.Base;
using Domain.Entities;
using Domain.Models;

namespace Domain.Core.Interfaces.Services
{
    public interface IServiceMotorista : IServiceBase<Motorista>
    {
        List<Motorista> GetByFilter(FiltroBuscaMotorista filtro);
    }
}