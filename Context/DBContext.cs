using IBKS.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBKS.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options): base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
