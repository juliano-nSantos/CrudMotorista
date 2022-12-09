using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO.DTO
{
    public class UsuarioDTO
    {

        public UsuarioDTO()
        {
            Permissoes = new PermissaoDTO();
            StatusUsuarios = new StatusUsuarioDTO();
            Enderecos = new EnderecoDTO();
        }

        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool PrimeiroAcesso { get; set; }
        public int PermissaoId { get; set; }
        public int StatusUsuarioId { get; set; }
        public int EnderecoId { get; set; }

        public PermissaoDTO Permissoes { get; set; }
        public StatusUsuarioDTO StatusUsuarios { get; set; }
        public EnderecoDTO Enderecos { get; set; }
    }
}