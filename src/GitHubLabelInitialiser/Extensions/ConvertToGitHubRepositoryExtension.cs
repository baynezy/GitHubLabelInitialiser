using GitHubLabelInitialiser.Models;
using Octokit;

namespace GitHubLabelInitialiser.Extensions
{
	static class ConvertToGitHubRepositoryExtension
	{
		/// <summary>
		/// Allows Octokit.Repository instances to convert themselves to the GitHubRepository instances
		/// </summary>
		/// <param name="repository">The Octokit.Repository instance we are converting</param>
		/// <returns>A converted GitHubRepository</returns>
		public static GitHubRepository ConvertToGitHubRepository(this Repository repository)
		{
			return new GitHubRepository
				{
					Name = repository.Name,
					OwnerUsername = repository.Owner.Login
				};
		}
	}
}
