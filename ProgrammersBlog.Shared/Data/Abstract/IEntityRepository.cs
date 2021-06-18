using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity, new()
    {
        //Task bir delegedir asenkron programlama için kullanılır.
        Task<T> GetAsync(Expression<Func<T,bool>> predicate, params Expression<Func<T,object>>[] includeProperties);
        //Birden fazla parametre alabilmesini "params" keywordü  gerçekleştirir
        // includeProperties isminde object türünde bir array tanımladık.

        Task<IList<T>> GetAllAsync(Expression<Func<T,bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        //NUll verme sebebimiz makalelerin istersek hepsini yükleriz istersek sadece bir kategoriye ait olanı yükleriz
        //predicate = null gelirse her şeyi göstericez, eğer gelmezse filtre uygulayacaz.

        Task AddSync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T,bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
