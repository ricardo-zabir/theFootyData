using System;
using Microsoft.EntityFrameworkCore;
using theFootyDataWebAPI.Models;

namespace theFootyDataWebAPI.Data
{
	public class footyDbContext : DbContext
	{
		
        public footyDbContext(DbContextOptions<footyDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Match> Matches { get; set; }
    }
}

