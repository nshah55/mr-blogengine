using BenLovell.BlogEngine.Core.Messages;
using Castle.MonoRail.Framework;

namespace BenLovell.BlogEngine.Web.Controllers
{
	[Layout("default")]
	public class PostController : SmartDispatcherController
	{
		public void Add()
		{
			RenderView("add");
		}

		public void Save([DataBind("post")] AddPostRequestDto post)
		{
			PropertyBag["responseMessage"] = "The post titled: 'Title' was created!";
			RenderView("postcreated");
		}
	}
}