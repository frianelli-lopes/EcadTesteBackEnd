using System;
using System.Collections.Generic;

namespace EcadTeste.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> Listar();
        T RecuperarPorId(Guid id);
        void Incluir(T obj);
        void Alterar(T obj);
        void Excluir(Guid id);
    }
}
