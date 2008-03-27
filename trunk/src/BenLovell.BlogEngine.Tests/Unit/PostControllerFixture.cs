using BenLovell.BlogEngine.Core.Messages;
using BenLovell.BlogEngine.Web.Controllers;
using Castle.MonoRail.TestSupport;
using MbUnit.Framework;

namespace BenLovell.BlogEngine.Tests.Unit
{
	[TestFixture]
	public class PostControllerFixture : BaseControllerTest
	{
		private PostController controller;

		[SetUp]
		public void SetUp()
		{
			controller = new PostController();
			PrepareController(controller, "post");
		}

		[Test]
		public void Add_ShouldRenderAddPostForm()
		{
			controller.Add();
			Assert.AreEqual(controller.SelectedViewName, @"post\add", "Expected view wasn't rendered");
		}

		[Test]
		public void Save_ShouldSavePost_AndDisplayResponse()
		{
			AddPostRequestDto post = new AddPostRequestDto();
			post.Title = "Title";
			post.Description = "Description";
			post.Content = "Content";

			controller.Save(post);

			Assert.AreEqual(controller.PropertyBag["responseMessage"], 
				@"The post titled: 'Title' was created!", "Incorrect response message displayed");
			Assert.AreEqual(controller.SelectedViewName, @"post\postcreated", 
				"Expected view wasn't rendered");
		}
	}
}