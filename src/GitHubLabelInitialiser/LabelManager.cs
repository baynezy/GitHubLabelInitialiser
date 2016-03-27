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

		public async Task<IList<GitHubLabel>> DeleteAllInRepository(string repositoryName)
		{
			var labels = _gitHubApi.GetAllForRepository(repositoryName);

			foreach (var label in await labels)
			{
				await _gitHubApi.DeleteLabel(label);
			}

			return await labels;
		}
	}
}
