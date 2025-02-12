namespace EntityFrameworkExample.models;

public class Student
{
	public int Id { get; set; }
	public string Name { get; set; }

	// Un étudiant peut avoir plusieurs professeurs
	public List<Professor> Professors { get; set; } = new();

	// Un étudiant participe à un seul meeting
	public int MeetingId { get; set; }
	public Meeting Meeting { get; set; }
}