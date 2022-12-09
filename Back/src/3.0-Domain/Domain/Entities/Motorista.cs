using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Motorista
    {
        public int IdMotorista { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public int StatusMotoristaId { get; set; }
        public int EnderecoId { get; set; }

        public StatusMotorista StatusMotoristas { get; set; }
        public Endereco Enderecos { get; set; }
    }
}