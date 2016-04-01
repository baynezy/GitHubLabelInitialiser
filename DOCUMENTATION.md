# GitHubLabelInitialiser
A .NET library for easily populating your repository with your bespoke labels

## Documentation
Fully navigable documentation available on [GitHub Pages](http://baynezy.github.io/GitHubLabelInitialiser/)

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