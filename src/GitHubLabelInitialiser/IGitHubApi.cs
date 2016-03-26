using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubLabelInitialiser
{
	public interface IGitHubApi
	{
		Task<IList<GitHubLabel>> GetAllForRepository(string repositoryName);
		Task<GitHubLabel> DeleteLabel(GitHubLabel isAny);
	}
}
