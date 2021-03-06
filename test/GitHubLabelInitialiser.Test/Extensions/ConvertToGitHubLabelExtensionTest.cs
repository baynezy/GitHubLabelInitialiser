using System;
using GitHubLabelInitialiser.Extensions;
using GitHubLabelInitialiser.Models;
using NUnit.Framework;
using Octokit;

namespace GitHubLabelInitialiser.Test.Extensions
{
	[TestFixture]
	class ConvertToGitHubLabelExtensionTest
	{
		[Test]
		public void ConvertToGitHubLabel_WhenCalledOnLabel_ThenShouldReturnGitHubLabel()
		{
			var label = new Label(new Uri("http://some.uri/"), "bug", "#ffffff");
			var newLabel = label.ConvertToGitHubLabel();

			Assert.That(newLabel, Is.InstanceOf<GitHubLabel>());
		}

		[Test]
		public void ConvertToGitHubLabel_WhenCalledOnLabel_ThenShouldCorrectlyPopulateNameOnGitHubLabel()
		{
			const string name = "bug";
			var label = new Label(new Uri("http://some.uri/"), name, "#ffffff");
			var newLabel = label.ConvertToGitHubLabel();

			Assert.That(newLabel.Name, Is.InstanceOf<string>());
			Assert.That(newLabel.Name, Is.EqualTo(name));
		}

		[Test]
		public void ConvertToGitHubLabel_WhenCalledOnLabel_ThenShouldCorrectlyPopulateColorOnGitHubLabel()
		{
			const string color = "#ffffff";
			var label = new Label(new Uri("http://some.uri/"), "bug", color);
			var newLabel = label.ConvertToGitHubLabel();

			Assert.That(newLabel.Color, Is.InstanceOf<string>());
			Assert.That(newLabel.Color, Is.EqualTo(color));
		}
	}
}
