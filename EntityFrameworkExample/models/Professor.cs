namespace EntityFrameworkExample.models;

public class Professor
{
	public int Id { get; set; }
	public string Name { get; set; }

	// Un professeur peut avoir plusieurs étudiants
	public List<Student> Students { get; set; } = new();

	// Un professeur dirige un seul meeting
	public Meeting Meeting { get; set; }
}