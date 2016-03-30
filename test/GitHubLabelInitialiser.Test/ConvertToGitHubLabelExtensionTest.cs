using System;
using NUnit.Framework;
using Octokit;

namespace GitHubLabelInitialiser.Test
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
		public void ConvertToGitHubLabel_WhenCalledOnLabel_ThenShouldCorrectlyPopulateUrlOnGitHubLabel()
		{
			const string uri = "http://some.uri/";
			var label = new Label(new Uri(uri), "bug", "#ffffff");
			var newLabel = label.ConvertToGitHubLabel();

			Assert.That(newLabel.Url, Is.InstanceOf<Uri>());
			Assert.That(newLabel.Url.ToString(), Is.EqualTo(uri));
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
