using BenLovell.BlogEngine.Core;
using BenLovell.BlogEngine.Core.Mappers;
using BenLovell.BlogEngine.Core.Messages;
using MbUnit.Framework;
using Rhino.Mocks;

namespace BenLovell.BlogEngine.Tests.Unit.Mappers
{
	[TestFixture]
	public class BlogPostMapperFixture
	{
		private MockRepository mockery;
		private AddPostRequestDto addPostRequestDto;
		private IBlogPostMapper mapper;

		[SetUp]
		public void Setup()
		{
			mockery = new MockRepository();
			addPostRequestDto = mockery.DynamicMock<AddPostRequestDto>();
			mapper = new BlogPostMapper();
		}

		[Test]
		public void Should_map_from_AddPostRequestDto()
		{
			using (mockery.Record())
			{
				SetupResult.For(addPostRequestDto.Title).Return("Title");
				SetupResult.For(addPostRequestDto.Description).Return("Description");
				SetupResult.For(addPostRequestDto.Content).Return("Content");
			}

			IBlogPost post;
			using (mockery.Playback())
			{
				post = mapper.MapFrom(addPostRequestDto);
			}

			Assert.AreEqual(post.Title, "Title", "Different title");
			Assert.AreEqual(post.Description, "Description", "Different description");
			Assert.AreEqual(post.Content, "Content", "Different content");
		}
	}
}