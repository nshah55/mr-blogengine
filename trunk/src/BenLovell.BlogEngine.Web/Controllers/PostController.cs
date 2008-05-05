using BenLovell.BlogEngine.Core;
using BenLovell.BlogEngine.Core.Messages;
using Castle.MonoRail.Framework;

namespace BenLovell.BlogEngine.Web.Controllers
{
	[Layout("default")]
	public class PostController : SmartDispatcherController
	{
		private readonly IBlogPostService blogPostService;

		public PostController(IBlogPostService blogPostService)
		{
			this.blogPostService = blogPostService;
		}

		[AccessibleThrough(Verb.Post)]
		public void Save([DataBind("post")] AddPostRequestDto post)
		{
			AddPostResponseDto response = blogPostService.AddPost(post);
			
			if(response.PostAdded)
				PropertyBag["responseMessage"] = "The post titled: 'Title' was created!";

			RenderView("postcreated");
		}

		public void Add()
		{
			RenderView("add");
		}
	}
}