using FoccoEmFrente.Kanban.Application.Context;
using FoccoEmFrente.Kanban.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoccoEmFrente.Kanban.Application.Repositories
{
    public class PostitRepository : IPostitRepository
    {
        protected readonly KanbanContext DbContext;
        protected readonly DbSet<Postit> DbSet;

        public IUnitOfWork UnitOfWork => DbContext;

        public PostitRepository(KanbanContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<Postit>();
        }

        public async Task<IEnumerable<Postit>> GetAllAsync(Guid userId)
        {
            return await DbSet
                .Where(postitis => postitis.UserId == userId)
                .ToListAsync();
        }

        public async Task<Postit> GetByIdAsync(Guid id, Guid userId)
        {
            return await DbSet
                .Where(postits => postits.UserId == userId && postits.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ExistAsync(Guid id, Guid userId)
        {
            return await DbSet
                .Where(postitis => postitis.UserId == userId && postitis.Id == id)
                .AnyAsync();
        }

        public Postit Add(Postit postit)
        {
            var entry = DbSet.Add(postit);

            DbContext.SaveChanges();

            return entry.Entity;
        }

        public Postit Update(Postit postit)
        {
            var entry = DbSet.Update(postit);

            DbContext.SaveChanges();

            return entry.Entity;
        }

        public Postit Delete(Postit postit)
        {
            var entry = DbSet.Remove(postit);

            DbContext.SaveChanges();

            return entry.Entity;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
