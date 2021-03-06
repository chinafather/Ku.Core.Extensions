﻿using Ku.Core.Extensions.Dapper.SqlDialect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ku.Core.Extensions.Dapper
{
    public interface IDapper : IDisposable
    {
        IDbConnection Connection { get; }

        ISqlDialect Dialect { set; get; }

        #region 事务

        ITransation BeginTrans();

        ITransation BeginTrans(IsolationLevel il);

        void Commit();

        void Rollback();

        #endregion

        #region 查询

        TEntity QueryOne<TEntity>(dynamic where, dynamic order = null) where TEntity : class;

        Task<TEntity> QueryOneAsync<TEntity>(dynamic where, dynamic order = null) where TEntity : class;

        IEnumerable<TEntity> QueryList<TEntity>(dynamic where, dynamic order = null) where TEntity : class;

        Task<IEnumerable<TEntity>> QueryListAsync<TEntity>(dynamic where, dynamic order = null) where TEntity : class;

        (int count, IEnumerable<TEntity> items) QueryPage<TEntity>(int page, int size, dynamic where, dynamic order = null) where TEntity : class;

        Task<(int count, IEnumerable<TEntity> items)> QueryPageAsync<TEntity>(int page, int size, dynamic where, dynamic order = null) where TEntity : class;

        #endregion

        #region 查询件数

        /// <summary>
        /// 查询件数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>数据件数</returns>
        int QueryCount<TEntity>(dynamic where) where TEntity : class;

        /// <summary>
        /// 查询件数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>数据件数</returns>
        Task<int> QueryCountAsync<TEntity>(dynamic where) where TEntity : class;

        #endregion

        #region 插入数据

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <returns>操作数据条数</returns>
        int Insert<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <returns>操作数据条数</returns>
        Task<int> InsertAsync<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// 批量新增数据
        /// </summary>
        /// <returns>操作数据条数</returns>
        int Insert<TEntity>(IEnumerable<TEntity> entitys) where TEntity : class;

        /// <summary>
        /// 批量新增数据
        /// </summary>
        /// <returns>操作数据条数</returns>
        Task<int> InsertAsync<TEntity>(IEnumerable<TEntity> entitys) where TEntity : class;

        #endregion

        #region 更新数据

        int Update<TEntity>(dynamic data, dynamic where = null) where TEntity : class;

        Task<int> UpdateAsync<TEntity>(dynamic data, dynamic where = null) where TEntity : class;

        //int Update<TEntity>(TEntity entity) where TEntity : class;

        //int Update<TEntity>(TEntity entity, params Expression<Func<TEntity, object>>[] updateFileds) where TEntity : class;

        //int Update<TEntity>(TEntity entity, params string[] updateFileds) where TEntity : class;

        //int UpdateExt(string table, string tableSchema, dynamic data, dynamic where);

        //Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class;

        //Task<int> UpdateAsync<TEntity>(TEntity entity, params Expression<Func<TEntity, object>>[] updateFileds) where TEntity : class;

        //Task<int> UpdateAsync<TEntity>(TEntity entity, params string[] updateFileds) where TEntity : class;

        //Task<int> UpdateExtAsync(string table, string tableSchema, dynamic data, dynamic where);

        #endregion

        #region 删除&逻辑删除

        int Delete<TEntity>(dynamic where) where TEntity : class;

        Task<int> DeleteAsync<TEntity>(dynamic where) where TEntity : class;

        #endregion

        #region 逻辑恢复

        int Restore<TEntity>(dynamic where) where TEntity : class;

        Task<int> RestoreAsync<TEntity>(dynamic where) where TEntity : class;

        #endregion
    }
}
