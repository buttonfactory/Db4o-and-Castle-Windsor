using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheStorage.Model;

namespace TheStorage.Web.DataAccess
{
    public interface IRepository
    {
        void CommitChanges();
        void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression);
        void Delete<T>(T item);
        void DeleteAll<T>();
        T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression);
        System.Linq.IQueryable<T> All<T>();
        void Save<T>(T item);
    }
}