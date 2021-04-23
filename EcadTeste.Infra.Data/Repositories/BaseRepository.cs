using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Models;
using EcadTeste.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcadTeste.Infra.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly EcadTesteContext Db;
        protected readonly DbSet<T> DbSet;

        protected BaseRepository(EcadTesteContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }

        public virtual T RecuperarPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual List<T> Listar()
        {
            return DbSet.ToList();
        }

        public virtual void Incluir(T entity)
        {
            DbSet.Add(entity);
            SaveChanges();
        }

        public virtual void Alterar(T entity)
        {
            DbSet.Update(entity);
            SaveChanges();
        }

        public virtual void Excluir(Guid id)
        {
            var entity = RecuperarPorId(id);
            DbSet.Remove(entity);
            SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
