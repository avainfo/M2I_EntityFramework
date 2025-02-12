using EntityFrameworkExample.models;

namespace EntityFrameworkExample;

public class Program
{
	/**
	 * Launch app with ./EntityFrameworkExample -p [password]
	 */
	public static void Main(string[] args)
	{
		var context = new AppDbContext();

		CreateOrder(context);

		if (args is not ["-p", _])
		{
			Console.WriteLine("Usage: ./EntityFrameworkExample -p <password>");
			return;
		}

		Constants.ConnectionPassword = args[1];

		var professor = new Professor { Name = "Dr. Smith" };
		var professor2 = new Professor { Name = "Dr. Smith2" };
		var meeting = new Meeting { Topic = "Maths 101", Professor = professor };
		var meeting2 = new Meeting { Topic = "Maths 202", Professor = professor2 };

		var student1 = new Student { Name = "Alice", Meeting = meeting };
		var student2 = new Student { Name = "Bob", Meeting = meeting };

		// Ajout des relations many-to-many
		professor.Students.Add(student1);
		professor.Students.Add(student2);

		student1.Professors.Add(professor);
		student2.Professors.Add(professor);

		context.Add(professor);
		context.Add(student1);
		context.Add(student2);

		var query = from s in context.Students
			join e in context.Meetings on s.MeetingId equals e.Id
			select new { s.Name, e.Topic };
		context.SaveChanges();
	}

	private static void CreateOrder(AppDbContext context)
	{
		var order = new Order
		{
			OrderDate = DateTime.Now, DeliveryTime = 13, DeliveryGuyId = 1, Description = "Coucou", Quantity = 2,
			CustomerId = 1, ProductName = "mcdo", UnitPrice = 13
		};
		context.Orders.Add(order);
		context.SaveChanges();
	}
}