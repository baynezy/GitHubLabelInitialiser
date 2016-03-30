using GitHubLabelInitialiser.Models;
using Octokit;

namespace GitHubLabelInitialiser.Extensions
{
	public static class ConvertToGitHubLabelExtension
	{
		/// <summary>
		/// Allows Octokit.Label instances to convert themselves to the GitHubLabel instances
		/// </summary>
		/// <param name="label">The Octokit.Label instance we are converting</param>
		/// <returns>A converted GitHubLabel</returns>
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
