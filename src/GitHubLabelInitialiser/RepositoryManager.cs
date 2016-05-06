using System.Collections.Generic;
using System.Threading.Tasks;
using GitHubLabelInitialiser.Models;

namespace GitHubLabelInitialiser
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly IGitHubApi _gitHubApi;

		public RepositoryManager(IGitHubApi gitHubApi)
		{
			_gitHubApi = gitHubApi;
		}

		public Task<IList<GitHubRepository>> GetAllForAuthenticatedUser()
		{
			return _gitHubApi.GetAllForAuthenticatedUser();
		}
	}
}
