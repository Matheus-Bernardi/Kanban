using FoccoEmFrente.Kanban.Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Application.Repositories
{
    public interface IPostitRepository : IRepository<Postit>
    {
        Task<IEnumerable<Postit>> GetAllAsync(Guid userId);

        Task<Postit> GetByIdAsync(Guid id, Guid userId);

        Task<bool> ExistAsync(Guid id, Guid userId);

        Postit Add(Postit postit);

        Postit Update(Postit postit);

        Postit Delete(Postit postit);
    }
}
