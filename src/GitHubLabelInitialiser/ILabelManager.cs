using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubLabelInitialiser
{
	public interface ILabelManager
	{
		Task<IList<GitHubLabel>> DeleteAllInRepository(string repositoryName);
	}
}