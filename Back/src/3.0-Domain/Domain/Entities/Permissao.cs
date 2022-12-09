using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Permissao
    {
        public int IdPermissao { get; set; }
        public string NomePermissao { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}