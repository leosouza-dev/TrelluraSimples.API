using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Trellura.Domain.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
