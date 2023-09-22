

namespace MGP.ApiDotNet6.Application.Services.Interfaces
{
    public interface IBaseService<T>
    {
        Task<ResultService<T>> GetByIdAsync(int id);
        Task<ResultService<ICollection<T>>> GetAllAsync();
        Task<ResultService<T>> CreateAsync(T entity);
        Task<ResultService<T>> UpdateAsync(T entity);
        Task<ResultService> DeleteAsync(int id);
    }
}
