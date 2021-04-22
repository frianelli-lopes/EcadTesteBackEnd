using System.Collections.Generic;

namespace EcadTeste.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        List<T> Listar();
        T RecuperarPorId(int id);
        void Incluir(T obj);
        void Alterar(T obj);
        void Excluir(int id);
    }
}
