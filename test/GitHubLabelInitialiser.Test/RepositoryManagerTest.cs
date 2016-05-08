using System.Collections.Generic;
using System.Threading.Tasks;
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
			api.Setup(m => m.GetAllRepositoriesForAuthenticatedUser());
			var manager = CreateManager(api.Object);

			manager.GetAllForAuthenticatedUser();

			api.Verify(f => f.GetAllRepositoriesForAuthenticatedUser(), Times.Once);
		}

		[Test]
		public async Task GetAllForAuthenticatedUser_WhenCalled_ThenShouldReturnRepositoriesFromIGitHubApi()
		{
			var api = new Mock<IGitHubApi>();
			var expectedRepo = new GitHubRepository {Name = "some-name"};
			api.Setup(m => m.GetAllRepositoriesForAuthenticatedUser()).ReturnsAsync(new List<GitHubRepository>
				{
					expectedRepo
				});

			var manager = CreateManager(api.Object);

			var repositories = await manager.GetAllForAuthenticatedUser();

			Assert.That(repositories.Count, Is.EqualTo(1));
			var returnedRepo = repositories[0];
			Assert.That(returnedRepo, Is.EqualTo(expectedRepo));
		}

		private static IRepositoryManager CreateManager(IGitHubApi api = null)
		{
			return new RepositoryManager(api ?? new Mock<IGitHubApi>().Object);
		}
	}
}
