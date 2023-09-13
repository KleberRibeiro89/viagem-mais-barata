using Sy    stem;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure
{
   public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly SATVTContext DbContext;

        protected DbSet<TEntity> EntitySet
        {
            get
            {
                return DbContext.Set<TEntity>();
            }
        }

        
 
        public Repository(SATVTContext context)
        {
            DbContext = context;
            //EntitySet = DbContext.Set<TEntity>();
        }

        /// <summary>
        /// Adicionar uma Entidade no Repositório
        /// </summary>
        /// <param name="entity"></param>
        public virtual TEntity Add(TEntity entity) => EntitySet.Add(entity).Entity;

        /// <summary>
        /// Atualizar uma Entidade no Repositório
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity) => DbContext.Entry(entity).State = EntityState.Modified;

        /// <summary>
        /// Remover uma Entidade do Repositório a partir do(s) valor(es) chave(s)
        /// </summary>
        /// <param name="keys"></param>
        public virtual void Delete(params object[] keys)
        {
            var entity = GetById(keys);

            if (entity != null)
            {
                EntitySet.Remove(entity);
            }
        }

        /// <summary>
        /// Remover uma Entidade do Repositório a partir da própria Entidade
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity) => EntitySet.Remove(entity);

        /// <summary>
        /// Remover uma lista de Entidades do Repositório a partir da própria Entidade
        /// </summary>
        /// <param name="entities"></param>
        public virtual void DeleteRange(IEnumerable<TEntity> entities) => EntitySet.RemoveRange(entities);


        /// <summary>
        /// Obter a primeira Entidade do Repositório
        /// </summary>
        /// <returns></returns>
        public TEntity First() => QuerySet.FirstOrDefault();

        

        /// <summary>
        /// Obter a primeira Entidade do Repositório
        /// </summary>
        /// <returns></returns>
        public TEntity Last() => QuerySet.LastOrDefault();

        
        /// <summary>
        /// Obter uma Entidade do Repositório a partir do(s) valor(es) chave(s)
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public TEntity GetById(params object[] keys) => EntitySet.Find(keys);

        /// <summary>
        /// Obter todas as Entidades do Repositório
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll() => QuerySet.AsEnumerable();


        /// <summary>
        /// Obter quantidade total de Entidades do Repositório
        /// </summary>
        /// <returns></returns>
        public virtual int Count() => QuerySet.Count();
        
        public void LoadRelatedEntity(string name)
        {
            QuerySet.Include(name).Load();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbContext.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Métodos Assíncronos
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await EntitySet.AddAsync(entity);
            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task DeleteAsync(params object[] keys)
        {
            var entity = await GetByIdAsync(keys);

            if (entity != null)
            {
                EntitySet.Remove(entity);
            }
        }

        public virtual async Task DeleteAsync(TEntity entity) => EntitySet.Remove(entity);


        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities) => EntitySet.RemoveRange(entities);

        
        public virtual Task<TEntity> FirstAsync() => QuerySet.FirstOrDefaultAsync();

        
        public virtual Task<TEntity> LastAsync() => QuerySet.LastOrDefaultAsync();

        
        public virtual Task<TEntity> GetByIdAsync(params object[] keys) => Task.FromResult(EntitySet.Find(keys));

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => QuerySet.AsEnumerable();

        public virtual Task<int> CountAsync() => QuerySet.CountAsync();


        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> SpecExpression) => await QuerySet.CountAsync(SpecExpression) == 0;

        #endregion
    }
}