using SmacoteriaBDFinal.Model.Data;
using SmacoteriaBDFinal.Model.Models;

namespace SmacoteriaBDFinal.Model.DataUnitOfWork;

public class UnitOfWork : IDisposable
{
    private DataContext context = new DataContext();
    private GenericRepository<Addition> additionRepository;
    private GenericRepository<Category> categoryRepository;
    private GenericRepository<Dish> dishRepository;
    private GenericRepository<DishInOrder> dishInOrderRepository;
    private GenericRepository<Order> orderRepository;

    public GenericRepository<Addition> AdditionRepository
    {
        get
        {
            if (this.additionRepository == null)
            {
                this.additionRepository = new GenericRepository<Addition>(this.context);
            }

            return this.additionRepository;
        }
    }

    public GenericRepository<Category> CategoryRepository
    {
        get
        {
            if (this.categoryRepository == null)
            {
                this.categoryRepository = new GenericRepository<Category>(this.context);
            }

            return this.categoryRepository;
        }
    }

    public GenericRepository<Dish> DishRepository
    {
        get
        {
            if (this.dishRepository == null)
            {
                this.dishRepository = new GenericRepository<Dish>(this.context);
            }

            return this.dishRepository;
        }
    }

    public GenericRepository<DishInOrder> DishInOrderRepository
    {
        get
        {
            if (this.dishInOrderRepository == null)
            {
                this.dishInOrderRepository = new GenericRepository<DishInOrder>(this.context);
            }

            return this.dishInOrderRepository;
        }
    }

    public GenericRepository<Order> OrderRepository
    {
        get
        {
            if (this.orderRepository == null)
            {
                this.orderRepository = new GenericRepository<Order>(this.context);
            }

            return this.orderRepository;
        }
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
