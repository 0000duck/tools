using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Lfz.Collections;
using Lfz.Data;

namespace Lfz.Data {
    /// <summary>
    /// ���ݲֿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        DbContext CurrentDbContext { get; }

        /// <summary>
        /// �����ύ,������Ӱ��������һ�����0��ʾ�����ɹ�
        /// </summary>
        int Commit();

        /// <summary>
        /// ����ʵ��
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// ��ӻ����
        /// </summary>
        /// <param name="entity"></param>
        void CreateOrUpdate(Guid id, T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(object id);

        /// <summary>
        /// ���������е�ΨһԪ�أ����������Ϊ�գ��򷵻�Ĭ��ֵ����������а������Ԫ�أ���ô���ص�һ��Ԫ��
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// 
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Exists(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="order"></param>
        /// <param name="skip"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, int skip, int count);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="order"></param>
        /// <param name="pageIndex">��0��ʼ����</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPageOfItems<T> GetPaged(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, int pageIndex,
                                 int pageSize);

        /// <summary>
        /// ִ��ԭʼsql���
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        void ExecuteSql(string sql, params object[] parameters);
    }
}