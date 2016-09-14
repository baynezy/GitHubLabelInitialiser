using System.Collections.Generic;
using System.Threading.Tasks;
using GitHubLabelInitialiser.Models;

namespace GitHubLabelInitialiser
{
	public interface ILabelManager
	{
		/// <summary>
		/// Remove all current labels on the specified repository
		/// </summary>
		/// <param name="username">Username of repository owner</param>
		/// <param name="repositoryName">The name of the repository being operated on</param>
		/// <returns>The labels that have just been removed</returns>
		Task<IList<GitHubLabel>> DeleteAllInRepository(string username, string repositoryName);

		/// <summary>
		/// Adds a collection of GitHubLabel to a repository
		/// </summary>
		/// <param name="username">Username of repository owner</param>
		/// <param name="repositoryName">The name of the repository being operated on</param>
		/// <param name="labels">A collection of GitHublabel to add to the repository</param>
		/// <returns>The labels that have just been added</returns>
		Task<IList<GitHubLabel>> AddLabelsToRepository(string username, string repositoryName, IList<GitHubLabel> labels);

		/// <summary>
		/// Removes all existing labels on the specified repository and replaces them with the ones suppled
		/// </summary>
		/// <param name="username">Username of repository owner</param>
		/// <param name="repositoryName">The name of the repository being operated on</param>
		/// <param name="labels">A collection of GitHublabel to add to the repository</param>
		/// <returns>The labels that have just been added</returns>
		Task<IList<GitHubLabel>> IntialiseLabels(string username, string repositoryName, List<GitHubLabel> labels);

		/// <summary>
		/// Gets all the labels for the repository
		/// </summary>
		/// <param name="username">Username of repository owner</param>
		/// <param name="repositoryName">The name of the repository being operated on</param>
		/// <returns>A collection of GitHubLabel for the repository</returns>
		Task<IList<GitHubLabel>> GetLabelsForRepository(string username, string repositoryName);
	}
}