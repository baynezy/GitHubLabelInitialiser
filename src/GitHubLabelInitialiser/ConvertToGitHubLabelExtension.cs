using Octokit;

namespace GitHubLabelInitialiser
{
	public static class ConvertToGitHubLabelExtension
	{
		public static GitHubLabel ConvertToGitHubLabel(this Label label)
		{
			return new GitHubLabel
				{
					Url = label.Url,
					Name = label.Name,
					Color = label.Color
				};
		}
	}
}
