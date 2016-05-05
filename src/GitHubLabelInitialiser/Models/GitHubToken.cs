using Octokit;

namespace GitHubLabelInitialiser.Models
{
	public class GitHubToken : IGitHubAccess
	{
		public Credentials Credentials
		{
			get { return new Credentials(Token); }
		}

		public string Token { get; set; }
	}
}
