using System;
using theFootyDataWorkerService.Models;
using Microsoft.EntityFrameworkCore;

namespace theFootyDataWorkerService.Models
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

        public DbSet<MatchEntity> Matches { get; set; }
    }
}

