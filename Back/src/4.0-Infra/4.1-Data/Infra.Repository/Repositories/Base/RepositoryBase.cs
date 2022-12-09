using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Interfaces.Repositories.Base;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Repositories.Base
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext _context;

        public RepositoryBase(SqlContext context)
        {
            _context = context;
        }

        public virtual void Add(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {                
                throw new Exception("Erro ao cadastrar : " + ex.Message);
            }            
        }        

        public virtual List<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Consultar : " + ex.Message);
            }            
        }

        public virtual TEntity GetById(int id)
        {
            try
            {
                return _context.Set<TEntity>().Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Consultar por código : " + ex.Message);
            }
        }

        public virtual void Remove(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir : " + ex.Message);
            }
        }

        public virtual void Update(TEntity obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar : " + ex.Message);
            }
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}