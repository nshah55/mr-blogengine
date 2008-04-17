using BenLovell.BlogEngine.Core;
using BenLovell.BlogEngine.Core.Messages;
using BenLovell.BlogEngine.Core.Services;
using MbUnit.Framework;
using Rhino.Mocks;

namespace BenLovell.BlogEngine.Tests.Unit.Services
{
	[TestFixture]
	public class BlogPostServiceFixture
	{
		private MockRepository mockery;
		private IBlogPost post;
		private IBlogPostMapper blogPostMapper;

		[SetUp]
		public void Setup()
		{
			mockery = new MockRepository();
			blogPostMapper = mockery.DynamicMock<IBlogPostMapper>();
			post = mockery.DynamicMock<IBlogPost>();
		}

		[Test]
		public void AddPost_ShouldSavePost_AndBuildResponseWithSuccess()
		{
			IBlogPostService service = new BlogPostService(blogPostMapper);
			AddPostResponseDto response = service.AddPost(new AddPostRequestDto());
			Assert.IsTrue(response.PostAdded, "PostAdded was false!");
		}

		[Test]
		public void AddPost_ShouldUseMapperForPost()
		{
			AddPostRequestDto requestDto = new AddPostRequestDto();
			IBlogPostService service = new BlogPostService(blogPostMapper);
			
			using(mockery.Record())
			{
				Expect.Call(blogPostMapper.MapFrom(requestDto)).Return(post);
			}

			using(mockery.Playback())
			{
				service.AddPost(requestDto);
			}
		}
	}
}