using System.Collections.Generic;

namespace EcadTeste.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> Listar();
        T RecuperarPorId(int id);
        void Incluir(T obj);
        void Alterar(T obj);
        void Excluir(int id);
    }
}
