using System.Collections.Generic;

namespace Volvo.Repository.Interface
{
    public interface IQuery<TEntity> where TEntity : class
    {
        #region métodos

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(string where = "");

        TEntity GetById(int id);

        #endregion
    }
}
