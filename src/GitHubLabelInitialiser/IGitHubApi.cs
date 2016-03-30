﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubLabelInitialiser
{
	/// <summary>
	/// Connect to GitHub's API
	/// </summary>
	public interface IGitHubApi
	{
		/// <summary>
		/// Get all the Issue Labels on a given GitHub repository
		/// </summary>
		/// <param name="username">Username of repository owner</param>
		/// <param name="repositoryName">The name of the repository being operated on</param>
		/// <returns>A collection of GitHubLabel for that repository</returns>
		Task<IList<GitHubLabel>> GetAllForRepository(string username, string repositoryName);

		/// <summary>
		/// Delete a specific label on a repository
		/// </summary>
		/// <param name="username">Username of repository owner</param>
		/// <param name="repositoryName">The name of the repository being operated on</param>
		/// <param name="label">The GitHubLabel that is to be removed</param>
		/// <returns>The GitHubLabel that was just removed</returns>
		Task<GitHubLabel> DeleteLabel(string username, string repositoryName, GitHubLabel label);

		/// <summary>
		/// Add a specific label on a repository
		/// </summary>
		/// <param name="username">Username of repository owner</param>
		/// <param name="repositoryName">The name of the repository being operated on</param>
		/// <param name="label">The GitHubLabel that is to being added</param>
		/// <returns>The GitHubLabel that was just added</returns>
		Task<GitHubLabel> AddLabel(string username, string repositoryName, GitHubLabel label);
	}
}
