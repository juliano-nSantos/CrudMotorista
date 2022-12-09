using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StatusUsuario
    {
        public int IdStatusUsuario { get; set; }
        public string DscStatusUsuario { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}