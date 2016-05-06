using System.Collections.Generic;
using GitHubLabelInitialiser.Models;
using Moq;
using NUnit.Framework;

namespace GitHubLabelInitialiser.Test
{
	[TestFixture]
	class LabelManagerTest
	{
		private string _username;
		private string _repositoryName;

		[SetUp]
		public void SetUp()
		{
			_username = "baynezy";
			_repositoryName = "my-repo";
		}

		[Test]
		public void LabelManager_Implements_ILabelManager()
		{
			var manager = CreateManager();

			Assert.That(manager, Is.InstanceOf<ILabelManager>());
		}

		[Test]
		public void DeleteAllInRepository_WhenCalled_ThenShouldCallIGitHubApiGetAllForRepository()
		{
			var api = new Mock<IGitHubApi>();
			api.Setup(m => m.GetAllForRepository(_username, _repositoryName));
			var manager = CreateManager(api.Object);

			manager.DeleteAllInRepository(_username, _repositoryName);

			api.Verify(f => f.GetAllForRepository(_username, _repositoryName), Times.Once());
		}

		[Test]
		public void DeleteAllInRepository_WhenCalled_ThenShouldCallIGitHubApiDeleteLabelAsManyTimesAsLabelsPresent()
		{
			var api = new Mock<IGitHubApi>();
			api.Setup(m => m.GetAllForRepository(_username, _repositoryName)).ReturnsAsync(new List<GitHubLabel>
				{
					new GitHubLabel(),
					new GitHubLabel()
				});
			var manager = CreateManager(api.Object);

			manager.DeleteAllInRepository(_username, _repositoryName);

			api.Verify(f => f.DeleteLabel(_username, _repositoryName, It.IsAny<GitHubLabel>()), Times.Exactly(2));
		}

		[Test]
		public void AddLabelsToRepository_WhenCalled_ThenShouldCallIGitHubApiAddLabelAsManyTimesAsLabelsPresent()
		{
			var api = new Mock<IGitHubApi>();
			var manager = CreateManager(api.Object);

			manager.AddLabelsToRepository(_username, _repositoryName, new List<GitHubLabel>
				{
					new GitHubLabel(),
					new GitHubLabel()
				});

			api.Verify(f => f.AddLabel(_username, _repositoryName, It.IsAny<GitHubLabel>()), Times.Exactly(2));
		}

		[Test]
		public void IntialiseLabels_WhenCalledWithLabels_ThenDeleteExistingLabels()
		{
			var api = new Mock<IGitHubApi>();
			api.Setup(m => m.GetAllForRepository(_username, _repositoryName)).ReturnsAsync(new List<GitHubLabel>
				{
					new GitHubLabel(),
					new GitHubLabel(),
					new GitHubLabel()
				});
			var manager = CreateManager(api.Object);

			manager.IntialiseLabels(_username, _repositoryName, new List<GitHubLabel>
				{
					new GitHubLabel(),
					new GitHubLabel()
				});

			api.Verify(f => f.DeleteLabel(_username, _repositoryName, It.IsAny<GitHubLabel>()), Times.Exactly(3));
		}

		[Test]
		public void IntialiseLabels_WhenCalledWithLabels_ThenAddNewLabels()
		{
			var api = new Mock<IGitHubApi>();
			api.Setup(m => m.GetAllForRepository(_username, _repositoryName)).ReturnsAsync(new List<GitHubLabel>
				{
					new GitHubLabel(),
					new GitHubLabel(),
					new GitHubLabel()
				});
			var manager = CreateManager(api.Object);

			manager.IntialiseLabels(_username, _repositoryName, new List<GitHubLabel>
				{
					new GitHubLabel(),
					new GitHubLabel()
				});

			api.Verify(f => f.AddLabel(_username, _repositoryName, It.IsAny<GitHubLabel>()), Times.Exactly(2));
		}

		private static ILabelManager CreateManager(IGitHubApi gitHubApi = null)
		{
			return new LabelManager(gitHubApi ?? new Mock<IGitHubApi>().Object);
		}
	}
}
