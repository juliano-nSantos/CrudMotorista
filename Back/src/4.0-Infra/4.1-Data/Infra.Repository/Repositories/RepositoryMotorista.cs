using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Extensions;
using Domain.Core.Interfaces.Repositories;
using Domain.Entities;
using Domain.Models;
using Infra.Data;
using Infra.Repository.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Repositories
{
    public class RepositoryMotorista : RepositoryBase<Motorista>, IRepositoryMotorista
    {
        private readonly SqlContext _context;

        public RepositoryMotorista(SqlContext context)
                    : base(context)
        {
            _context = context;
        }

        public override List<Motorista> GetAll()
        {
            try
            {
                 
                return _context.Motoristas
                               .Include(sm => sm.StatusMotoristas)
                               .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Consultar todos os motoristas : " + ex.Message);
            }  
        }

        public List<Motorista> GetByFilter(FiltroBuscaMotorista filtro)
        {
            try
            {
                IQueryable<Motorista> query = _context.Motoristas
                                    .Include(sm => sm.StatusMotoristas).IgnoreQueryFilters();

                if(filtro.CPF.NotIsNullOrEmpty())
                    query = query.Where(m => m.CPF == filtro.CPF);
                if(filtro.Nome.NotIsNullOrEmpty())
                    query = query.Where(m => m.Nome.Contains(filtro.Nome));
                if(filtro.Sexo.NotIsNullOrEmpty())
                    query = query.Where(m => m.Sexo == filtro.Sexo);
                if(filtro.StatusMotorista.NotIsNullOrGreaterThanZero())
                    query = query.Where(m => m.StatusMotoristaId == filtro.StatusMotorista);
                if(filtro.AnoNascimentoInicial.NotIsNullOrGreaterThanZero())
                    query = query.Where(m => m.DataNascimento.Year >= filtro.AnoNascimentoInicial);
                if(filtro.AnoNascimentoFinal.NotIsNullOrGreaterThanZero())
                    query = query.Where(m => m.DataNascimento.Year <= filtro.AnoNascimentoFinal);
                
                return query.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao Consultar motoristas por filtro: " + ex.Message);
            }
        }

        public override Motorista GetById(int id)
        {
            try
            {                
                return  _context.Motoristas
                               .Include(sm => sm.StatusMotoristas)
                               .Include(e => e.Enderecos)
                               .Where(m => m.IdMotorista == id)
                               .FirstOrDefault();                              
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Consultar por código : " + ex.Message);
            }
        }
    }
}