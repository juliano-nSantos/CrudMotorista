using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.DTO;

namespace API.Models
{
    public class ResponseMotorista
    {
        public List<MotoristaDTO> lstMotoristas { get; set; }
    }
}