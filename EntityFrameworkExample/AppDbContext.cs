﻿using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkExample;

public class AppDbContext : DbContext
{
	public DbSet<Order> Orders { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(Constants.ConnectionString);
	}
}