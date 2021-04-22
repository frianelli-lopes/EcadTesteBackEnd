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

        public void Alterar(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Excluir(Guid id)
        {
            var entity = RecuperarPorId(id);
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public void Incluir(T obj)
        {
            db.Set<T>().Add(obj);
            db.SaveChanges();
        }

        public List<T> Listar()
        {
            return db.Set<T>().ToList();
        }

        public T RecuperarPorId(Guid id)
        {
            return db.Set<T>().Find(id);
        }
    }
}
