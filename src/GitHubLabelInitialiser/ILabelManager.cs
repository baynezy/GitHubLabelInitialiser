using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubLabelInitialiser
{
	public interface ILabelManager
	{
		Task<IList<GitHubLabel>> DeleteAllInRepository(string username, string repositoryName);
		Task<IList<GitHubLabel>> AddLabelsToRepository(string username, string repositoryName, List<GitHubLabel> labels);
	}
}