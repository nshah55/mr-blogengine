using BenLovell.BlogEngine.Core;
using BenLovell.BlogEngine.Core.Messages;
using BenLovell.BlogEngine.Web.Controllers;
using Castle.MonoRail.TestSupport;
using MbUnit.Framework;
using Rhino.Mocks;

namespace BenLovell.BlogEngine.Tests.Unit.Controllers
{
	[TestFixture]
	public class PostControllerFixture : BaseControllerTest
	{
		private PostController controller;
		private IBlogPostService blogPostService;
		private MockRepository mockery;

		[SetUp]
		public void SetUp()
		{
			mockery = new MockRepository();
			blogPostService = mockery.DynamicMock<IBlogPostService>();
			controller = new PostController(blogPostService);
			PrepareController(controller, "post");
		}

		[Test]
		public void Save_ShouldSavePost_AndDisplayResponse()
		{
			AddPostRequestDto post = new AddPostRequestDto();
			post.Title = "Title";
			post.Description = "Description";
			post.Content = "Content";

			using(mockery.Record())
			{
				Expect.Call(blogPostService.AddPost(post)).Return(new AddPostResponseDto(true));
			}

			using(mockery.Playback())
			{
				controller.Save(post);
			}

			Assert.AreEqual(controller.PropertyBag["responseMessage"], 
				@"The post titled: 'Title' was created!", "Incorrect response message displayed");
			Assert.AreEqual(controller.SelectedViewName, @"post\postcreated", 
				"Expected view wasn't rendered");
		}

		[Test]
		public void Add_ShouldRenderAddPostForm()
		{
			controller.Add();
			Assert.AreEqual(controller.SelectedViewName, @"post\add", "Expected view wasn't rendered");
		}
	}
}