namespace EntityFrameworkExample;

public static class Constants
{
	public static string ConnectionPassword = "";
	public static string ConnectionString =
		$"Server=AVAP\\SQLEXPRESS;Database=master;Trusted_Connection=True;User Id=sa;Password={ConnectionPassword}; TrustServerCertificate=true";
}