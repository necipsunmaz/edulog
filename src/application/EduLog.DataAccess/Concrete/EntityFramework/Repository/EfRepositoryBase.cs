using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using EduLog.Core.Entities.Concrete;
using EduLog.Core.Utilities.Middleware;
using EduLog.DataAccess.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EduLog.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfRepositoryBase<TEntity, TContext> : AuthUser, IRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext, new()
    {
        public IDbContextTransaction BeginTransaction()
        {
            using TContext context = new TContext();
            return context.Database.BeginTransaction();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            using TContext context = new TContext();
            return context.Set<TEntity>().AsQueryable();
        }

        public virtual IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using TContext context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public virtual int Count()
        {
            using TContext context = new TContext();
            return context.Set<TEntity>().Count();
        }

        public virtual IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using TContext context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.AsQueryable();
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            using TContext context = new TContext();
            return context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using TContext context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.Where(predicate).FirstOrDefault();
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            using TContext context = new TContext();
            return context.Set<TEntity>().Where(predicate);
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using TContext context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.Where(predicate);
        }

        public virtual IQueryable<TEntity> FromSqlRaw(string query, object[] parameters)
        {
            using TContext context = new TContext();
            return context.Set<TEntity>().FromSqlRaw(query, parameters);
        }

        public int ExecuteSqlRaw(string query, params Expression<Func<TEntity, object>>[] parameters)
        {
            using TContext context = new TContext();
            return context.Database.ExecuteSqlRaw(query, parameters);
        }

        public void DetachEntity(TEntity entity)
        {
            using TContext context = new TContext();
            context.Entry(entity).State = EntityState.Detached;
        }

        public bool IsHaveForeign(TEntity entity)
        {
            using var transaction = BeginTransaction();
            try
            {
                Delete(entity);
                Commit();
                transaction.Rollback();
                return false;
            }
            catch
            {
                transaction.Rollback();
                return true;
            }
        }

        public virtual void Add(TEntity entity)
        {
            using TContext context = new TContext();
            context.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entityList)
        {
            using TContext context = new TContext();
            context.AddRange(entityList);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entityList)
        {
            using TContext context = new TContext();
            await context.Set<TEntity>().AddRangeAsync(entityList);
        }

        public virtual void Update(TEntity entity)
        {
            using TContext context = new TContext();
            context.Update(entity);
        }

        public virtual void Update(TEntity entity, params Expression<Func<TEntity, object>>[] updatedProperties)
        {
            using TContext context = new TContext();
            foreach (var property in updatedProperties)
            {
                context.Entry(entity).Property(property).IsModified = true;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using TContext context = new TContext();
            if (entity is BaseEntity baseLog)
            {
                baseLog.ModifiedById = GetUserId();
                baseLog.DataStatus = DataStatus.Deleted;
                baseLog.ModifiedAt = DateTime.Now;

                context.Update(entity);
            }
            else
            {
                context.Remove(entity);
            }
        }

        public virtual void DeleteWhere(Expression<Func<TEntity, bool>> predicate)
        {
            using TContext context = new TContext();
            foreach (var entity in context.Set<TEntity>().Where(predicate))
            {
                if (entity is BaseEntity baseLog)
                {
                    baseLog.ModifiedById = GetUserId();
                    baseLog.DataStatus = DataStatus.Deleted;
                    baseLog.ModifiedAt = DateTime.Now;

                    context.Update(entity);
                }
                else
                {
                    context.Remove(entity);
                }
            }
        }

        public virtual void Commit()
        {
            using TContext context = new TContext();
            OnBeforeSaving();
            context.SaveChanges();
        }

        public virtual async Task<int> CommitAsync()
        {
            using TContext context = new TContext();
            OnBeforeSaving();
            return await context.SaveChangesAsync();
        }

        private void OnBeforeSaving()
        {
            using TContext context = new TContext();
            DateTime now = DateTime.Now;
            int userId = GetUserId();
            foreach (var entry in context.ChangeTracker.Entries().Where(a => a.Entity is BaseEntity))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Detached:
                        ((BaseEntity)entry.Entity).CreatedAt = now;
                        ((BaseEntity)entry.Entity).CreatedById = userId;

                        if (((BaseEntity)entry.Entity).DataStatus == 0)
                            ((BaseEntity)entry.Entity).DataStatus = DataStatus.Activated;

                        // Ekleme yaparken string alanları otomatik trimliyoruz
                        foreach (var entity in entry.CurrentValues.Properties.Where(a => a.ClrType == typeof(string)))
                            entry.CurrentValues[entity.Name] = entry.CurrentValues[entity.Name]?.ToString()?.Trim();

                        break;

                    case EntityState.Modified:
                        ((BaseEntity)entry.Entity).ModifiedAt = now;
                        ((BaseEntity)entry.Entity).ModifiedById = userId;

                        // Güncelleme yaparken string alanları otomatik trimliyoruz
                        foreach (var entity in entry.CurrentValues.Properties.Where(a => a.ClrType == typeof(string)))
                            entry.CurrentValues[entity.Name] = entry.CurrentValues[entity.Name]?.ToString()?.Trim();
                        break;

                    case EntityState.Deleted:
                        ((BaseEntity)entry.Entity).ModifiedAt = now;
                        ((BaseEntity)entry.Entity).ModifiedById = userId;
                        break;
                }
            }
        }

        public void BulkInsert(IList<TEntity> entityList)
        {
            using TContext context = new TContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Set<TEntity>().AddRange(entityList);
                Commit();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task BulkInsertAsync(IList<TEntity> entityList)
        {
            using TContext context = new TContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                await context.Set<TEntity>().AddRangeAsync(entityList);
                await CommitAsync();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public void BulkUpdate(IList<TEntity> entityList)
        {
            using TContext context = new TContext();
            using IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                context.Set<TEntity>().UpdateRange(entityList);
                Commit();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task BulkUpdateAsync(IList<TEntity> entityList)
        {
            using TContext context = new TContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Set<TEntity>().UpdateRange(entityList);
                await CommitAsync();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public void BulkInsertOrUpdate(IList<TEntity> entityList)
        {
            using TContext context = new TContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var item in entityList)
                {
                    var entry = context.Entry(item);
                    switch (entry.State)
                    {
                        case EntityState.Detached:
                            if (entry.IsKeySet)
                                context.Update(item);
                            else
                                context.Add(item);
                            break;

                        case EntityState.Modified:
                            context.Update(item);
                            break;

                        case EntityState.Added:
                            context.Add(item);
                            break;

                        case EntityState.Unchanged:
                            //item already in db no need to do anything
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                Commit();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task BulkInsertOrUpdateAsync(IList<TEntity> entityList)
        {
            using TContext context = new TContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var item in entityList)
                {
                    var entry = context.Entry(item);
                    switch (entry.State)
                    {
                        case EntityState.Detached:
                            if (entry.IsKeySet)
                                context.Update(item);
                            else
                                context.Add(item);
                            break;

                        case EntityState.Modified:
                            context.Update(item);
                            break;

                        case EntityState.Added:
                            context.Add(item);
                            break;

                        case EntityState.Unchanged:
                            //item already in db no need to do anything
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                await CommitAsync();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public void BulkDelete(IList<TEntity> entityList)
        {
            using TContext context = new TContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Set<TEntity>().RemoveRange(entityList);
                Commit();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public async Task BulkDeleteAsync(IList<TEntity> entityList)
        {
            using TContext context = new TContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Set<TEntity>().RemoveRange(entityList);
                await CommitAsync();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }
    }
}