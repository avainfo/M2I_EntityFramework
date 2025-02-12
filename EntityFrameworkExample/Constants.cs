namespace EntityFrameworkExample;

public static class Constants
{
	public static string ConnectionPassword = "YourStrong@Passw0rd";

	public static string ConnectionString =
		$"Server=localhost;Database=exercices;Trusted_Connection=False;User Id=sa;Password={ConnectionPassword}; TrustServerCertificate=true; Encrypt=True;";
}
