namespace GitHubLabelInitialiser
{
	public interface IGitHubCredentials
	{
		string Login { get; set; }
		string Password { get; set; }
	}
}
