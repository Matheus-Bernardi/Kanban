using FoccoEmFrente.Kanban.Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Application.Services
{
    public interface IPostitService : IDisposable
    {
        Task<IEnumerable<Postit>> GetAllAsync(Guid userId);

        Task<Postit> GetByIdAsync(Guid id, Guid userId);
        
        Task<bool> ExistAsync(Guid id, Guid userId);

        Task<Postit> AddAsync(Postit postit);
        
        Task<Postit> UpdateAsync(Postit postit);
        
        Task<Postit> RemoveAsync(Postit postit);

        Task<Postit> RemoveAsync(Guid id, Guid userId);
    }
}
