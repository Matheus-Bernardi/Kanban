using FoccoEmFrente.Kanban.Application.Entities;
using System;

namespace FoccoEmFrente.Kanban.Application.Repositories
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
