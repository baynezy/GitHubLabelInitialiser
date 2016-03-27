using NUnit.Framework;

namespace GitHubLabelInitialiser.Test
{
	[TestFixture]
	class GitHubApiTest
	{
		[Test]
		public void GitHubApi_ImplementsIGitHubApi()
		{
			var api = CreateApi();
			
			Assert.That(api, Is.InstanceOf<IGitHubApi>());
		}

		private static IGitHubApi CreateApi()
		{
			return new GitHubApi();
		}
	}
}
