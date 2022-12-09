using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Interfaces.Repositories;
using Domain.Entities;
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