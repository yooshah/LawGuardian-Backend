using LawGuardian.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Infrastructure.Persistence
{
    public class LawGuardianDbContext:DbContext
    {

        public LawGuardianDbContext(DbContextOptions<LawGuardianDbContext> options) :base(options) { }
       
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
