using BenLovell.BlogEngine.Core.Messages;

namespace BenLovell.BlogEngine.Core
{
	public interface IBlogPostService
	{
		AddPostResponseDto AddPost(AddPostRequestDto post);
	}
}