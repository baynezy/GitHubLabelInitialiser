namespace GitHubLabelInitialiser.Models
{
	public interface IGitHubCredentials
	{
		/// <summary>
		/// Login name
		/// </summary>
		string Login { get; set; }

		/// <summary>
		/// Password for Login
		/// </summary>
		string Password { get; set; }
	}
}
