using BenLovell.BlogEngine.Core.Messages;

namespace BenLovell.BlogEngine.Core
{
	public interface IBlogPostMapper
	{
		IBlogPost MapFrom(AddPostRequestDto dto);
	}
}
