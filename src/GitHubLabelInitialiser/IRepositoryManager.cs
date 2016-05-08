using System.Collections.Generic;
using System.Threading.Tasks;
using GitHubLabelInitialiser.Models;

namespace GitHubLabelInitialiser
{
	public interface IRepositoryManager
	{
		/// <summary>
		/// Gets all the repositories for the authenticated GitHub user
		/// </summary>
		/// <returns>A collection of GitHubRepository for the authenticated</returns>
		Task<IList<GitHubRepository>> GetAllForAuthenticatedUser();
	}
}
