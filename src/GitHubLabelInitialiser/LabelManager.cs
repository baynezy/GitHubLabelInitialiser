using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubLabelInitialiser
{
	public class LabelManager : ILabelManager
	{
		private readonly IGitHubApi _gitHubApi;

		public LabelManager(IGitHubApi gitHubApi)
		{
			_gitHubApi = gitHubApi;
		}

		public async Task<IList<GitHubLabel>> DeleteAllInRepository(string username, string repositoryName)
		{
			var labels = await _gitHubApi.GetAllForRepository(username, repositoryName);
			var tasks = new Task[labels.Count];
			var count = 0;

			foreach (var label in labels)
			{
				tasks[count++] = _gitHubApi.DeleteLabel(username, repositoryName, label);
			}

			Task.WaitAll(tasks);

			return labels;
		}
	}
}
