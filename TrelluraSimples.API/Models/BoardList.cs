using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Trellura.Domain.Entities
{
    public class BoardList : Entity
    {
        public int Title { get; private set; }
        public List<Card> Cards { get; private set; }
        public Board Board { get; set; }
        public Guid BoardId { get; set; }
    }
}
