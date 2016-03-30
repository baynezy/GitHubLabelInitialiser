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

		private static IGitHubApi CreateApi(IGitHubCredentials gitHubCredentials = null, string appName = "my-cool-app")
		{
			IGitHubCredentials credentials;

			if (gitHubCredentials == null)
			{
				credentials = new GitHubCredentials
					{
						Login = "login",
						Password = "password"
					};
			}
			else
			{
				credentials = gitHubCredentials;
			}

			return new GitHubApi(credentials, appName);
		}
	}
}
