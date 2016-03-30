namespace GitHubLabelInitialiser
{
	/// <summary>
	/// Credentials object to access GitHub API
	/// </summary>
	public class GitHubCredentials : IGitHubCredentials
	{
		public string Login { get; set; }
		public string Password { get; set; }
	}
}
