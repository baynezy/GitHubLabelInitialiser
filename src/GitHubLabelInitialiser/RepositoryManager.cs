namespace GitHubLabelInitialiser
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly IGitHubApi _gitHubApi;

		public RepositoryManager(IGitHubApi gitHubApi)
		{
			_gitHubApi = gitHubApi;
		}

		public void GetAllForAuthenticatedUser()
		{
			_gitHubApi.GetAllForAuthenticatedUser();
		}
	}
}
