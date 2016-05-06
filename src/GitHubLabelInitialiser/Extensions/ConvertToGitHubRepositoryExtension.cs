using GitHubLabelInitialiser.Models;
using Octokit;

namespace GitHubLabelInitialiser.Extensions
{
	static class ConvertToGitHubRepositoryExtension
	{
		public static GitHubRepository ConvertToGitHubRepository(this Repository repository)
		{
			return new GitHubRepository
				{
					Name = repository.Name
				};
		}
	}
}
