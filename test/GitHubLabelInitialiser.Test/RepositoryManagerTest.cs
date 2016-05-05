using System.Collections.Generic;
using GitHubLabelInitialiser.Models;
using Moq;
using NUnit.Framework;

namespace GitHubLabelInitialiser.Test
{
	[TestFixture]
	class RepositoryManagerTest
	{
		[Test]
		public void RepositoryManager_ImplementsIRepositoryManager()
		{
			var manager = CreateManager();

			Assert.That(manager, Is.InstanceOf<IRepositoryManager>());
		}

		[Test]
		public void GetAllForAuthenticatedUser_WhenCalled_ThenShouldCallIGitHubApiGetAllForAuthenticatedUser()
		{
			var api = new Mock<IGitHubApi>();
			api.Setup(m => m.GetAllForAuthenticatedUser());
			var manager = CreateManager(api.Object);

			manager.GetAllForAuthenticatedUser();

			api.Verify(f => f.GetAllForAuthenticatedUser(), Times.Once);
		}

		private static IRepositoryManager CreateManager(IGitHubApi api = null)
		{
			return new RepositoryManager(api ?? new Mock<IGitHubApi>().Object);
		}
	}
}
