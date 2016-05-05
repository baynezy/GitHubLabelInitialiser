using GitHubLabelInitialiser.Models;
using NUnit.Framework;

namespace GitHubLabelInitialiser.Test.Models
{
	[TestFixture]
	class GitHubTokenTest
	{
		[Test]
		public void GitHubToken_Implements_IGitHubAcccess()
		{
			var token = CreateCredentials();

			Assert.That(token, Is.InstanceOf<IGitHubAccess>());
		}

		[Test]
		public void GitHubToken_WhenToken_ThenCreateValidCredentials()
		{
			const string token = "token";
			var credentials = CreateCredentials();
			credentials.Token = token;

			var ghCredentials = credentials.Credentials;

			Assert.That(ghCredentials.Password, Is.EqualTo(token));
		}

		private static GitHubToken CreateCredentials()
		{
			return new GitHubToken();
		}
	}
}
