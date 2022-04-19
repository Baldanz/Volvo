namespace Volvo.Repository.Interface
{
    public interface ICommand<TEntity> where TEntity : class
    {
        #region métodos

        void Post(TEntity entity);

        void Put(TEntity entity);

        void Delete(int id);

        #endregion
    }
}
