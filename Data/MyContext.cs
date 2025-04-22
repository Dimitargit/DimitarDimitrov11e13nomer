using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using DimitarDimitrov11e.Data.Models;

namespace DimitarDimitrov11e.Data
{
	public class MyContext:DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Reader> Readers { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public MyContext() { }
		public MyContext(DbContextOptions options) : base(options)
		{
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if(!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.connectionString);
			}
			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Reader>()
				.HasMany(r => r.Books)
				.WithMany(b => b.Readers);

			modelBuilder.Entity<Book>();
		}
	}
}
