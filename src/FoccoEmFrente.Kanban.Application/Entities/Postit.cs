using FoccoEmFrente.Kanban.Application.Enums;
using System;

namespace FoccoEmFrente.Kanban.Application.Entities
{
    public class Postit : Entity, IAggregateRoot
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Guid User { get; set; }

        public PostitColor Color { get; set; }

        public Guid UserId { get; set; }
    }
}
