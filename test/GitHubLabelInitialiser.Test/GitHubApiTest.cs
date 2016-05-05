using GitHubLabelInitialiser.Models;
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

		private static IGitHubApi CreateApi(IGitHubAccess gitHubAccess = null, string appName = "my-cool-app")
		{
			IGitHubAccess access;

			if (gitHubAccess == null)
			{
				access = new GitHubCredentials
					{
						Login = "login",
						Password = "password"
					};
			}
			else
			{
				access = gitHubAccess;
			}

			return new GitHubApi(access, appName);
		}
	}
}
