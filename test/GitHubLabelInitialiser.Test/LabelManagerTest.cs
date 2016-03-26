using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace GitHubLabelInitialiser.Test
{
	[TestFixture]
	class LabelManagerTest
	{
		[Test]
		public void LabelManager_Implements_ILabelManager()
		{
			var manager = CreateManager();

			Assert.That(manager, Is.InstanceOf<ILabelManager>());
		}

		[Test]
		public void DeleteAllInRepository_WhenCalled_ThenShouldCallIGitHubApiGetAllForRepository()
		{
			const string repositoryName = "my-repo";
			var api = new Mock<IGitHubApi>();
			api.Setup(m => m.GetAllForRepository(repositoryName));
			var manager = CreateManager(api.Object);

			manager.DeleteAllInRepository(repositoryName);

			api.Verify(f => f.GetAllForRepository(repositoryName), Times.Once());
		}

		[Test]
		public void DeleteAllInRepository_WhenCalled_ThenShouldCallIGitHubApiDeleteLabelAsManyTimesAsLabelsPresent()
		{
			const string repositoryName = "my-repo";
			var api = new Mock<IGitHubApi>();
			api.Setup(m => m.GetAllForRepository(repositoryName)).ReturnsAsync(new List<GitHubLabel>
				{
					new GitHubLabel(),
					new GitHubLabel()
				});
			var manager = CreateManager(api.Object);

			manager.DeleteAllInRepository(repositoryName);

			api.Verify(f => f.DeleteLabel(It.IsAny<GitHubLabel>()), Times.Exactly(2));
		}

		private static ILabelManager CreateManager(IGitHubApi gitHubApi = null)
		{
			return new LabelManager(gitHubApi ?? new Mock<IGitHubApi>().Object);
		}
	}
}
