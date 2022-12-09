using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.DTO;
using Domain.Entities;
using Infra.CrossCutting.Adapter.Interfaces;

namespace Infra.CrossCutting.Adapter.Map
{
    public class MapperMotorista : IMapperMotorista
    {
        private List<MotoristaDTO> lstMotoristasDto = new List<MotoristaDTO>();

        public List<MotoristaDTO> MapperListMotorista(List<Motorista> lstMotoristas)
        {
            if (lstMotoristas != null)
            {
                foreach (var item in lstMotoristas)
                {
                    lstMotoristasDto.Add(new MotoristaDTO
                    {
                        IdMotorista = item.IdMotorista,
                        Nome = item.Nome,
                        CPF = item.CPF,
                        Sexo = item.Sexo,
                        StatusMotoristaId = item.StatusMotoristas.IdStatusMotorista,
                        DscStatusMotorista = item.StatusMotoristas.DscStatusMotorista,
                    });
                }
            }

            return lstMotoristasDto;
        }

        public MotoristaDTO MapperToDTO(Motorista motorista)
        {            
            var motoristaDto = new MotoristaDTO
            {
                IdMotorista = motorista.IdMotorista,
                Nome = motorista.Nome,
                CPF = motorista.CPF,
                Sexo = motorista.Sexo,
                DataNascimento = motorista.DataNascimento,
                StatusMotoristaId = motorista.StatusMotoristaId,
                DscStatusMotorista = motorista.StatusMotoristas.DscStatusMotorista,
                EnderecoId = motorista.EnderecoId,
                Enderecos = new EnderecoDTO
                {
                    IdEndereco = motorista.Enderecos.IdEndereco,
                    Logradouro = motorista.Enderecos.Logradouro,
                    Numero = motorista.Enderecos.Numero,
                    Bairro = motorista.Enderecos.Bairro,
                    Cidade = motorista.Enderecos.Cidade,
                    UF = motorista.Enderecos.UF,
                    Cep = motorista.Enderecos.Cep
                }
            };

            return motoristaDto;
        }

        public Motorista MapperToEntity(MotoristaDTO motoristaDTO)
        {
            var motorista = new Motorista
            {
                Nome = motoristaDTO.Nome,
                CPF = motoristaDTO.CPF,
                Sexo = motoristaDTO.Sexo,
                DataNascimento = motoristaDTO.DataNascimento,
                StatusMotoristaId = motoristaDTO.StatusMotoristaId,
                EnderecoId = motoristaDTO.EnderecoId,
                Enderecos = new Endereco
                {
                    Logradouro = motoristaDTO.Enderecos.Logradouro,
                    Numero = motoristaDTO.Enderecos.Numero,
                    Bairro = motoristaDTO.Enderecos.Bairro,
                    Cidade = motoristaDTO.Enderecos.Cidade,
                    UF = motoristaDTO.Enderecos.UF,
                    Cep = motoristaDTO.Enderecos.Cep
                }
            };

            return motorista;
        }
    }
}