using CV.Core.Models;
using CV.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV.Data;

namespace CV.Services
{
    public class DbService : IDbService
    {
        protected readonly CvDbContext _context;

        public DbService(CvDbContext context)
        {
            _context = context;
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().SingleOrDefault<T>(entity => entity.Id == id);
        }

        public ServiceResult Create<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return new ServiceResult().Set(entity);
        }

        public ServiceResult Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

            return new ServiceResult(true);
        }

        public ServiceResult Update<T>(T entity) where T : Entity
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return new ServiceResult(true).Set(entity);
        }

        public IEnumerable<T> List<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }
    }
}
