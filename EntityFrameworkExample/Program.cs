namespace EntityFrameworkExample;

public class Program
{
	/**
	 * Launch app with ./EntityFrameworkExample -p [password]
	 */
	public static void Main(string[] args)
	{
		if (args is not ["-p", _])
		{
			Console.WriteLine("Usage: ./EntityFrameworkExample -p <password>");
			return;
		}

		Constants.ConnectionPassword = args[1];

		using (AppDbContext context = new AppDbContext())
		{
			var orders = context.Orders.ToList();

			foreach (Order order in orders)
			{
				Console.WriteLine($"Commande de {order.ProductName} pour l'utilisateur : {order.CustomerId}.");
			}

			Console.WriteLine("====================");
			var firstOrder = context.Orders.FirstOrDefault(order => order.DeliveryGuyId == 2);
			Console.WriteLine($"Heure de la première livraison: {firstOrder.OrderDate.TimeOfDay}.");

			Console.WriteLine("====================");
			orders = context.Orders.OrderBy(order => order.OrderDate).ToList();

			foreach (Order order in orders)
			{
				Console.WriteLine($"Commande de {order.ProductName} pour l'utilisateur : {order.CustomerId}.");
			}

			Console.WriteLine("====================");
			var customOrders = context.Orders
				.OrderBy(order => order.OrderDate)
				.Select(order => new { order.ProductName, order.Description })
				.ToList();
			foreach (var customOrder in customOrders)
			{
				Console.WriteLine($"Commande de {customOrder.ProductName} : {customOrder.Description}.");
			}
		}
	}
}