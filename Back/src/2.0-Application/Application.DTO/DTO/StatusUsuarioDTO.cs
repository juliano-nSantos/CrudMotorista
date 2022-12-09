using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO.DTO
{
    public class StatusUsuarioDTO
    {
        public int IdStatusUsuario { get; set; }
        public string DscStatusUsuario { get; set; }
        public bool Ativo { get; set; }
    }
}