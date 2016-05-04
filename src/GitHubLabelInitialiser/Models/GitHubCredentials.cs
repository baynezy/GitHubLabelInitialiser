using Octokit;

namespace GitHubLabelInitialiser.Models
{
	/// <summary>
	/// Credentials object to access GitHub API
	/// </summary>
	public class GitHubCredentials : IGitHubAccess
	{
		public string Login { get; set; }
		public string Password { get; set; }

		public Credentials Credentials
		{
			get { return new Credentials(Login, Password); }
		}
	}
}
