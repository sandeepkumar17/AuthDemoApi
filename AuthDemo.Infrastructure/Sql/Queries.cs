namespace AuthDemo.Infrastructure.Sql
{
    public static class Queries
    {
		//Get All Users
		public static string AllUsers => "SELECT [Id], [FirstName], [LastName], [UserName] FROM [dbo].[User]";

        //Get User By Id
        public static string UserById => "SELECT [Id], [FirstName], [LastName], [UserName] FROM [dbo].[User] WHERE [Id] = @Id";

        //Authenticate User
        public static string AuthenticateUser =>
			@"SELECT [Id], [FirstName], [LastName], [UserName]
			FROM [dbo].[User]
			WHERE [UserName] = @UserName
			AND [Password] = @Password";
	}
}
