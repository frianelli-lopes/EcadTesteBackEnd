using EcadTeste.Domain.Interfaces.Repositories;
using EcadTeste.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace EcadTeste.Service
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        
        public void Alterar(T obj)
        {
            _repository.Alterar(obj);
        }

        public void Excluir(int id)
        {
            _repository.Excluir(id);
        }

        public void Incluir(T obj)
        {
            _repository.Incluir(obj);
        }

        public List<T> Listar()
        {
            return _repository.Listar();
        }

        public T RecuperarPorId(int id)
        {
            return _repository.RecuperarPorId(id);
        }
    }
}
