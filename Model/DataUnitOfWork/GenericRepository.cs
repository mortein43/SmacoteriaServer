using Microsoft.EntityFrameworkCore;
using SmacoteriaBDFinal.Model.Data;

namespace SmacoteriaBDFinal.Model.DataUnitOfWork;

public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
{
    private DataContext context;
    private DbSet<T> dbSet;

    public GenericRepository(DataContext context)
    {
        this.context = context;
        this.dbSet = context.Set<T>();
    }

    public List<T> GetAll()
    {
        return this.dbSet.ToList();
    }

    public T GetById(int id)
    {
        return this.dbSet.Find(id);
    }

    public void Insert(T entity)
    {
        this.dbSet.Add(entity);
    }

    public void InsertRange(List<T> entity)
    {
        this.dbSet.AddRange(entity);
    }

    public void Delete(T entity)
    {
       
        if (entity != null)
            this.dbSet.Remove(entity);
    }

    public void Update(T entity)
    {
        this.context.Entry(entity).State = EntityState.Modified;
    }

    public void Save()
    {
        this.context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                this.context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
}
