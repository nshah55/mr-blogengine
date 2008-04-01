using BenLovell.BlogEngine.Core;
using BenLovell.BlogEngine.Core.Messages;

namespace BenLovell.BlogEngine.Core.Services
{
	public class BlogPostService : IBlogPostService
	{
		public AddPostResponseDto AddPost(AddPostRequestDto post)
		{
			return new AddPostResponseDto(true);
		}
	}
}
