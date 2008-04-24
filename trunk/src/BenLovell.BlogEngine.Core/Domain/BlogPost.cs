namespace BenLovell.BlogEngine.Core.Domain
{
	public class BlogPost : IBlogPost
	{
		private string title;
		private string description;
		private string content;

		public BlogPost(string title, string description, string content)
		{
			this.title = title;
			this.description = description;
			this.content = content;
		}

		public string Title
		{
			get { return title; }
		}

		public string Description
		{
			get { return description; }
		}

		public string Content
		{
			get { return content; }
		}
	}
}