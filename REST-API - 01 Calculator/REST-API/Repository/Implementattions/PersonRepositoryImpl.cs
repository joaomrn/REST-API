using RESTAPI.Model;
using RESTAPI.Model.Context;
using RESTAPI.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTAPI.Repository.Implementattions
{
    public class PersonRepositoryImpl : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepositoryImpl(MySQLContext mySQLContext) : base(mySQLContext) {}

        public List<Person> FindByName(string fristName, string lastName)
        {
            if (!string.IsNullOrEmpty(fristName) && !string.IsNullOrEmpty(lastName) )
            {
                return _mySQLContext.Persons
                .Where(p =>
                       p.Nome.Equals(fristName, StringComparison.CurrentCultureIgnoreCase) && p.Sobrenome.Equals(lastName, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
            }else if (!string.IsNullOrEmpty(fristName) && string.IsNullOrEmpty(lastName) )
            {
                return _mySQLContext.Persons
                .Where(p =>
                       p.Nome.Equals(fristName, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
            }else if (string.IsNullOrEmpty(fristName) && !string.IsNullOrEmpty(lastName) )
            {
                return _mySQLContext.Persons
                .Where(p =>
                       p.Sobrenome.Equals(lastName, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
            }
            else
            {
                return _mySQLContext.Persons.ToList();
            }
        }
    }
}
