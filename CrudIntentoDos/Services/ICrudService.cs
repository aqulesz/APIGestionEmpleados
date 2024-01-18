using CrudIntentoDos.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CrudIntentoDos.Services
{
    public interface ICrudService<T, TI, TU>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI sucursalInsertDto);
        Task<T> Update(int id, TU sucursalUpdateDto);
        Task<T> Delete(int id);
    }
}
