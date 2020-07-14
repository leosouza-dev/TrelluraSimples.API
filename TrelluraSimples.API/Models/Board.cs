using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Trellura.Domain.Entities
{
    public class Board : Entity
    {
        public int Title { get; private set; }
        public List<BoardList> BoardLists { get; private set; }
    }
}
