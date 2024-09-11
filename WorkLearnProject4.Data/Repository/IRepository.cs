namespace WorkLearnProject4.Data.Repository;

public interface IRepository<TEntity> where TEntity:class
{
    IEnumerable<TEntity> All {get;}
    void Add(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    TEntity FindById(Guid id);
    TEntity GetById(Guid id);
}