using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Trellura.Domain.Entities
{
    public class Card : Entity
    {
        public int Title { get; private set; }
        public BoardList BoardList { get; private set; }
        public Guid BoardListId { get; private set; }
    }
}
