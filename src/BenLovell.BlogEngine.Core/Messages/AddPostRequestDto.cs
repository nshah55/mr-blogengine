namespace BenLovell.BlogEngine.Core.Messages
{
	public class AddPostRequestDto
	{
		private string title;
		private string description;
		private string content;

		public virtual string Title
		{
			get { return title; }
			set { title = value; }
		}

		public virtual string Description
		{
			get { return description; }
			set { description = value; }
		}

		public virtual string Content
		{
			get { return content; }
			set { content = value; }
		}
	}
}
