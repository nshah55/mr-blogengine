namespace BenLovell.BlogEngine.Core.Messages
{
	public class AddPostResponseDto
	{
		private bool postAdded = false;

		public AddPostResponseDto(bool postAdded)
		{
			this.postAdded = postAdded;
		}

		public bool PostAdded
		{
			get { return postAdded; }
		}
	}
}