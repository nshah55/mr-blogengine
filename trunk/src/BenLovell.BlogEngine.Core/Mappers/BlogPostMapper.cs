using BenLovell.BlogEngine.Core.Domain;
using BenLovell.BlogEngine.Core.Messages;

namespace BenLovell.BlogEngine.Core.Mappers
{
	public class BlogPostMapper : IBlogPostMapper
	{
		public IBlogPost MapFrom(AddPostRequestDto dto)
		{
			IBlogPost blogPost = new BlogPost(dto.Title, dto.Description, dto.Content);
			return blogPost;
		}
	}
}
