using BenLovell.BlogEngine.Core;
using BenLovell.BlogEngine.Core.Messages;

namespace BenLovell.BlogEngine.Core.Services
{
	public class BlogPostService : IBlogPostService
	{
		private readonly IBlogPostMapper blogPostMapper;

		public BlogPostService(IBlogPostMapper blogPostMapper)
		{
			this.blogPostMapper = blogPostMapper;
		}

		public AddPostResponseDto AddPost(AddPostRequestDto post)
		{
			IBlogPost blogPost = blogPostMapper.MapFrom(post);
			return new AddPostResponseDto(true);
		}
	}
}
