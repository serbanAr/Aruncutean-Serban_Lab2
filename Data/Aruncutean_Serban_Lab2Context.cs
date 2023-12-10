using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aruncutean_Serban_Lab2.Models;

namespace Aruncutean_Serban_Lab2.Data
{
    public class Aruncutean_Serban_Lab2Context : DbContext
    {
        public Aruncutean_Serban_Lab2Context (DbContextOptions<Aruncutean_Serban_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Aruncutean_Serban_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Aruncutean_Serban_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Aruncutean_Serban_Lab2.Models.Author>? Authors { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Book>()
				.HasOne(b => b.Borrowing)
				.WithOne(b => b.Book)
				.HasForeignKey<Borrowing>(b => b.BookID);
		}

		public DbSet<Aruncutean_Serban_Lab2.Models.Category>? Category { get; set; }

		public DbSet<Aruncutean_Serban_Lab2.Models.Member>? Member { get; set; }

		public DbSet<Aruncutean_Serban_Lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
