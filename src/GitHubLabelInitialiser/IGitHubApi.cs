using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubLabelInitialiser
{
	public interface IGitHubApi
	{
		Task<IList<GitHubLabel>> GetAllForRepository(string username, string repositoryName);
		Task<GitHubLabel> DeleteLabel(string username, string repositoryName, GitHubLabel label);
		Task<GitHubLabel> AddLabel(string username, string repositoryName, GitHubLabel label);
	}
}
