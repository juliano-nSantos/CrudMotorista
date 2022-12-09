using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StatusMotorista
    {
        public int IdStatusMotorista { get; set; }
        public string DscStatusMotorista { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Motorista> Motoristas { get; set; }
    }
}