using BenLovell.BlogEngine.Core;
using BenLovell.BlogEngine.Core.Messages;
using BenLovell.BlogEngine.Core.Services;
using MbUnit.Framework;

namespace BenLovell.BlogEngine.Tests.Unit.Services
{
	[TestFixture]
	public class BlogPostServiceFixture
	{
		[Test]
		public void AddPost_ShouldSavePost_AndBuildResponseWithSuccess()
		{
			IBlogPostService service = new BlogPostService();
			AddPostResponseDto response = service.AddPost(new AddPostRequestDto());
			Assert.IsTrue(response.PostAdded, "PostAdded was false!");
		}
	}
}