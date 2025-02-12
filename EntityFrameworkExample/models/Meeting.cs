namespace EntityFrameworkExample.models;

public class Meeting
{
	public int Id { get; set; }
	public string Topic { get; set; }

	// Un meeting a un seul professeur
	public int ProfessorId { get; set; }
	public Professor Professor { get; set; }

	// Un meeting a plusieurs étudiants
	public List<Student> Students { get; set; } = new();
}