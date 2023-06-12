using System;
namespace torc.Iface
{
    public interface IOrderByClause<T> where T : class, new()
    {
        IOrderedQueryable<T> ApplySort(IQueryable<T> query, bool firstSort);
    }
}

