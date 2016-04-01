# GitHubLabelInitialiser
A .NET library for easily populating your repository with your bespoke labels

[![Stories in Ready](https://badge.waffle.io/baynezy/GitHubLabelInitialiser.svg?label=ready&title=Stories%20in%20Ready)](http://waffle.io/baynezy/GitHubLabelInitialiser)

## Build Status
<table>
    <tr>
        <th>master</th>
		<td><a href="https://ci.appveyor.com/project/baynezy/githublabelinitialiser"><img src="https://ci.appveyor.com/api/projects/status/46a5yy16oaa4eoyf/branch/master?svg=true" alt="master" title="master" /></a></td>
    </tr>
    <tr>
        <th>develop</th>
		<td><a href="https://ci.appveyor.com/project/baynezy/githublabelinitialiser"><img src="https://ci.appveyor.com/api/projects/status/46a5yy16oaa4eoyf/branch/develop?svg=true" alt="develop" title="develop" /></a></td>
    </tr>
</table>
## Documentation
Fully navigable documentation available on [GitHub Pages](http://baynezy.github.io/GitHubLabelInitialiser/)

## Installing via NuGet

[![NuGet version](https://badge.fury.io/nu/GitHubLabelInitialiser.svg)](http://badge.fury.io/nu/GitHubLabelInitialiser)

    Install-Package GitHubLabelInitialiser

## Usage
### LabelManager.IntialiseLabels
This method will do the following:-

1. Delete all the existing issue labels on a repository
2. Add the collection of issue labels you pass it to the repository

#### Example

    manager.IntialiseLabels(_username, _repositoryName, new List<GitHubLabel>
                    {
                        new GitHubLabel{Name="bug", Color="ff0000"},
                        new GitHubLabel{Name="feature", Color="fbca04"}
                    });


### LabelManager.DeleteAllInRepository
This method will remove all the issue labels on a repository.

####Example

	manager.DeleteAllInRepository(_username, _repositoryName);

### LabelManager.AddLabelsToRepository
This method will add new issue labels on the repository.

####Example

	manager.AddLabelsToRepository(_username, _repositoryName, new List<GitHubLabel>
					{
                        new GitHubLabel{Name="bug", Color="ff0000"},
                        new GitHubLabel{Name="feature", Color="fbca04"}
                    });

## License
This project is licensed under [Apache License 2.0](http://www.apache.org/licenses/LICENSE-2.0).