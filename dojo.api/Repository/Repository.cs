using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dojo.Api;

public interface IRepository<T> where T : class
{
    public Task<IList<T>> GetAll();
    public Task<T?> GetById(long id);
    public Task<T> Add(T todoItem);
    public Task<bool> Update(T todoItem);
    public Task<bool> Delete(long id);
}

public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<IList<T>> GetAll() => await _dbSet.ToListAsync();
    public async Task<T?> GetById(long id) => await _dbSet.FindAsync(id);

    public async Task<T> Add(T record)
    {
        EntityEntry<T> result = await _dbSet.AddAsync(record);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> Update(T record)
    {
        _dbSet.Attach(record);
        _context.Entry(record).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_dbSet.Any(e => e == record)) return false;
            else throw;
        }

        return true;
    }

    public async Task<bool> Delete(long id)
    {
        T? record = await GetById(id);
        if (record is null) return false;
        _dbSet.Remove(record);
        await _context.SaveChangesAsync();
        return true;
    }
}