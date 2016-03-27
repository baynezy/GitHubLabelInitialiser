using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubLabelInitialiser
{
	public class GitHubApi : IGitHubApi
	{
		public Task<IList<GitHubLabel>> GetAllForRepository(string repositoryName)
		{
			throw new System.NotImplementedException();
		}

		public Task<GitHubLabel> DeleteLabel(GitHubLabel label)
		{
			throw new System.NotImplementedException();
		}
	}
}
