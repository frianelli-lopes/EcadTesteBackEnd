using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcadTeste.Infra.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected EcadTesteContext db;

        public BaseRepository(EcadTesteContext context)
        {
            db = context;
        }

        public virtual void Alterar(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public virtual void Excluir(Guid id)
        {
            var entity = RecuperarPorId(id);
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public virtual void Incluir(T obj)
        {
            db.Set<T>().Add(obj);
            db.SaveChanges();
        }

        public virtual List<T> Listar()
        {
            return db.Set<T>().ToList();
        }

        public virtual T RecuperarPorId(Guid id)
        {
            return db.Set<T>().Find(id);
        }
    }
}
