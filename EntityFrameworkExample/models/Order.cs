namespace EntityFrameworkExample.models;

public class Order
{
	public int Id { get; set; }
	public string ProductName { get; set; } = "";
	public string Description { get; set; } = "";
	public int DeliveryTime { get; set; }
	public DateTime OrderDate { get; set; }
	public int Quantity { get; set; }
	public decimal UnitPrice { get; set; }
	public int CustomerId { get; set; }
	public int DeliveryGuyId { get; set; }
}