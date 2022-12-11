using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Repository
{
    public class GenericRepositori<T> : IGenericDal<T> where T : class
    {
        public void Add(T entity)
        {
            using (PortfolioContext context = new PortfolioContext())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (PortfolioContext context = new PortfolioContext())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            using (PortfolioContext context = new PortfolioContext())
            {
                return context.Set<T>().Where(filter).ToList();
            }
        }

        public List<T> GetAll()
        {
            using (PortfolioContext context = new PortfolioContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetById(int id)
        {
            using (PortfolioContext context = new PortfolioContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public void Update(T entity)
        {
            using (PortfolioContext context = new PortfolioContext())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
