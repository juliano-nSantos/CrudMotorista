using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO.DTO
{
    public class PermissaoDTO
    {
        public int IdPermissao { get; set; }
        public string NomePermissao { get; set; }
        public bool Ativo { get; set; }
    }
}