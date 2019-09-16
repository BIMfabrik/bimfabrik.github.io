using bimfabrik.model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace bimfabrik.model.DataAccess
{
    public class BimfabrikContext : DbContext
    {
        public BimfabrikContext() : base()
        { }

        public BimfabrikContext(DbContextOptions<BimfabrikContext> options)
           : base(options)
        { }

        //public DbSet<Blog> Blogs { get; set; }
        //public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
