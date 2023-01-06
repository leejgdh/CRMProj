using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeFunction.Models.DAO
{
    public class FranchiseeContext : DbContext
    {
        public FranchiseeContext(DbContextOptions<FranchiseeContext> options) : base(options)
        {

        }

        public DbSet<Franchisee> Franchisees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Franchisee>()
                .ToContainer("Franchisees")
                .HasPartitionKey(nameof(Franchisee.Name))
                .HasKey(e => e.BizNum);

        }
    }
}
