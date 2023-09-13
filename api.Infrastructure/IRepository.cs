using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure
{
    public interface IRepository<TEntity> : IDisposable
                    where TEntity : class
    {
        bool DiscardTenant { get; set; }

        /// <summary>
        /// Adicionar uma Entidade no Repositório
        /// </summary>
        /// <param name="entity"></param>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Atualizar uma Entidade no Repositório
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Remover uma Entidade do Repositório a partir do(s) valor(es) chave(s)
        /// </summary>
        /// <param name="keys"></param>
        void Delete(params object[] keys);

        /// <summary>
        /// Remover uma Entidade do Repositório a partir da própria Entidade
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Remover uma lista de Entidades do Repositório a partir da própria Entidade
        /// </summary>
        /// <param name="entities"></param>
        void DeleteRange(IEnumerable<TEntity> entities);


        /// <summary>
        /// Obter a primeira Entidade do Repositório
        /// </summary>
        /// <returns></returns>
        TEntity First();


        /// <summary>
        /// Obter a primeira Entidade do Repositório
        /// </summary>
        /// <returns></returns>
        TEntity Last();


        /// <summary>
        /// Obter uma Entidade do Repositório a partir do(s) valor(es) chave(s)
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        TEntity GetById(params object[] keys);

        /// <summary>
        /// Obter todas as Entidades do Repositório
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();




        /// <summary>
        /// Obter quantidade total de Entidades do Repositório
        /// </summary>
        /// <returns></returns>
        int Count();


        #region Métodos assíncronos
        /// <summary>
        /// Adicionar uma Entidade no Repositório
        /// </summary>
        /// <param name="entity"></param>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Atualizar uma Entidade no Repositório
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Remover uma Entidade do Repositório a partir do(s) valor(es) chave(s)
        /// </summary>
        /// <param name="keys"></param>
        Task DeleteAsync(params object[] keys);

        /// <summary>
        /// Remover uma Entidade do Repositório a partir da própria Entidade
        /// </summary>
        /// <param name="entity"></param>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Remover uma lista de Entidades do Repositório a partir da própria Entidade
        /// </summary>
        /// <param name="entities"></param>
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);


        /// <summary>
        /// Obter a primeira Entidade do Repositório
        /// </summary>
        /// <returns></returns>
        Task<TEntity> FirstAsync();


        /// <summary>
        /// Obter a primeira Entidade do Repositório
        /// </summary>
        /// <returns></returns>
        Task<TEntity> LastAsync();


        /// <summary>
        /// Obter uma Entidade do Repositório a partir do(s) valor(es) chave(s)
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(params object[] keys);

        /// <summary>
        /// Obter todas as Entidades do Repositório
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();


        /// <summary>
        /// Obter quantidade total de Entidades do Repositório
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();



        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> SpecExpression);

        #endregion

        void LoadRelatedEntity(string name);
    }
}