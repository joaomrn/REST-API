using Microsoft.EntityFrameworkCore;
using RESTAPI.Model.Base;
using RESTAPI.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _mySQLContext;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _mySQLContext = context;
            dataset = _mySQLContext.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _mySQLContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public void Delete(int id)
        {
            try
            {
                var result = dataset.SingleOrDefault(p => p.Id.Equals(id));

                if (result != null)
                {
                    dataset.Remove(result);
                    _mySQLContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;

            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            try
            {
                _mySQLContext.Entry(result).CurrentValues.SetValues(item);
                _mySQLContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public bool Exists(long? id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}
