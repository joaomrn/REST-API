using RESTAPI.Model;
using RESTAPI.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RESTAPI.Services.Implementattions
{
    public class PersonServiceImpl : IPersonService
    {
        private MySQLContext _mySQLContext;

        public PersonServiceImpl(MySQLContext mySQLContext)
        {
            _mySQLContext = mySQLContext;
        }

        public Person Create(Person person)
        {
            try
            {
                _mySQLContext.Add(person);
                _mySQLContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public void Delete(int id)
        {
            try
            {
                var result = _mySQLContext.Persons.SingleOrDefault(p => p.Id.Equals(id));

                if (result != null)
                {
                    _mySQLContext.Persons.Remove(result);
                    _mySQLContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            return _mySQLContext.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _mySQLContext.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person();

            var result = _mySQLContext.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            try
            {
                _mySQLContext.Entry(result).CurrentValues.SetValues(person);
                _mySQLContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        private bool Exist(int? id)
        {
            return _mySQLContext.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
