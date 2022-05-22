namespace AuthDemo.Infrastructure.Sql
{
    public static class Queries
    {
		public static string AllUsers => "SELECT [Id], [FirstName], [LastName], [UserName] FROM [dbo].[User]";

		public static string UserById => "SELECT [Id], [FirstName], [LastName], [UserName] FROM [dbo].[User] WHERE [Id] = @Id";

		public static string AuthenticateUser =>
			@"SELECT [Id], [FirstName], [LastName], [UserName]
			FROM [dbo].[User]
			WHERE [UserName] = @UserName
			AND [Password] = @Password";
	}
}
