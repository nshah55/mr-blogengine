namespace BenLovell.BlogEngine.Core
{
	public interface IBlogPost
	{
		string Title { get; }
		string Description { get; }
		string Content { get; }
	}
}
