using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO.DTO
{
    public class MotoristaDTO
    {
        public MotoristaDTO()
        {            
            Enderecos = new EnderecoDTO();
        }
        
        public int IdMotorista { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public int StatusMotoristaId { get; set; }
        public string DscStatusMotorista { get; set; }
        public int EnderecoId { get; set; }
        
        public EnderecoDTO Enderecos { get; set; }
    }
}