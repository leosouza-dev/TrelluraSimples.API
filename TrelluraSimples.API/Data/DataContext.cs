using Aura.Trellura.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrelluraSimples.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardList> BoardLists { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
