using Microsoft.EntityFrameworkCore.Storage;
using EduLog.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EduLog.DataAccess.Abstract.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAll();

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

        int Count();

        T GetSingle(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        IQueryable<T> FromSqlRaw(string query, object[] parameters);

        IDbContextTransaction BeginTransaction();

        int ExecuteSqlRaw(string query, params Expression<Func<T, object>>[] parameters);

        bool IsHaveForeign(T entity);

        void Add(T entity);

        void AddRange(IEnumerable<T> entityList);

        Task AddRangeAsync(IEnumerable<T> entityList);

        void Update(T entity);

        void Update(T entity, params Expression<Func<T, object>>[] updatedProperties);

        void Delete(T entity);

        void DeleteWhere(Expression<Func<T, bool>> predicate);

        void Commit();

        void DetachEntity(T entity);

        Task<int> CommitAsync();

        void BulkInsert(IList<T> entityList);

        Task BulkInsertAsync(IList<T> entityList);

        void BulkUpdate(IList<T> entityList);

        Task BulkUpdateAsync(IList<T> entityList);

        void BulkInsertOrUpdate(IList<T> entityList);

        Task BulkInsertOrUpdateAsync(IList<T> entityList);

        void BulkDelete(IList<T> entityList);

        Task BulkDeleteAsync(IList<T> entityList);
    }
}