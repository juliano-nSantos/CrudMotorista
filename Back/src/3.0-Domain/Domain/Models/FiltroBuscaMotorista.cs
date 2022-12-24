using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Serializable]
    public class FiltroBuscaMotorista
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public int? StatusMotorista { get; set; }
        public int? AnoNascimentoInicial { get; set; }
        public int? AnoNascimentoFinal { get; set; }
    }
}