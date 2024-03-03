namespace SmacoteriaBDFinal.Model.DataUnitOfWork;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    List<TEntity> GetAll();

    TEntity GetById(int id);

    void Insert(TEntity entity);

    void InsertRange(List<TEntity> entity);

    void Delete(TEntity entity);

    void Update(TEntity entity);

    void Save();
}
