using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Octokit;

namespace GitHubLabelInitialiser
{
	public class GitHubApi : IGitHubApi
	{
		private readonly GitHubClient _client;

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
	}
}
