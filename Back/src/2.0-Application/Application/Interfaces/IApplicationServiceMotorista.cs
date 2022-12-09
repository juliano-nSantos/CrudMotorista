using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.DTO;

namespace Application.Interfaces
{
    public interface IApplicationServiceMotorista
    {
        void Add(MotoristaDTO obj);
        MotoristaDTO GetById(int id);
        List<MotoristaDTO> GetAll();
        void Update(MotoristaDTO obj);
        void Remove(MotoristaDTO obj);
        void Dispose();
    }
}