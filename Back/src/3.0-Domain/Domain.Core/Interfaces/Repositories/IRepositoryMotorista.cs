using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Interfaces.Repositories.Base;
using Domain.Entities;
using Domain.Models;

namespace Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryMotorista : IRepositoryBase<Motorista>
    {
        List<Motorista> GetByFilter(FiltroBuscaMotorista filtro);
    }
}