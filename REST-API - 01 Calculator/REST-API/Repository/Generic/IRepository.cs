using RESTAPI.Model.Base;
using System.Collections.Generic;

namespace RESTAPI.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(int id);
        bool Exists(long? id);
    }
}
