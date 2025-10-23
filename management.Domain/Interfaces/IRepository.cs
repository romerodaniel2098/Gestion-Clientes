namespace management.Domain.Interfaces;

public interface IRepository<T> where T: class
{
    public Task<IEnumerable<T>?> GetAllAsync();
    public Task<T?> CreateAsync(T entity);
    public Task<bool?> DeleteAsync(int Id);
    public Task<T?> UpdateAsync(int Id, T entity);
}