using RESTAPI.Model;
using System.Collections.Generic;

namespace RESTAPI.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(int id);
        bool Exists(long? id);
    }
}
