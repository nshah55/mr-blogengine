using BenLovell.BlogEngine.Core;
using BenLovell.BlogEngine.Core.Messages;

namespace BenLovell.BlogEngine.Core.Services
{
	public class BlogPostService : IBlogPostService
	{
		private readonly IBlogPostMapper blogPostMapper;
		private readonly IBlogPostRepository blogPostRepository;

		public BlogPostService(IBlogPostMapper blogPostMapper, IBlogPostRepository blogPostRepository)
		{
			this.blogPostMapper = blogPostMapper;
			this.blogPostRepository = blogPostRepository;
		}

		public AddPostResponseDto AddPost(AddPostRequestDto post)
		{
			IBlogPost blogPost = blogPostMapper.MapFrom(post);
			blogPostRepository.Save(blogPost);

			return new AddPostResponseDto(true);
		}
	}
}
