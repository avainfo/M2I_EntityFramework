namespace EntityFrameworkExample;

public class Program
{
	public static void Main(string[] args)
	{
		using (AppDbContext context = new AppDbContext())
		{
			Console.WriteLine("Hello World!");
		}
	}
}