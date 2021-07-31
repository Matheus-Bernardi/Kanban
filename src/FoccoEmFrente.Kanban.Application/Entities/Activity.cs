using FoccoEmFrente.Kanban.Application.Enums;
using System;

namespace FoccoEmFrente.Kanban.Application.Entities
{
    public class Activity : Entity, IAggregateRoot
    {
        public string Title { get; set; }
        
        public ActivityStatus Status { get; set; }

        public Guid UserId { get; set; }

        public int Order { get; set; }
    }
}
