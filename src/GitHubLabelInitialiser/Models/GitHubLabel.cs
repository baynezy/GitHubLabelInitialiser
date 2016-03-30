using System;

namespace GitHubLabelInitialiser.Models
{
	/// <summary>
	/// GitHub Issue Label
	/// </summary>
	public class GitHubLabel
	{
		/// <summary>
		/// The Uri of the Label
		/// </summary>
		public Uri Url { get; set; }

		/// <summary>
		/// The Name of the label
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The colour of the label
		/// </summary>
		public string Color { get; set; }
	}
}
