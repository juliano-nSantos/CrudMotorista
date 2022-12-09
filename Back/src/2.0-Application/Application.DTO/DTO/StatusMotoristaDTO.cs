using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO.DTO
{
    public class StatusMotoristaDTO
    {
        public int IdStatusMotorista { get; set; }
        public string DscStatusMotorista { get; set; }
        public bool Ativo { get; set; }
    }
}