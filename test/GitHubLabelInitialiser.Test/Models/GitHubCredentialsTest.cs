using GitHubLabelInitialiser.Models;
using NUnit.Framework;

namespace GitHubLabelInitialiser.Test.Models
{
	[TestFixture]
	class GitHubCredentialsTest
	{
		[Test]
		public void GitHubCredentials_Implements_IGitHubAccess()
		{
			var credentials = CreateCredentials();

			Assert.That(credentials, Is.InstanceOf<IGitHubAccess>());
		}

		[Test]
		public void GitHubCredentials_WhenPassingUsernameAndPassword_ThenCreateValidCredentials()
		{
			const string username = "username";
			const string password = "password";
			var credentials = CreateCredentials();
			credentials.Login = username;
			credentials.Password = password;

			var ghCredentials = credentials.Credentials;

			Assert.That(ghCredentials.Login, Is.EqualTo(username));
			Assert.That(ghCredentials.Password, Is.EqualTo(password));
		}

		private static GitHubCredentials CreateCredentials()
		{
			return new GitHubCredentials();
		}
	}
}
