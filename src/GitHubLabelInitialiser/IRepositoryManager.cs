using System.Collections.Generic;
using System.Threading.Tasks;
using GitHubLabelInitialiser.Models;

namespace GitHubLabelInitialiser
{
	public interface IRepositoryManager
	{
		Task<IList<GitHubRepository>> GetAllForAuthenticatedUser();
	}
}
