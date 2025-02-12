using EntityFrameworkExample.models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkExample;

public class AppDbContext : DbContext
{
	
	public DbSet<User> Users { get; set; }
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(Constants.ConnectionString);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>()
			.OwnsOne(u => u.Address); // EF Core stocke Address en JSON
		// // Relation 1-1 entre Professor et Meeting
		// modelBuilder.Entity<Professor>()
		// 	.HasOne(p => p.Meeting)
		// 	.WithOne(m => m.Professor)
		// 	.HasForeignKey<Meeting>(m => m.ProfessorId)
		// 	.OnDelete(DeleteBehavior.Restrict); // Empêcher la suppression en cascade ici aussi.
		//
		// // Relation 1-N entre Meeting et Students
		// modelBuilder.Entity<Student>()
		// 	.HasOne(s => s.Meeting)
		// 	.WithMany(m => m.Students)
		// 	.HasForeignKey(s => s.MeetingId)
		// 	.OnDelete(DeleteBehavior.Restrict); // Empêche la suppression cascade.
		//
		// // Relation N-N entre Students et Professors (sans cascade delete)
		// modelBuilder.Entity<Student>()
		// 	.HasMany(s => s.Professors)
		// 	.WithMany(p => p.Students)
		// 	.UsingEntity<Dictionary<string, object>>(
		// 		"ProfessorStudent",
		// 		j => j
		// 			.HasOne<Professor>()
		// 			.WithMany()
		// 			.HasForeignKey("ProfessorId")
		// 			.OnDelete(DeleteBehavior.NoAction), // Empêcher toute suppression en cascade
		// 		j => j
		// 			.HasOne<Student>()
		// 			.WithMany()
		// 			.HasForeignKey("StudentId")
		// 			.OnDelete(DeleteBehavior.NoAction) // Empêcher toute suppression en cascade
		// 	);
	}
}

public class User
{
	public int Id { get; set; }
	public string Name { get; set; }
	public Address Address { get; set; }
}

public class Address
{
	public string Street { get; set; }
	public string City { get; set; }
}