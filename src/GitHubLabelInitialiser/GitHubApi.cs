using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHubLabelInitialiser.Extensions;
using GitHubLabelInitialiser.Models;
using Octokit;

namespace GitHubLabelInitialiser
{
	/// <summary>
	/// Concrete implementation of IGitHubApi
	/// </summary>
	public class GitHubApi : IGitHubApi
	{
		private readonly GitHubClient _client;

		/// <summary>
		/// New instance of GitHubApi
		/// </summary>
		/// <param name="gitHubCredentials">The IGitHubCredentials that are being used to authenticate with GitHub</param>
		/// <param name="appName">The name of your specific app</param>
		public GitHubApi(IGitHubCredentials gitHubCredentials, string appName)
		{
			_client = new GitHubClient(new ProductHeaderValue(appName))
				{
					Credentials = new Credentials(gitHubCredentials.Login, gitHubCredentials.Password)
				};
		}

		public async Task<IList<GitHubLabel>> GetAllForRepository(string username, string repositoryName)
		{
			var labels = await _client.Issue.Labels.GetAllForRepository(username, repositoryName);

			return labels.Select(l => l.ConvertToGitHubLabel()).ToList();
		}

		public async Task<GitHubLabel> DeleteLabel(string username, string repositoryName, GitHubLabel label)
		{
			await _client.Issue.Labels.Delete(username, repositoryName, label.Name);

			return label;
		}

		public async Task<GitHubLabel> AddLabel(string username, string repositoryName, GitHubLabel label)
		{
			await _client.Issue.Labels.Create(username, repositoryName, CreateLabel(label));

			return label;
		}

		private static NewLabel CreateLabel(GitHubLabel label)
		{
			return new NewLabel(label.Name, label.Color);
		}
	}
}
