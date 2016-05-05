using Octokit;

namespace GitHubLabelInitialiser.Models
{
	public interface IGitHubAccess
	{
		/// <summary>
		/// Credentials to authenticate with GitHub
		/// </summary>
		Credentials Credentials { get; }
	}
}
