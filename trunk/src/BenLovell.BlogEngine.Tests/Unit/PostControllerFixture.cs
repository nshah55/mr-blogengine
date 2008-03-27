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
	}
}